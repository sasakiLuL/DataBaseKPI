namespace RGR.Dal.Filters.BinaryFilters
{
    public class OrFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        public override string FilterString => "OR";
        internal OrFilter(TLeft right, TRight left) : base(right, left) { }
    }
}
