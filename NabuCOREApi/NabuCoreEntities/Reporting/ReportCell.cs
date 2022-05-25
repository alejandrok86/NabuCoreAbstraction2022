using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Reporting
{
    [DataContract]
    public class ReportCell : BaseType
    {
        [DataMember]
        public string CSSClass { get; set; }

        [DataMember]
        public string align { get; set; }

        [DataMember]
        public string valign { get; set; }

        [DataMember]
        public List<ReportElement> Elements { get; set; }

        public ReportCell() : base()
        {
            Elements = new List<ReportElement>();
        }

        public void FromXML(XElement root)
        {
            if (root.Name.ToString().CompareTo("Cell") == 0)
            {
                if (root.HasAttributes)
                {
                    foreach (XAttribute attrib in root.Attributes())
                    {
                        if (attrib.Name.ToString().CompareTo("class") == 0)
                            CSSClass = attrib.Value;
                        else if (attrib.Name.ToString().CompareTo("align") == 0)
                            align = attrib.Value;
                        else if (attrib.Name.ToString().CompareTo("valign") == 0)
                            valign = attrib.Value;
                    }
                }

                if (root.HasElements)
                {
                    Elements = new List<ReportElement>();
                    foreach (XElement child in root.Elements())
                    {
                        if (child.Name.ToString().CompareTo("TranslatedResource") == 0)
                        {
                            TranslatedResource translatedResource = new TranslatedResource();
                            translatedResource.FromXML(child);
                            Elements.Add(translatedResource);
                        }
                        else if (child.Name.ToString().CompareTo("TweetValue") == 0)
                        {
                            TweetValue tweetValue = new TweetValue();
                            tweetValue.FromXML(child);
                            Elements.Add(tweetValue);
                        }
                        else if (child.Name.ToString().CompareTo("TweetCollection") == 0)
                        {
                            TweetCollection tweetCollection = new TweetCollection();
                            tweetCollection.FromXML(child);
                            Elements.Add(tweetCollection);
                        }
                        else if (child.Name.ToString().CompareTo("TweetCollectionGraph") == 0)
                        {
                            TweetCollectionGraph tweetCollectionGraph = new TweetCollectionGraph();
                            tweetCollectionGraph.FromXML(child);
                            Elements.Add(tweetCollectionGraph);
                        }
                        else if (child.Name.ToString().CompareTo("ReportName") == 0)
                        {
                            ReportName reportName = new ReportName();
                            reportName.FromXML(child);
                            Elements.Add(reportName);
                        }
                        else if (child.Name.ToString().CompareTo("ReportDate") == 0)
                        {
                            ReportDate reportDate = new ReportDate();
                            reportDate.FromXML(child);
                            Elements.Add(reportDate);
                        }
                        else if (child.Name.ToString().CompareTo("NumberOfPages") == 0)
                        {
                            NumberOfPages numberOfPages = new NumberOfPages();
                            numberOfPages.FromXML(child);
                            Elements.Add(numberOfPages);
                        }
                        else if (child.Name.ToString().CompareTo("Literal") == 0)
                        {
                            Literal literal = new Literal();
                            literal.FromXML(child);
                            Elements.Add(literal);
                        }
                        else if (child.Name.ToString().CompareTo("ReportRangeDay") == 0)
                        {
                            ReportRangeDay reportRangeDay = new ReportRangeDay();
                            reportRangeDay.FromXML(child);
                            Elements.Add(reportRangeDay);
                        }
                        else if (child.Name.ToString().CompareTo("AccountValue") == 0)
                        {
                            AccountValue accountValue = new AccountValue();
                            accountValue.FromXML(child);
                            Elements.Add(accountValue);
                        }
                    }
                }
            }
        }

        public string ToXML()
        {
            string xml = "";

            xml += "<Cell";
            if (CSSClass.Length > 0)
                xml += " class=\"" + CSSClass + "\"";
            if (align.Length > 0)
                xml += " align=\"" + align + "\"";
            if (valign.Length > 0)
                xml += " valign=\"" + valign + "\"";
            xml += ">";

            if (Elements != null)
            {
                if (Elements.Count > 0)
                {
                    foreach (ReportElement element in Elements)
                    {
                        xml += element.ToXML();
                    }
                }
            }

            xml += "</Cell>";

            return xml;
        }
    }
}

