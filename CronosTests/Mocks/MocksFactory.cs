using Cronos.DataAccess.Interfaces;
using Cronos.Jobs;
using Cronos.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CronosTests.Mocks
{
    public static class MocksFactory
    {
        
        public static IServiceProvider ServiceProvider()
        {
            var serviceProvider = MockRepository.GenerateStub<IServiceProvider>();
            var scopeMock = MockRepository.GenerateStub<IServiceScope>();
            
            var jobMetadaDAO = MockRepository.GenerateStub<IJobMetadataDAO>();

            TestJob testJob = MockRepository.GenerateStub<TestJob>();
            
            scopeMock.Stub(x => x.ServiceProvider).Return(serviceProvider);
            serviceProvider.Stub(x => x.CreateScope()).Return(scopeMock);
            serviceProvider.Stub(x => x.GetRequiredService<IJobMetadataDAO>()).Return(jobMetadaDAO);

            serviceProvider.Stub(x => x.GetService<TestJob>()).Return(testJob);

            return serviceProvider;
        }

        public static ILogger<T> GetLogger<T>()
        {
            return MockRepository.GenerateStub<ILogger<T>>();
        }

    }
}
