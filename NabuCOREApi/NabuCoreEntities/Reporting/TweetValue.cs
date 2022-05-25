using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [KnownType(typeof(ReportElement))]
    [DataContract]
    public class TweetValue : ReportElement
    {
        [DataMember]
        public string TweetTypeAlias { get; set; }

        [DataMember]
        public string WhichTweet { get; set; }

        public TweetValue() : base()
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
                        if (attrib.Name.ToString().CompareTo("TypeAlias") == 0)
                            TweetTypeAlias = attrib.Value;
                        else if (attrib.Name.ToString().CompareTo("WhichTweet") == 0)
                            WhichTweet = attrib.Value;
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

            xml += "<TweetValue TypeAlias=\"" + TweetTypeAlias + "\" WhichTweet=\"" + WhichTweet + "\" />";

            return xml;
        }
    }
}
