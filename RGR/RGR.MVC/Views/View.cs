using Spectre.Console;
using System;

namespace RGR.MVC.Views;

public static class View
{
    public static void PrintEntityAdded(object entity)
    {
        var panel = new Panel("Added entity!");

        AnsiConsole.Write(panel);

        PrintEntities([entity]);
    }

    public static void PrintEntityUpdated(object entity)
    {
        var panel = new Panel("Updated entity!");

        AnsiConsole.Write(panel);

        PrintEntities([entity]);
    }

    public static void PrintEntityDeleted(object entity)
    {
        var panel = new Panel("Deleted entity!");

        AnsiConsole.Write(panel);

        PrintEntities([entity]);
    }

    public static void PrintEntities(IEnumerable<object> entities)
    {
        var table = new Table();

        var properties = entities.GetType()
            .GetElementType()!
            .GetProperties();

        var columnNames = properties
            .Select(p => p.Name)
            .ToList();

        table.AddColumns(columnNames.ToArray());

        foreach (var entity in entities) 
        {
            List<string> rows = new();

            foreach (var property in properties)
            {
                rows.Add(property.GetValue(entity)?.ToString() ?? "NULL");
            }

            table.AddRow(rows.ToArray());
        }

        AnsiConsole.Write(table);
    }

    public static void PrintError(Exception exception)
    {
        var panel = new Panel(exception.Message);

        AnsiConsole.Write(panel);
    }

    public static void PrintGenerated(long count)
    {
        var panel = new Panel($"Generated {count} records!");

        AnsiConsole.Write(panel);
    }
}
