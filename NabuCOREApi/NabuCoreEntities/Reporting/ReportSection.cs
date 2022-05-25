using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [DataContract]
    public class ReportSection : BaseType
    {
        [DataMember]
        public string CSSClass { get; set; }

        [DataMember]
        public string width { get; set; }

        [DataMember]
        public List<ReportRow> Rows { get; set; }


        public ReportSection() : base()
        {
            Rows = new List<ReportRow>();
        }

        public void FromXML(XElement root)
        {
            if (root.Name.ToString().CompareTo("Section") == 0)
            {
                if (root.HasAttributes)
                {
                    foreach (XAttribute attrib in root.Attributes())
                    {
                        if (attrib.Name.ToString().CompareTo("class") == 0)
                            CSSClass = attrib.Value;
                        else if (attrib.Name.ToString().CompareTo("width") == 0)
                            width = attrib.Value;
                    }
                }

                if (root.HasElements)
                {
                    Rows = new List<ReportRow>();
                    foreach (XElement child in root.Elements())
                    {
                        if (child.Name.ToString().CompareTo("Row") == 0)
                        {
                            ReportRow row = new ReportRow();
                            row.FromXML(child);
                            Rows.Add(row);
                        }
                    }
                }
            }
        }
        
        public string ToXML()
        {
            string xml = "";

            xml += "<Section";
            if (CSSClass.Length > 0)
            {
                xml += " class=\"" + CSSClass + "\"";
            }
            if (width.Length > 0)
            {
                xml += " width=\"" + width + "\"";
            }
            xml += ">";
            if (Rows != null)
            {
                if (Rows.Count > 0)
                {
                    foreach (ReportRow row in Rows)
                    {
                        xml += row.ToXML();
                    }
                }
            }
            xml += "</Section>";

            return xml;
        }
    }
}
