using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class ProblemPriority : BaseType
    {
        [DataMember]
        public int? ProblemPriorityID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ProblemPriority() : base()
        {
            ProblemPriorityID = null;
        }

        public ProblemPriority(int pProblemPriorityID) : base()
        {
            ProblemPriorityID = pProblemPriorityID;
        }

        public ProblemPriority(int? pProblemPriorityID) : base()
        {
            ProblemPriorityID = pProblemPriorityID;
        }

        public ProblemPriority(int pProblemPriorityID, Translation pDetail) : base()
        {
            ProblemPriorityID = pProblemPriorityID;
            Detail = pDetail;
        }

        public ProblemPriority(int? pProblemPriorityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ProblemPriorityID = pProblemPriorityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ProblemPriority(int pProblemPriorityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ProblemPriorityID = pProblemPriorityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
