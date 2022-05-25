using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    public class CalibrationTest : Test
    {
        [DataMember]
        public CalibrationTestType TestType { get; set; }

        public CalibrationTest() : base()
        {
        }

        public CalibrationTest(int? pCalibrationTestID) : base(pCalibrationTestID)
        {
        }

        public CalibrationTest(int pCalibrationTestID) : base(pCalibrationTestID)
        {
        }
    }
}
