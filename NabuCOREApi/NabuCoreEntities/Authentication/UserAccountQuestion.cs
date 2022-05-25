using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Authentication
{
    [DataContract]
    public class UserAccountQuestion : BaseType
    {
        [DataMember]
        public int? UserAccountQuestionID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public UserAccountQuestion() : base()
        {
            UserAccountQuestionID = null;
        }

        public UserAccountQuestion(int pUserAccountQuestionID) :  base()
        {
            UserAccountQuestionID = pUserAccountQuestionID;
        }

        public UserAccountQuestion(int? pUserAccountQuestionID) :  base()
        {
            UserAccountQuestionID = pUserAccountQuestionID;
        }
    }
}
