using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class StatementDOL : BaseDOL
    {
        public StatementDOL() : base()
        {
        }

        public StatementDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Statement Get(int pStatementID)
        {
            Statement statement = new Statement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Statement_Get]");
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
                        statement.Status = new StatementStatus(sqlDataReader.GetInt32(1));
                        statement.StatementDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            statement.FromDate = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            statement.ToDate = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            statement.OpeningBalance = sqlDataReader.GetDecimal(5);
                        if (sqlDataReader.IsDBNull(5) == false)
                            statement.ClosingBalance = sqlDataReader.GetDecimal(6);
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

        public Statement[] List(int pAccountID)
        {
            List<Statement> statements = new List<Statement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Statement_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Statement statement = new Statement(sqlDataReader.GetInt32(0));
                        statement.Status = new StatementStatus(sqlDataReader.GetInt32(1));
                        statement.StatementDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            statement.FromDate = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            statement.ToDate = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            statement.OpeningBalance = sqlDataReader.GetDecimal(5);
                        if (sqlDataReader.IsDBNull(5) == false)
                            statement.ClosingBalance = sqlDataReader.GetDecimal(6);

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

        public Statement Insert(Statement pStatement, int pAccountID)
        {
            Statement statement = new Statement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Statement_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatementStatusID", pStatement.Status.StatementStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatementDate", pStatement.StatementDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pStatement.FromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", pStatement.ToDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@OpeningBalance", pStatement.OpeningBalance));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClosingBalance", pStatement.ClosingBalance));
                    SqlParameter statementID = sqlCommand.Parameters.Add("@StatementID", SqlDbType.Int);
                    statementID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    statement = new Statement((Int32)statementID.Value);
                    statement.Status = pStatement.Status;
                    statement.StatementDate = pStatement.StatementDate;
                    statement.FromDate = pStatement.FromDate;
                    statement.ToDate = pStatement.ToDate;
                    statement.OpeningBalance = pStatement.OpeningBalance;
                    statement.ClosingBalance = pStatement.ClosingBalance;
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

        public Statement Update(Statement pStatement)
        {
            Statement statement = new Statement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Statement_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StatementID", pStatement.StatementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatementStatusID", pStatement.Status.StatementStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatementDate", pStatement.StatementDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pStatement.FromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", pStatement.ToDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@OpeningBalance", pStatement.OpeningBalance));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClosingBalance", pStatement.ClosingBalance));

                    sqlCommand.ExecuteNonQuery();

                    statement = new Statement(pStatement.StatementID);
                    statement.Status = pStatement.Status;
                    statement.StatementDate = pStatement.StatementDate;
                    statement.FromDate = pStatement.FromDate;
                    statement.ToDate = pStatement.ToDate;
                    statement.OpeningBalance = pStatement.OpeningBalance;
                    statement.ClosingBalance = pStatement.ClosingBalance;
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
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Statement_Delete]");
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
