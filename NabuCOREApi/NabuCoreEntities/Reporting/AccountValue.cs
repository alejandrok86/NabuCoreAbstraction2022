using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [KnownType(typeof(ReportElement))]
    [DataContract]
    public class AccountValue : ReportElement
    {
        [DataMember]
        public string Alias { get; set; }

        public AccountValue() : base()
        {
        }

        public override void FromXML(XElement root)
        {
            if (root.Name.ToString().CompareTo("AccountValue") == 0)
            {
                if (root.HasAttributes)
                {
                    foreach (XAttribute attrib in root.Attributes())
                    {
                        if (attrib.Name.ToString().CompareTo("Alias") == 0)
                            Alias = attrib.Value;
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

            xml += "<AccountValue Alias=\"" + Alias + "\" />";

            return xml;
        }
    }
}
