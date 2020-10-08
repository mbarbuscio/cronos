using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cronos.Models.Interfaces
{
    public interface IJobTask
    {
        Task Worker();
    }
}
