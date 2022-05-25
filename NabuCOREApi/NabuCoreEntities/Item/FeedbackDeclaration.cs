using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Item
{
    [DataContract]
    public class FeedbackDeclaration : BaseType
    {
        [DataMember]
        public int? FeedbackDeclarationID { get; set; }

        [DataMember]
        public string FeedbackDeclarationXML { get; set; }

        public FeedbackDeclaration() : base()
        {
            FeedbackDeclarationID = null;
        }

        public FeedbackDeclaration(int pFeedbackDeclarationID) : base()
        {
            FeedbackDeclarationID = pFeedbackDeclarationID;
        }

        public FeedbackDeclaration(int? pFeedbackDeclarationID) : base()
        {
            FeedbackDeclarationID = pFeedbackDeclarationID;
        }
    }
}
