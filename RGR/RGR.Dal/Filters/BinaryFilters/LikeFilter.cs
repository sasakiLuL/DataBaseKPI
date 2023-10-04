namespace RGR.Dal.Filters.BinaryFilters
{
    public class LikeFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        internal LikeFilter(TLeft right, TRight left) : base(right, left)
        {
            FilterString = "LIKE";
        }
    }
}
