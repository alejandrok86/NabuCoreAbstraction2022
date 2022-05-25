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
    public class ActionTypeDOL : BaseDOL
    {
        public ActionTypeDOL() : base()
        {
        }

        public ActionTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ActionType Get(int pActionTypeID, int pLanguageID)
        {
            ActionType actionType = new ActionType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ActionType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionTypeID", pActionTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        actionType = new ActionType(sqlDataReader.GetInt32(0));
                        actionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    actionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    actionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actionType;
        }

        public ActionType GetByAlias(string pAlias, int pLanguageID)
        {
            ActionType actionType = new ActionType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ActionType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        actionType = new ActionType(sqlDataReader.GetInt32(0));
                        actionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    actionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    actionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actionType;
        }

        public ActionType[] List(int pLanguageID)
        {
            List<ActionType> actionTypes = new List<ActionType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ActionType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ActionType actionType = new ActionType(sqlDataReader.GetInt32(0));
                        actionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        actionTypes.Add(actionType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ActionType actionType = new ActionType();
                    actionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    actionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    actionTypes.Add(actionType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actionTypes.ToArray();
        }

        public ActionType Insert(ActionType pActionType)
        {
            ActionType actionType = new ActionType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ActionType_Insert]");
                try
                {
                    pActionType.Detail = base.InsertTranslation(pActionType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pActionType.Detail.TranslationID));
                    SqlParameter actionTypeID = sqlCommand.Parameters.Add("@ActionTypeID", SqlDbType.Int);
                    actionTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    actionType = new ActionType((Int32)actionTypeID.Value);
                    actionType.Detail = new Translation(pActionType.Detail.TranslationID);
                    actionType.Detail.Alias = pActionType.Detail.Alias;
                    actionType.Detail.Description = pActionType.Detail.Description;
                    actionType.Detail.Name = pActionType.Detail.Name;
                }
                catch (Exception exc)
                {
                    actionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    actionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actionType;
        }

        public ActionType Update(ActionType pActionType)
        {
            ActionType actionType = new ActionType();

            pActionType.Detail = base.UpdateTranslation(pActionType.Detail);

            actionType = new ActionType(pActionType.ActionTypeID);
            actionType.Detail = new Translation(pActionType.Detail.TranslationID);
            actionType.Detail.Alias = pActionType.Detail.Alias;
            actionType.Detail.Description = pActionType.Detail.Description;
            actionType.Detail.Name = pActionType.Detail.Name;

            return actionType;
        }

        public ActionType Delete(ActionType pActionType)
        {
            ActionType actionType = new ActionType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ActionType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionTypeID", pActionType.ActionTypeID));

                    sqlCommand.ExecuteNonQuery();

                    actionType = new ActionType(pActionType.ActionTypeID);
                    base.DeleteAllTranslations(pActionType.Detail);
                }
                catch (Exception exc)
                {
                    actionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    actionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actionType;
        }
    }
}
