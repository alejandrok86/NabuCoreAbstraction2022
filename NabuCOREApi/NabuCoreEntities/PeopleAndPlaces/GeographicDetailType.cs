using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class GeographicDetailType : BaseType
    {
        [DataMember]
        public int? GeographicDetailTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public GeographicDetailType() : base()
        {
            GeographicDetailTypeID = null;
        }

        public GeographicDetailType(int pGeographicDetailTypeID) : base()
        {
            GeographicDetailTypeID = pGeographicDetailTypeID;
        }

        public GeographicDetailType(int? pGeographicDetailTypeID) : base()
        {
            GeographicDetailTypeID = pGeographicDetailTypeID;
        }

        public GeographicDetailType(int pGeographicDetailTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            GeographicDetailTypeID = pGeographicDetailTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public GeographicDetailType(int? pGeographicDetailTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            GeographicDetailTypeID = pGeographicDetailTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
