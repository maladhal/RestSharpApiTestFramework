using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using RestSharpApiTestFramework.Core.Models;

namespace RestSharpApiTestFramework.Tests.TestData
{
    public static class UserTestData
    {
        public static User ValidUser => new()
        {
            name = "John Doe", job = "Software Engineer" 
        };
        public static User InvalidUser => new()
        {
            name = null, job = null
        };
    
        public static User UserWithEmptyName => new()
        {
            name = string.Empty, job = "Software Engineer"
        };
    
        public static User UserWithEmptyJob => new()
        {
            name = "John Doe", job = string.Empty
        };
    }
}
