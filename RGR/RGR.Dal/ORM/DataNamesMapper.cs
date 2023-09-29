using System.Data;

namespace RGR.Dal.ORM
{
    public class DataNamesMapper<TEntity> where TEntity : class, new()
    {
        public TEntity Map(DataRow row)
        {

        }
        public IEnumerable<TEntity> Map(DataTable table)
        {

        }
    }
}
