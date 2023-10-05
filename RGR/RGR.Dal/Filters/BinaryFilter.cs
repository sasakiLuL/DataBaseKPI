namespace RGR.Dal.Filters
{
    public abstract class BinaryFilter<TLeft, TRight>
    {
        public TLeft Left { get; set; }
        public TRight Right { get; set; }
        public BinaryFilter(TLeft left, TRight right)
        {
            Right = right;
            Left = left;
        }
    }
}
