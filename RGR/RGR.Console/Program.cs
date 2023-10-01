using Npgsql;
using NpgsqlTypes;
using RGR.Dal;
using RGR.Dal.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;

var res = Select((Gym e) => new { e.GymName, e.PhoneNumber, e.Email });

Console.ReadLine();

static IList<TResult> Select<TEntity, TResult>(Expression<Func<TEntity, TResult>> selector)
{
    var connection = new NpgsqlConnection("host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345");

    var result = new List<TResult>();

    var arguments = (selector.Body.ReduceExtensions() as NewExpression)?.Arguments ?? 
        throw new Exception("Sequence returns no new types");

    var members = arguments.ToList().ConvertAll(e => (e as MemberExpression)?.Member ?? 
        throw new Exception("Sequence contains no elements"));

    var columns = members.ConvertAll(e => e.GetCustomAttribute<ColumnAttribute>()?.Name ?? e.Name);

    using var npgsqlCommandInstance = new NpgsqlCommand();

    string query = $"SELECT {columns.Aggregate((columns, next) => columns += $", {next}")} ";

    string fromQuery = "FROM gyms";

    npgsqlCommandInstance.CommandText = query + fromQuery;
    npgsqlCommandInstance.Connection = connection;

    connection.Open();

    using var reader = npgsqlCommandInstance.ExecuteReader();

    var anonType = selector.ReturnType.GetConstructors().FirstOrDefault();

    while (reader.Read())
    {
        List<object?> row = new List<object?>();

        foreach (var columnName in columns)
        {
            row.Add(reader[columnName]);
        }

        result.Add((TResult)anonType.Invoke(row.ToArray()));
    }

    connection.Close();

    return result;
}
//TableDefinition<Gym> gyms = new TableDefinition<Gym>(connection);

//var result = gyms.Query().Select(e => new { e.GymName, e.GymType }).Execute();

//result.ForEach(e => Console.WriteLine($"{e.GymName}, {e.GymType}"));


//var command = new CommandBuilder().From(context.Users).Join(context.Gyms).On()

//var data = context.Users.LeftJoin<Gyms>((u, g) => u.gym_id == g.gym_id)
//          .Select(e => new { e.FirstName, e.LastName })
//
//          .Where(e => e.Sex == 1)
//          .OrderBy(e => e.UserId)
//          .Execute();

//Table Users = new CommandBuilder<User>();