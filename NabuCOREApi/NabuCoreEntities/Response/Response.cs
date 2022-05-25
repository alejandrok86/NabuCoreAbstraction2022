using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Workflow;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    [Serializable()]
    public class Response : BaseType
    {
        [DataMember]
        public int? ResponseID { get; set; }

        [DataMember]
        public Respondent Respondent { get; set; }

        [DataMember]
        public ResponseType ResponseType { get; set; }

        [DataMember]
        public int Attempt { get; set; }

        [DataMember]
        public ContractedWork WorkflowItem { get; set; }

        [DataMember]
        public Content.Content[] ResponseContents { get; set; }

        public Response() : base()
        {
            ResponseID = null;
        }

        public Response(int pResponseID) : base()
        {
            ResponseID = pResponseID;
        }

        public Response(int? pResponseID) : base()
        {
            ResponseID = pResponseID;
        }
    }
}
