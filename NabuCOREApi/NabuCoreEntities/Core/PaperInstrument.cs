using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [KnownType(typeof(Instrument))]
    [DataContract]
    [Serializable()]
    public class PaperInstrument : Instrument
    {
        public PaperInstrument() : base()
        {
        }

        public PaperInstrument(int? pPaperInstrumentID) : base(pPaperInstrumentID)
        {
        }

        public PaperInstrument(int pPaperInstrumentID) : base(pPaperInstrumentID)
        {
        }
    }
}
