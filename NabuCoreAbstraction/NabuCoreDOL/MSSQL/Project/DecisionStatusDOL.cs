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
    public class DecisionStatusDOL : BaseDOL
    {
        public DecisionStatusDOL() : base()
        {
        }

        public DecisionStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public DecisionStatus Get(int pDecisionStatusID, int pLanguageID)
        {
            DecisionStatus decisionStatus = new DecisionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[DecisionStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionStatusID", pDecisionStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        decisionStatus = new DecisionStatus(sqlDataReader.GetInt32(0));
                        decisionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    decisionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    decisionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return decisionStatus;
        }

        public DecisionStatus GetByAlias(string pAlias, int pLanguageID)
        {
            DecisionStatus decisionStatus = new DecisionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[DecisionStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        decisionStatus = new DecisionStatus(sqlDataReader.GetInt32(0));
                        decisionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    decisionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    decisionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return decisionStatus;
        }

        public DecisionStatus[] List(int pLanguageID)
        {
            List<DecisionStatus> decisionStatuss = new List<DecisionStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[DecisionStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        DecisionStatus decisionStatus = new DecisionStatus(sqlDataReader.GetInt32(0));
                        decisionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        decisionStatuss.Add(decisionStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    DecisionStatus decisionStatus = new DecisionStatus();
                    decisionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    decisionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    decisionStatuss.Add(decisionStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return decisionStatuss.ToArray();
        }

        public DecisionStatus Insert(DecisionStatus pDecisionStatus)
        {
            DecisionStatus decisionStatus = new DecisionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[DecisionStatus_Insert]");
                try
                {
                    pDecisionStatus.Detail = base.InsertTranslation(pDecisionStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pDecisionStatus.Detail.TranslationID));
                    SqlParameter decisionStatusID = sqlCommand.Parameters.Add("@DecisionStatusID", SqlDbType.Int);
                    decisionStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    decisionStatus = new DecisionStatus((Int32)decisionStatusID.Value);
                    decisionStatus.Detail = new Translation(pDecisionStatus.Detail.TranslationID);
                    decisionStatus.Detail.Alias = pDecisionStatus.Detail.Alias;
                    decisionStatus.Detail.Description = pDecisionStatus.Detail.Description;
                    decisionStatus.Detail.Name = pDecisionStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    decisionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    decisionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return decisionStatus;
        }

        public DecisionStatus Update(DecisionStatus pDecisionStatus)
        {
            DecisionStatus decisionStatus = new DecisionStatus();

            pDecisionStatus.Detail = base.UpdateTranslation(pDecisionStatus.Detail);

            decisionStatus = new DecisionStatus(pDecisionStatus.DecisionStatusID);
            decisionStatus.Detail = new Translation(pDecisionStatus.Detail.TranslationID);
            decisionStatus.Detail.Alias = pDecisionStatus.Detail.Alias;
            decisionStatus.Detail.Description = pDecisionStatus.Detail.Description;
            decisionStatus.Detail.Name = pDecisionStatus.Detail.Name;

            return decisionStatus;
        }

        public DecisionStatus Delete(DecisionStatus pDecisionStatus)
        {
            DecisionStatus decisionStatus = new DecisionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[DecisionStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionStatusID", pDecisionStatus.DecisionStatusID));

                    sqlCommand.ExecuteNonQuery();

                    decisionStatus = new DecisionStatus(pDecisionStatus.DecisionStatusID);
                    base.DeleteAllTranslations(pDecisionStatus.Detail);
                }
                catch (Exception exc)
                {
                    decisionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    decisionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return decisionStatus;
        }
    }
}
