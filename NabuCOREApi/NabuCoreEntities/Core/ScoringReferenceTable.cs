using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    [Serializable()]
    public class ScoringReferenceTable : BaseType
    {
        [DataMember]
        public int? ScoringReferenceTableID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public Content.StructuredContent ReferenceTable { get; set; }

        public ScoringReferenceTable() : base()
        {
            ScoringReferenceTableID = null;
        }

        public ScoringReferenceTable(int pInstrumentScoringAlgorithmID) : base()
        {
            ScoringReferenceTableID = pInstrumentScoringAlgorithmID;
        }

        public ScoringReferenceTable(int? pInstrumentScoringAlgorithmID) : base()
        {
            ScoringReferenceTableID = pInstrumentScoringAlgorithmID;
        }

        public ScoringReferenceTable(int? pInstrumentScoringAlgorithmID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ScoringReferenceTableID = pInstrumentScoringAlgorithmID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ScoringReferenceTable(int pInstrumentScoringAlgorithmID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ScoringReferenceTableID = pInstrumentScoringAlgorithmID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
