namespace RGR.Dal.ORM
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataNamesAttribute : Attribute
    {
        public List<string> ValueNames { get; set; }

        public DataNamesAttribute()
        {
            ValueNames = new List<string>();
        }

        public DataNamesAttribute(params string[] valueNames)
        {
            ValueNames = valueNames.ToList();
        }
    }
}
