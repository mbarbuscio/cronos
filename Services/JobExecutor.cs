using Cronos.DataAccess.Interfaces;
using Cronos.Models;
using Cronos.Models.Interfaces;
using Cronos.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cronos.Services
{
    public class JobExecutor : BackgroundService, IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<JobExecutor> _logger;
        private Timer _timer;
        private readonly IExecutionsCache _executionsCache;

        public IServiceProvider Services { get; }

        public JobExecutor(
            ILogger<JobExecutor> logger,
            IServiceProvider services,
            IExecutionsCache executionsCache
        ) {
            Services = services;
            this._logger = logger;
            this._executionsCache = executionsCache;
        }

        public override void Dispose()
        {
            _timer?.Dispose();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Job Executor Started.");

            return this.ExecuteAsync(cancellationToken);
        }

        public async Task RunJobs()
        {
            var count = Interlocked.Increment(ref executionCount);

            using (var scope = Services.CreateScope())
            {
                // pull from db jobs that need to be started
                IList<Job> jobs = (await scope.ServiceProvider.GetRequiredService<IJobMetadataDAO>().GetJobstoExecute())
                    .Select(x => new Job(this._executionsCache) { MetaData = x }).ToList();

                foreach(Job job in jobs)
                {
                    try
                    {
                        this._executionsCache.ExecuteJob(job);
                        _ = job.Execute(Services);
                        // kick off jobs and put in cache
                    }
                    catch (Exception e)
                    {
                        job.AuditFail(e.Message);
                    }
                }

                _logger.LogInformation("Job Executor is working. Pulls since started: {Count}", count);
            }
        }

        private void ExecuteJobs(object state)
        {
            _ = this.RunJobs();
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Job Executor is stopping");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(ExecuteJobs, null, TimeSpan.FromSeconds(20), TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }
    }
}
