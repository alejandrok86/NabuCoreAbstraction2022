using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Project;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class IssueStatusDOL : BaseDOL
    {
        public IssueStatusDOL() : base()
        {
        }

        public IssueStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public IssueStatus Get(int pIssueStatusID, int pLanguageID)
        {
            IssueStatus issueStatus = new IssueStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[IssueStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueStatusID", pIssueStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        issueStatus = new IssueStatus(sqlDataReader.GetInt32(0));
                        issueStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    issueStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issueStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issueStatus;
        }

        public IssueStatus GetByAlias(string pAlias, int pLanguageID)
        {
            IssueStatus issueStatus = new IssueStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[IssueStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        issueStatus = new IssueStatus(sqlDataReader.GetInt32(0));
                        issueStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    issueStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issueStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issueStatus;
        }

        public IssueStatus[] List(int pLanguageID)
        {
            List<IssueStatus> issueStatuss = new List<IssueStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[IssueStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        IssueStatus issueStatus = new IssueStatus(sqlDataReader.GetInt32(0));
                        issueStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        issueStatuss.Add(issueStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    IssueStatus issueStatus = new IssueStatus();
                    issueStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issueStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    issueStatuss.Add(issueStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issueStatuss.ToArray();
        }

        public IssueStatus Insert(IssueStatus pIssueStatus)
        {
            IssueStatus issueStatus = new IssueStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[IssueStatus_Insert]");
                try
                {
                    pIssueStatus.Detail = base.InsertTranslation(pIssueStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pIssueStatus.Detail.TranslationID));
                    SqlParameter issueStatusID = sqlCommand.Parameters.Add("@IssueStatusID", SqlDbType.Int);
                    issueStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    issueStatus = new IssueStatus((Int32)issueStatusID.Value);
                    issueStatus.Detail = new Translation(pIssueStatus.Detail.TranslationID);
                    issueStatus.Detail.Alias = pIssueStatus.Detail.Alias;
                    issueStatus.Detail.Description = pIssueStatus.Detail.Description;
                    issueStatus.Detail.Name = pIssueStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    issueStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issueStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issueStatus;
        }

        public IssueStatus Update(IssueStatus pIssueStatus)
        {
            IssueStatus issueStatus = new IssueStatus();

            pIssueStatus.Detail = base.UpdateTranslation(pIssueStatus.Detail);

            issueStatus = new IssueStatus(pIssueStatus.IssueStatusID);
            issueStatus.Detail = new Translation(pIssueStatus.Detail.TranslationID);
            issueStatus.Detail.Alias = pIssueStatus.Detail.Alias;
            issueStatus.Detail.Description = pIssueStatus.Detail.Description;
            issueStatus.Detail.Name = pIssueStatus.Detail.Name;

            return issueStatus;
        }

        public IssueStatus Delete(IssueStatus pIssueStatus)
        {
            IssueStatus issueStatus = new IssueStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[IssueStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueStatusID", pIssueStatus.IssueStatusID));

                    sqlCommand.ExecuteNonQuery();

                    issueStatus = new IssueStatus(pIssueStatus.IssueStatusID);
                    base.DeleteAllTranslations(pIssueStatus.Detail);
                }
                catch (Exception exc)
                {
                    issueStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issueStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issueStatus;
        }
    }
}
