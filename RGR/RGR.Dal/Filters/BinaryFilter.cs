namespace RGR.Dal.Filters
{
    public abstract class BinaryFilter<TLeft, TRight> : IFilter
    {
        public TLeft Right { get; set; }
        public TRight Left { get; set; }
        public string FilterString { get; protected set; }
        public BinaryFilter(TLeft right, TRight left)
        {
            Right = right;
            Left = left;
        }
    }
}
