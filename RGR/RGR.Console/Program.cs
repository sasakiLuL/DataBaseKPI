using Npgsql;
using NpgsqlTypes;
using RGR.Dal;
using RGR.Dal.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;

var res = Select((Gym e) => e.HomePage);
static IList<TResult> Select<TEntity, TResult>(Expression<Func<TEntity, TResult>> selector)
{
    var connection = new NpgsqlConnection("host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345");

    var result = new List<TResult>();

    var member = (selector.Body.ReduceExtensions() as MemberExpression)?.Member ?? 
        throw new Exception("Wrong expression type. Needed member acces expression");

    var columnName = member.GetCustomAttribute<ColumnAttribute>()?.Name ?? member.Name;

    connection.Open();

    string query = $"SELECT {columnName}";

    connection.Close();

    return default;
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