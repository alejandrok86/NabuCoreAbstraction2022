using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Utility;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class Unit : BaseType
    {
        [DataMember]
        public int? UnitID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public Tier Tier { get; set; }

        [DataMember]
        public Instrument[] Instruments { get; set; }

        [DataMember]
        public UnitReport[] UnitReports { get; set; }

        [DataMember]
        public EntityAttributeCollection Attributes { get; set; }

        public Unit() : base()
        {
            UnitID = null;
        }

        public Unit(int? pUnitID) : base()
        {
            UnitID = pUnitID;
        }

        public Unit(int pUnitID) : base()
        {
            UnitID = pUnitID;
        }

        public Unit(int? pUnitID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            UnitID = pUnitID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
