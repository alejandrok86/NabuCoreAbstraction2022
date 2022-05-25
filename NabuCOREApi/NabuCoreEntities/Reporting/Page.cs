using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [DataContract]
    public class Page : BaseType
    {
        [DataMember]
        public List<ReportSection> Sections { get; set; }

        public Page() : base()
        {
            Sections = new List<ReportSection>();
        }

        public void FromXML(XElement root)
        {
            if (root.Name.ToString().CompareTo("Page") == 0)
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
                        if (child.Name.ToString().CompareTo("Sections") == 0)
                        {
                            if (child.HasElements)
                            {
                                Sections = new List<ReportSection>();
                                foreach (XElement xmlSection in child.Elements())
                                {
                                    ReportSection section = new ReportSection();
                                    section.FromXML(xmlSection);
                                    Sections.Add(section);
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

            xml += "<Page>";

            if (Sections != null)
            {
                if (Sections.Count > 0)
                {
                    xml += "<Sections>";
                    foreach (ReportSection section in Sections)
                    {
                        xml += section.ToXML();
                    }
                    xml += "</Sections>";
                }
            }

            xml += "</Page>";
            return xml;
        }
    }
}
