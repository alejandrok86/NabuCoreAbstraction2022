using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    [Serializable()]
    public class InstrumentPart : BaseType
    {
        [DataMember]
        public int? InstrumentPartID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public InstrumentSection[] Sections { get; set; }

        public InstrumentPart() : base()
        {
            InstrumentPartID = null;
        }

        public InstrumentPart(int? pInstrumentPartID) : base()
        {
            InstrumentPartID = pInstrumentPartID;
        }

        public InstrumentPart(int pInstrumentPartID) : base()
        {
            InstrumentPartID = pInstrumentPartID;
        }
        public InstrumentPart(int? pInstrumentPartID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            InstrumentPartID = pInstrumentPartID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public InstrumentPart(int pInstrumentPartID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            InstrumentPartID = pInstrumentPartID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
