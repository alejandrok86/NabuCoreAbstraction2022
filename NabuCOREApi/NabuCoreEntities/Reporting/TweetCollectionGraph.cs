using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [KnownType(typeof(ReportElement))]
    [DataContract]
    public class TweetCollectionGraph : ReportElement
    {
        [DataMember]
        public string TweetTypeAlias { get; set; }

        [DataMember]
        public int Limit { get; set; }

        [DataMember]
        public string Sort { get; set; }

        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public int Height { get; set; }

        public TweetCollectionGraph() : base()
        {
        }

        public override void FromXML(XElement root)
        {
            if (root.Name.ToString().CompareTo("TweetCollectionGraph") == 0)
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
                        else if (attrib.Name.ToString().CompareTo("Width") == 0)
                            Width = Convert.ToInt32(attrib.Value);
                        else if (attrib.Name.ToString().CompareTo("Height") == 0)
                            Height = Convert.ToInt32(attrib.Value);
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

            xml += "<TweetCollectionGraph TypeAlias=\"" + TweetTypeAlias + "\" Limit=\"" + Limit.ToString() + "\" Sort=\"" + Sort + "\" Width=\"" + Width.ToString() + "\" Height=\"" + Height.ToString() + "\" />";

            return xml;
        }
    }
}

