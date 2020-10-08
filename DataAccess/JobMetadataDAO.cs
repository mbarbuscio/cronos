using Cronos.DataAccess.Interfaces;
using Cronos.DataAccess.Querys;
using Cronos.Models;
using DataAccessLayer;
using DataAccessLayer.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cronos.DataAccess
{
    public class JobMetadataDAO : BaseDAO<JobMetadata>, IJobMetadataDAO
    {
        public JobMetadataDAO(DatabaseContext db) : base(db)
        { }

        protected override JobMetadata DoMap(SqlDataReader row)
        {
            return new JobMetadata()
            {
                Name = row["job_name"].ToString(),
                ScheduleName = row["job_display_name"].ToString()
            };
        }

        public async Task<IList<JobMetadata>> GetJobstoExecute()
        {
            return await this.FindMany(new GetJobMetadataToExecute());
        }
    }
}
