namespace RGR.Dal.Filters.BinaryFilters
{
    public class EqualFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        internal EqualFilter(TLeft right, TRight left) : base(right, left)
        {
            _filterString = "=";
        }
    }
}
