using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    [Serializable()]
    public class InstrumentSection : BaseType
    {
        [DataMember]
        public int? InstrumentSectionID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public InstrumentSection[] SubSections { get; set; }

        [DataMember]
        public Item.Item[] Items { get; set; }

        public InstrumentSection() : base()
        {
            InstrumentSectionID = null;
        }

        public InstrumentSection(int? pInstrumentSectionID) : base()
        {
            InstrumentSectionID = pInstrumentSectionID;
        }

        public InstrumentSection(int pInstrumentSectionID) : base()
        {
            InstrumentSectionID = pInstrumentSectionID;
        }

        public InstrumentSection(int? pInstrumentSectionID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            InstrumentSectionID = pInstrumentSectionID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public InstrumentSection(int pInstrumentSectionID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            InstrumentSectionID = pInstrumentSectionID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
