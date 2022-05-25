using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [KnownType(typeof(ReportElement))]
    [DataContract]
    public class ReportDate : ReportElement
    {
        public ReportDate() : base()
        {
        }

        public override void FromXML(XElement root)
        {
            if (root.Name.ToString().CompareTo("ReportDate") == 0)
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
                    }
                }
            }
        }

        public override string ToXML()
        {
            string xml = "";

            xml += "<ReportDate />";

            return xml;
        }
    }
}
