using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Development
{
    [DataContract]
    public class IterationType : BaseType
    {
        [DataMember]
        public int? IterationTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public IterationType() : base()
        {
            IterationTypeID = null;
        }

        public IterationType(int pIterationTypeID) : base()
        {
            IterationTypeID = pIterationTypeID;
        }

        public IterationType(int? pIterationTypeID) : base()
        {
            IterationTypeID = pIterationTypeID;
        }

        public IterationType(int pIterationTypeID, Translation pDetail) : base()
        {
            IterationTypeID = pIterationTypeID;
            Detail = pDetail;
        }

        public IterationType(int? pIterationTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IterationTypeID = pIterationTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public IterationType(int pIterationTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IterationTypeID = pIterationTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
