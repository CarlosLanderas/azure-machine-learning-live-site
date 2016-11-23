using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ML.Web.Infrastructure
{
    public class AzureHttpClientFactory
    {
        public static HttpClient  Create(AzureConnectionInfo connectionInfo)
        {
            var handler = new HttpClientHandler();
            handler.AutomaticDecompression = System.Net.DecompressionMethods.None;
            var httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri(connectionInfo.ClientUrl);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", connectionInfo.ApiKey);
            return httpClient;
        }
    }
}
