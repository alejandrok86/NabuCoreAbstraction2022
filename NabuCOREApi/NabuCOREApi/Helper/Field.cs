using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Octavo.Gate.Nabu.CORE.API.Helper
{
    [DataContract]
    public class Field
    {
        [DataMember]
        public string Name { get; set; } = "";
        [DataMember]
        public string Value { get; set; } = "";

        public Field()
        {
        }

        public Field(string pName, string pValue)
        {
            Name = pName;
            Value = pValue;
        }

        public Field(XmlElement pRoot)
        {
            try
            {
                if (pRoot.Name.CompareTo("field") == 0)
                {
                    foreach (XmlAttribute attribute in pRoot.Attributes)
                    {
                        if (attribute.Name.CompareTo("name") == 0)
                            Name = attribute.Value;
                    }

                    Value = pRoot.InnerXml.Replace("%26", "&");
                }
            }
            catch
            {
            }
        }

        public string ToXML()
        {
            string xml = "";

            xml += "<field name=\"" + Name + "\">" + Value.Replace("&","%26") + "</field>";

            return xml;
        }

        public DateTime? ConvertToDateTime()
        {
            DateTime? result = null;
            try
            {
                result = DateTime.ParseExact(Value, "dd-MMM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
            }
            return result;
        }
        public int ConvertToInt32()
        {
            int result = -1;
            try
            {
                result = Convert.ToInt32(Value);
            }
            catch
            {
            }
            return result;
        }
        public decimal ConvertToDecimal()
        {
            decimal result = -1;
            try
            {
                result = Convert.ToDecimal(Value);
            }
            catch
            {
            }
            return result;
        }
    }
}