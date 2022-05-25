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
    public class WeeklyRecurrenceDOL : BaseDOL
    {
        public WeeklyRecurrenceDOL() : base ()
        {
        }

        public WeeklyRecurrenceDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public WeeklyRecurrence Get(int pWeeklyRecurrenceID, int pLanguageID)
        {
            WeeklyRecurrence weeklyRecurrence = new WeeklyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[WeeklyRecurrence_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@WeeklyRecurrenceID", pWeeklyRecurrenceID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        weeklyRecurrence = new WeeklyRecurrence(sqlDataReader.GetInt32(0));
                        weeklyRecurrence.EveryXWeeks = sqlDataReader.GetInt32(1);
                        weeklyRecurrence.OnMondays = sqlDataReader.GetBoolean(2);
                        weeklyRecurrence.OnTuesdays = sqlDataReader.GetBoolean(3);
                        weeklyRecurrence.OnWednesdays = sqlDataReader.GetBoolean(4);
                        weeklyRecurrence.OnThursdays = sqlDataReader.GetBoolean(5);
                        weeklyRecurrence.OnFridays = sqlDataReader.GetBoolean(6);
                        weeklyRecurrence.OnSaturdays = sqlDataReader.GetBoolean(7);
                        weeklyRecurrence.OnSundays = sqlDataReader.GetBoolean(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    weeklyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    weeklyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return weeklyRecurrence;
        }

        public WeeklyRecurrence Insert(WeeklyRecurrence pWeeklyRecurrence)
        {
            WeeklyRecurrence weeklyRecurrence = new WeeklyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[WeeklyRecurrence_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@WeeklyRecurrenceID", pWeeklyRecurrence.RecurrenceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@EveryXWeeks", pWeeklyRecurrence.EveryXWeeks));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnMondays", pWeeklyRecurrence.OnMondays));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnTuesdays", pWeeklyRecurrence.OnTuesdays));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnWednesdays", pWeeklyRecurrence.OnWednesdays));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnThursdays", pWeeklyRecurrence.OnThursdays));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnFridays", pWeeklyRecurrence.OnFridays));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnSaturdays", pWeeklyRecurrence.OnSaturdays));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnSundays", pWeeklyRecurrence.OnSundays));

                    sqlCommand.ExecuteNonQuery();

                    weeklyRecurrence = new WeeklyRecurrence(pWeeklyRecurrence.RecurrenceID);
                    weeklyRecurrence.EveryXWeeks = pWeeklyRecurrence.EveryXWeeks;
                    weeklyRecurrence.OnMondays = pWeeklyRecurrence.OnMondays;
                    weeklyRecurrence.OnTuesdays = pWeeklyRecurrence.OnTuesdays;
                    weeklyRecurrence.OnWednesdays = pWeeklyRecurrence.OnWednesdays;
                    weeklyRecurrence.OnThursdays = pWeeklyRecurrence.OnThursdays;
                    weeklyRecurrence.OnFridays = pWeeklyRecurrence.OnFridays;
                    weeklyRecurrence.OnSaturdays = pWeeklyRecurrence.OnSaturdays;
                    weeklyRecurrence.OnSundays = pWeeklyRecurrence.OnSundays;
                }
                catch (Exception exc)
                {
                    weeklyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    weeklyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return weeklyRecurrence;
        }

        public WeeklyRecurrence Update(WeeklyRecurrence pWeeklyRecurrence)
        {
            WeeklyRecurrence weeklyRecurrence = new WeeklyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[WeeklyRecurrence_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@WeeklyRecurrenceID", pWeeklyRecurrence.RecurrenceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@EveryXWeeks", pWeeklyRecurrence.EveryXWeeks));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnMondays", pWeeklyRecurrence.OnMondays));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnTuesdays", pWeeklyRecurrence.OnTuesdays));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnWednesdays", pWeeklyRecurrence.OnWednesdays));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnThursdays", pWeeklyRecurrence.OnThursdays));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnFridays", pWeeklyRecurrence.OnFridays));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnSaturdays", pWeeklyRecurrence.OnSaturdays));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnSundays", pWeeklyRecurrence.OnSundays));

                    sqlCommand.ExecuteNonQuery();

                    weeklyRecurrence = new WeeklyRecurrence(pWeeklyRecurrence.RecurrenceID);
                    weeklyRecurrence.EveryXWeeks = pWeeklyRecurrence.EveryXWeeks;
                    weeklyRecurrence.OnMondays = pWeeklyRecurrence.OnMondays;
                    weeklyRecurrence.OnTuesdays = pWeeklyRecurrence.OnTuesdays;
                    weeklyRecurrence.OnWednesdays = pWeeklyRecurrence.OnWednesdays;
                    weeklyRecurrence.OnThursdays = pWeeklyRecurrence.OnThursdays;
                    weeklyRecurrence.OnFridays = pWeeklyRecurrence.OnFridays;
                    weeklyRecurrence.OnSaturdays = pWeeklyRecurrence.OnSaturdays;
                    weeklyRecurrence.OnSundays = pWeeklyRecurrence.OnSundays;
                }
                catch (Exception exc)
                {
                    weeklyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    weeklyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return weeklyRecurrence;
        }

        public WeeklyRecurrence Delete(WeeklyRecurrence pWeeklyRecurrence)
        {
            WeeklyRecurrence weeklyRecurrence = new WeeklyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[WeeklyRecurrence_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@WeeklyRecurrenceID", pWeeklyRecurrence.RecurrenceID));

                    sqlCommand.ExecuteNonQuery();

                    weeklyRecurrence = new WeeklyRecurrence(pWeeklyRecurrence.RecurrenceID);
                }
                catch (Exception exc)
                {
                    weeklyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    weeklyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return weeklyRecurrence;
        }
    }
}
