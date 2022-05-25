using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Development
{
    [DataContract]
    public class IterationStatus : BaseType
    {
        [DataMember]
        public int? IterationStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public IterationStatus() : base()
        {
            IterationStatusID = null;
        }

        public IterationStatus(int pIterationStatusID) : base()
        {
            IterationStatusID = pIterationStatusID;
        }

        public IterationStatus(int? pIterationStatusID) : base()
        {
            IterationStatusID = pIterationStatusID;
        }

        public IterationStatus(int pIterationStatusID, Translation pDetail) : base()
        {
            IterationStatusID = pIterationStatusID;
            Detail = pDetail;
        }

        public IterationStatus(int? pIterationStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IterationStatusID = pIterationStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public IterationStatus(int pIterationStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IterationStatusID = pIterationStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
