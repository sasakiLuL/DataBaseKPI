namespace RGR.Dal.Filters.BinaryFilters
{
    public class LessThanFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        internal LessThanFilter(TLeft right, TRight left) : base(right, left)
        {
            _filterString = "<";
        }
    }
}
