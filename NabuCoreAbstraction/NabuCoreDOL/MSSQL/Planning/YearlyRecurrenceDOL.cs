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
    public class YearlyRecurrenceDOL : BaseDOL
    {
        public YearlyRecurrenceDOL() : base ()
        {
        }

        public YearlyRecurrenceDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public YearlyRecurrence Get(int pYearlyRecurrenceID, int pLanguageID)
        {
            YearlyRecurrence yearlyRecurrence = new YearlyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[YearlyRecurrence_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@YearlyRecurrenceID", pYearlyRecurrenceID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        yearlyRecurrence = new YearlyRecurrence(sqlDataReader.GetInt32(0));
                        yearlyRecurrence.EveryXYears = sqlDataReader.GetInt32(1);
                        yearlyRecurrence.UseSpecificDay = sqlDataReader.GetBoolean(2);
                        yearlyRecurrence.DayOfMonth = sqlDataReader.GetInt32(3);
                        yearlyRecurrence.Month = sqlDataReader.GetInt32(4);
                        yearlyRecurrence.Frequency = sqlDataReader.GetString(5);
                        yearlyRecurrence.DayType = sqlDataReader.GetString(6);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    yearlyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    yearlyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return yearlyRecurrence;
        }

        public YearlyRecurrence Insert(YearlyRecurrence pYearlyRecurrence)
        {
            YearlyRecurrence yearlyRecurrence = new YearlyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[YearlyRecurrence_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@YearlyRecurrenceID", pYearlyRecurrence.RecurrenceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@EveryXYears", pYearlyRecurrence.EveryXYears));
                    sqlCommand.Parameters.Add(new SqlParameter("@UseSpecificDay", pYearlyRecurrence.UseSpecificDay));
                    sqlCommand.Parameters.Add(new SqlParameter("@DayOfMonth", pYearlyRecurrence.DayOfMonth));
                    sqlCommand.Parameters.Add(new SqlParameter("@Month", pYearlyRecurrence.Month));
                    sqlCommand.Parameters.Add(new SqlParameter("@Frequency", pYearlyRecurrence.Frequency));
                    sqlCommand.Parameters.Add(new SqlParameter("@DayType", pYearlyRecurrence.DayType));

                    sqlCommand.ExecuteNonQuery();

                    yearlyRecurrence = new YearlyRecurrence(pYearlyRecurrence.RecurrenceID);
                    yearlyRecurrence.EveryXYears = pYearlyRecurrence.EveryXYears;
                    yearlyRecurrence.UseSpecificDay = pYearlyRecurrence.UseSpecificDay;
                    yearlyRecurrence.DayOfMonth = pYearlyRecurrence.DayOfMonth;
                    yearlyRecurrence.Month = pYearlyRecurrence.Month;
                    yearlyRecurrence.Frequency = pYearlyRecurrence.Frequency;
                    yearlyRecurrence.DayType = pYearlyRecurrence.DayType;
                }
                catch (Exception exc)
                {
                    yearlyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    yearlyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return yearlyRecurrence;
        }

        public YearlyRecurrence Update(YearlyRecurrence pYearlyRecurrence)
        {
            YearlyRecurrence yearlyRecurrence = new YearlyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[YearlyRecurrence_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@YearlyRecurrenceID", pYearlyRecurrence.RecurrenceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@EveryXYears", pYearlyRecurrence.EveryXYears));
                    sqlCommand.Parameters.Add(new SqlParameter("@UseSpecificDay", pYearlyRecurrence.UseSpecificDay));
                    sqlCommand.Parameters.Add(new SqlParameter("@DayOfMonth", pYearlyRecurrence.DayOfMonth));
                    sqlCommand.Parameters.Add(new SqlParameter("@Month", pYearlyRecurrence.Month));
                    sqlCommand.Parameters.Add(new SqlParameter("@Frequency", pYearlyRecurrence.Frequency));
                    sqlCommand.Parameters.Add(new SqlParameter("@DayType", pYearlyRecurrence.DayType));

                    sqlCommand.ExecuteNonQuery();

                    yearlyRecurrence = new YearlyRecurrence(pYearlyRecurrence.RecurrenceID);
                    yearlyRecurrence.EveryXYears = pYearlyRecurrence.EveryXYears;
                    yearlyRecurrence.UseSpecificDay = pYearlyRecurrence.UseSpecificDay;
                    yearlyRecurrence.DayOfMonth = pYearlyRecurrence.DayOfMonth;
                    yearlyRecurrence.Month = pYearlyRecurrence.Month;
                    yearlyRecurrence.Frequency = pYearlyRecurrence.Frequency;
                    yearlyRecurrence.DayType = pYearlyRecurrence.DayType;
                }
                catch (Exception exc)
                {
                    yearlyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    yearlyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return yearlyRecurrence;
        }

        public YearlyRecurrence Delete(YearlyRecurrence pYearlyRecurrence)
        {
            YearlyRecurrence yearlyRecurrence = new YearlyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[YearlyRecurrence_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@YearlyRecurrenceID", pYearlyRecurrence.RecurrenceID));

                    sqlCommand.ExecuteNonQuery();

                    yearlyRecurrence = new YearlyRecurrence(pYearlyRecurrence.RecurrenceID);
                }
                catch (Exception exc)
                {
                    yearlyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    yearlyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return yearlyRecurrence;
        }
    }
}
