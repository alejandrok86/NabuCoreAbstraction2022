namespace Octavo.Gate.Nabu.CORE.Entities
{
    public class BaseResultColumn
    {
        public string Value { get; set; }
        public BaseResultColumn()
        {
        }
        public BaseResultColumn(string pValue)
        {
            Value = pValue;
        }
    }
}
