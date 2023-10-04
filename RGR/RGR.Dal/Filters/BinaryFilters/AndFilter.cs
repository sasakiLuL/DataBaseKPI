namespace RGR.Dal.Filters.BinaryFilters
{
    public class AndFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        internal AndFilter(TLeft right, TRight left) : base(right, left)
        {
            FilterString = "AND";
        }
    }
}
