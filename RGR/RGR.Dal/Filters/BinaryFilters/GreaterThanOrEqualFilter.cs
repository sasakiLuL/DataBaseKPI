namespace RGR.Dal.Filters.BinaryFilters
{
    public class GreaterThanOrEqualFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        internal GreaterThanOrEqualFilter(TLeft right, TRight left) : base(right, left)
        {
            FilterString = ">=";
        }
    }
}
