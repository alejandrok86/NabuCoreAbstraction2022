using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class AttendanceRegisterStatus : BaseType
    {
        [DataMember]
        public int? AttendanceRegisterStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public AttendanceRegisterStatus() : base()
        {
            AttendanceRegisterStatusID = null;
        }

        public AttendanceRegisterStatus(int? pAttendanceRegisterStatusID) : base()
        {
            AttendanceRegisterStatusID = pAttendanceRegisterStatusID;
        }

        public AttendanceRegisterStatus(int pAttendanceRegisterStatusID) : base()
        {
            AttendanceRegisterStatusID = pAttendanceRegisterStatusID;
        }

        public AttendanceRegisterStatus(int? pAttendanceRegisterStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            AttendanceRegisterStatusID = pAttendanceRegisterStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public AttendanceRegisterStatus(int pAttendanceRegisterStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            AttendanceRegisterStatusID = pAttendanceRegisterStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
