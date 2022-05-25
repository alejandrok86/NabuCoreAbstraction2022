using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    [Serializable()]
    public class InstrumentScoringAlgorithm : BaseType
    {
        [DataMember]
        public int? InstrumentScoringAlgorithmID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public ScoringReferenceTable[] ScoringReferenceTables { get; set; }

        public InstrumentScoringAlgorithm() : base()
        {
            InstrumentScoringAlgorithmID = null;
        }

        public InstrumentScoringAlgorithm(int pInstrumentScoringAlgorithmID) : base()
        {
            InstrumentScoringAlgorithmID = pInstrumentScoringAlgorithmID;
        }

        public InstrumentScoringAlgorithm(int? pInstrumentScoringAlgorithmID) : base()
        {
            InstrumentScoringAlgorithmID = pInstrumentScoringAlgorithmID;
        }

        public InstrumentScoringAlgorithm(int? pInstrumentScoringAlgorithmID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            InstrumentScoringAlgorithmID = pInstrumentScoringAlgorithmID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public InstrumentScoringAlgorithm(int pInstrumentScoringAlgorithmID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            InstrumentScoringAlgorithmID = pInstrumentScoringAlgorithmID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
