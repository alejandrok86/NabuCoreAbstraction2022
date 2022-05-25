using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class ChangeStatus : BaseType
    {
        [DataMember]
        public int? ChangeStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ChangeStatus() : base()
        {
            ChangeStatusID = null;
        }

        public ChangeStatus(int pChangeStatusID) : base()
        {
            ChangeStatusID = pChangeStatusID;
        }

        public ChangeStatus(int? pChangeStatusID) : base()
        {
            ChangeStatusID = pChangeStatusID;
        }

        public ChangeStatus(int pChangeStatusID, Translation pDetail) : base()
        {
            ChangeStatusID = pChangeStatusID;
            Detail = pDetail;
        }

        public ChangeStatus(int? pChangeStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ChangeStatusID = pChangeStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ChangeStatus(int pChangeStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ChangeStatusID = pChangeStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
