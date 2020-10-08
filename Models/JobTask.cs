using Cronos.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cronos.Models
{
    public abstract class JobTask : IJobTask
    {
        public abstract Task Worker();
    }
}
