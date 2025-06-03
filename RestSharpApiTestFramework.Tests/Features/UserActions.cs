using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using RestSharp;
using RestSharpApiTestFramework.Core.Client;
using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Abstractions;

namespace RestSharpApiTestFramework.Tests.Features
{
    public class UserActions
    {
        private readonly RequestClient _requestClient = new RequestClient("https://reqres.in/");
        private readonly ITestOutputHelper output;

        public UserActions(ITestOutputHelper output) 
        {
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

    }
}
