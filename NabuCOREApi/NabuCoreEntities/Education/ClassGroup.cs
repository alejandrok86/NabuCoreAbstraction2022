using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class ClassGroup : BaseType
    {
        [DataMember]
        public int? ClassGroupID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ClassGroup() : base()
        {
            ClassGroupID = null;
        }

        public ClassGroup(int? pClassGroupID) : base()
        {
            ClassGroupID = pClassGroupID;
        }

        public ClassGroup(int pClassGroupID) : base()
        {
            ClassGroupID = pClassGroupID;
        }

        public ClassGroup(int? pClassGroupID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ClassGroupID = pClassGroupID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ClassGroup(int pClassGroupID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ClassGroupID = pClassGroupID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
