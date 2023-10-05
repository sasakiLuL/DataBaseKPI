namespace RGR.Dal.Filters.BinaryFilters
{
    public class LessThanOrEqualFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        public override string FilterString => "<=";
        internal LessThanOrEqualFilter(TLeft right, TRight left) : base(right, left) { }
    }
}
