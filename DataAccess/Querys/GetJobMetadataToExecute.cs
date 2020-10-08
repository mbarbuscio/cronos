using DataAccessLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.DataAccess.Querys
{
    public class GetJobMetadataToExecute : QueryBase
    {
        public GetJobMetadataToExecute()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" select job_name, job_display_name from jobs_metadata ");
            sb.AppendLine(" where some criteria to get what needs to be run");

            SetQuery(sb.ToString());
        }
    }
}
