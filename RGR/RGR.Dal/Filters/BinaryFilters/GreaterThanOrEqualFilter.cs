namespace RGR.Dal.Filters.BinaryFilters
{
    public class GreaterThanOrEqualFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        public override string FilterString => ">=";
        internal GreaterThanOrEqualFilter(TLeft right, TRight left) : base(right, left) { }
    }
}
