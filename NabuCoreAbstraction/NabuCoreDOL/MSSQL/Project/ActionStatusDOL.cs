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
    public class ActionStatusDOL : BaseDOL
    {
        public ActionStatusDOL() : base()
        {
        }

        public ActionStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ActionStatus Get(int pActionStatusID, int pLanguageID)
        {
            ActionStatus actionStatus = new ActionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ActionStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionStatusID", pActionStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        actionStatus = new ActionStatus(sqlDataReader.GetInt32(0));
                        actionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    actionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    actionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actionStatus;
        }

        public ActionStatus GetByAlias(string pAlias, int pLanguageID)
        {
            ActionStatus actionStatus = new ActionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ActionStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        actionStatus = new ActionStatus(sqlDataReader.GetInt32(0));
                        actionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    actionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    actionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actionStatus;
        }

        public ActionStatus[] List(int pLanguageID)
        {
            List<ActionStatus> actionStatuss = new List<ActionStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ActionStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ActionStatus actionStatus = new ActionStatus(sqlDataReader.GetInt32(0));
                        actionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        actionStatuss.Add(actionStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ActionStatus actionStatus = new ActionStatus();
                    actionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    actionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    actionStatuss.Add(actionStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actionStatuss.ToArray();
        }

        public ActionStatus Insert(ActionStatus pActionStatus)
        {
            ActionStatus actionStatus = new ActionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ActionStatus_Insert]");
                try
                {
                    pActionStatus.Detail = base.InsertTranslation(pActionStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pActionStatus.Detail.TranslationID));
                    SqlParameter actionStatusID = sqlCommand.Parameters.Add("@ActionStatusID", SqlDbType.Int);
                    actionStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    actionStatus = new ActionStatus((Int32)actionStatusID.Value);
                    actionStatus.Detail = new Translation(pActionStatus.Detail.TranslationID);
                    actionStatus.Detail.Alias = pActionStatus.Detail.Alias;
                    actionStatus.Detail.Description = pActionStatus.Detail.Description;
                    actionStatus.Detail.Name = pActionStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    actionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    actionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actionStatus;
        }

        public ActionStatus Update(ActionStatus pActionStatus)
        {
            ActionStatus actionStatus = new ActionStatus();

            pActionStatus.Detail = base.UpdateTranslation(pActionStatus.Detail);

            actionStatus = new ActionStatus(pActionStatus.ActionStatusID);
            actionStatus.Detail = new Translation(pActionStatus.Detail.TranslationID);
            actionStatus.Detail.Alias = pActionStatus.Detail.Alias;
            actionStatus.Detail.Description = pActionStatus.Detail.Description;
            actionStatus.Detail.Name = pActionStatus.Detail.Name;

            return actionStatus;
        }

        public ActionStatus Delete(ActionStatus pActionStatus)
        {
            ActionStatus actionStatus = new ActionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ActionStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionStatusID", pActionStatus.ActionStatusID));

                    sqlCommand.ExecuteNonQuery();

                    actionStatus = new ActionStatus(pActionStatus.ActionStatusID);
                    base.DeleteAllTranslations(pActionStatus.Detail);
                }
                catch (Exception exc)
                {
                    actionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    actionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actionStatus;
        }
    }
}
