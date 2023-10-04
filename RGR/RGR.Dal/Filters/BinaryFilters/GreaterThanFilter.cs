namespace RGR.Dal.Filters.BinaryFilters
{
    public class GreaterThanFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        internal GreaterThanFilter(TLeft right, TRight left) : base(right, left)
        {
            _filterString = ">";
        }
    }
}

