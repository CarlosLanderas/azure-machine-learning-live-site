using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ML.Web.Infrastructure
{
    public interface IAzureMLClient
    {
        Task<HttpResponseMessage> PostData(Dictionary<string, string> data);
    }
}
