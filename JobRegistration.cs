using Cronos.Jobs;
using Cronos.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cronos
{
    public static class JobRegistration
    {
        public static void Register(IServiceCollection services)
        {
            // Add your jobs to DI as scoped services
            services.AddScoped<IJobTask, TestJob>();

            services.AddTransient<ServiceResolver>(serviceProvider => key =>
            {
                switch(key)
                {
                    // Register your jobs with a name
                    case "TestJob": 
                        return serviceProvider.GetService<TestJob>();
                        
                    default:
                        throw new KeyNotFoundException();
                }
            });
        }
    }

    public delegate IJobTask ServiceResolver(string key);
}
