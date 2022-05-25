using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class ProblemCategory : BaseType
    {
        [DataMember]
        public int? ProblemCategoryID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ProblemCategory() : base()
        {
            ProblemCategoryID = null;
        }

        public ProblemCategory(int pProblemCategoryID) : base()
        {
            ProblemCategoryID = pProblemCategoryID;
        }

        public ProblemCategory(int? pProblemCategoryID) : base()
        {
            ProblemCategoryID = pProblemCategoryID;
        }

        public ProblemCategory(int pProblemCategoryID, Translation pDetail) : base()
        {
            ProblemCategoryID = pProblemCategoryID;
            Detail = pDetail;
        }

        public ProblemCategory(int? pProblemCategoryID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ProblemCategoryID = pProblemCategoryID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ProblemCategory(int pProblemCategoryID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ProblemCategoryID = pProblemCategoryID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
