namespace RGR.Dal.Filters.BinaryFilters
{
    public class NotEqualFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        public override string FilterString => "!=";
        internal NotEqualFilter(TLeft right, TRight left) : base(right, left) { }
    }
}
