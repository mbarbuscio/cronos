using Cronos.Models;
using Cronos.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cronos.Services.Interfaces
{
    public interface IExecutionsCache
    {
        void ExecuteJob(Job job);
        void JobCompleted(string jobName);
    }
}
