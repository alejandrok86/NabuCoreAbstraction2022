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
    public class VerificationTestDOL : BaseDOL
    {
        public VerificationTestDOL() : base()
        {
        }

        public VerificationTestDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public VerificationTest Get(int pVerificationTestID)
        {
            VerificationTest verificationTest = new VerificationTest();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTest_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestID", pVerificationTestID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        verificationTest = new VerificationTest(sqlDataReader.GetInt32(0));
                        verificationTest.PartTested = new Part(sqlDataReader.GetInt32(1));
                        verificationTest.TestedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        verificationTest.TestStarted = sqlDataReader.GetDateTime(3);
                        if(sqlDataReader.IsDBNull(4)==false)
                            verificationTest.TestEnded = sqlDataReader.GetDateTime(4);
                        verificationTest.Status = new TestStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            verificationTest.Outcome = new TestOutcome(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            verificationTest.TestType = new VerificationTestType(sqlDataReader.GetInt32(7));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    verificationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTest;
        }

        public VerificationTest[] List(int pPartID)
        {
            List<VerificationTest> verificationTests = new List<VerificationTest>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTest_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        VerificationTest verificationTest = new VerificationTest(sqlDataReader.GetInt32(0));
                        verificationTest.PartTested = new Part(sqlDataReader.GetInt32(1));
                        verificationTest.TestedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        verificationTest.TestStarted = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            verificationTest.TestEnded = sqlDataReader.GetDateTime(4);
                        verificationTest.Status = new TestStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            verificationTest.Outcome = new TestOutcome(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            verificationTest.TestType = new VerificationTestType(sqlDataReader.GetInt32(7));
                        verificationTests.Add(verificationTest);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    VerificationTest verificationTest = new VerificationTest();
                    verificationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    verificationTests.Add(verificationTest);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTests.ToArray();
        }

        public VerificationTest Insert(VerificationTest pVerificationTest, int pPartID)
        {
            VerificationTest verificationTest = new VerificationTest();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTest_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestTypeID", pVerificationTest.TestType.TestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestedByPartyID", pVerificationTest.TestedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStarted", pVerificationTest.TestStarted));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestEnded", ((pVerificationTest.TestEnded.HasValue) ? pVerificationTest.TestEnded : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStatusID", pVerificationTest.Status.TestStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestOutcomeID", pVerificationTest.Outcome.TestOutcomeID));
                    SqlParameter verificationTestID = sqlCommand.Parameters.Add("@VerificationTestID", SqlDbType.Int);
                    verificationTestID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    verificationTest = new VerificationTest((Int32)verificationTestID.Value);
                    verificationTest.PartTested = new Part(pPartID);
                    verificationTest.TestedBy = pVerificationTest.TestedBy;
                    verificationTest.TestStarted = pVerificationTest.TestStarted;
                    verificationTest.TestEnded = pVerificationTest.TestEnded;
                    verificationTest.Status = pVerificationTest.Status;
                    verificationTest.Outcome = pVerificationTest.Outcome;
                    verificationTest.TestType = pVerificationTest.TestType;
                }
                catch (Exception exc)
                {
                    verificationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTest;
        }

        public VerificationTest Update(VerificationTest pVerificationTest)
        {
            VerificationTest verificationTest = new VerificationTest();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTest_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestID", pVerificationTest.TestID));
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestTypeID", pVerificationTest.TestType.TestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pVerificationTest.PartTested.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestedByPartyID", pVerificationTest.TestedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStarted", pVerificationTest.TestStarted));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestEnded", ((pVerificationTest.TestEnded.HasValue) ? pVerificationTest.TestEnded : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStatusID", pVerificationTest.Status.TestStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestOutcomeID", pVerificationTest.Outcome.TestOutcomeID));

                    sqlCommand.ExecuteNonQuery();

                    verificationTest = new VerificationTest(pVerificationTest.TestID);
                    verificationTest.PartTested = pVerificationTest.PartTested;
                    verificationTest.TestedBy = pVerificationTest.TestedBy;
                    verificationTest.TestStarted = pVerificationTest.TestStarted;
                    verificationTest.TestEnded = pVerificationTest.TestEnded;
                    verificationTest.Status = pVerificationTest.Status;
                    verificationTest.Outcome = pVerificationTest.Outcome;
                    verificationTest.TestType = pVerificationTest.TestType;
                }
                catch (Exception exc)
                {
                    verificationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTest;
        }

        public VerificationTest Delete(VerificationTest pVerificationTest)
        {
            VerificationTest verificationTest = new VerificationTest();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTest_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestID", pVerificationTest.TestID));

                    sqlCommand.ExecuteNonQuery();

                    verificationTest = new VerificationTest(pVerificationTest.TestID);
                }
                catch (Exception exc)
                {
                    verificationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTest;
        }
    }
}
