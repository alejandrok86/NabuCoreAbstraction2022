using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class InstitutionClientCategory : BaseType
    {
        [DataMember]
        public int? InstitutionClientCategoryID { get; set; }

        [DataMember]
        public ClientCategory ClientCategory { get; set; }

        [DataMember]
        public CategoryClassification CategoryClassification { get; set; }

        [DataMember]
        public bool IsOffshore { get; set; }

        [DataMember]
        public bool AcceptsDeposits { get; set; }

        [DataMember]
        public Social.Comment Comment { get; set; }

        public InstitutionClientCategory() : base()
        {
            InstitutionClientCategoryID = null;
            IsOffshore = false;
            AcceptsDeposits = true;
        }
        public InstitutionClientCategory(int pInstitutionClientCategoryID) : base()
        {
            InstitutionClientCategoryID = pInstitutionClientCategoryID;
        }
        public InstitutionClientCategory(int? pInstitutionClientCategoryID) : base()
        {
            InstitutionClientCategoryID = pInstitutionClientCategoryID;
        }
    }
}
