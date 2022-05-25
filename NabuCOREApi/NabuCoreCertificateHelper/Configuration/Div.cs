using System.Collections.Generic;
using System.Xml;

namespace Octavo.Gate.Nabu.CORE.Certificate.Configuration
{
    public class Div : Element
    {
        public List<Element> children = new List<Element>();

        public Div()
        {
            Name = "div";
            ID = "";
        }

        public Div(XmlElement pRoot)
        {
            if (pRoot.Name.ToString().CompareTo("div") == 0)
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
                        if (childNode.Name.CompareTo("div") == 0)
                            children.Add(new Div(childNode));
                        else if (childNode.Name.CompareTo("p") == 0)
                            children.Add(new P(childNode));
                        else if (childNode.Name.CompareTo("table") == 0)
                            children.Add(new Table(childNode));
                    }
                }
            }
        }

        public string ToXML()
        {
            string xml = "";
            xml += "<div";
            if (ID != null && ID.Trim().Length > 0)
                xml += " id=\"" + ID + "\"";
            if (Style != null)
                xml += Style.ToXML();
            if (children != null && children.Count > 0)
            {
                xml += ">";
                foreach (Element element in children)
                {
                    if (element.GetType() == typeof(Div))
                    {
                        Div div = element as Div;
                        xml += div.ToXML();
                    }
                    else if (element.GetType() == typeof(P))
                    {
                        P p = element as P;
                        xml += p.ToXML();
                    }
                    else if (element.GetType() == typeof(Table))
                    {
                        Table table = element as Table;
                        xml += table.ToXML();
                    }
                }
                xml += "</div>";
            }
            else
                xml += "/>";
            return xml;
        }
    }
}
