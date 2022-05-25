using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [KnownType(typeof(ReportElement))]
    [DataContract]
    public class Literal : ReportElement
    {
        [DataMember]
        public string Value { get; set; }

        public Literal() : base()
        {
        }

        public override void FromXML(XElement root)
        {
            if (root.Name.ToString().CompareTo("TweetValue") == 0)
            {
                if (root.HasAttributes)
                {
                    foreach (XAttribute attrib in root.Attributes())
                    {
                        if (attrib.Name.ToString().CompareTo("Value") == 0)
                            Value = attrib.Value;
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

            xml += "<Literal Value=\"" + Value + "\" />";

            return xml;
        }
    }
}
