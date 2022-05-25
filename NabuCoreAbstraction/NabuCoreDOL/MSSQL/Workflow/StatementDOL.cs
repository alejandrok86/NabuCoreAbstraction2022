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
    public class StatementDOL : BaseDOL
    {
        public StatementDOL() : base()
        {
        }

        public StatementDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Statement Get(int pStatementID, int pLanguageID)
        {
            Statement statement = new Statement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Statement_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StatementID", pStatementID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        statement = new Statement(sqlDataReader.GetInt32(0));
                        statement.State = new State(sqlDataReader.GetInt32(1));
                        statement.State.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        statement.Action = new Octavo.Gate.Nabu.CORE.Entities.Workflow.Action(sqlDataReader.GetInt32(3));
                        statement.Action.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        statement.NextActivityStep = new ActivityStep(sqlDataReader.GetInt32(5));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    statement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    statement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return statement;
        }

        public Statement[] List(int pActivityStepID, int pLanguageID)
        {
            List<Statement> statements = new List<Statement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Statement_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityStepID", pActivityStepID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Statement statement = new Statement(sqlDataReader.GetInt32(0));
                        statement.State = new State(sqlDataReader.GetInt32(1));
                        statement.State.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        statement.Action = new Octavo.Gate.Nabu.CORE.Entities.Workflow.Action(sqlDataReader.GetInt32(3));
                        statement.Action.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        statement.NextActivityStep = new ActivityStep(sqlDataReader.GetInt32(5));
                        statements.Add(statement);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Statement statement = new Statement();
                    statement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    statement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    statements.Add(statement);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return statements.ToArray();
        }

        public Statement Insert(Statement pStatement, int? pActivityStepID)
        {
            Statement statement = new Statement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Statement_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityStepID", pActivityStepID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StateID", pStatement.State.StateID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionID", pStatement.Action.ActionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@NextActivityStepID", ((pStatement.NextActivityStep != null)?pStatement.NextActivityStep.ActivityStepID : null)));
                    SqlParameter statementID = sqlCommand.Parameters.Add("@StatementID", SqlDbType.Int);
                    statementID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    statement = new Statement((Int32)statementID.Value);
                    statement.Action = new Entities.Workflow.Action(pStatement.Action.ActionID);
                    statement.Action.Detail = new Translation(pStatement.Action.Detail.TranslationID);
                    statement.Action.Detail.Alias = pStatement.Action.Detail.Alias;
                    statement.State = new Entities.Workflow.State(pStatement.State.StateID);
                    statement.State.Detail = new Translation(pStatement.State.Detail.TranslationID);
                    statement.State.Detail.Alias = pStatement.State.Detail.Alias;
                    if (pStatement.NextActivityStep != null)
                        statement.NextActivityStep = new ActivityStep(pStatement.NextActivityStep.ActivityStepID);
                }
                catch (Exception exc)
                {
                    statement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    statement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return statement;
        }

        public Statement Update(Statement pStatement, int? pActivityStepID)
        {
            Statement statement = new Statement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Statement_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StatementID", pStatement.StatementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActivityStepID", pActivityStepID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StateID", pStatement.State.StateID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionID", pStatement.Action.ActionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@NextActivityStepID", ((pStatement.NextActivityStep != null) ? pStatement.NextActivityStep.ActivityStepID : null)));

                    sqlCommand.ExecuteNonQuery();

                    statement = new Statement(pStatement.StatementID);
                    statement.Action = new Entities.Workflow.Action(pStatement.Action.ActionID);
                    statement.Action.Detail = new Translation(pStatement.Action.Detail.TranslationID);
                    statement.Action.Detail.Alias = pStatement.Action.Detail.Alias;
                    statement.State = new Entities.Workflow.State(pStatement.State.StateID);
                    statement.State.Detail = new Translation(pStatement.State.Detail.TranslationID);
                    statement.State.Detail.Alias = pStatement.State.Detail.Alias;
                    if (pStatement.NextActivityStep != null)
                        statement.NextActivityStep = new ActivityStep(pStatement.NextActivityStep.ActivityStepID);
                }
                catch (Exception exc)
                {
                    statement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    statement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return statement;
        }

        public Statement Delete(Statement pStatement)
        {
            Statement statement = new Statement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchWorkflow].[Statement_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StatementID", pStatement.StatementID));

                    sqlCommand.ExecuteNonQuery();

                    statement = new Statement(pStatement.StatementID);
                }
                catch (Exception exc)
                {
                    statement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    statement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return statement;
        }
    }
}
