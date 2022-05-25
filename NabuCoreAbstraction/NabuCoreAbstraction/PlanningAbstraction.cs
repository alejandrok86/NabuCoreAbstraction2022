using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
using System;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class PlanningAbstraction : BaseAbstraction
    {
        public PlanningAbstraction() : base()
        {
        }

        public PlanningAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Appointment
         *********************************************************************/
        public Appointment GetAppointment(int pAppointmentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAppointmentID, pLanguageID);
            }
            else
                return null;
        }

        public Appointment[] ListAppointments(int pPartyID, DateTime pFrom, DateTime pTo, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyID, pFrom, pTo, pLanguageID);
            }
            else
                return null;
        }

        public Appointment InsertAppointment(Appointment pAppointment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAppointment);
            }
            else
                return null;
        }

        public Appointment UpdateAppointment(Appointment pAppointment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAppointment);
            }
            else
                return null;
        }

        public Appointment DeleteAppointment(Appointment pAppointment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAppointment);
            }
            else
                return null;
        }
        /**********************************************************************
         * Appointment Type
         *********************************************************************/
        public AppointmentType GetAppointmentType(int pAppointmentTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentTypeDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAppointmentTypeID, pLanguageID);
            }
            else
                return null;
        }

        public AppointmentType GetAppointmentTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentTypeDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public AppointmentType[] ListAppointmentTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentTypeDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AppointmentType InsertAppointmentType(AppointmentType pAppointmentType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentTypeDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAppointmentType);
            }
            else
                return null;
        }

        public AppointmentType UpdateAppointmentType(AppointmentType pAppointmentType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentTypeDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAppointmentType);
            }
            else
                return null;
        }

        public AppointmentType DeleteAppointmentType(AppointmentType pAppointmentType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentTypeDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAppointmentType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Daily Recurrence
         *********************************************************************/
        public DailyRecurrence GetDailyRecurrence(int pRecurrenceID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DailyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.DailyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRecurrenceID, pLanguageID);
            }
            else
                return null;
        }

        public DailyRecurrence InsertDailyRecurrence(DailyRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DailyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.DailyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRecurrence);
            }
            else
                return null;
        }

        public DailyRecurrence UpdateDailyRecurrence(DailyRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DailyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.DailyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRecurrence);
            }
            else
                return null;
        }

        public DailyRecurrence DeleteDailyRecurrence(DailyRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DailyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.DailyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRecurrence);
            }
            else
                return null;
        }
        /**********************************************************************
         * Deliverable
         *********************************************************************/
        public Deliverable GetDeliverable(int pDeliverableID, Project pProject)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDeliverableID, pProject);
            }
            else
                return null;
        }

        public Deliverable GetDeliverable(int pDeliverableID, Programme pProgramme)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDeliverableID, pProgramme);
            }
            else
                return null;
        }

        public Deliverable GetDeliverable(int pDeliverableID, Task pTask)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDeliverableID, pTask);
            }
            else
                return null;
        }

        public Deliverable[] ListDeliverables(Task pTask)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pTask);
            }
            else
                return null;
        }

        public Deliverable[] ListDeliverables(Project pProject)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pProject);
            }
            else
                return null;
        }

        public Deliverable[] ListDeliverables(Programme pProgramme)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pProgramme);
            }
            else
                return null;
        }

        public Deliverable InsertDeliverable(Deliverable pRecurrence, Project pProject)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRecurrence, pProject);
            }
            else
                return null;
        }

        public Deliverable InsertDeliverable(Deliverable pRecurrence, Programme pProgramme)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRecurrence, pProgramme);
            }
            else
                return null;
        }

        public Deliverable InsertDeliverable(Deliverable pRecurrence, Task pTask)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRecurrence, pTask);
            }
            else
                return null;
        }

        public Deliverable UpdateDeliverable(Deliverable pRecurrence, Project pProject)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRecurrence, pProject);
            }
            else
                return null;
        }

        public Deliverable UpdateDeliverable(Deliverable pRecurrence, Programme pProgramme)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRecurrence, pProgramme);
            }
            else
                return null;
        }

        public Deliverable UpdateDeliverable(Deliverable pRecurrence, Task pTask)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRecurrence, pTask);
            }
            else
                return null;
        }

        public Deliverable DeleteDeliverable(Deliverable pRecurrence, Programme pProgramme)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRecurrence, pProgramme);
            }
            else
                return null;
        }

        public Deliverable DeleteDeliverable(Deliverable pRecurrence, Project pProject)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRecurrence, pProject);
            }
            else
                return null;
        }

        public Deliverable DeleteDeliverable(Deliverable pRecurrence, Task pTask)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRecurrence, pTask);
            }
            else
                return null;
        }
        public BaseBoolean AssignContentToProject(Project pProject, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pProject, pContent);
            }
            else
                return null;
        }
        public BaseBoolean RemoveContentFromProject(Project pProject, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pProject, pContent);
            }
            else
                return null;
        }
        public BaseBoolean AssignBinaryToProject(Project pProject, Entities.Development.Binary pBinary)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pProject, pBinary);
            }
            else
                return null;
        }
        public BaseBoolean RemoveBinaryFromProject(Project pProject, Entities.Development.Binary pBinary)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pProject, pBinary);
            }
            else
                return null;
        }
        /**********************************************************************
         * Deliverable Type
         *********************************************************************/
        public DeliverableType GetDeliverableType(int pDeliverableTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableTypeDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDeliverableTypeID, pLanguageID);
            }
            else
                return null;
        }

        public DeliverableType GetDeliverableTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableTypeDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public DeliverableType[] ListDeliverableTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableTypeDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public DeliverableType InsertDeliverableType(DeliverableType pDeliverableType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableTypeDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDeliverableType);
            }
            else
                return null;
        }

        public DeliverableType UpdateDeliverableType(DeliverableType pDeliverableType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableTypeDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDeliverableType);
            }
            else
                return null;
        }

        public DeliverableType DeleteDeliverableType(DeliverableType pDeliverableType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableTypeDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDeliverableType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Duration
         *********************************************************************/
        public Duration GetDuration(int pDurationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DurationDOL DOL = new CORE.DOL.MSSQL.Planning.DurationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDurationID);
            }
            else
                return null;
        }

        public Duration InsertDuration(Duration pDuration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DurationDOL DOL = new CORE.DOL.MSSQL.Planning.DurationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDuration);
            }
            else
                return null;
        }

        public Duration UpdateDuration(Duration pDuration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DurationDOL DOL = new CORE.DOL.MSSQL.Planning.DurationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDuration);
            }
            else
                return null;
        }

        public Duration DeleteDuration(Duration pDuration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DurationDOL DOL = new CORE.DOL.MSSQL.Planning.DurationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDuration);
            }
            else
                return null;
        }
        /**********************************************************************
         * Meeting Participant
         *********************************************************************/
        public MeetingParticipant[] ListMeetingParticipants(int pAppointmentID, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListOtherParticipants(pAppointmentID, pPartyID);
            }
            else
                return null;
        }

        public BaseBoolean DeleteAllParticipants(int pAppointmentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.DeleteAllParticipants(pAppointmentID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveParticipant(int pAppointmentID, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveParticipant(pAppointmentID, pPartyID);
            }
            else
                return null;
        }

        public MeetingParticipant AddParticipant(int pAppointmentID, MeetingParticipant pMeetingParticipant)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AddParticipant(pAppointmentID, pMeetingParticipant);
            }
            else
                return null;
        }

        public MeetingParticipant UpdateParticipant(int pAppointmentID, MeetingParticipant pMeetingParticipant)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.AppointmentDOL DOL = new CORE.DOL.MSSQL.Planning.AppointmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.UpdateParticipant(pAppointmentID, pMeetingParticipant);
            }
            else
                return null;
        }

        /**********************************************************************
         * Monthly Recurrence
         *********************************************************************/
        public MonthlyRecurrence GetMonthlyRecurrence(int pRecurrenceID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.MonthlyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.MonthlyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRecurrenceID, pLanguageID);
            }
            else
                return null;
        }

        public MonthlyRecurrence InsertMonthlyRecurrence(MonthlyRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.MonthlyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.MonthlyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRecurrence);
            }
            else
                return null;
        }

        public MonthlyRecurrence UpdateMonthlyRecurrence(MonthlyRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.MonthlyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.MonthlyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRecurrence);
            }
            else
                return null;
        }

        public MonthlyRecurrence DeleteMonthlyRecurrence(MonthlyRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.MonthlyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.MonthlyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRecurrence);
            }
            else
                return null;
        }
        /**********************************************************************
         * Note
         *********************************************************************/
        public Note AssignNoteTo(int pNoteID, Entities.Project.Action pAction)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pAction);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Entities.Project.Assumption pAssumption)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pAssumption);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Entities.Project.Issue pIssue)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pIssue);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Entities.Project.Risk pRisk)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pRisk);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Project pProject)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pProject);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Programme pProgramme)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pProgramme);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Task pTask)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID,pTask);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Entities.ServiceManagement.Incident pIncident)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pIncident);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Entities.ServiceManagement.Problem pProblem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pProblem);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Entities.ServiceManagement.Change pChange)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pChange);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Entities.Development.Defect pDefect)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pDefect);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Entities.Development.Iteration pIteration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pIteration);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Entities.Development.Requirement pRequirement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pRequirement);
            }
            else
                return null;
        }
        public Note AssignNoteTo(int pNoteID, Entities.Financial.AccountTransaction pTransaction)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pNoteID, pTransaction);
            }
            else
                return null;
        }

        public Note GetNote(int pNoteID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pNoteID);
            }
            else
                return null;
        }

        public Note[] ListNotesFor(Entities.Project.Action pAction)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pAction);
            }
            else
                return null;
        }
        public Note[] ListNotesFor(Entities.Project.Assumption pAssumption)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pAssumption);
            }
            else
                return null;
        }
        public Note[] ListNotesFor(Entities.Project.Issue pIssue)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pIssue);
            }
            else
                return null;
        }
        public Note[] ListNotesFor(Entities.Project.Risk pRisk)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pRisk);
            }
            else
                return null;
        }
        public Note[] ListNotesFor(Project pProject)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pProject);
            }
            else
                return null;
        }
        public Note[] ListNotesFor(Programme pProgramme)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pProgramme);
            }
            else
                return null;
        }
        public Note[] ListNotesFor(Entities.ServiceManagement.Incident pIncident)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pIncident);
            }
            else
                return null;
        }
        public Note[] ListNotesFor(Entities.ServiceManagement.Problem pProblem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pProblem);
            }
            else
                return null;
        }
        public Note[] ListNotesFor(Entities.ServiceManagement.Change pChange)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pChange);
            }
            else
                return null;
        }
        public Note[] ListNotesFor(Entities.Development.Defect pDefect)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pDefect);
            }
            else
                return null;
        }
        public Note[] ListNotesFor(Entities.Development.Iteration pIteration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pIteration);
            }
            else
                return null;
        }
        public Note[] ListNotesFor(Entities.Development.Requirement pRequirement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pRequirement);
            }
            else
                return null;
        }
        public Note[] ListNotesFor(Entities.Financial.AccountTransaction pTransaction)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFor(pTransaction);
            }
            else
                return null;
        }

        public Note InsertNote(Note pNote)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pNote);
            }
            else
                return null;
        }

        public Note UpdateNote(Note pNote)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pNote);
            }
            else
                return null;
        }

        public Note DeleteNote(Note pNote)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.NoteDOL DOL = new CORE.DOL.MSSQL.Planning.NoteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pNote);
            }
            else
                return null;
        }

        /**********************************************************************
         * Programme
         *********************************************************************/
        public Programme GetProgramme(int pProgrammeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProgrammeID);
            }
            else
                return null;
        }

        public Programme GetProgrammeByCode(string pProgrammeCode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByCode(pProgrammeCode);
            }
            else
                return null;
        }

        public Programme[] ListProgrammes(int pOwnerPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pOwnerPartyID);
            }
            else
                return null;
        }

        public Programme[] ListChildProgrammes(int pParentProgrammeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListChildren(pParentProgrammeID);
            }
            else
                return null;
        }

        public Programme InsertProgramme(Programme pProgramme, int? pParentProgrammeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProgramme, pParentProgrammeID);
            }
            else
                return null;
        }

        public Programme UpdateProgramme(Programme pProgramme, int? pParentProgrammeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProgramme, pParentProgrammeID);
            }
            else
                return null;
        }

        public Programme UpdateProgramme(Programme pProgramme)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProgramme);
            }
            else
                return null;
        }

        public Programme DeleteProgramme(Programme pProgramme)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProgramme);
            }
            else
                return null;
        }
        public BaseBoolean AssignContentToProgramme(Programme pProgramme, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pProgramme, pContent);
            }
            else
                return null;
        }
        public BaseBoolean RemoveContentFromProgramme(Programme pProgramme, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pProgramme, pContent);
            }
            else
                return null;
        }
        /**********************************************************************
         * ProgrammeStatus
         *********************************************************************/
        public ProgrammeStatus GetProgrammeStatus(int pProgrammeStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeStatusDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProgrammeStatusID, pLanguageID);
            }
            else
                return null;
        }

        public ProgrammeStatus GetProgrammeStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeStatusDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ProgrammeStatus[] ListProgrammeStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeStatusDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ProgrammeStatus InsertProgrammeStatus(ProgrammeStatus pProgrammeStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeStatusDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProgrammeStatus);
            }
            else
                return null;
        }

        public ProgrammeStatus UpdateProgrammeStatus(ProgrammeStatus pProgrammeStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeStatusDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProgrammeStatus);
            }
            else
                return null;
        }

        public ProgrammeStatus DeleteProgrammeStatus(ProgrammeStatus pProgrammeStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProgrammeStatusDOL DOL = new CORE.DOL.MSSQL.Planning.ProgrammeStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProgrammeStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Project
         *********************************************************************/
        public Project GetProject(int pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProjectID);
            }
            else
                return null;
        }

        public Project GetProjectByCode(string pProjectCode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByCode(pProjectCode);
            }
            else
                return null;
        }

        public Project[] ListProjects(int pProjectOwnerPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pProjectOwnerPartyID);
            }
            else
                return null;
        }

        public Project[] ListProjectsInProgramme(int? pProgrammeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForProgramme(pProgrammeID);
            }
            else
                return null;
        }

        public Project[] ListChildProjects(int pParentProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListChildren(pParentProjectID);
            }
            else
                return null;
        }

        public Project InsertProject(Project pProject, int? pProgrammeID, int? pParentProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProject, pProgrammeID, pParentProjectID);
            }
            else
                return null;
        }

        public Project UpdateProject(Project pProject, int? pProgrammeID, int? pParentProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProject, pProgrammeID, pParentProjectID);
            }
            else
                return null;
        }

        public Project UpdateProject(Project pProject)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProject);
            }
            else
                return null;
        }

        public Project DeleteProject(Project pProject)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProject);
            }
            else
                return null;
        }
        public BaseBoolean AssignContentToDeliverable(Deliverable pDeliverable, Project pProject, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pDeliverable,pProject, pContent);
            }
            else
                return null;
        }
        public BaseBoolean AssignContentToDeliverable(Deliverable pDeliverable, Task pTask, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pDeliverable, pTask, pContent);
            }
            else
                return null;
        }
        public BaseBoolean AssignContentToDeliverable(Deliverable pDeliverable, Programme pProgramme, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pDeliverable, pProgramme, pContent);
            }
            else
                return null;
        }
        public BaseBoolean RemoveContentFromDeliverable(Deliverable pDeliverable, Project pProject, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pDeliverable, pProject, pContent);
            }
            else
                return null;
        }
        public BaseBoolean RemoveContentFromDeliverable(Deliverable pDeliverable, Programme pProgramme, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pDeliverable, pProgramme, pContent);
            }
            else
                return null;
        }
        public BaseBoolean RemoveContentFromDeliverable(Deliverable pDeliverable, Task pTask, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.DeliverableDOL DOL = new CORE.DOL.MSSQL.Planning.DeliverableDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pDeliverable, pTask, pContent);
            }
            else
                return null;
        }
        /**********************************************************************
         * ProjectStatus
         *********************************************************************/
        public ProjectStatus GetProjectStatus(int pProjectStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectStatusDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProjectStatusID, pLanguageID);
            }
            else
                return null;
        }

        public ProjectStatus GetProjectStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectStatusDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ProjectStatus[] ListProjectStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectStatusDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ProjectStatus InsertProjectStatus(ProjectStatus pProjectStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectStatusDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProjectStatus);
            }
            else
                return null;
        }

        public ProjectStatus UpdateProjectStatus(ProjectStatus pProjectStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectStatusDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProjectStatus);
            }
            else
                return null;
        }

        public ProjectStatus DeleteProjectStatus(ProjectStatus pProjectStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.ProjectStatusDOL DOL = new CORE.DOL.MSSQL.Planning.ProjectStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProjectStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Recurrence
         *********************************************************************/
        public BaseRecurrence GetRecurrence(int pRecurrenceID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.RecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.RecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRecurrenceID, pLanguageID);
            }
            else
                return null;
        }

        public BaseRecurrence InsertRecurrence(BaseRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.RecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.RecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRecurrence);
            }
            else
                return null;
        }

        public BaseRecurrence UpdateRecurrence(BaseRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.RecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.RecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRecurrence);
            }
            else
                return null;
        }

        public BaseRecurrence DeleteRecurrence(BaseRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.RecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.RecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRecurrence);
            }
            else
                return null;
        }
        /**********************************************************************
         * Recurrence Type
         *********************************************************************/
        public RecurrenceType GetRecurrenceType(int pRecurrenceTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.RecurrenceTypeDOL DOL = new CORE.DOL.MSSQL.Planning.RecurrenceTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRecurrenceTypeID, pLanguageID);
            }
            else
                return null;
        }

        public RecurrenceType GetRecurrenceTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.RecurrenceTypeDOL DOL = new CORE.DOL.MSSQL.Planning.RecurrenceTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public RecurrenceType[] ListRecurrenceTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.RecurrenceTypeDOL DOL = new CORE.DOL.MSSQL.Planning.RecurrenceTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public RecurrenceType InsertRecurrenceType(RecurrenceType pRecurrenceType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.RecurrenceTypeDOL DOL = new CORE.DOL.MSSQL.Planning.RecurrenceTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRecurrenceType);
            }
            else
                return null;
        }

        public RecurrenceType UpdateRecurrenceType(RecurrenceType pRecurrenceType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.RecurrenceTypeDOL DOL = new CORE.DOL.MSSQL.Planning.RecurrenceTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRecurrenceType);
            }
            else
                return null;
        }

        public RecurrenceType DeleteRecurrenceType(RecurrenceType pRecurrenceType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.RecurrenceTypeDOL DOL = new CORE.DOL.MSSQL.Planning.RecurrenceTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRecurrenceType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Task
         *********************************************************************/
        public Task GetTask(int pTaskID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TaskDOL DOL = new CORE.DOL.MSSQL.Planning.TaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTaskID);
            }
            else
                return null;
        }

        public Task[] ListTasks(int pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TaskDOL DOL = new CORE.DOL.MSSQL.Planning.TaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pProjectID);
            }
            else
                return null;
        }

        public Task[] ListChildTasks(int pParentTaskID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TaskDOL DOL = new CORE.DOL.MSSQL.Planning.TaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pParentTaskID);
            }
            else
                return null;
        }

        public Task InsertTask(Task pTask, int pProjectID, int? pParentTaskID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TaskDOL DOL = new CORE.DOL.MSSQL.Planning.TaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTask, pProjectID, pParentTaskID);
            }
            else
                return null;
        }

        public Task UpdateTask(Task pTask, int pProjectID, int? pParentTaskID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TaskDOL DOL = new CORE.DOL.MSSQL.Planning.TaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTask, pProjectID, pParentTaskID);
            }
            else
                return null;
        }

        public Task DeleteTask(Task pTask)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TaskDOL DOL = new CORE.DOL.MSSQL.Planning.TaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTask);
            }
            else
                return null;
        }

        public Entities.BaseBoolean AssignResourceToTask(Task pTask, Entities.Core.Party pResource)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TaskDOL DOL = new CORE.DOL.MSSQL.Planning.TaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignResource(pTask,pResource);
            }
            else
                return null;
        }
        public Entities.BaseBoolean RemoveResourceFromTask(Task pTask, Entities.Core.Party pResource)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TaskDOL DOL = new CORE.DOL.MSSQL.Planning.TaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignResource(pTask, pResource);
            }
            else
                return null;
        }
        /**********************************************************************
         * Template
         *********************************************************************/
        public Template GetTemplate(int pTemplateID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TemplateDOL DOL = new CORE.DOL.MSSQL.Planning.TemplateDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTemplateID);
            }
            else
                return null;
        }

        public Template[] ListTemplates()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TemplateDOL DOL = new CORE.DOL.MSSQL.Planning.TemplateDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public Template InsertTemplate(Template pTemplate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TemplateDOL DOL = new CORE.DOL.MSSQL.Planning.TemplateDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTemplate);
            }
            else
                return null;
        }

        public Template UpdateTemplate(Template pTemplate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TemplateDOL DOL = new CORE.DOL.MSSQL.Planning.TemplateDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTemplate);
            }
            else
                return null;
        }

        public Template DeleteTemplate(Template pTemplate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TemplateDOL DOL = new CORE.DOL.MSSQL.Planning.TemplateDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTemplate);
            }
            else
                return null;
        }
        /**********************************************************************
         * Template Task
         *********************************************************************/
        public TemplateTask GetTemplateTask(int pTemplateTaskID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TemplateTaskDOL DOL = new CORE.DOL.MSSQL.Planning.TemplateTaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTemplateTaskID);
            }
            else
                return null;
        }

        public TemplateTask[] ListTemplateTasks(int pTemplateID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TemplateTaskDOL DOL = new CORE.DOL.MSSQL.Planning.TemplateTaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pTemplateID);
            }
            else
                return null;
        }

        public TemplateTask[] ListChildTemplateTasks(int pParentTemplateTaskID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TemplateTaskDOL DOL = new CORE.DOL.MSSQL.Planning.TemplateTaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListChildren(pParentTemplateTaskID);
            }
            else
                return null;
        }

        public TemplateTask InsertTemplateTask(TemplateTask pTemplateTask, int pTemplateID, int? pParentTemplateTaskID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TemplateTaskDOL DOL = new CORE.DOL.MSSQL.Planning.TemplateTaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTemplateTask, pTemplateID, pParentTemplateTaskID);
            }
            else
                return null;
        }

        public TemplateTask UpdateTemplateTask(TemplateTask pTemplateTask, int pTemplateID, int? pParentTemplateTaskID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TemplateTaskDOL DOL = new CORE.DOL.MSSQL.Planning.TemplateTaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTemplateTask, pTemplateID, pParentTemplateTaskID);
            }
            else
                return null;
        }

        public TemplateTask DeleteTemplateTask(TemplateTask pTemplateTask)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.TemplateTaskDOL DOL = new CORE.DOL.MSSQL.Planning.TemplateTaskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTemplateTask);
            }
            else
                return null;
        }
        /**********************************************************************
         * Weekly Recurrence
         *********************************************************************/
        public WeeklyRecurrence GetWeeklyRecurrence(int pRecurrenceID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.WeeklyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.WeeklyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRecurrenceID, pLanguageID);
            }
            else
                return null;
        }

        public WeeklyRecurrence InsertWeeklyRecurrence(WeeklyRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.WeeklyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.WeeklyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRecurrence);
            }
            else
                return null;
        }

        public WeeklyRecurrence UpdateWeeklyRecurrence(WeeklyRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.WeeklyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.WeeklyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRecurrence);
            }
            else
                return null;
        }

        public WeeklyRecurrence DeleteWeeklyRecurrence(WeeklyRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.WeeklyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.WeeklyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRecurrence);
            }
            else
                return null;
        }
        /**********************************************************************
         * Yearly Recurrence
         *********************************************************************/
        public YearlyRecurrence GetYearlyRecurrence(int pRecurrenceID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.YearlyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.YearlyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRecurrenceID, pLanguageID);
            }
            else
                return null;
        }

        public YearlyRecurrence InsertYearlyRecurrence(YearlyRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.YearlyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.YearlyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRecurrence);
            }
            else
                return null;
        }

        public YearlyRecurrence UpdateYearlyRecurrence(YearlyRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.YearlyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.YearlyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRecurrence);
            }
            else
                return null;
        }

        public YearlyRecurrence DeleteYearlyRecurrence(YearlyRecurrence pRecurrence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning.YearlyRecurrenceDOL DOL = new CORE.DOL.MSSQL.Planning.YearlyRecurrenceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRecurrence);
            }
            else
                return null;
        }
    }
}
