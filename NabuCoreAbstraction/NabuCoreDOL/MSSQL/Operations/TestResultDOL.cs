using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Operations;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class TestResultDOL : BaseDOL
    {
        public TestResultDOL() : base()
        {
        }

        public TestResultDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public TestResult Get(int pTestResultID)
        {
            TestResult testResult = new TestResult();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestResult_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestResultID", pTestResultID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        testResult = new TestResult(sqlDataReader.GetInt32(0));
                        testResult.LineNumber = sqlDataReader.GetInt32(1);
                        testResult.Criteria = new TestCriteria(sqlDataReader.GetInt32(2));
                        testResult.Value = sqlDataReader.GetString(3);
                        testResult.Outcome = new TestOutcome(sqlDataReader.GetInt32(4));
                        if(sqlDataReader.IsDBNull(5)==false)
                            testResult.AnalysisFromValue = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            testResult.AnalysisToValue = sqlDataReader.GetString(6);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    testResult.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testResult.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testResult;
        }

        public TestResult[] List(int pTestID)
        {
            List<TestResult> testResults = new List<TestResult>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestResult_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TestResult testResult = new TestResult(sqlDataReader.GetInt32(0));
                        testResult.LineNumber = sqlDataReader.GetInt32(1);
                        testResult.Criteria = new TestCriteria(sqlDataReader.GetInt32(2));
                        testResult.Value = sqlDataReader.GetString(3);
                        testResult.Outcome = new TestOutcome(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            testResult.AnalysisFromValue = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            testResult.AnalysisToValue = sqlDataReader.GetString(6);
                        testResults.Add(testResult);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TestResult testResult = new TestResult();
                    testResult.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testResult.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    testResults.Add(testResult);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testResults.ToArray();
        }

        public TestResult Insert(TestResult pTestResult, int pTestID)
        {
            TestResult testResult = new TestResult();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestResult_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestID", pTestID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LineNumber", pTestResult.LineNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaID", pTestResult.Criteria.TestCriteriaID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Value", pTestResult.Value));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestOutcomeID", pTestResult.Outcome.TestOutcomeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisFromValue", pTestResult.AnalysisFromValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisToValue", pTestResult.AnalysisFromValue));
                    SqlParameter testResultID = sqlCommand.Parameters.Add("@TestResultID", SqlDbType.Int);
                    testResultID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    testResult = new TestResult((Int32)testResultID.Value);
                    testResult.LineNumber = pTestResult.LineNumber;
                    testResult.Criteria = pTestResult.Criteria;
                    testResult.Value = pTestResult.Value;
                    testResult.Outcome = pTestResult.Outcome;
                }
                catch (Exception exc)
                {
                    testResult.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testResult.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testResult;
        }

        public TestResult Update(TestResult pTestResult)
        {
            TestResult testResult = new TestResult();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestResult_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestResultID", pTestResult.TestResultID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LineNumber", pTestResult.LineNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaID", pTestResult.Criteria.TestCriteriaID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Value", pTestResult.Value));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestOutcomeID", pTestResult.Outcome.TestOutcomeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisFromValue", pTestResult.AnalysisFromValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisToValue", pTestResult.AnalysisFromValue));

                    sqlCommand.ExecuteNonQuery();

                    testResult = new TestResult(pTestResult.TestResultID);
                    testResult.LineNumber = pTestResult.LineNumber;
                    testResult.Criteria = pTestResult.Criteria;
                    testResult.Value = pTestResult.Value;
                    testResult.Outcome = pTestResult.Outcome;
                }
                catch (Exception exc)
                {
                    testResult.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testResult.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testResult;
        }

        public TestResult Delete(TestResult pTestResult)
        {
            TestResult testResult = new TestResult();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestResult_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestResultID", pTestResult.TestResultID));

                    sqlCommand.ExecuteNonQuery();

                    testResult = new TestResult(pTestResult.TestResultID);
                }
                catch (Exception exc)
                {
                    testResult.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testResult.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testResult;
        }
    }
}
