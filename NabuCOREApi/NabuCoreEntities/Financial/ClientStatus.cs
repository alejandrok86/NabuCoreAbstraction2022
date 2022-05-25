using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class ClientStatus : BaseType
    {
        [DataMember]
        public int? ClientStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ClientStatus() : base()
        {
            ClientStatusID = null;
        }

        public ClientStatus(int pClientStatusID) : base()
        {
            ClientStatusID = pClientStatusID;
        }

        public ClientStatus(int? pClientStatusID) : base()
        {
            ClientStatusID = pClientStatusID;
        }

        public ClientStatus(int pClientStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ClientStatusID = pClientStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
