using Cronos.Models;
using Cronos.Models.Interfaces;
using Cronos.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cronos.Services
{
    public class ExecutionCache : IExecutionsCache
    {
        private IMemoryCache _executions;

        public void ExecuteJob(Job job)
        {
            if(!_executions.TryGetValue(job.MetaData.Name, out job))
            {
                _executions.Set(job.MetaData.Name, job);
            } else
            {
                throw new DBConcurrencyException($"Could Not Start Job {job.MetaData.ScheduleName} is already running.");
            }
        }

        public void JobCompleted(string jobName)
        {
            _executions.Remove(jobName);
        }
    }
}
