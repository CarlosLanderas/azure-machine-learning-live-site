using Microsoft.Extensions.Options;
using ML.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ML.Web.Infrastructure
{
    public class AzureMLIrisClient : IAzureMLClient
    {
        private readonly IOptions<AzureMLIrisOptions> azureOptions;
        private HttpClient httpClient = null;

        public AzureMLIrisClient(IOptions<AzureMLIrisOptions> azureOptions)
        {
            this.azureOptions = azureOptions;
            this.httpClient = AzureHttpClientFactory.Create(azureOptions.Value);
        }

        public async Task<HttpResponseMessage> PostData(Dictionary<string, string> data)
        {
            return await httpClient.PostAsJsonAsync(string.Empty, CreateRequest(data));
        }

        private ScoreRequest CreateRequest(Dictionary<string, string> data)
        {
            var inputsDictionary = new Dictionary<string, List<Dictionary<string, string>>>
            {
                {"input1", new List<Dictionary<string, string>>() {data}}
            };

            return new ScoreRequest()
            {
                Inputs = inputsDictionary
            };
        }

        private void InitializeClient()
        {
            var handler = new HttpClientHandler();
            handler.AutomaticDecompression = System.Net.DecompressionMethods.None;
            httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri(azureOptions.Value.ApiKey);            
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", azureOptions.Value.ApiKey);
        }
    }
}
