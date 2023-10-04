using Npgsql;
using NpgsqlTypes;
using RGR.Dal.Filters;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RGR.Dal
{
    public sealed class Query<TEntity> : IQuery<TEntity>
    {
        public NpgsqlConnection Connection { get; set; }
        private string _queringDataString;
        private string _dataDestinationString;
        private string _filteringDataString;
        private NpgsqlCommand _commandInstance;
        private Query()
        {
            Connection = null;
            _queringDataString = null;
            _dataDestinationString = null;
            _filteringDataString = null;
            _commandInstance = null;
        }
        internal Query(NpgsqlConnection connection) 
        {
            Connection = connection;
            _queringDataString = "";
            _dataDestinationString = "";
            _filteringDataString = "";
            _commandInstance = new("", Connection);
        }
        private string getSQLString()
        {
            return _queringDataString + _dataDestinationString + _filteringDataString;
        }
        public IEnumerable<TEntity> Execute()
        {
            _commandInstance.CommandText = getSQLString();

            List<TEntity> outEntities = new List<TEntity>();

            Type entityType = typeof(TEntity);

            ConstructorInfo constructor = entityType.GetConstructors()?.FirstOrDefault() ??
                    throw new Exception("Type hasn't any constructors");

            bool isAnon = entityType.GetCustomAttribute<CompilerGeneratedAttribute>() != null;

            Connection.Open();

            using (NpgsqlDataReader reader = _commandInstance.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!isAnon)
                    {
                        outEntities?.Add((TEntity)constructor.Invoke(null));

                        for (int i = 0; i < (int)reader.FieldCount; i++)
                        {
                            MemberInfo? member = typeof(TEntity).GetMembers()
                                .Where(p => p.GetCustomAttribute<ColumnAttribute>()?.Name == reader.GetName(i))
                                .FirstOrDefault();

                            switch (member)
                            {
                                case PropertyInfo prop:
                                    prop.SetValue(outEntities.Last(), (reader.GetValue(i) is DBNull) ? null : reader.GetValue(i));
                                    break;
                                case FieldInfo field:
                                    field.SetValue(outEntities.Last(), (reader.GetValue(i) is DBNull) ? null : reader.GetValue(i));
                                    break;
                                case MemberInfo _:
                                    throw new Exception("Entitity has no property or fiel with column attribute");
                            }
                        }
                    }
                    else
                    {
                        List<object?> rows = new List<object?>();

                        for (int i = 0; i < (int)reader.FieldCount; i++)
                        {
                            rows.Add(reader.GetValue(i));
                        }

                        outEntities?.Add((TEntity)constructor.Invoke(rows.ToArray()));
                    }

                }
            }

            Connection.Close();

            return outEntities;
        }
        public void ExecuteNoQuery()
        {
            _commandInstance.CommandText = getSQLString();

            Connection.Open();

            _commandInstance.ExecuteNonQuery();

            Connection.Close();
        }
        internal IQuery<TEntity> From()
        {
            string databaseName = typeof(TEntity).GetCustomAttribute<TableAttribute>()?.Name ?? 
                throw new Exception("Class has no table attribute");

            NpgsqlParameter param = new($"{databaseName.ToUpper()}", NpgsqlDbType.Varchar)
            {
                Value = databaseName
            };

            _commandInstance.Parameters.Add(param);

            _dataDestinationString += $"FROM {param.ParameterName} ";

            return this;
        }
        public IQuery<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> predicate)
        {
            throw new NotImplementedException();
        }
        public IQuery<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            Type entityType = typeof(TEntity);

            var arguments = getArgumentsExpressionsList(selector);

            var members = getMembersList(arguments);

            var columns = members.ConvertAll(e => e.GetCustomAttribute<ColumnAttribute>()?.Name ?? e.Name);

            var parametersNames = columns.ConvertAll(e => $"{e.ToUpper()}");

            foreach (var (colName, paramName) in columns.Zip(parametersNames))
            {
                NpgsqlParameter param = new(paramName, NpgsqlDbType.Varchar)
                {
                    Value = colName
                };
                _commandInstance.Parameters.Add(param);
            }

            _queringDataString += $"SELECT {parametersNames.Aggregate((columns, next) => columns += $", {next}")} ";

            Query<TResult> newQuery = new();
            newQuery.Connection = Connection;
            newQuery._dataDestinationString = _dataDestinationString;
            newQuery._filteringDataString = _filteringDataString;
            newQuery._queringDataString = _queringDataString;
            newQuery._commandInstance = _commandInstance;

            return newQuery;
        }
        public IQuery<TEntity> Where<TFilter>(Expression<Func<TEntity, TFilter>> predicate) where TFilter : IFilter
        {
            List<Expression> filterArguments = (predicate.Body as MethodCallExpression)?.Arguments.ToList() ??
                throw new Exception("a");

            MethodCallExpression methodCallExpression = (predicate.Body as MethodCallExpression);

            //typeof(IFilter).GetProperty("FilterString").GetValue(predicate.);

            return default;
        }
        private List<Expression> getArgumentsExpressionsList<TResult>(Expression<Func<TEntity, TResult>> expression)
        {
            return (expression.Body.ReduceExtensions() as NewExpression)?.Arguments.ToList() ??
                throw new Exception("Sequence returns no new types");
        }
        private List<MemberInfo> getMembersList(List<Expression> expressions)
        {
            return expressions.ToList().ConvertAll(e => (e as MemberExpression)?.Member ??
                throw new Exception("Sequence contains no elements"));
        }
        private string ToSqlOperator(ExpressionType type)
        {
            return type switch
            {
                ExpressionType.Equal => "=",
                ExpressionType.GreaterThan => ">",
                ExpressionType.LessThan => "<",
                ExpressionType.GreaterThanOrEqual => ">=",
                ExpressionType.LessThanOrEqual => "<=",
                ExpressionType.NotEqual => "!=",
                ExpressionType.Not => "NOT",
                ExpressionType.AndAlso => "AND",
                ExpressionType.OrElse => "OR",
                _ => throw new Exception("No allowed expression type")
            };
        }
        private string CreateWhereSqString(BinaryExpression predicate)
        {
            if (predicate.Right is BinaryExpression)
                return CreateWhereSqString((BinaryExpression)predicate.Right);

            if (predicate.Left is BinaryExpression)
                return CreateWhereSqString((BinaryExpression)predicate.Right);

            string columnName = (predicate.Right as MemberExpression)?.Member?
                .GetCustomAttribute<ColumnAttribute>()?.Name ?? 
                throw new Exception("b");

            if (predicate.NodeType == ExpressionType.Call)
            {

            }

            return null;
        }
    }
}
