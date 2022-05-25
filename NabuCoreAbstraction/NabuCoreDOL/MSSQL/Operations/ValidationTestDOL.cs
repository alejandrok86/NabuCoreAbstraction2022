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
    public class ValidationTestDOL : BaseDOL
    {
        public ValidationTestDOL() : base()
        {
        }

        public ValidationTestDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ValidationTest Get(int pValidationTestID)
        {
            ValidationTest validationTest = new ValidationTest();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTest_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestID", pValidationTestID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        validationTest = new ValidationTest(sqlDataReader.GetInt32(0));
                        validationTest.PartTested = new Part(sqlDataReader.GetInt32(1));
                        validationTest.TestedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        validationTest.TestStarted = sqlDataReader.GetDateTime(3);
                        if(sqlDataReader.IsDBNull(4)==false)
                            validationTest.TestEnded = sqlDataReader.GetDateTime(4);
                        validationTest.Status = new TestStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            validationTest.Outcome = new TestOutcome(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            validationTest.TestType = new ValidationTestType(sqlDataReader.GetInt32(7));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    validationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTest;
        }

        public ValidationTest[] List(int pPartID)
        {
            List<ValidationTest> validationTests = new List<ValidationTest>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTest_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ValidationTest validationTest = new ValidationTest(sqlDataReader.GetInt32(0));
                        validationTest.PartTested = new Part(sqlDataReader.GetInt32(1));
                        validationTest.TestedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        validationTest.TestStarted = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            validationTest.TestEnded = sqlDataReader.GetDateTime(4);
                        validationTest.Status = new TestStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            validationTest.Outcome = new TestOutcome(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            validationTest.TestType = new ValidationTestType(sqlDataReader.GetInt32(7));
                        validationTests.Add(validationTest);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ValidationTest validationTest = new ValidationTest();
                    validationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    validationTests.Add(validationTest);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTests.ToArray();
        }

        public ValidationTest Insert(ValidationTest pValidationTest, int pPartID)
        {
            ValidationTest validationTest = new ValidationTest();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTest_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestTypeID", pValidationTest.TestType.TestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestedByPartyID", pValidationTest.TestedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStarted", pValidationTest.TestStarted));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestEnded", ((pValidationTest.TestEnded.HasValue) ? pValidationTest.TestEnded : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStatusID", pValidationTest.Status.TestStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestOutcomeID", pValidationTest.Outcome.TestOutcomeID));
                    SqlParameter validationTestID = sqlCommand.Parameters.Add("@ValidationTestID", SqlDbType.Int);
                    validationTestID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    validationTest = new ValidationTest((Int32)validationTestID.Value);
                    validationTest.PartTested = new Part(pPartID);
                    validationTest.TestedBy = pValidationTest.TestedBy;
                    validationTest.TestStarted = pValidationTest.TestStarted;
                    validationTest.TestEnded = pValidationTest.TestEnded;
                    validationTest.Status = pValidationTest.Status;
                    validationTest.Outcome = pValidationTest.Outcome;
                    validationTest.TestType = pValidationTest.TestType;
                }
                catch (Exception exc)
                {
                    validationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTest;
        }

        public ValidationTest Update(ValidationTest pValidationTest)
        {
            ValidationTest validationTest = new ValidationTest();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTest_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestID", pValidationTest.TestID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestTypeID", pValidationTest.TestType.TestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pValidationTest.PartTested.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestedByPartyID", pValidationTest.TestedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStarted", pValidationTest.TestStarted));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestEnded", ((pValidationTest.TestEnded.HasValue) ? pValidationTest.TestEnded : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStatusID", pValidationTest.Status.TestStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestOutcomeID", pValidationTest.Outcome.TestOutcomeID));

                    sqlCommand.ExecuteNonQuery();

                    validationTest = new ValidationTest(pValidationTest.TestID);
                    validationTest.PartTested = pValidationTest.PartTested;
                    validationTest.TestedBy = pValidationTest.TestedBy;
                    validationTest.TestStarted = pValidationTest.TestStarted;
                    validationTest.TestEnded = pValidationTest.TestEnded;
                    validationTest.Status = pValidationTest.Status;
                    validationTest.Outcome = pValidationTest.Outcome;
                    validationTest.TestType = pValidationTest.TestType;
                }
                catch (Exception exc)
                {
                    validationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTest;
        }

        public ValidationTest Delete(ValidationTest pValidationTest)
        {
            ValidationTest validationTest = new ValidationTest();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTest_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestID", pValidationTest.TestID));

                    sqlCommand.ExecuteNonQuery();

                    validationTest = new ValidationTest(pValidationTest.TestID);
                }
                catch (Exception exc)
                {
                    validationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTest;
        }
    }
}
