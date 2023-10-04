using RGR.Dal.QueryFilters.BinaryFilters;

namespace RGR.Dal
{
    public static class QueryOperations
    {
        public static AndFilter Equal(QueryFilter left, QueryFilter right)
        {
            return new AndFilter(left, right);
        }
        public static AndFilter GreaterThan<TLeft, TRight>(TLeft left, TRight right)
        {
            return new AndFilter<TLeft, TRight>(left, right);
        }
        public static AndFilter LessThan(QueryFilter left, QueryFilter right)
        {
            return new AndFilter(left, right);
        }
        public static AndFilter GreaterThan(QueryFilter left, QueryFilter right)
        {
            return new AndFilter(left, right);
        }
    }
}
