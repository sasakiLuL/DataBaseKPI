namespace RGR.Dal.Filters.BinaryFilters
{
    public class LessThanOrEqualFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        internal LessThanOrEqualFilter(TLeft right, TRight left) : base(right, left)
        {
            _filterString = "<=";
        }
    }
}
