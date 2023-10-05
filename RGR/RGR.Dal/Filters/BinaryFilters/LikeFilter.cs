namespace RGR.Dal.Filters.BinaryFilters
{
    public class LikeFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        public override string FilterString => "LIKE";
        internal LikeFilter(TLeft right, TRight left) : base(right, left) { }
    }
}
