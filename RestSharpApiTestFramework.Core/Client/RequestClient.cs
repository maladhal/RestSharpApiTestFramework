using RestSharp;


namespace RestSharpApiTestFramework.Core.Client
{
    public class RequestClient
    {
        private readonly RestClient _client;

        public RequestClient(string baseUrl)
        {
            var options = new RestClientOptions(baseUrl)
            {
                ThrowOnAnyError = true,
            };
            _client = new RestClient(options);
        }
        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            return await _client.ExecuteAsync(request);
        }

    }
}
