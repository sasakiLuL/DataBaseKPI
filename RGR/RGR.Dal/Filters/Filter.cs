using Npgsql;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;

namespace RGR.Dal.Filters
{
    public class Filter<TEntity>
    {
        private static long _filterCounter = 0;

        protected static long FilterCounter { get { _filterCounter++; return _filterCounter; } }

        internal string ColumnName { get; private set; }

        internal string QueryString { get; private set; }

        internal List<NpgsqlParameter> Parameters { get; private set; }

        protected Filter()
        {
            QueryString = "";
            ColumnName = "";
            Parameters = new List<NpgsqlParameter>();
        }

        public static Filter<TEntity> Value<Param>(Expression<Func<TEntity, Param>> exp, string schema = "")
        {
            MemberInfo member = (exp.Body as MemberExpression)?.Member ??
                throw new Exception("a");
            var outFilt = new Filter<TEntity>();
            if (schema != "") outFilt.ColumnName += schema + '.';
            outFilt.ColumnName += member.GetCustomAttribute<ColumnAttribute>()?.Name ?? member.Name;
            outFilt.QueryString += outFilt.ColumnName + ' ';
            return outFilt;
        }

        public Filter<TEntity> Between<ValType>(ValType first, ValType second)
        {
            var param = new NpgsqlParameter() { Value = first, ParameterName = $"@PARAM_{FilterCounter}" };
            Parameters.Add(param);
            QueryString += $"BETWEEN {param.ParameterName} AND ";

            param = new NpgsqlParameter() { Value = second, ParameterName = $"@PARAM_{FilterCounter}" };
            Parameters.Add(param);
            QueryString += param.ParameterName;
            return this;
        }

        public Filter<TEntity> Like(string pattern)
        {
            var param = new NpgsqlParameter() { Value = pattern, ParameterName = $"@PARAM_{FilterCounter}" };
            Parameters.Add(param);
            QueryString += $"LIKE {param.ParameterName}";
            return this;
        }

        public static Filter<TEntity> operator |(Filter<TEntity> first, Filter<TEntity> second)
        {
            Filter<TEntity> outVariable = new Filter<TEntity>();
            outVariable.ColumnName = first.ColumnName;
            outVariable.Parameters.AddRange(first.Parameters);
            outVariable.Parameters.AddRange(second.Parameters);
            outVariable.QueryString = first.QueryString;
            outVariable.QueryString += " OR " + second.QueryString;

            return outVariable;
        }

        public static Filter<TEntity> operator &(Filter<TEntity> first, Filter<TEntity> second)
        {
            Filter<TEntity> outVariable = new Filter<TEntity>();
            outVariable.ColumnName = first.ColumnName;
            outVariable.Parameters.AddRange(first.Parameters);
            outVariable.Parameters.AddRange(second.Parameters);
            outVariable.QueryString = first.QueryString;
            outVariable.QueryString += " AND " + second.QueryString;

            return outVariable;
        }
    }
}
