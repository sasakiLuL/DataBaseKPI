using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Dal
{
    public class DbSet<TEntity>
    {
        public NpgsqlConnection Connection;
        public DbSet(NpgsqlConnection connection)
        {
            Connection = connection;
        }
        public IQuery<TEntity> Query()
        {
            return new Query<TEntity>(Connection).From();
        }
    }
}
