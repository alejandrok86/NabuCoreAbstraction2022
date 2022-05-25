using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class StatementStatus : BaseType
    {
        [DataMember]
        public int? StatementStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public StatementStatus() : base()
        {
            StatementStatusID = null;
        }

        public StatementStatus(int pStatementStatusID) : base()
        {
            StatementStatusID = pStatementStatusID;
        }

        public StatementStatus(int? pStatementStatusID) : base()
        {
            StatementStatusID = pStatementStatusID;
        }

        public StatementStatus(int pStatementStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            StatementStatusID = pStatementStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
