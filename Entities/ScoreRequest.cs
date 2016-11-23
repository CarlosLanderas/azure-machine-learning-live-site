using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.Web.Entities
{
    public class ScoreRequest
    {
        public  Dictionary<string, List<Dictionary<string, string>>> Inputs { get; set; } =
            new Dictionary<string, List<Dictionary<string, string>>>();

        public Dictionary<string, string> GlobalParameters { get; set; } = new Dictionary<string, string>();
    }
}
