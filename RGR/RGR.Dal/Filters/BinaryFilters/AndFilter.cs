namespace RGR.Dal.Filters.BinaryFilters
{
    public class AndFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>, IFilter
    {
        internal AndFilter(TLeft right, TRight left) : base(right, left) {}
        public static string FilterOperatorString => "AND";
    }
}
