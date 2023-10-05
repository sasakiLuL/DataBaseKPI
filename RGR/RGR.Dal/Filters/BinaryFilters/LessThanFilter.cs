namespace RGR.Dal.Filters.BinaryFilters
{
    public class LessThanFilter<TLeft, TRight> : BinaryFilter<TLeft, TRight>
    {
        public override string FilterString => "<";
        internal LessThanFilter(TLeft right, TRight left) : base(right, left) { }
    }
}
