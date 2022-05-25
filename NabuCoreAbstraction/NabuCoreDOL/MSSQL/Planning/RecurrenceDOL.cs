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
    public class RecurrenceDOL : BaseDOL
    {
        public RecurrenceDOL() : base ()
        {
        }

        public RecurrenceDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public BaseRecurrence Get(int pRecurrenceID, int pLanguageID)
        {
            BaseRecurrence recurrence = new BaseRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Recurrence_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BaseRecurrenceID", pRecurrenceID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        recurrence = new BaseRecurrence(sqlDataReader.GetInt32(0));
                        recurrence.RecurrenceType = new RecurrenceType(sqlDataReader.GetInt32(1));
                        recurrence.RecurrenceType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(2));
                        recurrence.RecurrenceType.Detail.Alias = sqlDataReader.GetString(3);
                        recurrence.ScheduledHour = sqlDataReader.GetInt32(4);
                        recurrence.ScheduledMinute = sqlDataReader.GetInt32(5);
                        recurrence.ScheduledSecond = sqlDataReader.GetInt32(6);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    recurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    recurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return recurrence;
        }

        public BaseRecurrence Insert(BaseRecurrence pRecurrence)
        {
            BaseRecurrence recurrence = new BaseRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Recurrence_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RecurrenceTypeID", pRecurrence.RecurrenceType.RecurrenceTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScheduledHour", pRecurrence.ScheduledHour));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScheduledMinute", pRecurrence.ScheduledMinute));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScheduledSecond", pRecurrence.ScheduledSecond));
                    SqlParameter recurrenceID = sqlCommand.Parameters.Add("@RecurrenceID", SqlDbType.Int);
                    recurrenceID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    recurrence = new BaseRecurrence((Int32)recurrenceID.Value);
                    recurrence.RecurrenceType = new RecurrenceType(pRecurrence.RecurrenceType.RecurrenceTypeID);
                    recurrence.ScheduledHour = pRecurrence.ScheduledHour;
                    recurrence.ScheduledMinute = pRecurrence.ScheduledMinute;
                    recurrence.ScheduledSecond = pRecurrence.ScheduledSecond;
                }
                catch (Exception exc)
                {
                    recurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    recurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return recurrence;
        }

        public BaseRecurrence Update(BaseRecurrence pRecurrence)
        {
            BaseRecurrence recurrence = new BaseRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Recurrence_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RecurrenceID", pRecurrence.RecurrenceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RecurrenceTypeID", pRecurrence.RecurrenceType.RecurrenceTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScheduledHour", pRecurrence.ScheduledHour));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScheduledMinute", pRecurrence.ScheduledMinute));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScheduledSecond", pRecurrence.ScheduledSecond));

                    sqlCommand.ExecuteNonQuery();

                    recurrence = new BaseRecurrence(pRecurrence.RecurrenceID);
                    recurrence.RecurrenceType = new RecurrenceType(pRecurrence.RecurrenceType.RecurrenceTypeID);
                    recurrence.ScheduledHour = pRecurrence.ScheduledHour;
                    recurrence.ScheduledMinute = pRecurrence.ScheduledMinute;
                    recurrence.ScheduledSecond = pRecurrence.ScheduledSecond;
                }
                catch (Exception exc)
                {
                    recurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    recurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return recurrence;
        }

        public BaseRecurrence Delete(BaseRecurrence pRecurrence)
        {
            BaseRecurrence recurrence = new BaseRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Recurrence_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RecurrenceID", pRecurrence.RecurrenceID));

                    sqlCommand.ExecuteNonQuery();

                    recurrence = new BaseRecurrence(pRecurrence.RecurrenceID);
                }
                catch (Exception exc)
                {
                    recurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    recurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return recurrence;
        }
    }
}
