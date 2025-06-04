using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using RestSharpApiTestFramework.Core.Models;

namespace RestSharpApiTestFramework.Tests.TestData
{
    public static class LoginTestData
    {
        public static Login ValidLogin => new()
        {
            email = "eve.holt@reqres.in", password = "cityslicka" };
        
        public static Login InvalidUser => new()
        {
            email = "evse.holt@reqres.in", password = "cityslicka"
        };
    
        public static Login UserWithEmptyEmail => new()
        {
            email = string.Empty,
            password = "Software Engineer"
        };

    }
}
