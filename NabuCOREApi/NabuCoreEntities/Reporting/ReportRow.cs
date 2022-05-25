using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [DataContract]
    public class ReportRow : BaseType
    {
        [DataMember]
        public string CSSClass { get; set; }

        [DataMember]
        public List<ReportCell> Cells { get; set; }

        public ReportRow() : base()
        {
            Cells = new List<ReportCell>();
        }

        public void FromXML(XElement root)
        {
            if (root.Name.ToString().CompareTo("Row") == 0)
            {
                if (root.HasAttributes)
                {
                    foreach (XAttribute attrib in root.Attributes())
                    {
                        if (attrib.Name.ToString().CompareTo("class") == 0)
                        {
                            CSSClass = attrib.Value;
                        }
                    }
                }

                if (root.HasElements)
                {
                    Cells = new List<ReportCell>();
                    foreach (XElement child in root.Elements())
                    {
                        if (child.Name.ToString().CompareTo("Cell") == 0)
                        {
                            ReportCell cell = new ReportCell();
                            cell.FromXML(child);
                            Cells.Add(cell);
                        }
                    }
                }
            }
        }
        
        public string ToXML()
        {
            string xml = "";

            xml += "<Row";
            if (CSSClass.Length > 0)
            {
                xml += " class=\"" + CSSClass + "\"";
            }
            xml += ">";

            if (Cells != null)
            {
                if (Cells.Count > 0)
                {
                    foreach (ReportCell cell in Cells)
                    {
                        xml += cell.ToXML();
                    }
                }
            }

            xml += "</Row>";

            return xml;
        }
    }
}
