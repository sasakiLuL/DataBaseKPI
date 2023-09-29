using System.Data;

namespace RGR.Dal.ORM
{
    public class DataNamesMapper<TEntity> where TEntity : class, new()
    {
        public TEntity Map(DataRow row)
        {
            //Step 1 - Get the Column Names
            var columnNames = row.Table.Columns
                                       .Cast<DataColumn>()
                                       .Select(x => x.ColumnName)
                                       .ToList();

            //Step 2 - Get the Property Data Names
            var properties = (typeof(TEntity)).GetProperties()
                                              .Where(x => x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any())
                                              .ToList();

            //Step 3 - Map the data
            TEntity entity = new TEntity();
            foreach (var prop in properties)
            {
                PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
            }

            return entity;
        }
        public IEnumerable<TEntity> Map(DataTable table)
        {
            //Step 1 - Get the Column Names
            var columnNames = table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();

            //Step 2 - Get the Property Data Names
            var properties = (typeof(TEntity)).GetProperties()
                                                .Where(x => x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any())
                                                .ToList();

            //Step 3 - Map the data
            List<TEntity> entities = new List<TEntity>();
            foreach (DataRow row in table.Rows)
            {
                TEntity entity = new TEntity();
                foreach (var prop in properties)
                {
                    PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
                }
                entities.Add(entity);
            }

            return entities;
        }
    }
}
