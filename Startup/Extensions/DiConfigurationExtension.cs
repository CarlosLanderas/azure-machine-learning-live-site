using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ML.Web.Infrastructure;
using ML.Web.Hubs;

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Core;
using ML.Web.Controllers;

namespace ML.Web.DiConfiguration
{
    public static class DiConfigurationExtension
    {
        public static IServiceProvider BuildDependenciesContainer(this IServiceCollection services)
        {
            
            var builder = new ContainerBuilder();
            builder.Populate(services);
            
            builder.RegisterType<AzureMLCarsClient>().Named<IAzureMLClient>(Constants.AZURE_ML_CARS_CLIENT);
            builder.RegisterType<AzureMLIrisClient>().Named<IAzureMLClient>(Constants.AZURE_ML_IRIS_CLIENT);
            
            builder.RegisterType<CarsController>()
                    .WithParameter(ResolvedParameter.ForNamed<IAzureMLClient>(Constants.AZURE_ML_CARS_CLIENT));

            builder.RegisterType<IrisController>()
                    .WithParameter(ResolvedParameter.ForNamed<IAzureMLClient>(Constants.AZURE_ML_IRIS_CLIENT));

            
            builder.RegisterType<AzureMlHub>();
            
            var container = builder.Build();
            return new AutofacServiceProvider(container);                             
            
        }
    }
}
