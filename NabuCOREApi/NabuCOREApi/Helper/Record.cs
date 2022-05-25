using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace Octavo.Gate.Nabu.CORE.API.Helper
{
    [DataContract]
    public class Record
    {
        [DataMember]
        public bool hasErrors { get; set; } = false;
        [DataMember]
        public string errorMessage { get; set; } = "";
        [DataMember]
        public List<Field> fields { get; set; } = new List<Field>();

        public Record()
        {
        }

        public Record(XmlElement pRoot)
        {
            try
            {
                if (pRoot.Name.CompareTo("record") == 0)
                {
                    foreach (XmlElement child in pRoot.ChildNodes)
                    {
                        if (child.Name.CompareTo("field") == 0)
                            fields.Add(new Field(child));
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

            xml += "<record>";
            if (fields != null && fields.Count > 0)
            {
                foreach (Field field in fields)
                    xml += field.ToXML();
            }
            xml += "<hasErrors>" + ((hasErrors == true) ? "true" : "false") + "</hasErrors>";
            xml += "<errorMessage>" + errorMessage + "</errorMessage>";
            xml += "</record>";

            return xml;
        }

        public string GetFieldValue(string pFieldName)
        {
            string result = "";
            try
            {
                foreach (Field field in fields)
                {
                    if (field.Name.CompareTo(pFieldName) == 0)
                    {
                        result = field.Value;
                        break;
                    }
                }
            }
            catch
            {
            }
            return result;
        }
    }
}