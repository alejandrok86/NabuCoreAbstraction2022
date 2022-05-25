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
    public class StateDOL : BaseDOL
    {
        public StateDOL() : base()
        {
        }

        public StateDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.State Get(int pStateID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.State state = new Octavo.Gate.Nabu.CORE.Entities.Workflow.State();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[State_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StateID", pStateID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        state = new Octavo.Gate.Nabu.CORE.Entities.Workflow.State(sqlDataReader.GetInt32(0));
                        state.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    state.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    state.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return state;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.State[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Workflow.State> states = new List<Octavo.Gate.Nabu.CORE.Entities.Workflow.State>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[State_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Workflow.State state = new Octavo.Gate.Nabu.CORE.Entities.Workflow.State(sqlDataReader.GetInt32(0));
                        state.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        states.Add(state);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Workflow.State state = new Octavo.Gate.Nabu.CORE.Entities.Workflow.State();
                    state.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    state.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    states.Add(state);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return states.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.State Insert(Octavo.Gate.Nabu.CORE.Entities.Workflow.State pState)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.State state = new Octavo.Gate.Nabu.CORE.Entities.Workflow.State();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[State_Insert]");
                try
                {
                    pState.Detail = base.InsertTranslation(pState.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pState.Detail.TranslationID));
                    SqlParameter stateID = sqlCommand.Parameters.Add("@StateID", SqlDbType.Int);
                    stateID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    state = new Octavo.Gate.Nabu.CORE.Entities.Workflow.State((Int32)stateID.Value);
                    state.Detail = new Translation(pState.Detail.TranslationID);
                    state.Detail.Alias = pState.Detail.Alias;
                    state.Detail.Description = pState.Detail.Description;
                    state.Detail.Name = pState.Detail.Name;
                }
                catch (Exception exc)
                {
                    state.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    state.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return state;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.State Update(Octavo.Gate.Nabu.CORE.Entities.Workflow.State pState)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.State state = new Octavo.Gate.Nabu.CORE.Entities.Workflow.State();

            pState.Detail = base.UpdateTranslation(pState.Detail);

            state = new Octavo.Gate.Nabu.CORE.Entities.Workflow.State(pState.StateID);
            state.Detail = new Translation(pState.Detail.TranslationID);
            state.Detail.Alias = pState.Detail.Alias;
            state.Detail.Description = pState.Detail.Description;
            state.Detail.Name = pState.Detail.Name;

            return state;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Workflow.State Delete(Octavo.Gate.Nabu.CORE.Entities.Workflow.State pState)
        {
            Octavo.Gate.Nabu.CORE.Entities.Workflow.State state = new Octavo.Gate.Nabu.CORE.Entities.Workflow.State();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[State_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StateID", pState.StateID));

                    sqlCommand.ExecuteNonQuery();

                    state = new Octavo.Gate.Nabu.CORE.Entities.Workflow.State(pState.StateID);
                    base.DeleteAllTranslations(pState.Detail);
                }
                catch (Exception exc)
                {
                    state.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    state.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return state;
        }
    }
}
