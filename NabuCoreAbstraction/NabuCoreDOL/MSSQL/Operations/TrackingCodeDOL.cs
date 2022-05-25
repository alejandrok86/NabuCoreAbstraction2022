using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class TrackingCodeDOL : BaseDOL
    {
        public TrackingCodeDOL() : base ()
        {
        }

        public TrackingCodeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TrackingCode Get(int pTrackingCodeID)
        {
            TrackingCode trackingCode = new TrackingCode();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TrackingCode_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrackingCodeID", pTrackingCodeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        trackingCode = new TrackingCode(sqlDataReader.GetInt32(0));
                        trackingCode.Code = sqlDataReader.GetString(1);
                        trackingCode.TrackingCodeType = new TrackingCodeType(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    trackingCode.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trackingCode.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trackingCode;
        }

        public TrackingCode GetByCode(string pCode)
        {
            TrackingCode trackingCode = new TrackingCode();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TrackingCode_GetByCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", pCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        trackingCode = new TrackingCode(sqlDataReader.GetInt32(0));
                        trackingCode.Code = sqlDataReader.GetString(1);
                        trackingCode.TrackingCodeType = new TrackingCodeType(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    trackingCode.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trackingCode.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trackingCode;
        }

        public TrackingCode[] List()
        {
            List<TrackingCode> trackingCodes = new List<TrackingCode>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TrackingCode_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TrackingCode trackingCode = new TrackingCode(sqlDataReader.GetInt32(0));
                        trackingCode.Code = sqlDataReader.GetString(1);
                        trackingCode.TrackingCodeType = new TrackingCodeType(sqlDataReader.GetInt32(2));
                        trackingCodes.Add(trackingCode);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TrackingCode trackingCode = new TrackingCode();
                    trackingCode.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trackingCode.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    trackingCodes.Add(trackingCode);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trackingCodes.ToArray();
        }

        public TrackingCode Insert(TrackingCode pTrackingCode)
        {
            TrackingCode trackingCode = new TrackingCode();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TrackingCode_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", pTrackingCode.Code));
                    sqlCommand.Parameters.Add(new SqlParameter("@TrackingCodeTypeID", pTrackingCode.TrackingCodeType.TrackingCodeTypeID));
                    SqlParameter trackingCodeID = sqlCommand.Parameters.Add("@TrackingCodeID", SqlDbType.Int);
                    trackingCodeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    trackingCode = new TrackingCode((Int32)trackingCodeID.Value);
                    trackingCode.Code = pTrackingCode.Code;
                    trackingCode.TrackingCodeType = pTrackingCode.TrackingCodeType;
                }
                catch (Exception exc)
                {
                    trackingCode.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trackingCode.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trackingCode;
        }

        public TrackingCode Update(TrackingCode pTrackingCode)
        {
            TrackingCode trackingCode = new TrackingCode();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TrackingCode_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrackingCodeID", pTrackingCode.TrackingCodeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", pTrackingCode.Code));
                    sqlCommand.Parameters.Add(new SqlParameter("@TrackingCodeTypeID", pTrackingCode.TrackingCodeType.TrackingCodeTypeID));

                    sqlCommand.ExecuteNonQuery();

                    trackingCode = new TrackingCode(pTrackingCode.TrackingCodeID);
                    trackingCode.Code = pTrackingCode.Code;
                    trackingCode.TrackingCodeType = pTrackingCode.TrackingCodeType;
                }
                catch (Exception exc)
                {
                    trackingCode.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trackingCode.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trackingCode;
        }

        public TrackingCode Delete(TrackingCode pTrackingCode)
        {
            TrackingCode trackingCode = new TrackingCode();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TrackingCode_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrackingCodeID", pTrackingCode.TrackingCodeID));

                    sqlCommand.ExecuteNonQuery();

                    trackingCode = new TrackingCode(pTrackingCode.TrackingCodeID);
                }
                catch (Exception exc)
                {
                    trackingCode.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trackingCode.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trackingCode;
        }
    }
}
