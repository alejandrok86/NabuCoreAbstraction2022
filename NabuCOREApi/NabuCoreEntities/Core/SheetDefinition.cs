using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    [Serializable()]
    public class SheetDefinition : BaseType
    {
        [DataMember]
        public int? SheetDefinitionID { get; set; }

        [DataMember]
        public PaperInstrument PaperInstrument { get; set; }

        [DataMember]
        public int PageNumber { get; set; }

        public SheetDefinition() : base()
        {
            SheetDefinitionID = null;
        }

        public SheetDefinition(int? pSheetDefinitionID) : base()
        {
            SheetDefinitionID = pSheetDefinitionID;
        }

        public SheetDefinition(int pSheetDefinitionID) : base()
        {
            SheetDefinitionID = pSheetDefinitionID;
        }
    }
}
