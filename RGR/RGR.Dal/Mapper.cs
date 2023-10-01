using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Dal
{
    public static class Mapper
    {
        public static string GetTableName(Type table)
        {
            return (table.GetCustomAttributes(typeof(TableAttribute), false).First() as TableAttribute)?.Name ?? table.Name;
        }
        //public static string GetColumnName<TEntity>(string name)
        //{
        //    TEntity sample = new TEntity();
        //    var proprty = sample.GetType().GetProperty(name);
        //    if (proprty == null)
        //        throw new Exception("ss");

        //    return (proprty.GetCustomAttribute(typeof(ColumnAttribute), false) as ColumnAttribute)?.Name ?? name;
        //}

    }
}
