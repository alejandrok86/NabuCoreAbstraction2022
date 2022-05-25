using System.Drawing;

namespace Octavo.Gate.Nabu.CORE.Certificate
{
    public class Renderer
    {
        private Configuration.CertificateLayout _certificateLayout;
        public List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();

        public int Top = 0;
        public int Left = 0;

        public Renderer()
        {
        }
        public Renderer(Configuration.CertificateLayout pCertificateLayout)
        {
            _certificateLayout = pCertificateLayout;
        }

        public void Render(string pDestinationImage)
        {
            // load the background of the certificate from disk into RAM
            Bitmap certificateBackgroundAsBitmap = (Bitmap)Image.FromFile(_certificateLayout.BackgroundImage);//load the image file
            try
            {
                // now use the image as a graphics object
                using (Graphics graphics = Graphics.FromImage(certificateBackgroundAsBitmap))
                {
                    // iterate through the certificate elements
                    foreach (Configuration.Element element in _certificateLayout.elements)
                    {
                        // render the corresponding element
                        if (element.GetType() == typeof(Configuration.Div))
                            _renderDiv(element as Configuration.Div, graphics);
                        else if (element.GetType() == typeof(Configuration.P))
                            _renderP(element as Configuration.P, graphics);
                        else if (element.GetType() == typeof(Configuration.Table))
                            _renderTable(element as Configuration.Table, graphics);
                    }
                }
                certificateBackgroundAsBitmap.Save(pDestinationImage);
            }
            catch
            {
            }
            certificateBackgroundAsBitmap.Dispose();
        }

        private void _renderDiv(Configuration.Div pDivElement, Graphics graphics)
        {
            Configuration.Style combinedStyle = CombineStyles(pDivElement.Style);

            try
            {
                if (combinedStyle.Get("top").Trim().Length > 0)
                {
                    Top = Convert.ToInt32(combinedStyle.Get("top").Replace("px", ""));
                    if (combinedStyle.Get("left").Trim().Length > 0)
                        Left = Convert.ToInt32(combinedStyle.Get("left").Replace("px", ""));
                }
                if (pDivElement.children != null && pDivElement.children.Count > 0)
                {
                    foreach (Configuration.Element element in pDivElement.children)
                    {
                        // render the corresponding element
                        if (element.GetType() == typeof(Configuration.P))
                            _renderP(element as Configuration.P, graphics);
                        else if (element.GetType() == typeof(Configuration.Table))
                            _renderTable(element as Configuration.Table, graphics);
                    }
                }
            }
            catch
            {
            }
        }

        private void _renderP(Configuration.P pPElement, Graphics graphics)
        {
            Configuration.Style combinedStyle = CombineStyles(pPElement.Style);
            try
            {
                if (pPElement.ID != null && pPElement.ID.Trim().Length > 0)
                {
                    foreach (KeyValuePair<string, string> dataItem in data)
                    {
                        if (dataItem.Key.CompareTo(pPElement.ID) == 0)
                        {
                            pPElement.InnerText = dataItem.Value;
                            break;
                        }
                    }
                }
                int fontSize = Convert.ToInt32(combinedStyle.Get("font-size").Replace("pt", ""));

                using (Font selectedFont = new Font(combinedStyle.Get("font-family"), fontSize, GetFontStyle(combinedStyle.Get("font-weight"))))
                {
                    if (combinedStyle.Get("text-align").CompareTo("center") == 0)
                    {
                        Rectangle rect = new Rectangle(0, Top, _certificateLayout.Width.Value, fontSize * 2);
                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Center;
                        graphics.DrawString(pPElement.InnerText, selectedFont, GetBrushColor(combinedStyle.Get("color")), rect, stringFormat);
                    }
                    else
                        graphics.DrawString(pPElement.InnerText, selectedFont, GetBrushColor(combinedStyle.Get("color")), new PointF(Left, Top));
                }
            }
            catch
            {
            }
        }

        private void _renderTable(Configuration.Table pTableElement, Graphics graphics)
        {
            Configuration.Style combinedStyle = CombineStyles(pTableElement.Style);
            try
            {
                foreach (Configuration.TR row in pTableElement.rows)
                {
                    int oldLeft = Left;
                    _renderTR(row, graphics);
                    Left = oldLeft;
                }
            }
            catch
            {
            }
        }

        private void _renderTR(Configuration.TR pTRElement, Graphics graphics)
        {
            Configuration.Style combinedStyle = CombineStyles(pTRElement.Style);
            try
            {
                foreach (Configuration.TD cell in pTRElement.cells)
                    _renderTD(cell, graphics);
                if(combinedStyle.Get("height").Trim().Length > 0)
                    Top += Convert.ToInt32(combinedStyle.Get("height").Replace("px",""));
            }
            catch
            {
            }
        }

