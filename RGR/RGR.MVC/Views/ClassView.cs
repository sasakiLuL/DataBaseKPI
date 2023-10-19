using RGR.Dal.Models.Entities;
using RGR.MVC.Views.BaseView;
using Spectre.Console;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace RGR.MVC.Views
{
    public class ClassView : BaseView<Class>
    {
        public ClassView() : base() { }

        public void PrintFullClassInfo(List<(Class Entity, string CourseName, long ParticipantCount)> entities, string query)
        {
            var table = new Table();

            table.Title = new TableTitle(typeof(Class).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(Class).Name,
                new Style(decoration: Decoration.Bold)
            );

            Markup[] additionalTableColumnsMarkup = new Markup[]
            {
                new Markup("CourseName", new Style(foreground: ColumnColor)),
                new Markup("ParticipantCount", new Style(foreground: ColumnColor))
            };

            table.AddColumns(
                CreateTableColumns(typeof(Class), ColumnColor,
                    additionalTableColumnsMarkup.ToList().ConvertAll(m =>
                        new TableColumn(m)
                    )
                )
            );

            foreach (var entity in entities)
            {
                Markup[] additionalTableRows = new Markup[]
                {
                    new Markup(entity.CourseName.ToString(), new Style(foreground: NotHoweredColor)),
                    new Markup(entity.ParticipantCount.ToString(), new Style(foreground: NotHoweredColor))
                };

                table.AddRow(
                    CreateTableRow(entity.Entity, RowColor, additionalTableRows)
                );
            }

            AnsiConsole.Write(table);
            AnsiConsole.Write(new Markup($"[{RowColor.ToMarkup()}]" + query + "[/]\n"));
        }
    }
}
