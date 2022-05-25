using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class ProblemStatus : BaseType
    {
        [DataMember]
        public int? ProblemStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ProblemStatus() : base()
        {
            ProblemStatusID = null;
        }

        public ProblemStatus(int pProblemStatusID) : base()
        {
            ProblemStatusID = pProblemStatusID;
        }

        public ProblemStatus(int? pProblemStatusID) : base()
        {
            ProblemStatusID = pProblemStatusID;
        }

        public ProblemStatus(int pProblemStatusID, Translation pDetail) : base()
        {
            ProblemStatusID = pProblemStatusID;
            Detail = pDetail;
        }

        public ProblemStatus(int? pProblemStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ProblemStatusID = pProblemStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ProblemStatus(int pProblemStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ProblemStatusID = pProblemStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
