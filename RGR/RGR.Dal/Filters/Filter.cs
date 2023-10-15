﻿using Npgsql;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;

namespace RGR.Dal.Filters
{
    public class Filter<TEntity> : IFilter<TEntity> where TEntity : class, new()
    {
        private static long _filterCounter = 0;

        protected static long FilterCounter { get { _filterCounter++; return _filterCounter; } }

        public string ColumnName { get; protected set; }

        public string QueryString { get; protected set; }

        public List<NpgsqlParameter> Parameters { get; private set; }

        protected Filter()
        {
            QueryString = "";
            ColumnName = "";
            Parameters = new List<NpgsqlParameter>();
        }

        public static Filter<TEntity> Value<F>(Expression<Func<TEntity, F>> exp)
        {
            MemberInfo member = (exp.Body as MemberExpression)?.Member ??
                throw new Exception("a");
            var outFilt = new Filter<TEntity>();
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
    }
}
