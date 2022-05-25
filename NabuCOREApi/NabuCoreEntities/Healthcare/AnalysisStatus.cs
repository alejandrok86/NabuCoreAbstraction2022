using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class AnalysisStatus : BaseType
    {
        [DataMember]
        public int? AnalysisStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public AnalysisStatus() : base()
        {
            AnalysisStatusID = null;
        }
        public AnalysisStatus(int pAnalysisStatusID) : base()
        {
            AnalysisStatusID = pAnalysisStatusID;
        }
        public AnalysisStatus(int? pAnalysisStatusID) : base()
        {
            AnalysisStatusID = pAnalysisStatusID;
        }
        public AnalysisStatus(int? pAnalysisStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            AnalysisStatusID = pAnalysisStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
