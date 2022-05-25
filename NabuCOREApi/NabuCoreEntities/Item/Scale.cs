using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Item
{
    [DataContract]
    public class Scale : BaseType
    {
        [DataMember]
        public int? ScaleID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public Scale() : base()
        {
            ScaleID = null;
        }
        public Scale(int pScaleID) : base()
        {
            ScaleID = pScaleID;
        }
        public Scale(int? pScaleID) : base()
        {
            ScaleID = pScaleID;
        }
        public Scale(int? pScaleID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ScaleID = pScaleID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
