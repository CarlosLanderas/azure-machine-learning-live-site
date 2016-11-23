using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ML.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.Web.Options.Extensions
{
    public static class OptionsConfigurationExtension
    {
        public static void RegisterApplicationOptions(this IServiceCollection services,IConfigurationRoot configuration)
        {   
            services.Configure<AzureMLCarOptions>(configuration.GetSection("AzureML:Cars"));
            services.Configure<AzureMLIrisOptions>(configuration.GetSection("AzureML:Iris"));
        }
    }
}
