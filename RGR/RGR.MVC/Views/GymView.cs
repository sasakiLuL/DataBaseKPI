using RGR.Dal.Models.Entities;
using RGR.MVC.Views.BaseView;
using Spectre.Console;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace RGR.MVC.Views
{
    public class GymView : BaseView<Gym>
    {
        public GymView() : base() {}

        public void ViewAllWithUserAndCoachesCount(List<(Gym Entity, long UsersCount, long CoachesCount)> entities)
        {
            var table = new Table();

            table.Title = new TableTitle(typeof(Gym).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(Gym).Name, 
                new Style(decoration: Decoration.Bold)    
            );

            Markup[] additionalTableColumnsMarkup = new Markup[]
            {
                new Markup("UsersCount", new Style(foreground: ColumnColor)),
                new Markup("CoachesCount", new Style(foreground: ColumnColor))
            };

            table.AddColumns(
                CreateTableColumns(typeof(Gym), ColumnColor, 
                    additionalTableColumnsMarkup.ToList().ConvertAll(m => 
                        new TableColumn(m)
                    )
                )
            );

            foreach (var entity in entities)
            {
                Markup[] additionalTableRows = new Markup[]
                {
                    new Markup(entity.UsersCount.ToString(), new Style(foreground: AdditionalColor)),
                    new Markup(entity.CoachesCount.ToString(), new Style(foreground: AdditionalColor))
                };

                table.AddRow(
                    CreateTableRow(entity.Entity, RowColor, additionalTableRows)
                );
            }

            AnsiConsole.Write(table);
        }
    }
}
