using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    [DataContract]
    public class BaseKeyPair : BaseType
    {
        [DataMember]
        public int? ID { get; set; }

        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public string Value { get; set; }

        public BaseKeyPair() : base()
        {
            ID = null;
        }
        
        public BaseKeyPair(int? pID) : base()
        {
            ID = pID;
        }

        public BaseKeyPair(int pID) : base()
        {
            ID = pID;
        }

        public BaseKeyPair(string pKey, string pValue) : base()
        {
            ID = null;
            Key = pKey;
            Value = pValue;
        }

        public BaseKeyPair(int? pID, string pKey, string pValue) : base()
        {
            ID = pID;
            Key = pKey;
            Value = pValue;
        }

        public BaseKeyPair(int pID, string pKey, string pValue) : base()
        {
            ID = pID;
            Key = pKey;
            Value = pValue;
        }
        public BaseKeyPair(int pID, string pValue) : base()
        {
            ID = pID;
            Value = pValue;
        }
    }
}
