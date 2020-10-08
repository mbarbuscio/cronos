using Cronos.Models;
using Cronos.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cronos.Jobs
{
    public class TestJob : JobTask, IJobTask
    {
        public override async Task Worker()
        {
            await Console.Out.WriteLineAsync("Testing this job is running;");
        }
    }
}
