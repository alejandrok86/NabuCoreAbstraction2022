using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class EmbeddedPageDefinition : BaseType
    {
        [DataMember]
        public int? DefinitionID { get; set; }

        [DataMember]
        public Uri PageSource { get; set; }

        [DataMember]
        public string AllowScrolling { get; set; }         // yes, no, auto

        [DataMember]
        public string Name { get; set; }                    // name of the iframe

        [DataMember]
        public string LongDescription { get; set; }         // long description of the iframe

        [DataMember]
        public string WidthPixels { get; set; }             // width of iframe on page

        [DataMember]
        public string HeightPixels { get; set; }            // height of iframe on page

        [DataMember]
        public string Alignment { get; set; }               // deprecated, should use styles, but values are left, right, top, middle, bottom

        [DataMember]
        public string FrameBorder { get; set; }             // 1 = display border, 0 = do not display border

        [DataMember]
        public string MarginWidth { get; set; }             // Specifies the left and right margins of the content of the iframe

        [DataMember]
        public string MarginHeight { get; set; }            // Specifies the top and bottom margins of the content of the ifram

        [DataMember]
        public bool SiteAllowsIFrames { get; set; }

        public EmbeddedPageDefinition() : base()
        {
            DefinitionID = null;
            AllowScrolling = "";          // yes, no, auto
            Name = "";                    // name of the iframe
            LongDescription = "";         // long description of the iframe
            WidthPixels = "";             // width of iframe on page
            HeightPixels = "";            // height of iframe on page
            Alignment = "";               // deprecated, should use styles, but values are left, right, top, middle, bottom
            FrameBorder = "";             // 1 = display border, 0 = do not display border
            MarginWidth = "";             // Specifies the left and right margins of the content of the iframe
            MarginHeight = "";            // Specifies the top and bottom margins of the content of the ifram
            SiteAllowsIFrames = false;
        }

    public EmbeddedPageDefinition(int pDefinitionID) : base()
        {
            DefinitionID = pDefinitionID;
        }

        public EmbeddedPageDefinition(int? pDefinitionID) : base()
        {
            DefinitionID = pDefinitionID;
        }
    }
}
