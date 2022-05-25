using System.Collections.Generic;
using System.Xml;

namespace Octavo.Gate.Nabu.CORE.Certificate.Configuration
{
    public class P : Element
    {
        public string InnerText = "";

        public P()
        {
            Name = "p";
            ID = "";
        }

        public P(XmlElement pRoot)
        {
            if (pRoot.Name.ToString().CompareTo("p") == 0)
            {
                Name = pRoot.Name;
                if (pRoot.HasAttributes)
                {
                    foreach (XmlAttribute attribute in pRoot.Attributes)
                    {
                        if (attribute.Name.ToString().CompareTo("id") == 0)
                            ID = attribute.Value;
                        else if (attribute.Name.ToString().CompareTo("style") == 0)
                            Style = new Style(attribute.Value);
                    }
                }
                if (pRoot.InnerText != null && pRoot.InnerText.Trim().Length > 0)
                    InnerText = pRoot.InnerText;
            }
        }

        public string ToXML()
        {
            string xml = "";
            xml += "<p";
            if (ID != null && ID.Trim().Length > 0)
                xml += " id=\"" + ID + "\"";
            if (Style != null)
                xml += Style.ToXML();
            xml += ">";
            xml += InnerText;
            xml += "</p>";
            return xml;
        }
    }
}
