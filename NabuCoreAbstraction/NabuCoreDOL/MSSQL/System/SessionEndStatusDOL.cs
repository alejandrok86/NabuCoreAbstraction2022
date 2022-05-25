using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.System
{
    public class SessionEndStatusDOL : BaseDOL
    {
        public SessionEndStatusDOL() : base()
        {
        }

        public SessionEndStatusDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public SessionEndStatus Get(int pSessionEndStatusID, int pLanguageID)
        {
            SessionEndStatus sessionEndStatus = new SessionEndStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[SessionEndStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SessionEndStatusID", pSessionEndStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        sessionEndStatus = new SessionEndStatus(sqlDataReader.GetInt32(0));
                        sessionEndStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    sessionEndStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sessionEndStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sessionEndStatus;
        }

        public SessionEndStatus GetByAlias(string pAlias, int pLanguageID)
        {
            SessionEndStatus sessionEndStatus = new SessionEndStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[SessionEndStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        sessionEndStatus = new SessionEndStatus(sqlDataReader.GetInt32(0));
                        sessionEndStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    sessionEndStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sessionEndStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sessionEndStatus;
        }

        public SessionEndStatus[] List(int pLanguageID)
        {
            List<SessionEndStatus> sessionEndStatuss = new List<SessionEndStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[SessionEndStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        SessionEndStatus sessionEndStatus = new SessionEndStatus(sqlDataReader.GetInt32(0));
                        sessionEndStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        sessionEndStatuss.Add(sessionEndStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    SessionEndStatus sessionEndStatus = new SessionEndStatus();
                    sessionEndStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sessionEndStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    sessionEndStatuss.Add(sessionEndStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sessionEndStatuss.ToArray();
        }

        public SessionEndStatus Insert(SessionEndStatus pSessionEndStatus)
        {
            SessionEndStatus sessionEndStatus = new SessionEndStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[SessionEndStatus_Insert]");
                try
                {
                    pSessionEndStatus.Detail = base.InsertTranslation(pSessionEndStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pSessionEndStatus.Detail.TranslationID));
                    SqlParameter sessionEndStatusID = sqlCommand.Parameters.Add("@SessionEndStatusID", SqlDbType.Int);
                    sessionEndStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    sessionEndStatus = new SessionEndStatus((Int32)sessionEndStatusID.Value);
                    sessionEndStatus.Detail = new Translation(pSessionEndStatus.Detail.TranslationID);
                    sessionEndStatus.Detail.Alias = pSessionEndStatus.Detail.Alias;
                    sessionEndStatus.Detail.Description = pSessionEndStatus.Detail.Description;
                    sessionEndStatus.Detail.Name = pSessionEndStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    sessionEndStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sessionEndStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sessionEndStatus;
        }

        public SessionEndStatus Update(SessionEndStatus pSessionEndStatus)
        {
            SessionEndStatus sessionEndStatus = new SessionEndStatus();

            pSessionEndStatus.Detail = base.UpdateTranslation(pSessionEndStatus.Detail);

            sessionEndStatus = new SessionEndStatus(pSessionEndStatus.SessionEndStatusID);
            sessionEndStatus.Detail = new Translation(pSessionEndStatus.Detail.TranslationID);
            sessionEndStatus.Detail.Alias = pSessionEndStatus.Detail.Alias;
            sessionEndStatus.Detail.Description = pSessionEndStatus.Detail.Description;
            sessionEndStatus.Detail.Name = pSessionEndStatus.Detail.Name;

            return sessionEndStatus;
        }

        public SessionEndStatus Delete(SessionEndStatus pSessionEndStatus)
        {
            SessionEndStatus sessionEndStatus = new SessionEndStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[SessionEndStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SessionEndStatusID", pSessionEndStatus.SessionEndStatusID));

                    sqlCommand.ExecuteNonQuery();

                    sessionEndStatus = new SessionEndStatus(pSessionEndStatus.SessionEndStatusID);
                    base.DeleteAllTranslations(pSessionEndStatus.Detail);
                }
                catch (Exception exc)
                {
                    sessionEndStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sessionEndStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sessionEndStatus;
        }
    }
}

