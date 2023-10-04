namespace RGR.Dal.Filters
{
    public abstract class BinaryFilter<TLeft, TRight> : IFilter
    {
        public TLeft Right { get; set; }
        public TRight Left { get; set; }
        protected static string _filterString;
        static BinaryFilter()
        {
            _filterString = string.Empty;
        }
        public string FilterString { get { return _filterString; } }
        public BinaryFilter(TLeft right, TRight left)
        {
            Right = right;
            Left = left;
        }
    }
}
