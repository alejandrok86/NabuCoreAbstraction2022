namespace Octavo.Gate.Nabu.CORE.Certificate.Configuration
{
    public class Element
    {
        public string Name;

        public string ID;

        public List<KeyValuePair<string, string>> attributes = new List<KeyValuePair<string, string>>();

        public Style Style = new Style();
    }
}
