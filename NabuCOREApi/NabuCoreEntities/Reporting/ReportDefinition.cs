using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [DataContract]
    public class ReportDefinition : BaseType
    {
        [DataMember]
        public int? ReportDefinitionID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public Party OwnedBy { get; set; }

        [DataMember]
        public HeaderDefinition Header { get; set; }

        [DataMember]
        public BodyDefinition Body { get; set; }

        [DataMember]
        public FooterDefinition Footer { get; set; }

        [DataMember]
        public bool RequiresParameters { get; set; }

        [DataMember]
        public string CSSFile { get; set; }

        public ReportDefinition() : base()
        {
            ReportDefinitionID = null;
        }

        public ReportDefinition(int pReportDefinitionID) : base()
        {
            ReportDefinitionID = pReportDefinitionID;
        }

        public ReportDefinition(int? pReportDefinitionID) : base()
        {
            ReportDefinitionID = pReportDefinitionID;
        }

        public void FromXML(string pReportDefinitionXML)
        {
            XElement root = XElement.Parse(pReportDefinitionXML);
            if (root.Name.ToString().CompareTo("ReportDefinition") == 0)
            {
                if (root.HasAttributes)
                {
                    foreach (XAttribute attrib in root.Attributes())
                    {
                        if (attrib.Name.ToString().CompareTo("CSSFile") == 0)
                            CSSFile = attrib.Value;
                    }
                }

                if (root.HasElements)
                {
                    foreach (XElement child in root.Elements())
                    {
                        if (child.Name.ToString().CompareTo("Header") == 0)
                        {
                            Header = new HeaderDefinition();
                            Header.FromXML(child);
                        }
                        else if (child.Name.ToString().CompareTo("Body") == 0)
                        {
                            Body = new BodyDefinition();
                            Body.FromXML(child);
                        }
                        else if (child.Name.ToString().CompareTo("Footer") == 0)
                        {
                            Footer = new FooterDefinition();
                            Footer.FromXML(child);
                        }
                    }
                }
            }
        }

        public string ToXML()
        {
            string xml = "";

            xml += "<ReportDefinition";
            if (CSSFile.Length > 0)
                xml += " CSSFile=\"" + CSSFile + "\"";
            xml += ">";
            if (Header != null)
            {
                xml += Header.ToXML();
            }
            if (Body != null)
            {
                xml += Body.ToXML();
            }
            if (Footer != null)
            {
                xml += Footer.ToXML();
            }
            xml += "</ReportDefinition>";

            return xml;
        }
    }
}
