using RGR.Dal.Models.Entities;
using RGR.MVC.Views.BaseView;
using Spectre.Console;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace RGR.MVC.Views
{
    public class UserView : BaseView<User>
    {
        public UserView() : base() { }

        public void PrintUsersContracts(List<(User Entity, long ContractsCount)> entities, string query)
        {
            var table = new Table();

            table.Title = new TableTitle(typeof(User).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(User).Name,
                new Style(decoration: Decoration.Bold)
            );

            Markup[] additionalTableColumnsMarkup = new Markup[]
            {
                new Markup("ContractsCount", new Style(foreground: ColumnColor))
            };

            table.AddColumns(
                CreateTableColumns(typeof(User), ColumnColor,
                    additionalTableColumnsMarkup.ToList().ConvertAll(m =>
                        new TableColumn(m)
                    )
                )
            );

            foreach (var entity in entities)
            {
                Markup[] additionalTableRows = new Markup[]
                {
                    new Markup(entity.ContractsCount.ToString(), new Style(foreground: NotHoweredColor))
                };

                table.AddRow(
                    CreateTableRow(entity.Entity, RowColor, additionalTableRows)
                );
            }

            AnsiConsole.Write(table);
            AnsiConsole.Write(new Markup($"[{RowColor.ToMarkup()}]" + query + "[/]"));
        }
    }
}

