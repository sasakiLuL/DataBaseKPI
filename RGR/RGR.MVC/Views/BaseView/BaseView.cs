using Spectre.Console;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace RGR.MVC.Views.BaseView
{
    public abstract class BaseView<TEntity> : IView<TEntity> where TEntity : class, new()
    {
        public IEnumerable<TEntity> Entities { get; set; }

        public BaseView(IEnumerable<TEntity> entities)
        {
            Entities = entities;
        }

        public void Print()
        {
            var table = new Table();

            List<TableColumn> columnsNames = new List<TableColumn>();
            
            Type type = typeof(TEntity);
            List<PropertyInfo> properties = type.GetProperties().ToList();

            columnsNames = properties.ConvertAll(e => new TableColumn(
                    "[blue]" 
                    + (e.GetCustomAttributes<ColumnAttribute>().FirstOrDefault()?.TypeName ?? e.Name)
                    + "[/]").LeftAligned());

            columnsNames.ForEach(e => table.AddColumn(e));

            foreach (TEntity entity in Entities)
            {
                List<string> columnsValues = new List<string>();

                properties.ForEach(p => columnsValues.Add(p.GetValue(entity)?.ToString() ?? "NULL"));

                table.AddRow(columnsValues.ToArray());
            }

            AnsiConsole.Write(table);
        }
    }
}
