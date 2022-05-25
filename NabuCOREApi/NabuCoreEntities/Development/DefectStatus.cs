using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Development
{
    [DataContract]
    public class DefectStatus : BaseType
    {
        [DataMember]
        public int? DefectStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public DefectStatus() : base()
        {
            DefectStatusID = null;
        }

        public DefectStatus(int pDefectStatusID) : base()
        {
            DefectStatusID = pDefectStatusID;
        }

        public DefectStatus(int? pDefectStatusID) : base()
        {
            DefectStatusID = pDefectStatusID;
        }

        public DefectStatus(int pDefectStatusID, Translation pDetail) : base()
        {
            DefectStatusID = pDefectStatusID;
            Detail = pDetail;
        }

        public DefectStatus(int? pDefectStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            DefectStatusID = pDefectStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public DefectStatus(int pDefectStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            DefectStatusID = pDefectStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
