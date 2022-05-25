using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class CalibrationTestType : TestType
    {
        [DataMember]
        public List<TestCriterion> CalibrationTestCriterion { get; set; }

        public CalibrationTestType() : base()
        {
            CalibrationTestCriterion = new List<TestCriterion>();
        }

        public CalibrationTestType(int? pCalibrationTestTypeID) : base(pCalibrationTestTypeID)
        {
        }

        public CalibrationTestType(int pCalibrationTestTypeID) : base(pCalibrationTestTypeID)
        {
        }

        public CalibrationTestType(int? pCalibrationTestTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base(pCalibrationTestTypeID, pAlias, pTranslationID, pLanguage, pName, pDescription)
        {
        }

        public CalibrationTestType(int pCalibrationTestTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base(pCalibrationTestTypeID, pAlias, pTranslationID, pLanguage, pName, pDescription)
        {
        }
    }
}
