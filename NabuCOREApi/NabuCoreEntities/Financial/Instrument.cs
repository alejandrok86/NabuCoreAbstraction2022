using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Instrument : BaseType
    {
        [DataMember]
        public int? InstrumentID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string TickerCode { get; set; }

        [DataMember]
        public Currency Currency { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        public Instrument() : base()
        {
            InstrumentID = null;
        }

        public Instrument(int pInstrumentID) : base()
        {
            InstrumentID = pInstrumentID;
        }

        public Instrument(int? pInstrumentID) : base()
        {
            InstrumentID = pInstrumentID;
        }

        public Instrument(int pInstrumentID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            InstrumentID = pInstrumentID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
