using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [KnownType(typeof(ReportRangeDay))]
    [KnownType(typeof(Literal))]
    [KnownType(typeof(TranslatedResource))]
    [KnownType(typeof(TweetCollection))]
    [KnownType(typeof(TweetValue))]
    [KnownType(typeof(ReportDate))]
    [KnownType(typeof(NumberOfPages))]
    [KnownType(typeof(ReportName))]
    [KnownType(typeof(AccountValue))]
    [DataContract]
    public class ReportElement : BaseType
    {
        public ReportElement() : base()
        {
        }

        public virtual void FromXML(XElement root)
        {
            if (root.Name.ToString().CompareTo("ReportElement") == 0)
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

        public virtual string ToXML()
        {
            string xml = "";

            xml += "<ReportElement />";

            return xml;
        }
    }
}
