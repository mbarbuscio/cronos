using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.Base
{
    public class QueryBase
    {
        private IList<SqlParameter> _parameters;
        private string _query;

        public QueryBase()
        {
            this._parameters = new List<SqlParameter>();
        }

        public IList<SqlParameter> Parameters
        {
            get { return _parameters; }
        }

        public string Query
        {
            get { return _query; }
        }

        protected void SetQuery(string query)
        {
            this._query = query;
        }
    }
}
