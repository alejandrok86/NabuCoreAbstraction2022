using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Error
{
    [DataContract]
    public class ErrorDetail
    {
        [DataMember]
        public int? ErrorID { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        public ErrorDetail()
        {
            ErrorID = null;
            ErrorMessage = "";
        }

        public ErrorDetail(int pErrorID)
        {
            ErrorID = pErrorID;
        }

        public ErrorDetail(int? pErrorID)
        {
            ErrorID = pErrorID;
        }

        public ErrorDetail(int pErrorID, string pErrorMessage)
        {
            ErrorID = pErrorID;
            ErrorMessage = pErrorMessage;
        }
    }
}
