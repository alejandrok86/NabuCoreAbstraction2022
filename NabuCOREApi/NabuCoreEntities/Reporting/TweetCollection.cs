using System.Runtime.Serialization;
using System.Xml.Linq;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [KnownType(typeof(ReportElement))]
    [DataContract]
    public class TweetCollection : ReportElement
    {
        [DataMember]
        public string TweetTypeAlias { get; set; }

        [DataMember]
        public int Limit { get; set; }

        [DataMember]
        public string Sort { get; set; }

        public TweetCollection() : base()
        {
        }

        public override void FromXML(XElement root)
        {
            if (root.Name.ToString().CompareTo("TweetCollection") == 0)
            {
                if (root.HasAttributes)
                {
                    foreach (XAttribute attrib in root.Attributes())
                    {
                        if (attrib.Name.ToString().CompareTo("TypeAlias") == 0)
                            TweetTypeAlias = attrib.Value;
                        else if (attrib.Name.ToString().CompareTo("Limit") == 0)
                            Limit = Convert.ToInt32(attrib.Value);
                        else if (attrib.Name.ToString().CompareTo("Sort") == 0)
                            Sort = attrib.Value;
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

            xml += "<TweetCollection TypeAlias=\"" + TweetTypeAlias + "\" Limit=\"" + Limit.ToString() + "\" Sort=\"" + Sort + "\" />";

            return xml;
        }
    }
}
