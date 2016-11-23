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
    public class AzureMLIrisClient : AzureMLClientBase, IAzureMLClient
    {
        private readonly IOptions<AzureMLIrisOptions> azureOptions;
        private readonly  HttpClient httpClient = null;

        public AzureMLIrisClient(IOptions<AzureMLIrisOptions> azureOptions)
        {
            this.azureOptions = azureOptions;
            this.httpClient = AzureHttpClientFactory.Create(azureOptions.Value);
        }

        public async Task<HttpResponseMessage> PostData(Dictionary<string, string> data)
        {
            return await httpClient.PostAsJsonAsync(string.Empty, CreateRequest(data));
        }

        
    }
}
