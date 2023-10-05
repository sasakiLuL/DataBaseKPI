namespace RGR.Dal.Filters.BinaryFilters
{
    public class EqualFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>, IFilter
    {
        public EqualFilter(TLeft right, TRight left) : base(right, left) {}
        public static string FilterOperatorString => "=";
    }
}
