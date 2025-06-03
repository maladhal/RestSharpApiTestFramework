using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace RestSharpApiTestFramework.Tests
{
    public class TestFixture : IDisposable
    {
        public Guid Guid; 

        public TestFixture()
        {
            Guid = Guid.NewGuid();// e.g., database connections, mock servers
        }

        public void Dispose()
        {
            // Cleanup test dependencies
        }
    }
}