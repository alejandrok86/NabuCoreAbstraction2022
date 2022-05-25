using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Audit;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit
{
    public class AuditEventTypeDOL : BaseDOL
    {
        public AuditEventTypeDOL() : base ()
        {
        }

        public AuditEventTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AuditEventType Get(int pAuditEventTypeID, int pLanguageID)
        {
            AuditEventType auditEventType = new AuditEventType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAudit].[AuditEventType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AuditEventTypeID", pAuditEventTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        auditEventType = new AuditEventType(sqlDataReader.GetInt32(0));
                        auditEventType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    auditEventType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    auditEventType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return auditEventType;
        }

        public AuditEventType GetByAlias(string pAlias, int pLanguageID)
        {
            AuditEventType auditEventType = new AuditEventType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAudit].[AuditEventType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        auditEventType = new AuditEventType(sqlDataReader.GetInt32(0));
                        auditEventType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    auditEventType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    auditEventType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return auditEventType;
        }

        public AuditEventType[] List(int pLanguageID)
        {
            List<AuditEventType> auditEventTypes = new List<AuditEventType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAudit].[AuditEventType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AuditEventType auditEventType = new AuditEventType(sqlDataReader.GetInt32(0));
                        auditEventType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        auditEventTypes.Add(auditEventType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AuditEventType auditEventType = new AuditEventType();
                    auditEventType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    auditEventType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    auditEventTypes.Add(auditEventType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return auditEventTypes.ToArray();
        }

        public AuditEventType Insert(AuditEventType pAuditEventType)
        {
            AuditEventType auditEventType = new AuditEventType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAudit].[AuditEventType_Insert]");
                try
                {
                    pAuditEventType.Detail = base.InsertTranslation(pAuditEventType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAuditEventType.Detail.TranslationID));
                    SqlParameter auditEventTypeID = sqlCommand.Parameters.Add("@AuditEventTypeID", SqlDbType.Int);
                    auditEventTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    auditEventType = new AuditEventType((Int32)auditEventTypeID.Value);
                    auditEventType.Detail = new Translation(pAuditEventType.Detail.TranslationID);
                    auditEventType.Detail.Alias = pAuditEventType.Detail.Alias;
                    auditEventType.Detail.Description = pAuditEventType.Detail.Description;
                    auditEventType.Detail.Name = pAuditEventType.Detail.Name;
                }
                catch (Exception exc)
                {
                    auditEventType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    auditEventType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return auditEventType;
        }

        public AuditEventType Update(AuditEventType pAuditEventType)
        {
            AuditEventType auditEventType = new AuditEventType();

            pAuditEventType.Detail = base.UpdateTranslation(pAuditEventType.Detail);

            auditEventType = new AuditEventType(pAuditEventType.AuditEventTypeID);
            auditEventType.Detail = new Translation(pAuditEventType.Detail.TranslationID);
            auditEventType.Detail.Alias = pAuditEventType.Detail.Alias;
            auditEventType.Detail.Description = pAuditEventType.Detail.Description;
            auditEventType.Detail.Name = pAuditEventType.Detail.Name;

            return auditEventType;
        }

        public AuditEventType Delete(AuditEventType pAuditEventType)
        {
            AuditEventType auditEventType = new AuditEventType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAudit].[AuditEventType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AuditEventTypeID", pAuditEventType.AuditEventTypeID));

                    sqlCommand.ExecuteNonQuery();

                    auditEventType = new AuditEventType(pAuditEventType.AuditEventTypeID);

                    base.DeleteAllTranslations(pAuditEventType.Detail);
                }
                catch (Exception exc)
                {
                    auditEventType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    auditEventType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return auditEventType;
        }
    }
}

