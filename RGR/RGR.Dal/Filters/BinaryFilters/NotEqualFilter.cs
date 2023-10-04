namespace RGR.Dal.Filters.BinaryFilters
{
    public class NotEqualFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        internal NotEqualFilter(TLeft right, TRight left) : base(right, left)
        {
            FilterString = "!=";
        }
    }
}
