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
    public class TestCriteriaDOL : BaseDOL
    {
        public TestCriteriaDOL() : base()
        {
        }

        public TestCriteriaDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public TestCriteria Get(int? pTestCriteriaID, int pLanguageID)
        {
            TestCriteria testCriteria = new TestCriteria();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestCriteria_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaID", pTestCriteriaID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        testCriteria = new TestCriteria(sqlDataReader.GetInt32(0));
                        testCriteria.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        testCriteria.DataType = new FeatureDataType(sqlDataReader.GetInt32(2));
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    testCriteria.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testCriteria.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testCriteria;
        }

        public TestCriteria GetByAlias(string pAlias, int pLanguageID)
        {
            TestCriteria testCriteria = new TestCriteria();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestCriteria_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        testCriteria = new TestCriteria(sqlDataReader.GetInt32(0));
                        testCriteria.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        testCriteria.DataType = new FeatureDataType(sqlDataReader.GetInt32(2));
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    testCriteria.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testCriteria.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testCriteria;
        }

        public TestCriteria[] List(int pLanguageID)
        {
            List<TestCriteria> testCriterias = new List<TestCriteria>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestCriteria_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TestCriteria testCriteria = new TestCriteria(sqlDataReader.GetInt32(0));
                        testCriteria.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        testCriteria.DataType = new FeatureDataType(sqlDataReader.GetInt32(2));
                        testCriterias.Add(testCriteria);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TestCriteria testCriteria = new TestCriteria();
                    testCriteria.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testCriteria.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    testCriterias.Add(testCriteria);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testCriterias.ToArray();
        }

        public TestCriteria Insert(TestCriteria pTestCriteria)
        {
            TestCriteria testCriteria = new TestCriteria();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestCriteria_Insert]");
                try
                {
                    pTestCriteria.Detail = base.InsertTranslation(pTestCriteria.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTestCriteria.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FeatureDataTypeID", pTestCriteria.DataType.FeatureDataTypeID));
                    SqlParameter testCriteriaID = sqlCommand.Parameters.Add("@TestCriteriaID", SqlDbType.Int);
                    testCriteriaID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    testCriteria = new TestCriteria((Int32)testCriteriaID.Value);
                    testCriteria.Detail = new Translation(pTestCriteria.Detail.TranslationID);
                    testCriteria.Detail.Alias = pTestCriteria.Detail.Alias;
                    testCriteria.Detail.Description = pTestCriteria.Detail.Description;
                    testCriteria.Detail.Name = pTestCriteria.Detail.Name;
                    testCriteria.DataType = pTestCriteria.DataType;
                }
                catch (Exception exc)
                {
                    testCriteria.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testCriteria.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testCriteria;
        }

        public TestCriteria Update(TestCriteria pTestCriteria)
        {
            TestCriteria testCriteria = new TestCriteria();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestCriteria_Update]");
                try
                {
                    testCriteria.Detail = base.UpdateTranslation(pTestCriteria.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaID", pTestCriteria.TestCriteriaID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FeatureDataTypeID", pTestCriteria.DataType.FeatureDataTypeID));

                    sqlCommand.ExecuteNonQuery();

                    testCriteria = new TestCriteria(pTestCriteria.TestCriteriaID);
                    testCriteria.Detail = new Translation(pTestCriteria.Detail.TranslationID);
                    testCriteria.Detail.Alias = pTestCriteria.Detail.Alias;
                    testCriteria.Detail.Description = pTestCriteria.Detail.Description;
                    testCriteria.Detail.Name = pTestCriteria.Detail.Name;
                    testCriteria.DataType = pTestCriteria.DataType;
                }
                catch (Exception exc)
                {
                    testCriteria.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testCriteria.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testCriteria;
        }

        public TestCriteria Delete(TestCriteria pTestCriteria)
        {
            TestCriteria testCriteria = new TestCriteria();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestCriteria_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaID", pTestCriteria.TestCriteriaID));

                    sqlCommand.ExecuteNonQuery();

                    testCriteria = new TestCriteria(pTestCriteria.TestCriteriaID);
                    base.DeleteAllTranslations(pTestCriteria.Detail);
                }
                catch (Exception exc)
                {
                    testCriteria.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testCriteria.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testCriteria;
        }
    }
}
