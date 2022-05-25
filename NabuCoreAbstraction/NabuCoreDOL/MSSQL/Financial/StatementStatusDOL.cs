using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class StatementStatusDOL : BaseDOL
    {
        public StatementStatusDOL()
            : base()
        {
        }

        public StatementStatusDOL(string pConnectionString, string pErrorLogFile)
            : base(pConnectionString, pErrorLogFile)
        {
        }

        public StatementStatus Get(int pStatementStatusID, int pLanguageID)
        {
            StatementStatus statementStatus = new StatementStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[StatementStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StatementStatusID", pStatementStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        statementStatus = new StatementStatus(sqlDataReader.GetInt32(0));
                        statementStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    statementStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    statementStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return statementStatus;
        }

        public StatementStatus GetByAlias(string pAlias, int pLanguageID)
        {
            StatementStatus statementStatus = new StatementStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[StatementStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        statementStatus = new StatementStatus(sqlDataReader.GetInt32(0));
                        statementStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    statementStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    statementStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return statementStatus;
        }

        public StatementStatus[] List(int pLanguageID)
        {
            List<StatementStatus> statementStatuss = new List<StatementStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[StatementStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        StatementStatus statementStatus = new StatementStatus(sqlDataReader.GetInt32(0));
                        statementStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        statementStatuss.Add(statementStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    StatementStatus statementStatus = new StatementStatus();
                    statementStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    statementStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    statementStatuss.Add(statementStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return statementStatuss.ToArray();
        }

        public StatementStatus Insert(StatementStatus pStatementStatus)
        {
            StatementStatus statementStatus = new StatementStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[StatementStatus_Insert]");
                try
                {
                    pStatementStatus.Detail = base.InsertTranslation(pStatementStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pStatementStatus.Detail.TranslationID));
                    SqlParameter statementStatusID = sqlCommand.Parameters.Add("@StatementStatusID", SqlDbType.Int);
                    statementStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    statementStatus = new StatementStatus((Int32)statementStatusID.Value);
                    statementStatus.Detail = new Translation(pStatementStatus.Detail.TranslationID);
                    statementStatus.Detail.Alias = pStatementStatus.Detail.Alias;
                    statementStatus.Detail.Description = pStatementStatus.Detail.Description;
                    statementStatus.Detail.Name = pStatementStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    statementStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    statementStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return statementStatus;
        }

        public StatementStatus Update(StatementStatus pStatementStatus)
        {
            StatementStatus statementStatus = new StatementStatus();

            pStatementStatus.Detail = base.UpdateTranslation(pStatementStatus.Detail);

            statementStatus = new StatementStatus(pStatementStatus.StatementStatusID);
            statementStatus.Detail = new Translation(pStatementStatus.Detail.TranslationID);
            statementStatus.Detail.Alias = pStatementStatus.Detail.Alias;
            statementStatus.Detail.Description = pStatementStatus.Detail.Description;
            statementStatus.Detail.Name = pStatementStatus.Detail.Name;

            return statementStatus;
        }

        public StatementStatus Delete(StatementStatus pStatementStatus)
        {
            StatementStatus statementStatus = new StatementStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[StatementStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StatementStatusID", pStatementStatus.StatementStatusID));

                    sqlCommand.ExecuteNonQuery();

                    statementStatus = new StatementStatus(pStatementStatus.StatementStatusID);
                    base.DeleteAllTranslations(pStatementStatus.Detail);
                }
                catch (Exception exc)
                {
                    statementStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    statementStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return statementStatus;
        }
    }
}
