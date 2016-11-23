using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ML.Web.Entities;

namespace ML.Web.Infrastructure
{
    public class AzureMLClientBase
    {
        protected ScoreRequest CreateRequest(Dictionary<string, string> data)
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
    }
}
