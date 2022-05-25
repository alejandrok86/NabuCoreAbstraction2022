using System.Xml;

namespace Octavo.Gate.Nabu.CORE.Certificate.Configuration
{
    public class CertificateLayout
    {
        public string BackgroundImage = null;
        public int? Width = null;
        public int? Height = null;
        public Style DefaultStyle = null;

        public List<Element> elements = new List<Element>();

        public CertificateLayout()
        {
        }

        public CertificateLayout(string pConfigFile)
        {
            Read(pConfigFile);
        }

        private bool Read(string pConfigFile)
        {
            bool result = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pConfigFile);
                foreach (XmlNode certificateNode in doc.ChildNodes)
                {
                    if (certificateNode.Name.ToString().CompareTo("certificate") == 0)
                    {
                        foreach (XmlAttribute attribute in certificateNode.Attributes)
                        {
                            if (attribute.Name.CompareTo("backgroundImage") == 0)
                                BackgroundImage = attribute.Value;
                            else if (attribute.Name.CompareTo("width") == 0)
                                Width = Convert.ToInt32(attribute.Value);
                            else if (attribute.Name.CompareTo("height") == 0)
                                Height = Convert.ToInt32(attribute.Value);
                            else if (attribute.Name.CompareTo("style") == 0)
                                DefaultStyle = new Style(attribute.Value);
                        }

                        foreach (XmlElement childNode in certificateNode.ChildNodes)
                        {
                            if (childNode.Name.CompareTo("div") == 0)
                                elements.Add(new Div(childNode));
                            else if (childNode.Name.CompareTo("p") == 0)
                                elements.Add(new P(childNode));
                            else if (childNode.Name.CompareTo("table") == 0)
                                elements.Add(new Table(childNode));
                        }
                    }
                }
                result = true;
            }
            catch
            {
            }
            return result;
        }

        public bool Write(string pConfigFile)
        {
            bool result = false;
            try
            {
                if (File.Exists(pConfigFile))
                    File.Delete(pConfigFile);

                using (StreamWriter sw = new StreamWriter(pConfigFile, false))
                {
                    sw.Write(ToXML());
                    sw.Close();
                }
                result = true;
            }
            catch
            {
            }
            return result;
        }

        private string ToXML()
        {
            string xml = "";
            xml += "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            xml += "<certificate";
            xml += " backgroundImage=\"" + ((BackgroundImage != null && BackgroundImage.Trim().Length > 0) ? BackgroundImage : "") + "\"";
            xml += " width=\"" + ((Width.HasValue) ? Width.Value.ToString() : "") + "\"";
            xml += " height=\"" + ((Height.HasValue) ? Height.Value.ToString() : "") + "\"";
            if (DefaultStyle != null)
                xml += DefaultStyle.ToXML();
            xml += ">";
            foreach (Element element in elements)
            {
                if (element.GetType() == typeof(Div))
                {
                    Div div = element as Div;
                    xml += div.ToXML();
                }
                else if (element.GetType() == typeof(P))
                {
                    P p = element as P;
                    xml += p.ToXML();
                }
                else if (element.GetType() == typeof(Table))
                {
                    Table table = element as Table;
                    xml += table.ToXML();
                }
            }
            xml += "</certificate>";
            return xml;
        }
    }
}
