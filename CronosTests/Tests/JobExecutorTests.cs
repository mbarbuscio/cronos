using Cronos.DataAccess.Interfaces;
using Cronos.Jobs;
using Cronos.Models;
using Cronos.Services;
using CronosTests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CronosTests.Tests
{
    [TestFixture]
    public class JobExecutorTests
    {
        private JobExecutor jobExecutor;

        private ILogger<JobExecutor> loggerMock;

        private IServiceProvider serviceProvideMock;

        [SetUp]
        public async Task SetUp()
        {
            serviceProvideMock = MocksFactory.ServiceProvider();
            loggerMock = MocksFactory.GetLogger<JobExecutor>();

            jobExecutor = new JobExecutor(
                loggerMock,
                serviceProvideMock,
                new ExecutionCache()
            );

            await jobExecutor.StopAsync(new CancellationToken(true));
        }

        [Test]
        public async Task RunJob()
        {
            await jobExecutor.RunJobs();

            serviceProvideMock.AssertWasCalled(x => x.GetService<TestJob>());

            serviceProvideMock.GetRequiredService<IJobMetadataDAO>().AssertWasCalled(x => x.GetJobstoExecute());
        }
    }
}
