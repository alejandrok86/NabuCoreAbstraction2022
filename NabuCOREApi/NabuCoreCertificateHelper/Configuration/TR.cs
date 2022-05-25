using System.Collections.Generic;
using System.Xml;

namespace Octavo.Gate.Nabu.CORE.Certificate.Configuration
{
    public class TR : Element
    {
        public List<TD> cells = new List<TD>();

        public TR()
        {
            Name = "tr";
            ID = "";
        }

        public TR(XmlElement pRoot)
        {
            if (pRoot.Name.ToString().CompareTo("tr") == 0)
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
                if (pRoot.HasChildNodes)
                {
                    foreach (XmlElement childNode in pRoot.ChildNodes)
                    {
                        if (childNode.Name.CompareTo("td") == 0)
                            cells.Add(new TD(childNode));
                    }
                }
            }
        }

        public string ToXML()
        {
            string xml = "";
            xml += "<tr";
            if (ID != null && ID.Trim().Length > 0)
                xml += " id=\"" + ID + "\"";
            if (Style != null)
                xml += Style.ToXML();
            xml += ">";
            if (cells != null && cells.Count > 0)
            {
                foreach (TD row in cells)
                    xml += row.ToXML();
            }
            xml += "</tr>";
            return xml;
        }
    }
}
