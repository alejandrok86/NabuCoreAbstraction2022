using System.Collections.Generic;
using System.Xml;

namespace Octavo.Gate.Nabu.CORE.Certificate.Configuration
{
    public class Table : Element
    {
        public List<TR> rows = new List<TR>();

        public Table()
        {
            Name = "table";
            ID = "";
        }

        public Table(XmlElement pRoot)
        {
            if (pRoot.Name.ToString().CompareTo("table") == 0)
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
                        if (childNode.Name.CompareTo("tr") == 0)
                            rows.Add(new TR(childNode));
                    }
                }
            }
        }

        public string ToXML()
        {
            string xml = "";
            xml += "<table";
            if (ID != null && ID.Trim().Length > 0)
                xml += " id=\"" + ID + "\"";
            if (Style != null)
                xml += Style.ToXML();
            xml += ">";
            if (rows != null && rows.Count > 0)
            {
                foreach (TR row in rows)
                    xml += row.ToXML();
            }
            xml += "</table>";
            return xml;
        }
    }
}
