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

        protected Color ColumnColor { get; private set; }

        protected Color RowColor { get; private set; }

        protected Color AdditionalColor { get; private set; }

        protected Color ErrorColor { get; private set; }

        protected BaseView()
        {
            Properties = typeof(TEntity).GetProperties().ToList();
            ColumnColor = Color.Aquamarine1_1;
            RowColor = Color.NavajoWhite1;
            AdditionalColor = Color.DarkOliveGreen3_2;
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

            Properties.ForEach(p => columnsValues.Add(
                new Markup(
                    p.GetCustomAttribute<KeyAttribute>() == null ?
                        $"[{color.ToMarkup()}]" + (p.GetValue(entity)?.ToString() ?? "NULL") + "[/]" :
                        $"[bold underline {color.ToMarkup()}]" + (p.GetValue(entity)?.ToString() ?? "NULL") + "[/]"
                    )
            ));

            return new Columns(columnsValues.ToArray());
        }

        public void PrintAllEntities(IEnumerable<TEntity> entities)
        {
            var table = new Table();

            table.Title = new TableTitle(typeof(Gym).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(Gym).Name,
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
        }

        public void PrintEntityDeleted(TEntity entity)
        {
            var rows = new Rows(
                new Markup($"[{RowColor.ToMarkup()}]We have just removed entity from [{RowColor.ToMarkup()}]{typeof(TEntity).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(TEntity).Name}[/] table with values:[/]"),
                CreateColumns(entity, RowColor)
            );

            Panel panel = new Panel(rows)
            {
                Header = new PanelHeader($"[{ColumnColor.ToMarkup()}]Entity deleted![/]"),
                Expand = true
            };

            AnsiConsole.Write(panel);
        }

        public void PrintEntityAdded(TEntity entity)
        {
            var rows = new Rows(
                new Markup($"[{RowColor.ToMarkup()}]Hooray! We have just added entity to our [{RowColor.ToMarkup()}]{typeof(TEntity).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(TEntity).Name}[/] table with value:[/]"),
                CreateColumns(entity, RowColor)
            );

            Panel panel = new Panel(rows)
            {
                Header = new PanelHeader($"[{ColumnColor.ToMarkup()}]Entity added![/]"),
                Expand = true
            };

            AnsiConsole.Write(panel);
        }

        public void PrintEntityUpdated(TEntity oldEntity, TEntity newEntity)
        {
            var rows = new Rows(
                new Markup($"[{RowColor.ToMarkup()}]Changes:[/]"),
                CreateColumns(oldEntity, Color.NavajoWhite3),
                CreateColumns(newEntity, Color.DarkOliveGreen1)
            );

            Panel panel = new Panel(rows)
            {
                Header = new PanelHeader($"[{ColumnColor.ToMarkup()}]Entity added![/]"),
                Expand = true
            };

            AnsiConsole.Write(panel);
        }

        public void PrintMissingEntityError(TEntity entity, Exception exception)
        {
            var rows = new Rows(
                new Markup($"[{ErrorColor.ToMarkup()}]We are sorry, we have no [{RowColor.ToMarkup()}]{typeof(TEntity).Name}[/] with values:[/]"),
                CreateColumns(entity, RowColor),
                new Markup($"[{ErrorColor.ToMarkup()}]Exception: {exception.Message}[/]")
            );

            Panel panel = new Panel(rows)
            {
                Header = new PanelHeader($"[{ErrorColor.ToMarkup()}]Missing Entity Error![/]"),
                Expand = true
            };

            AnsiConsole.Write(panel);
        }
    }
}
