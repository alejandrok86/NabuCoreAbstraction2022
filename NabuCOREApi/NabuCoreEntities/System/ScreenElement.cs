using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [DataContract]
    public class ScreenElement : BaseType
    {
        [DataMember]
        public int? ScreenElementID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ScreenElement() : base()
        {
            ScreenElementID = null;
        }

        public ScreenElement(int pScreenElementID) : base()
        {
            ScreenElementID = pScreenElementID;
        }

        public ScreenElement(int? pScreenElementID) : base()
        {
            ScreenElementID = pScreenElementID;
        }

        public ScreenElement(int pScreenElementID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ScreenElementID = pScreenElementID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ScreenElement(string pAlias, Language pLanguage, string pName, string pDescription) : base()
        {
            ScreenElementID = null;
            Detail = new Translation(pAlias, pLanguage, pName, pDescription);
        }
    }
}