        private void _renderTD(Configuration.TD pTDElement, Graphics graphics)
        {
            Configuration.Style combinedStyle = CombineStyles(pTDElement.Style);
            try
            {
                foreach (Configuration.Element element in pTDElement.children)
                {
                    // render the corresponding element
                    if (element.GetType() == typeof(Configuration.P))
                        _renderP(element as Configuration.P, graphics);

                    if (combinedStyle.Get("width").Trim().Length > 0)
                        Left += Convert.ToInt32(combinedStyle.Get("width").Replace("px", ""));
                }
            }
            catch
            {
            }
        }

        private Configuration.Style CombineStyles(Configuration.Style pElementStyle)
        {
            Configuration.Style combinedStyle = new Configuration.Style();
            foreach (KeyValuePair<string,string> stylePair in _certificateLayout.DefaultStyle.Items)
            {
                bool found = false;
                if (pElementStyle != null && pElementStyle.Items.Count > 0)
                {
                    foreach (KeyValuePair<string, string> elementStylePair in pElementStyle.Items)
                    {
                        if (elementStylePair.Key.CompareTo(stylePair.Key) == 0)
                        {
                            found = true;
                            break;
                        }
                    }
                }
                if (found == false)
                    combinedStyle.Add(stylePair.Key, stylePair.Value);
            }

            foreach (KeyValuePair<string, string> elementStylePair in pElementStyle.Items)
            {
                bool found = false;
                foreach (KeyValuePair<string, string> stylePair in combinedStyle.Items)
                {
                    if (stylePair.Key.CompareTo(elementStylePair.Key) == 0)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                    combinedStyle.Add(elementStylePair.Key, elementStylePair.Value);
            }
            return combinedStyle;
        }

        private FontStyle GetFontStyle(string pFontWeight)
        {
            FontStyle fontStyle = FontStyle.Regular;

            if (pFontWeight != null && pFontWeight.Trim().Length > 0)
            {
                if (pFontWeight.ToLower().CompareTo("bold") == 0)
                    fontStyle = FontStyle.Bold;
                else if (pFontWeight.ToLower().CompareTo("italic") == 0)
                    fontStyle = FontStyle.Italic;
                else if (pFontWeight.ToLower().CompareTo("strikeout") == 0)
                    fontStyle = FontStyle.Strikeout;
                else if (pFontWeight.ToLower().CompareTo("underline") == 0)
                    fontStyle = FontStyle.Underline;
            }

            return fontStyle;
        }

        private Brush GetBrushColor(string pColor)
        {
            Brush brush = Brushes.Black;
            if (pColor.CompareTo("blue")==0)
                brush = Brushes.Blue;
            else if (pColor.CompareTo("red") == 0)
                brush = Brushes.Red;
            return brush;
        }
        /************************************************************************************************************************************
         * Public Helper Methods
         ***********************************************************************************************************************************/
        public string GetMaximumMark(Octavo.Gate.Nabu.CORE.Entities.Utility.EntityAttributeCollection attributeCollection)
        {
            string maximumScore = "";
            foreach (Octavo.Gate.Nabu.CORE.Entities.Utility.EntityAttribute attrib in attributeCollection.Items)
            {
                if (attrib.AttributeName.CompareTo("MaximumScore") == 0)
                    maximumScore = attrib.AttributeValue;
            }
            return maximumScore;
        }

        public string GetDisplayScore(double numericalOutcome, Octavo.Gate.Nabu.CORE.Entities.Utility.EntityAttributeCollection attributeCollection)
        {
            string outputScore = "";

            if (attributeCollection != null)
            {
                double maximumScore = -1;
                double passMarkPercentage = -1;
                foreach (Octavo.Gate.Nabu.CORE.Entities.Utility.EntityAttribute attrib in attributeCollection.Items)
                {
                    if (attrib.AttributeName.CompareTo("MaximumScore") == 0)
                        maximumScore = Convert.ToDouble(attrib.AttributeValue);
                    else if (attrib.AttributeName.CompareTo("PassMarkPercentage") == 0)
                        passMarkPercentage = Convert.ToInt32(attrib.AttributeValue);
                }
                if (passMarkPercentage != -1)
                {
                    if (maximumScore != -1)
                    {
                        double scoreAsPercentage = 0;
                        scoreAsPercentage = (numericalOutcome / maximumScore) * 100;
                        outputScore = Convert.ToInt32(scoreAsPercentage).ToString();
                    }
                    else
                        outputScore = numericalOutcome.ToString();
                }
                else
                    outputScore = numericalOutcome.ToString();
            }
            else
                outputScore = numericalOutcome.ToString();

            return outputScore;
        }

        public string GetPassMarkPercentage(Octavo.Gate.Nabu.CORE.Entities.Utility.EntityAttributeCollection attributeCollection)
        {
            string passMarkPercentage = "0";
            foreach (Octavo.Gate.Nabu.CORE.Entities.Utility.EntityAttribute attrib in attributeCollection.Items)
            {
                if (attrib.AttributeName.CompareTo("PassMarkPercentage") == 0)
                    passMarkPercentage = attrib.AttributeValue;
            }
            return passMarkPercentage;
        }
    }
}
