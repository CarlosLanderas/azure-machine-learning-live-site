using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ML.Web.Infrastructure;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using ML.Web.Hubs;

namespace ML.Web.Controllers
{
    [Route("[controller]")]
    public class CarsController
    {
        private readonly IAzureMLClient azureMLCarsClient;
        private readonly IConnectionManager connectionManager;

        public CarsController(IAzureMLClient azureMLCarsClient, IConnectionManager connectionManager)
        {
            this.azureMLCarsClient = azureMLCarsClient;
            this.connectionManager = connectionManager;
        }

        [HttpPost, Route("[action]")]
        public async Task<bool> Predict([FromBody]Dictionary<string, string> data)
        {
            var postResult = await azureMLCarsClient.PostData(data);
            var result = await postResult.Content.ReadAsStringAsync();
            if (postResult.IsSuccessStatusCode)
             {
                connectionManager.GetHubContext<AzureMlHub>().Clients.All.notifyCarPredictionCreated(result);
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
