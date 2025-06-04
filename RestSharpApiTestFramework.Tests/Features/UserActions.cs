using FluentAssertions;
using RestSharp;
using RestSharpApiTestFramework.Core.Client;
using Xunit;
using Xunit.Abstractions;
using RestSharpApiTestFramework.Core.Models;

namespace RestSharpApiTestFramework.Tests.Features
{
    public class UserActions : IClassFixture<TestFixture>
    {
        private readonly RequestClient _requestClient = new RequestClient("https://reqres.in/");
        private readonly ITestOutputHelper output;
        private readonly Guid guid; // Unique identifier for the test run

        public UserActions(ITestOutputHelper output, TestFixture testFixture) 
        {
            guid = testFixture.Guid; // Unique identifier for the test run
            this.output = output;
        }
        [Theory]
        [InlineData("morpheus", "leader")]
        [InlineData("john", "developer")]
        [InlineData("jane", "designer")]
        public async Task PatchUser(string username, string job)
        {
            var request = new RestRequest("/api/users/2", Method.Patch);
            request.AddHeader("x-api-key", "reqres-free-v1");

            request.AddJsonBody(new { name = username, job = job });

            
            var response = await _requestClient.ExecuteAsync(request);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
        [Theory]
        [InlineData("John Doe", "Software Engineer", System.Net.HttpStatusCode.Created)]
        [InlineData("Timmy", "Software Engineer", System.Net.HttpStatusCode.Created)]
        [InlineData(null, null, System.Net.HttpStatusCode.BadRequest)]
        public async Task CreateNewUserAsync(string name, string job, System.Net.HttpStatusCode code)

        {
            var request = new RestRequest("/api/users", Method.Post);

            request.AddHeader("x-api-key", "reqres-free-v1");

            request.AddJsonBody(new User
            {
                name = name,
                job = job
            });

            // Act
            var response = await _requestClient.ExecuteAsync(request);
            output.WriteLine(response.Content.ToString());
            output.WriteLine(guid.ToString());
            // Assert
            response.IsSuccessful.Should().BeTrue();
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(code);
        }
    }
}
