using FluentAssertions;
using RestSharp;
using RestSharpApiTestFramework.Core.Client;
using Xunit;
using Xunit.Abstractions;
using RestSharpApiTestFramework.Core.Models;
using System.Net;

namespace RestSharpApiTestFramework.Tests.Features
{
    public class Login : IClassFixture<TestFixture>
    {
        private readonly RequestClient _requestClient = new RequestClient("https://reqres.in/");
        private readonly ITestOutputHelper output;
        private readonly Guid guid; // Unique identifier for the test run

        public Login(ITestOutputHelper output, TestFixture testFixture) 
        {
            guid = testFixture.Guid; // Unique identifier for the test run
            this.output = output;
        }
        [Theory]
        [InlineData("eve.holt@reqres.in", "cityslicka", System.Net.HttpStatusCode.OK)]
        [InlineData("john", "developer", System.Net.HttpStatusCode.BadRequest)]
        [InlineData("jane", "designer", System.Net.HttpStatusCode.BadRequest)]
        public async Task LoginUser(string email, string password, System.Net.HttpStatusCode code)
        {
            var request = new RestRequest("/api/login", Method.Post);
            request.AddHeader("x-api-key", "reqres-free-v1");

            request.AddJsonBody(new { email = email, password = password });

            
            var response = await _requestClient.ExecuteAsync(request);
            output.WriteLine(response.Content.ToString());
            output.WriteLine(guid.ToString());

            response.StatusCode.Should().Be(code);
        }
      
    }
}
