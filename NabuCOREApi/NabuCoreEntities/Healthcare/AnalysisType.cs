using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class AnalysisType : BaseType
    {
        [DataMember]
        public int? AnalysisTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public AnalysisType() : base()
        {
            AnalysisTypeID = null;
        }
        public AnalysisType(int pAnalysisTypeID) : base()
        {
            AnalysisTypeID = pAnalysisTypeID;
        }
        public AnalysisType(int? pAnalysisTypeID) : base()
        {
            AnalysisTypeID = pAnalysisTypeID;
        }
        public AnalysisType(int? pAnalysisTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            AnalysisTypeID = pAnalysisTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
