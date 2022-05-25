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
    public class DurationDOL : BaseDOL
    {
        public DurationDOL() : base ()
        {
        }

        public DurationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Duration Get(int pDurationID)
        {
            Duration duration = new Duration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Duration_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationID", pDurationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        duration = new Duration(sqlDataReader.GetInt32(0));
		                duration.PlannedStart = sqlDataReader.GetDateTime(1);
                        if(sqlDataReader.IsDBNull(2)==false)
    		                duration.ForecastStart = sqlDataReader.GetDateTime(2);
                        if(sqlDataReader.IsDBNull(3)==false)
	    	                duration.ActualStart = sqlDataReader.GetDateTime(3);
		                duration.PlannedEnd = sqlDataReader.GetDateTime(4);
                        if(sqlDataReader.IsDBNull(5)==false)
		                    duration.ForecastEnd = sqlDataReader.GetDateTime(5);
                        if(sqlDataReader.IsDBNull(6)==false)
                            duration.ActualEnd = sqlDataReader.GetDateTime(6);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    duration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    duration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return duration;
        }

        public Duration[] List()
        {
            return null;
        }

        public Duration Insert(Duration pDuration)
        {
            Duration duration = new Duration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Duration_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PlannedStart", pDuration.PlannedStart));
                    sqlCommand.Parameters.Add(new SqlParameter("@PlannedEnd", pDuration.PlannedEnd));
                    SqlParameter durationID = sqlCommand.Parameters.Add("@DurationID", SqlDbType.Int);
                    durationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    duration = new Duration((Int32)durationID.Value);
                    duration.PlannedStart = pDuration.PlannedStart;
                    duration.PlannedEnd = pDuration.PlannedEnd;
                }
                catch (Exception exc)
                {
                    duration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    duration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return duration;
        }

        public Duration Update(Duration pDuration)
        {
            Duration duration = new Duration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Duration_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationID", pDuration.DurationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PlannedStart", pDuration.PlannedStart));
                    sqlCommand.Parameters.Add(new SqlParameter("@ForecastStart", ((pDuration.ForecastStart.HasValue == true) ? pDuration.ForecastStart : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActualStart", ((pDuration.ActualStart.HasValue == true) ? pDuration.ActualStart : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PlannedEnd", pDuration.PlannedEnd));
                    sqlCommand.Parameters.Add(new SqlParameter("@ForecastEnd", ((pDuration.ForecastEnd.HasValue == true) ? pDuration.ForecastEnd : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActualEnd", ((pDuration.ActualEnd.HasValue == true) ? pDuration.ActualEnd : null)));

                    sqlCommand.ExecuteNonQuery();

                    duration = new Duration(pDuration.DurationID);
                    duration.PlannedStart = pDuration.PlannedStart;
                    duration.ForecastStart = pDuration.ForecastStart;
                    duration.ActualStart = pDuration.ActualStart;
                    duration.PlannedEnd = pDuration.PlannedEnd;
                    duration.ForecastEnd = pDuration.ForecastEnd;
                    duration.ActualEnd = pDuration.ActualEnd;
                }
                catch (Exception exc)
                {
                    duration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    duration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return duration;
        }

        public Duration Delete(Duration pDuration)
        {
            Duration duration = new Duration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Duration_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationID", pDuration.DurationID));

                    sqlCommand.ExecuteNonQuery();

                    duration = new Duration(pDuration.DurationID);
                }
                catch (Exception exc)
                {
                    duration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    duration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return duration;
        }
    }
}
