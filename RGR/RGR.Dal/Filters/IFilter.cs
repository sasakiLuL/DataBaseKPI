using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Dal.Filters
{
    public interface IFilter
    {
        static abstract string FilterOperatorString { get; }
        static virtual string GetFilteringString(string value, string filter, string[] operators)
        {
            return $"{value} {filter} {operators.Aggregate((operatorsString, next) => operatorsString += next)}";
        }
    }
}
