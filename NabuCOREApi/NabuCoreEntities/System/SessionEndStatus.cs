using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [DataContract]
    public class SessionEndStatus : BaseType
    {
        [DataMember]
        public int? SessionEndStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public SessionEndStatus() : base()
        {
            SessionEndStatusID = null;
        }

        public SessionEndStatus(int pSessionEndStatusID) : base()
        {
            SessionEndStatusID = pSessionEndStatusID;
        }

        public SessionEndStatus(int? pSessionEndStatusID) : base()
        {
            SessionEndStatusID = pSessionEndStatusID;
        }

        public SessionEndStatus(int pSessionEndStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            SessionEndStatusID = pSessionEndStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public SessionEndStatus(int? pSessionEndStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            SessionEndStatusID = pSessionEndStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
