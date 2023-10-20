using RGR.Dal.Models.Entities;
using Spectre.Console;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace RGR.MVC.Views.BaseView
{
    public abstract class BaseView<TEntity> : IView<TEntity> where TEntity : class, new()
    {
        protected List<PropertyInfo> Properties { get; private set; }

        public Color ColumnColor { get; set; }

        public Color RowColor { get; set; }

        public Color NotHoweredColor { get; set; }

        public Color ErrorColor { get; set; }

        protected BaseView()
        {
            Properties = typeof(TEntity).GetProperties().ToList();
            ColumnColor = Color.Aquamarine1_1;
            RowColor = Color.NavajoWhite1;
            NotHoweredColor = Color.DarkOliveGreen3_2;
            ErrorColor = Color.Red1;
        }

        protected TableColumn[] CreateTableColumns(Type type, Color color, IEnumerable<TableColumn> additionalColums = null)
        {
            List<TableColumn> columns = new List<TableColumn>();

            columns = Properties.ConvertAll(p => new TableColumn(
                    $"[bold {color.ToMarkup()}]"
                    + (p.GetCustomAttribute<ColumnAttribute>()?.Name ?? p.Name)
                    + "[/]").LeftAligned());

            if (additionalColums != null) 
                columns.AddRange(additionalColums);

            return columns.ToArray();
        }

        protected TableRow CreateTableRow(TEntity entity, Color color, IEnumerable<Markup> additionalRows = null)
        {
            List<Markup> columnsValues = new List<Markup>();

            Properties.ForEach(p => columnsValues.Add(
                new Markup(
                    p.GetCustomAttribute<KeyAttribute>() == null ?
                        $"[{color.ToMarkup()}]" + (p.GetValue(entity)?.ToString() ?? "NULL") + "[/]" :
                        $"[bold underline {color.ToMarkup()}]" + (p.GetValue(entity)?.ToString() ?? "NULL") + "[/]"
                    )
            ));

            if (additionalRows != null)
                columnsValues.AddRange(additionalRows);

            return new TableRow(columnsValues.ToArray());
        }

        protected Columns CreateColumns(TEntity entity, Color color)
        {
            List<Markup> columnsValues = new List<Markup>();

            Properties.ForEach(p => 
            {
                string res = " ";
                if (p.GetCustomAttribute<KeyAttribute>() == null)
                    res = $"[{color.ToMarkup()}]" + (p.GetValue(entity)?.ToString() ?? "NULL") + "[/]";

                columnsValues.Add(new Markup(res));
            });

            return new Columns(columnsValues.ToArray());
        }

        public void PrintEntities(IEnumerable<TEntity> entities, string query)
        {
            var table = new Table();

            table.Title = new TableTitle(
                typeof(TEntity).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(TEntity).Name,
                new Style(decoration: Decoration.Bold)
            );

            table.AddColumns(
                CreateTableColumns(typeof(TEntity), ColumnColor)
            );

            foreach (TEntity entity in entities)
                table.AddRow(
                    CreateTableRow(entity, RowColor)
                );

            AnsiConsole.Write(table);
            AnsiConsole.Write(new Markup($"[{RowColor.ToMarkup()}]" + query + "[/]\n"));
        }

        public void PrintEntityDeleted(TEntity entity, string query)
        {
            var rows = new Rows(
                new Markup($"[{RowColor.ToMarkup()}]We have just removed [{RowColor.ToMarkup()}]{typeof(TEntity).Name}[/] from [white]{typeof(TEntity).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(TEntity).Name}[/] table with values:[/]"),
                CreateColumns(entity, RowColor)
            );

            Panel panel = new Panel(rows)
            {
                Header = new PanelHeader($"[{ColumnColor.ToMarkup()}]{typeof(TEntity).Name} deleted![/]"),
                Expand = true
            };

            AnsiConsole.Write(panel);
            AnsiConsole.Write(new Markup($"[{RowColor.ToMarkup()}]" + query + "[/]\n"));
        }

        public void PrintEntityAdded(TEntity entity, string query)
        {
            var rows = new Rows(
                new Markup($"[{RowColor.ToMarkup()}]Hooray! We have just added [{RowColor.ToMarkup()}]{typeof(TEntity).Name}[/] to our [white]{typeof(TEntity).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(TEntity).Name}[/] table with value:[/]"),
                CreateColumns(entity, RowColor)
            );

            Panel panel = new Panel(rows)
            {
                Header = new PanelHeader($"[{ColumnColor.ToMarkup()}]{typeof(TEntity).Name} added![/]"),
                Expand = true
            };

            AnsiConsole.Write(panel);
            AnsiConsole.Write(new Markup($"[{RowColor.ToMarkup()}]" + query + "[/]\n"));
        }

        public void PrintEntityUpdated(TEntity oldEntity, TEntity newEntity, string query)
        {
            var rows = new Rows(
                new Markup($"[{RowColor.ToMarkup()}]Changes:[/]"),
                CreateColumns(oldEntity, Color.NavajoWhite3),
                CreateColumns(newEntity, Color.DarkOliveGreen1)
            );

            Panel panel = new Panel(rows)
            {
                Header = new PanelHeader($"[{ColumnColor.ToMarkup()}]{typeof(TEntity).Name} updated![/]"),
                Expand = true
            };

            AnsiConsole.Write(panel);
            AnsiConsole.Write(new Markup($"[{RowColor.ToMarkup()}]" + query + "[/]\n"));
        }

        public void PrintError(Exception exception)
        {
            var rows = new Rows(
                new Markup($"[{ErrorColor.ToMarkup()}]Exception: {exception.Message}[/]")
            );

            Panel panel = new Panel(rows)
            {
                Header = new PanelHeader($"[{ErrorColor.ToMarkup()}]{typeof(TEntity).Name} Error![/]"),
            };

            AnsiConsole.Write(panel);
        }

        public void PrintGenerated(long count)
        {
            var rows = new Rows(
                new Markup($"[{RowColor.ToMarkup()}]Generated {count}[/]")
            );

            Panel panel = new Panel(rows)
            {
                Header = new PanelHeader($"[{ColumnColor.ToMarkup()}]Generated values![/]"),
            };

            AnsiConsole.Write(panel);
        }
    }
}
