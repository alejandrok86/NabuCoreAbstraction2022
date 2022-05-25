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
    public class MonthlyRecurrenceDOL : BaseDOL
    {
        public MonthlyRecurrenceDOL() : base ()
        {
        }

        public MonthlyRecurrenceDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public MonthlyRecurrence Get(int pMonthlyRecurrenceID, int pLanguageID)
        {
            MonthlyRecurrence monthlyRecurrence = new MonthlyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[MonthlyRecurrence_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@MonthlyRecurrenceID", pMonthlyRecurrenceID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        monthlyRecurrence = new MonthlyRecurrence(sqlDataReader.GetInt32(0));
                        monthlyRecurrence.UseSpecificDay = sqlDataReader.GetBoolean(1);
                        monthlyRecurrence.DayOfMonth = sqlDataReader.GetInt32(2);
                        monthlyRecurrence.EveryXMonths = sqlDataReader.GetInt32(3);
                        monthlyRecurrence.Frequency = sqlDataReader.GetString(4);
                        monthlyRecurrence.DayType = sqlDataReader.GetString(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    monthlyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    monthlyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return monthlyRecurrence;
        }

        public MonthlyRecurrence Insert(MonthlyRecurrence pMonthlyRecurrence)
        {
            MonthlyRecurrence monthlyRecurrence = new MonthlyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[MonthlyRecurrence_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@MonthlyRecurrenceID", pMonthlyRecurrence.RecurrenceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UseSpecificDay", pMonthlyRecurrence.UseSpecificDay));
                    sqlCommand.Parameters.Add(new SqlParameter("@DayOfMonth", pMonthlyRecurrence.DayOfMonth));
                    sqlCommand.Parameters.Add(new SqlParameter("@EveryXMonths", pMonthlyRecurrence.EveryXMonths));
                    sqlCommand.Parameters.Add(new SqlParameter("@Frequency", pMonthlyRecurrence.Frequency));
                    sqlCommand.Parameters.Add(new SqlParameter("@DayType", pMonthlyRecurrence.DayType));

                    sqlCommand.ExecuteNonQuery();

                    monthlyRecurrence = new MonthlyRecurrence(pMonthlyRecurrence.RecurrenceID);
                    monthlyRecurrence.UseSpecificDay = pMonthlyRecurrence.UseSpecificDay;
                    monthlyRecurrence.DayOfMonth = pMonthlyRecurrence.DayOfMonth;
                    monthlyRecurrence.EveryXMonths = pMonthlyRecurrence.EveryXMonths;
                    monthlyRecurrence.Frequency = pMonthlyRecurrence.Frequency;
                    monthlyRecurrence.DayType = pMonthlyRecurrence.DayType;
                }
                catch (Exception exc)
                {
                    monthlyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    monthlyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return monthlyRecurrence;
        }

        public MonthlyRecurrence Update(MonthlyRecurrence pMonthlyRecurrence)
        {
            MonthlyRecurrence monthlyRecurrence = new MonthlyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[MonthlyRecurrence_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@MonthlyRecurrenceID", pMonthlyRecurrence.RecurrenceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UseSpecificDay", pMonthlyRecurrence.UseSpecificDay));
                    sqlCommand.Parameters.Add(new SqlParameter("@DayOfMonth", pMonthlyRecurrence.DayOfMonth));
                    sqlCommand.Parameters.Add(new SqlParameter("@EveryXMonths", pMonthlyRecurrence.EveryXMonths));
                    sqlCommand.Parameters.Add(new SqlParameter("@Frequency", pMonthlyRecurrence.Frequency));
                    sqlCommand.Parameters.Add(new SqlParameter("@DayType", pMonthlyRecurrence.DayType));

                    sqlCommand.ExecuteNonQuery();

                    monthlyRecurrence = new MonthlyRecurrence(pMonthlyRecurrence.RecurrenceID);
                    monthlyRecurrence.UseSpecificDay = pMonthlyRecurrence.UseSpecificDay;
                    monthlyRecurrence.DayOfMonth = pMonthlyRecurrence.DayOfMonth;
                    monthlyRecurrence.EveryXMonths = pMonthlyRecurrence.EveryXMonths;
                    monthlyRecurrence.Frequency = pMonthlyRecurrence.Frequency;
                    monthlyRecurrence.DayType = pMonthlyRecurrence.DayType;
                }
                catch (Exception exc)
                {
                    monthlyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    monthlyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return monthlyRecurrence;
        }

        public MonthlyRecurrence Delete(MonthlyRecurrence pMonthlyRecurrence)
        {
            MonthlyRecurrence monthlyRecurrence = new MonthlyRecurrence();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[MonthlyRecurrence_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@MonthlyRecurrenceID", pMonthlyRecurrence.RecurrenceID));

                    sqlCommand.ExecuteNonQuery();

                    monthlyRecurrence = new MonthlyRecurrence(pMonthlyRecurrence.RecurrenceID);
                }
                catch (Exception exc)
                {
                    monthlyRecurrence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    monthlyRecurrence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return monthlyRecurrence;
        }
    }
}
