using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [DataContract]
    public class FunctionalArea : BaseType
    {
        [DataMember]
        public int? FunctionalAreaID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public FunctionalArea() : base()
        {
            FunctionalAreaID = null;
        }

        public FunctionalArea(int pFunctionalAreaID) : base()
        {
            FunctionalAreaID = pFunctionalAreaID;
        }

        public FunctionalArea(int? pFunctionalAreaID) : base()
        {
            FunctionalAreaID = pFunctionalAreaID;
        }

        public FunctionalArea(int pFunctionalAreaID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            FunctionalAreaID = pFunctionalAreaID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
        public FunctionalArea(int? pFunctionalAreaID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            FunctionalAreaID = pFunctionalAreaID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
