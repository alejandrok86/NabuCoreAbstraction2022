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
    public class TestOutcomeDOL : BaseDOL
    {
        public TestOutcomeDOL() : base()
        {
        }

        public TestOutcomeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public TestOutcome Get(int? pTestOutcomeID, int pLanguageID)
        {
            TestOutcome testOutcome = new TestOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestOutcome_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestOutcomeID", pTestOutcomeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        testOutcome = new TestOutcome(sqlDataReader.GetInt32(0));
                        testOutcome.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    testOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testOutcome;
        }

        public TestOutcome GetByAlias(string pAlias, int pLanguageID)
        {
            TestOutcome testOutcome = new TestOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestOutcome_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        testOutcome = new TestOutcome(sqlDataReader.GetInt32(0));
                        testOutcome.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    testOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testOutcome;
        }

        public TestOutcome[] List(int pLanguageID)
        {
            List<TestOutcome> testOutcomes = new List<TestOutcome>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestOutcome_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TestOutcome testOutcome = new TestOutcome(sqlDataReader.GetInt32(0));
                        testOutcome.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        testOutcomes.Add(testOutcome);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TestOutcome testOutcome = new TestOutcome();
                    testOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    testOutcomes.Add(testOutcome);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testOutcomes.ToArray();
        }

        public TestOutcome Insert(TestOutcome pTestOutcome)
        {
            TestOutcome testOutcome = new TestOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestOutcome_Insert]");
                try
                {
                    pTestOutcome.Detail = base.InsertTranslation(pTestOutcome.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTestOutcome.Detail.TranslationID));
                    SqlParameter testOutcomeID = sqlCommand.Parameters.Add("@TestOutcomeID", SqlDbType.Int);
                    testOutcomeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    testOutcome = new TestOutcome((Int32)testOutcomeID.Value);
                    testOutcome.Detail = new Translation(pTestOutcome.Detail.TranslationID);
                    testOutcome.Detail.Alias = pTestOutcome.Detail.Alias;
                    testOutcome.Detail.Description = pTestOutcome.Detail.Description;
                    testOutcome.Detail.Name = pTestOutcome.Detail.Name;
                }
                catch (Exception exc)
                {
                    testOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testOutcome;
        }

        public TestOutcome Update(TestOutcome pTestOutcome)
        {
            TestOutcome testOutcome = new TestOutcome();

            testOutcome.Detail = base.UpdateTranslation(pTestOutcome.Detail);

            return testOutcome;
        }

        public TestOutcome Delete(TestOutcome pTestOutcome)
        {
            TestOutcome testOutcome = new TestOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestOutcome_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestOutcomeID", pTestOutcome.TestOutcomeID));

                    sqlCommand.ExecuteNonQuery();

                    testOutcome = new TestOutcome(pTestOutcome.TestOutcomeID);
                    base.DeleteAllTranslations(pTestOutcome.Detail);
                }
                catch (Exception exc)
                {
                    testOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testOutcome;
        }
    }
}
