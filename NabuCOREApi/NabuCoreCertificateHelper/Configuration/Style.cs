using System.Collections.Generic;
using System.Xml;

namespace Octavo.Gate.Nabu.CORE.Certificate.Configuration
{
    public class Style
    {
        public List<KeyValuePair<string, string>> Items = new List<KeyValuePair<string, string>>();

        public Style()
        {
        }

        public Style(string pStyleString)
        {
            if (pStyleString != null && pStyleString.Trim().Length > 0)
            {
                string semiColon = ";";
                string colon = ":";

                string[] parts = pStyleString.Split(semiColon.ToCharArray());
                if (parts.Length > 0)
                {
                    foreach (string part in parts)
                    {
                        if (part.Trim().Length > 0 && part.Contains(colon))
                        {
                            string[] pair = part.Split(colon.ToCharArray());
                            if (pair.Length > 0)
                            {
                                Add(pair[0].Trim(), pair[1].Trim());
                            }
                        }
                    }
                }
            }
        }

        public void Add(string pKey, string pValue)
        {
            Items.Add(new KeyValuePair<string, string>(pKey.ToLower(), pValue.ToLower()));
        }

        public string ToXML()
        {
            string xml = " style=\"";
            foreach (KeyValuePair<string, string> item in Items)
                xml += item.Key + ":" + item.Value + "; ";
            xml += "\"";
            return xml;
        }

        public string Get(string pKey)
        {
            string result = "";
            foreach (KeyValuePair<string, string> item in Items)
            {
                if (item.Key.ToLower().CompareTo(pKey.ToLower()) == 0)
                {
                    result = item.Value;
                    break;
                }
            }
            return result;
        }
    }
}
