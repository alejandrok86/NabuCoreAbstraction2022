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
    public class TrackingCodeTypeDOL : BaseDOL
    {
        public TrackingCodeTypeDOL() : base ()
        {
        }

        public TrackingCodeTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TrackingCodeType Get(int pTrackingCodeTypeID, int pLanguageID)
        {
            TrackingCodeType trackingCodeType = new TrackingCodeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TrackingCodeType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrackingCodeTypeID", pTrackingCodeTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        trackingCodeType = new TrackingCodeType(sqlDataReader.GetInt32(0));
                        trackingCodeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    trackingCodeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trackingCodeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trackingCodeType;
        }

        public TrackingCodeType GetByAlias(string pAlias, int pLanguageID)
        {
            TrackingCodeType trackingCodeType = new TrackingCodeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TrackingCodeType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        trackingCodeType = new TrackingCodeType(sqlDataReader.GetInt32(0));
                        trackingCodeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    trackingCodeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trackingCodeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trackingCodeType;
        }

        public TrackingCodeType[] List(int pLanguageID)
        {
            List<TrackingCodeType> trackingCodeTypes = new List<TrackingCodeType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TrackingCodeType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TrackingCodeType trackingCodeType = new TrackingCodeType(sqlDataReader.GetInt32(0));
                        trackingCodeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        trackingCodeTypes.Add(trackingCodeType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TrackingCodeType trackingCodeType = new TrackingCodeType();
                    trackingCodeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trackingCodeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    trackingCodeTypes.Add(trackingCodeType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trackingCodeTypes.ToArray();
        }

        public TrackingCodeType Insert(TrackingCodeType pTrackingCodeType)
        {
            TrackingCodeType trackingCodeType = new TrackingCodeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TrackingCodeType_Insert]");
                try
                {
                    pTrackingCodeType.Detail = base.InsertTranslation(pTrackingCodeType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTrackingCodeType.Detail.TranslationID));
                    SqlParameter trackingCodeTypeID = sqlCommand.Parameters.Add("@TrackingCodeTypeID", SqlDbType.Int);
                    trackingCodeTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    trackingCodeType = new TrackingCodeType((Int32)trackingCodeTypeID.Value);
                    trackingCodeType.Detail = new Translation(pTrackingCodeType.Detail.TranslationID);
                    trackingCodeType.Detail.Alias = pTrackingCodeType.Detail.Alias;
                    trackingCodeType.Detail.Description = pTrackingCodeType.Detail.Description;
                    trackingCodeType.Detail.Name = pTrackingCodeType.Detail.Name;
                }
                catch (Exception exc)
                {
                    trackingCodeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trackingCodeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trackingCodeType;
        }

        public TrackingCodeType Update(TrackingCodeType pTrackingCodeType)
        {
            TrackingCodeType trackingCodeType = new TrackingCodeType();

            trackingCodeType.Detail = base.UpdateTranslation(pTrackingCodeType.Detail);

            return trackingCodeType;
        }

        public TrackingCodeType Delete(TrackingCodeType pTrackingCodeType)
        {
            TrackingCodeType trackingCodeType = new TrackingCodeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TrackingCodeType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrackingCodeTypeID", pTrackingCodeType.TrackingCodeTypeID));

                    sqlCommand.ExecuteNonQuery();

                    trackingCodeType = new TrackingCodeType(pTrackingCodeType.TrackingCodeTypeID);
                    base.DeleteAllTranslations(pTrackingCodeType.Detail);
                }
                catch (Exception exc)
                {
                    trackingCodeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trackingCodeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trackingCodeType;
        }
    }
}

