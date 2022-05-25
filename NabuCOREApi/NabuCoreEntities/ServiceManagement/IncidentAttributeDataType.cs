using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class IncidentAttributeDataType : BaseType
    {
        [DataMember]
        public int? IncidentAttributeDataTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public IncidentAttributeDataType() : base()
        {
            IncidentAttributeDataTypeID = null;
        }

        public IncidentAttributeDataType(int pIncidentAttributeDataTypeID) : base()
        {
            IncidentAttributeDataTypeID = pIncidentAttributeDataTypeID;
        }

        public IncidentAttributeDataType(int? pIncidentAttributeDataTypeID) : base()
        {
            IncidentAttributeDataTypeID = pIncidentAttributeDataTypeID;
        }

        public IncidentAttributeDataType(int pIncidentAttributeDataTypeID, Translation pDetail) : base()
        {
            IncidentAttributeDataTypeID = pIncidentAttributeDataTypeID;
            Detail = pDetail;
        }

        public IncidentAttributeDataType(int? pIncidentAttributeDataTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IncidentAttributeDataTypeID = pIncidentAttributeDataTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public IncidentAttributeDataType(int pIncidentAttributeDataTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IncidentAttributeDataTypeID = pIncidentAttributeDataTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
