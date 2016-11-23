using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ML.Web.Entities;
using Newtonsoft.Json;

namespace ML.Web.Infrastructure
{
    public class AzureMLCarsClient: AzureMLClientBase, IAzureMLClient
    {
        private readonly IOptions<AzureMLCarOptions> azureOptions;
        private readonly HttpClient httpClient = null;

        public AzureMLCarsClient(IOptions<AzureMLCarOptions> azureOptions)
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
