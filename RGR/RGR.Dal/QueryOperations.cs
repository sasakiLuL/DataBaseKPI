using RGR.Dal.Filters;
using RGR.Dal.Filters.BinaryFilters;

namespace RGR.Dal
{
    public static class QueryOperations
    {
        public static IFilter Equal<TLeft, TRight>(TLeft left, TRight right)
        {
            return new EqualFilter<TLeft, TRight>(left, right);
        }
        public static IFilter Or<TLeft, TRight>(TLeft left, TRight right)
        {
            return new OrFilter<TLeft, TRight>(left, right);
        }
    }
}
