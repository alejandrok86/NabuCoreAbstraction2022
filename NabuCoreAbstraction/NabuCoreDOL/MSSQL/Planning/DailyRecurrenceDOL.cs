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
    public class DailyRecurrenceDOL : BaseDOL
    {
        public DailyRecurrenceDOL() : base ()
        {
        }

        public DailyRecurrenceDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public DailyRecurrence Get(int pDailyRecurrenceID, int pLanguageID)
        {
            DailyRecurrence dailyRecurrence = new DailyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[DailyRecurrence_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DailyRecurrenceID", pDailyRecurrenceID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        dailyRecurrence = new DailyRecurrence(sqlDataReader.GetInt32(0));
                        dailyRecurrence.OnlyWeekdays = sqlDataReader.GetBoolean(1);
                        dailyRecurrence.EveryXDays = sqlDataReader.GetInt32(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    dailyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    dailyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return dailyRecurrence;
        }

        public DailyRecurrence Insert(DailyRecurrence pDailyRecurrence)
        {
            DailyRecurrence dailyRecurrence = new DailyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[DailyRecurrence_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DailyRecurrenceID", pDailyRecurrence.RecurrenceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnlyWeekdays", pDailyRecurrence.OnlyWeekdays));
                    sqlCommand.Parameters.Add(new SqlParameter("@EveryXDays", pDailyRecurrence.EveryXDays));

                    sqlCommand.ExecuteNonQuery();

                    dailyRecurrence = new DailyRecurrence(pDailyRecurrence.RecurrenceID);
                    dailyRecurrence.OnlyWeekdays = pDailyRecurrence.OnlyWeekdays;
                    dailyRecurrence.EveryXDays = pDailyRecurrence.EveryXDays;
                }
                catch (Exception exc)
                {
                    dailyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    dailyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return dailyRecurrence;
        }

        public DailyRecurrence Update(DailyRecurrence pDailyRecurrence)
        {
            DailyRecurrence dailyRecurrence = new DailyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[DailyRecurrence_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DailyRecurrenceID", pDailyRecurrence.RecurrenceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OnlyWeekdays", pDailyRecurrence.OnlyWeekdays));
                    sqlCommand.Parameters.Add(new SqlParameter("@EveryXDays", pDailyRecurrence.EveryXDays));

                    sqlCommand.ExecuteNonQuery();

                    dailyRecurrence = new DailyRecurrence(pDailyRecurrence.RecurrenceID);
                    dailyRecurrence.OnlyWeekdays = pDailyRecurrence.OnlyWeekdays;
                    dailyRecurrence.EveryXDays = pDailyRecurrence.EveryXDays;
                }
                catch (Exception exc)
                {
                    dailyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    dailyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return dailyRecurrence;
        }

        public DailyRecurrence Delete(DailyRecurrence pDailyRecurrence)
        {
            DailyRecurrence dailyRecurrence = new DailyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[DailyRecurrence_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DailyRecurrenceID", pDailyRecurrence.RecurrenceID));

                    sqlCommand.ExecuteNonQuery();

                    dailyRecurrence = new DailyRecurrence(pDailyRecurrence.RecurrenceID);
                }
                catch (Exception exc)
                {
                    dailyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    dailyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return dailyRecurrence;
        }
    }
}
