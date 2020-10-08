using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Base
{
    public abstract class BaseDAO<T>
    {
        protected DatabaseContext _db;

        public BaseDAO(DatabaseContext db)
        {
            this._db = db;
        }

        protected int Execute(QueryBase query)
        {
            using (SqlConnection conn = this._db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query.Query, conn);

                foreach (SqlParameter param in query.Parameters)
                {
                    cmd.Parameters.Add(param);
                }

                return cmd.ExecuteNonQuery();
            }
        }

        protected int Insert(QueryBase query)
        {
            using (SqlConnection conn = this._db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query.Query, conn);

                foreach (SqlParameter param in query.Parameters)
                {
                    cmd.Parameters.Add(param);
                }

                return cmd.ExecuteNonQuery();
            }
        }

        protected async Task<T> Find(QueryBase query)
        {
            using (SqlConnection conn = this._db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query.Query, conn);

                foreach (SqlParameter param in query.Parameters)
                {
                    cmd.Parameters.Add(param);
                }

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        return DoMap(reader);
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
        }

        protected async Task<IList<T>> FindMany(QueryBase query)
        {
            IList<T> list = new List<T>();
            using (SqlConnection conn = this._db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query.Query, conn);

                foreach (SqlParameter param in query.Parameters)
                {
                    cmd.Parameters.Add(param);
                }

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        list.Add(DoMap(reader));
                    }
                }
            }

            return list;
        }

        protected abstract T DoMap(SqlDataReader row);
    }
}
