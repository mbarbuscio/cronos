using Cronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cronos.DataAccess.Interfaces
{
    public interface IJobMetadataDAO
    {
        Task<IList<JobMetadata>> GetJobstoExecute();
    }
}
