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
    public class TestDOL : BaseDOL
    {
        public TestDOL() : base()
        {
        }

        public TestDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Test Get(int pTestID)
        {
            Test test = new Test();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Test_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestID", pTestID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        test = new Test(sqlDataReader.GetInt32(0));
                        test.PartTested = new Part(sqlDataReader.GetInt32(1));
                        test.TestedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            test.TestStarted = sqlDataReader.GetDateTime(3);
                        if(sqlDataReader.IsDBNull(4)==false)
                            test.TestEnded = sqlDataReader.GetDateTime(4);
                        test.Status = new TestStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            test.Outcome = new TestOutcome(sqlDataReader.GetInt32(6));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    test.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    test.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return test;
        }

        public Test[] List(int pPartID)
        {
            List<Test> tests = new List<Test>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Test_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Test test = new Test(sqlDataReader.GetInt32(0));
                        test.PartTested = new Part(sqlDataReader.GetInt32(1));
                        test.TestedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            test.TestStarted = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            test.TestEnded = sqlDataReader.GetDateTime(4);
                        test.Status = new TestStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            test.Outcome = new TestOutcome(sqlDataReader.GetInt32(6));
                        tests.Add(test);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Test test = new Test();
                    test.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    test.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tests.Add(test);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tests.ToArray();
        }

        public Test Insert(Test pTest, int pPartID)
        {
            Test test = new Test();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Test_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestedByPartyID", pTest.TestedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStarted", ((pTest.TestStarted.HasValue) ? pTest.TestStarted : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestEnded", ((pTest.TestEnded.HasValue) ? pTest.TestEnded : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStatusID", pTest.Status.TestStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestOutcomeID", pTest.Outcome.TestOutcomeID));
                    SqlParameter testID = sqlCommand.Parameters.Add("@TestID", SqlDbType.Int);
                    testID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    test = new Test((Int32)testID.Value);
                    test.PartTested = new Part(pPartID);
                    test.TestedBy = pTest.TestedBy;
                    test.TestStarted = pTest.TestStarted;
                    test.TestEnded = pTest.TestEnded;
                    test.Status = pTest.Status;
                    test.Outcome = pTest.Outcome;
                }
                catch (Exception exc)
                {
                    test.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    test.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return test;
        }

        public Test Update(Test pTest)
        {
            Test test = new Test();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Test_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestID", pTest.TestID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pTest.PartTested.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestedByPartyID", pTest.TestedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStarted", ((pTest.TestStarted.HasValue) ? pTest.TestStarted : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestEnded", ((pTest.TestEnded.HasValue) ? pTest.TestEnded : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStatusID", pTest.Status.TestStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestOutcomeID", pTest.Outcome.TestOutcomeID));

                    sqlCommand.ExecuteNonQuery();

                    test = new Test(pTest.TestID);
                    test.PartTested = pTest.PartTested;
                    test.TestedBy = pTest.TestedBy;
                    test.TestStarted = pTest.TestStarted;
                    test.TestEnded = pTest.TestEnded;
                    test.Status = pTest.Status;
                    test.Outcome = pTest.Outcome;
                }
                catch (Exception exc)
                {
                    test.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    test.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return test;
        }

        public Test Delete(Test pTest)
        {
            Test test = new Test();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Test_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestID", pTest.TestID));

                    sqlCommand.ExecuteNonQuery();

                    test = new Test(pTest.TestID);
                }
                catch (Exception exc)
                {
                    test.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    test.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return test;
        }
        public Entities.BaseBoolean AssignContent(int pTestID, int pContentID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean();
            result.Value = false;
            
            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Test_AssignContent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestID", pTestID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
        public Entities.BaseBoolean RemoveContent(int pTestID, int pContentID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Test_RemoveContent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestID", pTestID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
        public Entities.BaseBoolean AssignComment(int pTestID, int pCommentID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Test_AssignComment]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestID", pTestID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentID", pCommentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
        public Entities.BaseBoolean RemoveComment(int pTestID, int pCommentID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Test_RemoveComment]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestID", pTestID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentID", pCommentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}
