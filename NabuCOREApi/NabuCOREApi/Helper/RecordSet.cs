using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace Octavo.Gate.Nabu.CORE.API.Helper
{
    [DataContract]
    public class RecordSet
    {
        [DataMember]
        public bool hasErrors { get; set; } = false;
        [DataMember]
        public string errorMessage { get; set; } = "";
        [DataMember]
        public List<Record> records { get; set; } = new List<Record>();

        public RecordSet()
        {
        }

        public RecordSet(string xmlFragment)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlFragment);
                XmlElement root = doc.DocumentElement;
                if (root.Name.CompareTo("recordSet") == 0)
                {
                    foreach (XmlElement child in root.ChildNodes)
                    {
                        if (child.Name.CompareTo("record") == 0)
                            records.Add(new Record(child));
                        else if (child.Name.CompareTo("hasErrors") == 0)
                            hasErrors = ((child.InnerXml.ToLower().CompareTo("true") == 0) ? true : false);
                        else if (child.Name.CompareTo("errorMessage") == 0)
                            errorMessage = child.InnerXml;
                    }
                }
            }
            catch
            {
            }
        }

        public string ToXML()
        {
            string xml = "";

            xml += "<recordSet>";
            if (records != null && records.Count > 0)
            {
                foreach (Record record in records)
                    xml += record.ToXML();
            }
            xml += "<hasErrors>" + ((hasErrors == true) ? "true" : "false") + "</hasErrors>";
            xml += "<errorMessage>" + errorMessage + "</errorMessage>";
            xml += "</recordSet>";

            return xml;
        }
    }
}