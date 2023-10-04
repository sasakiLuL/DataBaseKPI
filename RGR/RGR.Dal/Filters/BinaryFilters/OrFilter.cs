namespace RGR.Dal.Filters.BinaryFilters
{
    public class OrFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        internal OrFilter(TLeft right, TRight left) : base(right, left)
        {
            _filterString = "OR";
        }
    }
}
