using Cronos.Models.Interfaces;
using Cronos.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cronos.Models
{
    public class Job
    {
        public JobMetadata MetaData { get; set; }

        private readonly IExecutionsCache _executionsCache;
        public Job(IExecutionsCache executionsCache)
        {
            this._executionsCache = executionsCache;
        }

        public async Task Execute(IServiceProvider serviceProvider)
        {
            AuditStart();

            using (var scope = serviceProvider.CreateScope())
            {
                IJobTask executorTask = scope.ServiceProvider.GetRequiredService<ServiceResolver>()(this.MetaData.Name);
                try
                {
                    await executorTask.Worker();
                    AuditSuccess();
                } catch (Exception e)
                {
                    // save error details
                    AuditFail(e.Message);
                }
            }

        }

        private void OnFinish()
        {
            // when execution is done, deregister from cache
            this._executionsCache.JobCompleted(this.MetaData.Name);
            // get dependencies and queue them
        }

        private void AuditStart()
        {
            // dowork()
        }

        public void AuditFail(string errorMessage)
        {
            // dowork()
            this.OnFinish();
        }

        private void AuditSuccess()
        {
            // dowork()
            this.OnFinish();
        }
    }
}
