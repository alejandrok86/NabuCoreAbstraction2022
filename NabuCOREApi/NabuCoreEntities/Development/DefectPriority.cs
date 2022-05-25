using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Development
{
    [DataContract]
    public class DefectPriority : BaseType
    {
        [DataMember]
        public int? DefectPriorityID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public DefectPriority() : base()
        {
            DefectPriorityID = null;
        }

        public DefectPriority(int pDefectPriorityID) : base()
        {
            DefectPriorityID = pDefectPriorityID;
        }

        public DefectPriority(int? pDefectPriorityID) : base()
        {
            DefectPriorityID = pDefectPriorityID;
        }

        public DefectPriority(int pDefectPriorityID, Translation pDetail) : base()
        {
            DefectPriorityID = pDefectPriorityID;
            Detail = pDetail;
        }

        public DefectPriority(int? pDefectPriorityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            DefectPriorityID = pDefectPriorityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public DefectPriority(int pDefectPriorityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            DefectPriorityID = pDefectPriorityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
