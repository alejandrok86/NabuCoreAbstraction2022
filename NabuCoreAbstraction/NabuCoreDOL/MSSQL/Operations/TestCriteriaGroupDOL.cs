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
    public class TestCriteriaGroupDOL : BaseDOL
    {
        public TestCriteriaGroupDOL() : base()
        {
        }

        public TestCriteriaGroupDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public TestCriteriaGroup Get(int? pTestCriteriaGroupID, int pLanguageID)
        {
            TestCriteriaGroup testCriteriaGroup = new TestCriteriaGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestCriteriaGroup_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaGroupID", pTestCriteriaGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        testCriteriaGroup = new TestCriteriaGroup(sqlDataReader.GetInt32(0));
                        testCriteriaGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        testCriteriaGroup.DisplaySequence = sqlDataReader.GetInt32(2);
                        testCriteriaGroup.IsMultipleLineGroup = sqlDataReader.GetBoolean(3);
                        if(sqlDataReader.IsDBNull(4))
                            testCriteriaGroup.MaximumLines = sqlDataReader.GetInt32(0);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    testCriteriaGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testCriteriaGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testCriteriaGroup;
        }

        public TestCriteriaGroup GetByAlias(string pAlias, int pLanguageID)
        {
            TestCriteriaGroup testCriteriaGroup = new TestCriteriaGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestCriteriaGroup_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        testCriteriaGroup = new TestCriteriaGroup(sqlDataReader.GetInt32(0));
                        testCriteriaGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        testCriteriaGroup.DisplaySequence = sqlDataReader.GetInt32(2);
                        testCriteriaGroup.IsMultipleLineGroup = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4))
                            testCriteriaGroup.MaximumLines = sqlDataReader.GetInt32(0);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    testCriteriaGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testCriteriaGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testCriteriaGroup;
        }

        public TestCriteriaGroup[] List(int pLanguageID)
        {
            List<TestCriteriaGroup> testCriteriaGroups = new List<TestCriteriaGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestCriteriaGroup_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TestCriteriaGroup testCriteriaGroup = new TestCriteriaGroup(sqlDataReader.GetInt32(0));
                        testCriteriaGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        testCriteriaGroup.DisplaySequence = sqlDataReader.GetInt32(2);
                        testCriteriaGroup.IsMultipleLineGroup = sqlDataReader.GetBoolean(3);
                        if(sqlDataReader.IsDBNull(4))
                            testCriteriaGroup.MaximumLines = sqlDataReader.GetInt32(0);
                        testCriteriaGroups.Add(testCriteriaGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TestCriteriaGroup testCriteriaGroup = new TestCriteriaGroup();
                    testCriteriaGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testCriteriaGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    testCriteriaGroups.Add(testCriteriaGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testCriteriaGroups.ToArray();
        }

        public TestCriteriaGroup Insert(TestCriteriaGroup pTestCriteriaGroup)
        {
            TestCriteriaGroup testCriteriaGroup = new TestCriteriaGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestCriteriaGroup_Insert]");
                try
                {
                    pTestCriteriaGroup.Detail = base.InsertTranslation(pTestCriteriaGroup.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTestCriteriaGroup.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pTestCriteriaGroup.DisplaySequence));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsMultipleLineGroup", pTestCriteriaGroup.IsMultipleLineGroup));
                    sqlCommand.Parameters.Add(new SqlParameter("@MaximumLines", pTestCriteriaGroup.MaximumLines));
                    SqlParameter testCriteriaGroupID = sqlCommand.Parameters.Add("@TestCriteriaGroupID", SqlDbType.Int);
                    testCriteriaGroupID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    testCriteriaGroup = new TestCriteriaGroup((Int32)testCriteriaGroupID.Value);
                    testCriteriaGroup.Detail = new Translation(pTestCriteriaGroup.Detail.TranslationID);
                    testCriteriaGroup.Detail.Alias = pTestCriteriaGroup.Detail.Alias;
                    testCriteriaGroup.Detail.Description = pTestCriteriaGroup.Detail.Description;
                    testCriteriaGroup.Detail.Name = pTestCriteriaGroup.Detail.Name;
                    testCriteriaGroup.DisplaySequence = pTestCriteriaGroup.DisplaySequence;
                    testCriteriaGroup.IsMultipleLineGroup = pTestCriteriaGroup.IsMultipleLineGroup;
                    testCriteriaGroup.MaximumLines = pTestCriteriaGroup.MaximumLines;
                }
                catch (Exception exc)
                {
                    testCriteriaGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testCriteriaGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testCriteriaGroup;
        }

        public TestCriteriaGroup Update(TestCriteriaGroup pTestCriteriaGroup)
        {
            TestCriteriaGroup testCriteriaGroup = new TestCriteriaGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestCriteriaGroup_Update]");
                try
                {
                    testCriteriaGroup.Detail = base.UpdateTranslation(pTestCriteriaGroup.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaGroupID", pTestCriteriaGroup.TestCriteriaGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pTestCriteriaGroup.DisplaySequence));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsMultipleLineGroup", pTestCriteriaGroup.IsMultipleLineGroup));
                    sqlCommand.Parameters.Add(new SqlParameter("@MaximumLines", pTestCriteriaGroup.MaximumLines));

                    sqlCommand.ExecuteNonQuery();

                    testCriteriaGroup = new TestCriteriaGroup(pTestCriteriaGroup.TestCriteriaGroupID);
                    testCriteriaGroup.Detail = new Translation(pTestCriteriaGroup.Detail.TranslationID);
                    testCriteriaGroup.Detail.Alias = pTestCriteriaGroup.Detail.Alias;
                    testCriteriaGroup.Detail.Description = pTestCriteriaGroup.Detail.Description;
                    testCriteriaGroup.Detail.Name = pTestCriteriaGroup.Detail.Name;
                    testCriteriaGroup.DisplaySequence = pTestCriteriaGroup.DisplaySequence;
                    testCriteriaGroup.IsMultipleLineGroup = pTestCriteriaGroup.IsMultipleLineGroup;
                    testCriteriaGroup.MaximumLines = pTestCriteriaGroup.MaximumLines;
                }
                catch (Exception exc)
                {
                    testCriteriaGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testCriteriaGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testCriteriaGroup;
        }

        public TestCriteriaGroup Delete(TestCriteriaGroup pTestCriteriaGroup)
        {
            TestCriteriaGroup testCriteriaGroup = new TestCriteriaGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[TestCriteriaGroup_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaGroupID", pTestCriteriaGroup.TestCriteriaGroupID));

                    sqlCommand.ExecuteNonQuery();

                    testCriteriaGroup = new TestCriteriaGroup(pTestCriteriaGroup.TestCriteriaGroupID);
                    base.DeleteAllTranslations(pTestCriteriaGroup.Detail);
                }
                catch (Exception exc)
                {
                    testCriteriaGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    testCriteriaGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return testCriteriaGroup;
        }
    }
}
