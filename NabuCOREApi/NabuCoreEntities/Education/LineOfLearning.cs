using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class LineOfLearning : BaseType
    {
        [DataMember]
        public int? LineOfLearningID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public LineOfLearning() : base()
        {
            LineOfLearningID = null;
        }

        public LineOfLearning(int? pLineOfLearningID) : base()
        {
            LineOfLearningID = pLineOfLearningID;
        }

        public LineOfLearning(int pLineOfLearningID) : base()
        {
            LineOfLearningID = pLineOfLearningID;
        }

        public LineOfLearning(int? pLineOfLearningID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            LineOfLearningID = pLineOfLearningID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public LineOfLearning(int pLineOfLearningID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            LineOfLearningID = pLineOfLearningID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
