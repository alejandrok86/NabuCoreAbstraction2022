using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class NonLearnerSubscriptionType : BaseType
    {
        [DataMember]
        public int? NonLearnerSubscriptionTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public NonLearnerSubscriptionType() : base()
        {
            NonLearnerSubscriptionTypeID = null;
        }

        public NonLearnerSubscriptionType(int? pNonLearnerSubscriptionTypeID) : base()
        {
            NonLearnerSubscriptionTypeID = pNonLearnerSubscriptionTypeID;
        }

        public NonLearnerSubscriptionType(int pNonLearnerSubscriptionTypeID) : base()
        {
            NonLearnerSubscriptionTypeID = pNonLearnerSubscriptionTypeID;
        }

        public NonLearnerSubscriptionType(int? pNonLearnerSubscriptionTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            NonLearnerSubscriptionTypeID = pNonLearnerSubscriptionTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public NonLearnerSubscriptionType(int pNonLearnerSubscriptionTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            NonLearnerSubscriptionTypeID = pNonLearnerSubscriptionTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
