using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Development
{
    [DataContract]
    public class Binary : BaseType
    {
        [DataMember]
        public int? BinaryID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Namespace { get; set; }

        [DataMember]
        public string GUID { get; set; }

        [DataMember]
        public Binary[] Dependencies { get; set; }

        public Binary() : base()
        {
            BinaryID = null;
        }

        public Binary(int pBinaryID) : base()
        {
            BinaryID = pBinaryID;
        }

        public Binary(int? pBinaryID) : base()
        {
            BinaryID = pBinaryID;
        }
    }
}
