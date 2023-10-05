using RGR.Dal.Filters;
using RGR.Dal.Filters.BinaryFilters;

namespace RGR.Dal
{
    public static class QueryOperations
    {
        public static EqualFilter<TLeft, TRight> Equal<TLeft, TRight>(TLeft left, TRight right)
        {
            return new EqualFilter<TLeft, TRight>(left, right);
        }
        public static AndFilter<TLeft, TRight> Or<TLeft, TRight>(TLeft left, TRight right)
        {
            return new AndFilter<TLeft, TRight>(left, right);
        }
    }
}
