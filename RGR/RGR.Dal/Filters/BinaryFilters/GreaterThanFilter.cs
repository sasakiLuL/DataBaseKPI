namespace RGR.Dal.Filters.BinaryFilters
{
    public class GreaterThanFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        static GreaterThanFilter()
        {
            _filterString = ">";
        }
        internal GreaterThanFilter(TLeft right, TRight left) : base(right, left) { }
    }
}

