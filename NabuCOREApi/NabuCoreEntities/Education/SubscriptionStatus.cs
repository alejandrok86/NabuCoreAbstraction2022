using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class SubscriptionStatus : BaseType
    {
        [DataMember]
        public int? SubscriptionStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public SubscriptionStatus() : base()
        {
            SubscriptionStatusID = null;
        }

        public SubscriptionStatus(int? pSubscriptionStatusID) : base()
        {
            SubscriptionStatusID = pSubscriptionStatusID;
        }

        public SubscriptionStatus(int pSubscriptionStatusID) : base()
        {
            SubscriptionStatusID = pSubscriptionStatusID;
        }

        public SubscriptionStatus(int? pSubscriptionStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            SubscriptionStatusID = pSubscriptionStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public SubscriptionStatus(int pSubscriptionStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            SubscriptionStatusID = pSubscriptionStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
