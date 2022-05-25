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
    public class IssueTypeDOL : BaseDOL
    {
        public IssueTypeDOL() : base()
        {
        }

        public IssueTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public IssueType Get(int pIssueTypeID, int pLanguageID)
        {
            IssueType issueType = new IssueType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[IssueType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueTypeID", pIssueTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        issueType = new IssueType(sqlDataReader.GetInt32(0));
                        issueType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    issueType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issueType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issueType;
        }

        public IssueType GetByAlias(string pAlias, int pLanguageID)
        {
            IssueType issueType = new IssueType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[IssueType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        issueType = new IssueType(sqlDataReader.GetInt32(0));
                        issueType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    issueType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issueType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issueType;
        }

        public IssueType[] List(int pLanguageID)
        {
            List<IssueType> issueTypes = new List<IssueType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[IssueType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        IssueType issueType = new IssueType(sqlDataReader.GetInt32(0));
                        issueType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        issueTypes.Add(issueType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    IssueType issueType = new IssueType();
                    issueType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issueType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    issueTypes.Add(issueType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issueTypes.ToArray();
        }

        public IssueType Insert(IssueType pIssueType)
        {
            IssueType issueType = new IssueType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[IssueType_Insert]");
                try
                {
                    pIssueType.Detail = base.InsertTranslation(pIssueType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pIssueType.Detail.TranslationID));
                    SqlParameter issueTypeID = sqlCommand.Parameters.Add("@IssueTypeID", SqlDbType.Int);
                    issueTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    issueType = new IssueType((Int32)issueTypeID.Value);
                    issueType.Detail = new Translation(pIssueType.Detail.TranslationID);
                    issueType.Detail.Alias = pIssueType.Detail.Alias;
                    issueType.Detail.Description = pIssueType.Detail.Description;
                    issueType.Detail.Name = pIssueType.Detail.Name;
                }
                catch (Exception exc)
                {
                    issueType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issueType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issueType;
        }

        public IssueType Update(IssueType pIssueType)
        {
            IssueType issueType = new IssueType();

            pIssueType.Detail = base.UpdateTranslation(pIssueType.Detail);

            issueType = new IssueType(pIssueType.IssueTypeID);
            issueType.Detail = new Translation(pIssueType.Detail.TranslationID);
            issueType.Detail.Alias = pIssueType.Detail.Alias;
            issueType.Detail.Description = pIssueType.Detail.Description;
            issueType.Detail.Name = pIssueType.Detail.Name;

            return issueType;
        }

        public IssueType Delete(IssueType pIssueType)
        {
            IssueType issueType = new IssueType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[IssueType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueTypeID", pIssueType.IssueTypeID));

                    sqlCommand.ExecuteNonQuery();

                    issueType = new IssueType(pIssueType.IssueTypeID);
                    base.DeleteAllTranslations(pIssueType.Detail);
                }
                catch (Exception exc)
                {
                    issueType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issueType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issueType;
        }
    }
}
