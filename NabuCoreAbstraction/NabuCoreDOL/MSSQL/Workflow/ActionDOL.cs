using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Workflow;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow
{
    public class ActionDOL : BaseDOL
    {
        public ActionDOL() : base()
        {
        }

        public ActionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.Action Get(int pActionID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.Action action = new Octavo.Gate.Nabu.CORE.Entities.Workflow.Action();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Action_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionID", pActionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        action = new Octavo.Gate.Nabu.CORE.Entities.Workflow.Action(sqlDataReader.GetInt32(0));
                        action.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    action.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    action.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return action;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.Action[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Workflow.Action> actions = new List<Octavo.Gate.Nabu.CORE.Entities.Workflow.Action>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Action_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Workflow.Action action = new Octavo.Gate.Nabu.CORE.Entities.Workflow.Action(sqlDataReader.GetInt32(0));
                        action.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        actions.Add(action);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Workflow.Action action = new Octavo.Gate.Nabu.CORE.Entities.Workflow.Action();
                    action.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    action.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    actions.Add(action);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actions.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.Action Insert(Octavo.Gate.Nabu.CORE.Entities.Workflow.Action pAction)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.Action action = new Octavo.Gate.Nabu.CORE.Entities.Workflow.Action();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Action_Insert]");
                try
                {
                    pAction.Detail = base.InsertTranslation(pAction.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAction.Detail.TranslationID));
                    SqlParameter actionID = sqlCommand.Parameters.Add("@ActionID", SqlDbType.Int);
                    actionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    action = new Octavo.Gate.Nabu.CORE.Entities.Workflow.Action((Int32)actionID.Value);
                    action.Detail = new Translation(pAction.Detail.TranslationID);
                    action.Detail.Alias = pAction.Detail.Alias;
                    action.Detail.Description = pAction.Detail.Description;
                    action.Detail.Name = pAction.Detail.Name;
                }
                catch (Exception exc)
                {
                    action.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    action.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return action;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.Action Update(Octavo.Gate.Nabu.CORE.Entities.Workflow.Action pAction)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.Action action = new Octavo.Gate.Nabu.CORE.Entities.Workflow.Action();

            pAction.Detail = base.UpdateTranslation(pAction.Detail);

            action = new Octavo.Gate.Nabu.CORE.Entities.Workflow.Action(pAction.ActionID);
            action.Detail = new Translation(pAction.Detail.TranslationID);
            action.Detail.Alias = pAction.Detail.Alias;
            action.Detail.Description = pAction.Detail.Description;
            action.Detail.Name = pAction.Detail.Name;

            return action;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.Action Delete(Octavo.Gate.Nabu.CORE.Entities.Workflow.Action pAction)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.Action action = new Octavo.Gate.Nabu.CORE.Entities.Workflow.Action();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Action_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionID", pAction.ActionID));

                    sqlCommand.ExecuteNonQuery();

                    action = new Octavo.Gate.Nabu.CORE.Entities.Workflow.Action(pAction.ActionID);
                    base.DeleteAllTranslations(pAction.Detail);
                }
                catch (Exception exc)
                {
                    action.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    action.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return action;
        }
    }
}
