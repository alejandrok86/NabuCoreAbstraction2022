using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [DataContract]
    public class BodyDefinition : BaseType
    {
        [DataMember]
        public List<Page> Pages { get; set; }

        public BodyDefinition() : base()
        {
            Pages = new List<Page>();
        }

        public void FromXML(XElement root)
        {
            if (root.Name.ToString().CompareTo("Body") == 0)
            {
                if (root.HasAttributes)
                {
                    foreach (XAttribute attrib in root.Attributes())
                    {
                    }
                }

                if (root.HasElements)
                {
                    foreach (XElement child in root.Elements())
                    {
                        if (child.Name.ToString().CompareTo("Pages") == 0)
                        {
                            if (child.HasElements)
                            {
                                Pages = new List<Page>();
                                foreach (XElement xmlPage in child.Elements())
                                {
                                    Page page = new Page();
                                    page.FromXML(xmlPage);
                                    Pages.Add(page);
                                }
                            }
                        }
                    }
                }
            }
        }
        public string ToXML()
        {
            string xml = "";
            xml += "<Body>";

            if (Pages != null)
            {
                if (Pages.Count > 0)
                {
                    xml += "<Pages>";

                    foreach (Page page in Pages)
                    {
                        xml += page.ToXML();
                    }

                    xml += "</Pages>";
                }
            }

            xml += "</Body>";
            return xml;
        }
    }
}
