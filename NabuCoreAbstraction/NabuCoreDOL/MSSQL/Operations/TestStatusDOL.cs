using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class TestStatusDOL : BaseDOL
    {
        public TestStatusDOL() : base ()
        {
        }

        public TestStatusDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TestStatus Get(int? pTestStatusID, int pLanguageID)
        {
            TestStatus testStatus = new TestStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStatusID", pTestStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        testStatus = new TestStatus(sqlDataReader.GetInt32(0));
                        testStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    testStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testStatus;
        }

        public TestStatus GetByAlias(string pAlias, int pLanguageID)
        {
            TestStatus testStatus = new TestStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        testStatus = new TestStatus(sqlDataReader.GetInt32(0));
                        testStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    testStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testStatus;
        }

        public TestStatus[] List(int pLanguageID)
        {
            List<TestStatus> testStatuss = new List<TestStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TestStatus testStatus = new TestStatus(sqlDataReader.GetInt32(0));
                        testStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        testStatuss.Add(testStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TestStatus testStatus = new TestStatus();
                    testStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    testStatuss.Add(testStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testStatuss.ToArray();
        }

        public TestStatus Insert(TestStatus pTestStatus)
        {
            TestStatus testStatus = new TestStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestStatus_Insert]");
                try
                {
                    pTestStatus.Detail = base.InsertTranslation(pTestStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTestStatus.Detail.TranslationID));
                    SqlParameter testStatusID = sqlCommand.Parameters.Add("@TestStatusID", SqlDbType.Int);
                    testStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    testStatus = new TestStatus((Int32)testStatusID.Value);
                    testStatus.Detail = new Translation(pTestStatus.Detail.TranslationID);
                    testStatus.Detail.Alias = pTestStatus.Detail.Alias;
                    testStatus.Detail.Description = pTestStatus.Detail.Description;
                    testStatus.Detail.Name = pTestStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    testStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testStatus;
        }

        public TestStatus Update(TestStatus pTestStatus)
        {
            TestStatus testStatus = new TestStatus();

            testStatus.Detail = base.UpdateTranslation(pTestStatus.Detail);

            return testStatus;
        }

        public TestStatus Delete(TestStatus pTestStatus)
        {
            TestStatus testStatus = new TestStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStatusID", pTestStatus.TestStatusID));

                    sqlCommand.ExecuteNonQuery();

                    testStatus = new TestStatus(pTestStatus.TestStatusID);
                    base.DeleteAllTranslations(pTestStatus.Detail);
                }
                catch (Exception exc)
                {
                    testStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testStatus;
        }
    }
}
