using System;
using System.Runtime.Serialization;
using System.Collections;
using System.Xml.Linq;

namespace Octavo.Gate.Nabu.CORE.Entities.Utility
{
    [DataContract]
    [Serializable()]
    public class EntityAttributeCollection : BaseType
    {
        [DataMember]
        public EntityAttribute[] Items { get; set; }

        public EntityAttributeCollection() : base()
        {
        }

        public EntityAttributeCollection(EntityAttribute Attribute) : base()
        {
            Add(Attribute);
        }

        public EntityAttributeCollection(string xmlAttributeFragment)
        {
            Items = null;
            try
            {
                XMLHelper xmlHelper = new XMLHelper();
                string XMLFragment = xmlHelper.XMLEncode(xmlAttributeFragment);
                XElement oXmlElement = XElement.Parse(XMLFragment);
                if (oXmlElement.Name.ToString().CompareTo("attributes") == 0)
                {
                    if (oXmlElement.HasElements)
                    {
                        foreach (XNode oXNode in oXmlElement.Nodes())
                        {
                            if (oXNode.GetType() == typeof(XElement))
                            {
                                XElement xelement = (XElement)oXNode;
                                if (xelement.Name.ToString().CompareTo("attribute") == 0)
                                {
                                    if (xelement.HasAttributes)
                                    {
                                        EntityAttribute entityAttribute = new EntityAttribute();
                                        foreach (XAttribute attrib in xelement.Attributes())
                                        {
                                            if (attrib.Name.ToString().CompareTo("name") == 0)
                                            {
                                                entityAttribute.AttributeName = attrib.Value.ToString();
                                            }
                                            else if (attrib.Name.ToString().CompareTo("dataType") == 0)
                                            {
                                                entityAttribute.AttributeDataType = attrib.Value.ToString();
                                            }
                                            else if (attrib.Name.ToString().CompareTo("value") == 0)
                                            {
                                                entityAttribute.AttributeValue = attrib.Value.ToString();
                                            }
                                        }
                                        Add(entityAttribute);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void Add(EntityAttribute Attribute)
        {
            ArrayList itemCollection = new ArrayList();
            if (Items == null)
            {
            }
            else
            {
                foreach (EntityAttribute attrib in Items)
                {
                    itemCollection.Add(attrib);
                }
            }
            itemCollection.Add(Attribute);
            Items = null;
            Items = (EntityAttribute[])itemCollection.ToArray(typeof(EntityAttribute));
        }

        public EntityAttribute GetAttributeByName(string pAttributeName)
        {
            EntityAttribute returnValue = null;
            foreach (EntityAttribute attrib in Items)
            {
                if (attrib.AttributeName.CompareTo(pAttributeName) == 0)
                {
                    returnValue = attrib;
                    break;
                }
            }
            return returnValue;
        }

        public string ToXMLFragment()
        {
            string xml = "";
            if (Items != null)
            {
                if (Items.Length > 0)
                {
                    xml += "<attributes>";
                    foreach (EntityAttribute attrib in Items)
                    {
                        xml += "<attribute";
                        xml += " name=\"" + attrib.AttributeName + "\"";
                        xml += " dataType=\"" + attrib.AttributeDataType + "\"";
                        xml += " value=\"" + attrib.AttributeValue + "\"";
                        xml += "/>";
                    } 
                    xml += "</attributes>";
                }
            }
            return xml;
        }
    }
}
