using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using ML.Web.Hubs;
using ML.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.Web.Controllers
{
    [Route("[controller]")]
    public class IrisController
    {
        private readonly IAzureMLClient azureMLIrisClient;
        private readonly IConnectionManager connectionManager;

        public IrisController(IAzureMLClient azureMLIrisClient, IConnectionManager connectionManager)
            {
            this.azureMLIrisClient = azureMLIrisClient;
            this.connectionManager = connectionManager;
        }

        [HttpPost, Route("[action]")]
        public async Task<bool> Predict([FromBody]Dictionary<string, string> data)
        {
            var postResult = await azureMLIrisClient.PostData(data);
            var result = await postResult.Content.ReadAsStringAsync();
            if (postResult.IsSuccessStatusCode)
            {
                connectionManager.GetHubContext<AzureMlHub>().Clients.All.notifyFlowerPredictionCreated(result);
            }
            return postResult.IsSuccessStatusCode;
        }

        [HttpPost, Route("[action]")]
        public Task<bool> Upload()
        {
            return Task.FromResult(true);
        }
    }
}
