using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Development
{
    [DataContract]
    public class DefectType : BaseType
    {
        [DataMember]
        public int? DefectTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public DefectType() : base()
        {
            DefectTypeID = null;
        }

        public DefectType(int pDefectTypeID) : base()
        {
            DefectTypeID = pDefectTypeID;
        }

        public DefectType(int? pDefectTypeID) : base()
        {
            DefectTypeID = pDefectTypeID;
        }

        public DefectType(int pDefectTypeID, Translation pDetail) : base()
        {
            DefectTypeID = pDefectTypeID;
            Detail = pDetail;
        }

        public DefectType(int? pDefectTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            DefectTypeID = pDefectTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public DefectType(int pDefectTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            DefectTypeID = pDefectTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
