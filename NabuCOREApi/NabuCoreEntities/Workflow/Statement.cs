using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [DataContract]
    [Serializable()]
    public class Statement : BaseType
    {
        [DataMember]
        public int? StatementID { get; set; }

        [DataMember]
        public State State { get; set; }

        [DataMember]
        public Action Action { get; set; }

        [DataMember]
        public ActivityStep NextActivityStep { get; set; }

        public Statement() : base()
        {
            StatementID = null;
        }

        public Statement(int pStatementID) : base()
        {
            StatementID = pStatementID;
        }

        public Statement(int? pStatementID) : base()
        {
            StatementID = pStatementID;
        }
    }
}
