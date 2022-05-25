using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning
{
    public class AppointmentDOL : BaseDOL
    {
        public AppointmentDOL() : base ()
        {
        }

        public AppointmentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Appointment Get(int pAppointmentID, int pLanguageID)
        {
            Appointment appointment = new Appointment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Appointment_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AppointmentID", pAppointmentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        appointment = new Appointment(sqlDataReader.GetInt32(0));
                        appointment.AppointmentType = new AppointmentType(sqlDataReader.GetInt32(1));
                        appointment.AppointmentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2),pLanguageID);
                        if(sqlDataReader.IsDBNull(4)==false)
                            appointment.AppointmentDuration = new Duration(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            appointment.Recurrence = new BaseRecurrence(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            appointment.Subject = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            appointment.Location = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            appointment.NextAppointment = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            appointment.PreviousAppointment = sqlDataReader.GetDateTime(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    appointment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    appointment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return appointment;
        }

        public Appointment[] List(int pPartyID, DateTime pFrom, DateTime pTo, int pLanguageID)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Appointment_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@From", pFrom));
                    sqlCommand.Parameters.Add(new SqlParameter("@To", pTo));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Appointment appointment = new Appointment(sqlDataReader.GetInt32(0));
                        appointment.AppointmentType = new AppointmentType(sqlDataReader.GetInt32(1));
                        appointment.AppointmentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        if (sqlDataReader.IsDBNull(4) == false)
                            appointment.AppointmentDuration = new Duration(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            appointment.Recurrence = new BaseRecurrence(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            appointment.Subject = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            appointment.Location = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            appointment.NextAppointment = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            appointment.PreviousAppointment = sqlDataReader.GetDateTime(9);
                        appointments.Add(appointment);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Appointment appointment = new Appointment();
                    appointment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    appointment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    appointments.Add(appointment);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return appointments.ToArray();
        }

        public MeetingParticipant[] ListOtherParticipants(int pAppointmentID,int pPartyID)
        {
            List<MeetingParticipant> meetingParticipants = new List<MeetingParticipant>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Appointment_ListOtherParticipants]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AppointmentID", pAppointmentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        MeetingParticipant meetingParticipant = new MeetingParticipant(sqlDataReader.GetInt32(0));
                        meetingParticipant.HasAccepted = sqlDataReader.GetBoolean(1);
                        meetingParticipants.Add(meetingParticipant);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    MeetingParticipant meetingParticipant = new MeetingParticipant();
                    meetingParticipant.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    meetingParticipant.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    meetingParticipants.Add(meetingParticipant);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return meetingParticipants.ToArray();
        }

        public Appointment Insert(Appointment pAppointment)
        {
            Appointment appointment = new Appointment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Appointment_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AppointmentTypeID", pAppointment.AppointmentType.AppointmentTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationID", ((pAppointment.AppointmentDuration != null) ? pAppointment.AppointmentDuration.DurationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@RecurrenceID", ((pAppointment.Recurrence != null) ? pAppointment.Recurrence.RecurrenceID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Subject", pAppointment.Subject));
                    sqlCommand.Parameters.Add(new SqlParameter("@Location", pAppointment.Location));
                    sqlCommand.Parameters.Add(new SqlParameter("@NextAppointment", ((pAppointment.NextAppointment.HasValue == true) ? pAppointment.NextAppointment : null)));
                    SqlParameter appointmentID = sqlCommand.Parameters.Add("@AppointmentID", SqlDbType.Int);
                    appointmentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    appointment = new Appointment((Int32)appointmentID.Value);
                    if (pAppointment.AppointmentDuration != null)
                        appointment.AppointmentDuration = new Duration(pAppointment.AppointmentDuration.DurationID);
                    appointment.AppointmentType = new AppointmentType(pAppointment.AppointmentType.AppointmentTypeID);
                    appointment.Location = pAppointment.Location;
                    appointment.NextAppointment = pAppointment.NextAppointment;
                    if (appointment.Recurrence != null)
                        appointment.Recurrence = new BaseRecurrence(pAppointment.Recurrence.RecurrenceID);
                    appointment.Subject = pAppointment.Subject;
                }
                catch (Exception exc)
                {
                    appointment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    appointment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return appointment;
        }

        public Appointment Update(Appointment pAppointment)
        {
            Appointment appointment = new Appointment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Appointment_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AppointmentID", pAppointment.AppointmentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AppointmentTypeID", pAppointment.AppointmentType.AppointmentTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationID", ((pAppointment.AppointmentDuration != null) ? pAppointment.AppointmentDuration.DurationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@RecurrenceID", ((pAppointment.Recurrence != null) ? pAppointment.Recurrence.RecurrenceID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Subject", pAppointment.Subject));
                    sqlCommand.Parameters.Add(new SqlParameter("@Location", pAppointment.Location));
                    sqlCommand.Parameters.Add(new SqlParameter("@NextAppointment", ((pAppointment.NextAppointment.HasValue == true) ? pAppointment.NextAppointment : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PreviousAppointment", ((pAppointment.PreviousAppointment.HasValue == true) ? pAppointment.PreviousAppointment : null)));

                    sqlCommand.ExecuteNonQuery();

                    appointment = new Appointment((int)pAppointment.AppointmentID);
                    if (pAppointment.AppointmentDuration != null)
                        appointment.AppointmentDuration = new Duration(pAppointment.AppointmentDuration.DurationID);
                    appointment.AppointmentType = new AppointmentType(pAppointment.AppointmentType.AppointmentTypeID);
                    appointment.Location = pAppointment.Location;
                    appointment.NextAppointment = pAppointment.NextAppointment;
                    if (pAppointment.PreviousAppointment != null)
                        appointment.PreviousAppointment = pAppointment.PreviousAppointment;
                    if (pAppointment.Recurrence != null)
                        appointment.Recurrence = new BaseRecurrence(pAppointment.Recurrence.RecurrenceID);
                    appointment.Subject = pAppointment.Subject;
                }
                catch (Exception exc)
                {
                    appointment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    appointment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return appointment;
        }

        public Appointment Delete(Appointment pAppointment)
        {
            Appointment appointment = new Appointment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Appointment_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AppointmentID", pAppointment.AppointmentID));

                    sqlCommand.ExecuteNonQuery();

                    appointment = new Appointment(pAppointment.AppointmentID);
                }
                catch (Exception exc)
                {
                    appointment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    appointment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return appointment;
        }

        public BaseBoolean DeleteAllParticipants(int pAppointmentID)
        {
            BaseBoolean result = new BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Participants_DeleteAppointment]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AppointmentID", pAppointmentID));

                    sqlCommand.ExecuteNonQuery();

                    result = new BaseBoolean();
                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean RemoveParticipant(int pAppointmentID, int pPartyID)
        {
            BaseBoolean result = new BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Participants_DeleteParticipant]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AppointmentID", pAppointmentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    sqlCommand.ExecuteNonQuery();

                    result = new BaseBoolean();
                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public MeetingParticipant AddParticipant(int pAppointmentID,MeetingParticipant pMeetingParticipant)
        {
            MeetingParticipant meetingParticipant = new MeetingParticipant();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Participants_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AppointmentID", pAppointmentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pMeetingParticipant.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Accepted", pMeetingParticipant.HasAccepted));

                    sqlCommand.ExecuteNonQuery();

                    meetingParticipant = new MeetingParticipant(pMeetingParticipant.PartyID);
                    meetingParticipant.HasAccepted = pMeetingParticipant.HasAccepted;
                }
                catch (Exception exc)
                {
                    meetingParticipant.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    meetingParticipant.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return meetingParticipant;
        }

        public MeetingParticipant UpdateParticipant(int pAppointmentID, MeetingParticipant pMeetingParticipant)
        {
            MeetingParticipant meetingParticipant = new MeetingParticipant();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Participants_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AppointmentID", pAppointmentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pMeetingParticipant.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Accepted", pMeetingParticipant.HasAccepted));

                    sqlCommand.ExecuteNonQuery();

                    meetingParticipant = new MeetingParticipant((int)pMeetingParticipant.PartyID);
                    meetingParticipant.HasAccepted = pMeetingParticipant.HasAccepted;
                }
                catch (Exception exc)
                {
                    meetingParticipant.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    meetingParticipant.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return meetingParticipant;
        }
    }
}
