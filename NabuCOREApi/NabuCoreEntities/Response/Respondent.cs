using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Workflow;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    [Serializable()]
    public class Respondent : Party
    {
        public Respondent() : base()
        {
        }

        public Respondent(int pRespondentID) : base(pRespondentID)
        {
        }

        public Respondent(int? pRespondentID) : base(pRespondentID)
        {
        }
    }
}
