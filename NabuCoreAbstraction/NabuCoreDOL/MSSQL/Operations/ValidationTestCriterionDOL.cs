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
    public class ValidationTestCriterionDOL : BaseDOL
    {
        public ValidationTestCriterionDOL() : base ()
        {
        }

        public ValidationTestCriterionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TestCriterion Get(int pValidationTestCriteriaID)
        {
            TestCriterion validationTestCriterion = new TestCriterion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestCriteria_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestCriteriaID", pValidationTestCriteriaID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        validationTestCriterion = new TestCriterion(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(2)==false)
                            validationTestCriterion.TestCriteriaGroupID = sqlDataReader.GetInt32(2);
                        validationTestCriterion.TestCriteriaID = sqlDataReader.GetInt32(3);
                        validationTestCriterion.DisplaySequence = sqlDataReader.GetInt32(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    validationTestCriterion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTestCriterion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestCriterion;
        }


        public TestCriterion[] List(int pValidationTestTypeID)
        {
            List<TestCriterion> validationTestCriterion = new List<TestCriterion>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestCriteria_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestTypeID", pValidationTestTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TestCriterion testCriterion = new TestCriterion(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            testCriterion.TestCriteriaGroupID = sqlDataReader.GetInt32(2);
                        testCriterion.TestCriteriaID = sqlDataReader.GetInt32(3);
                        testCriterion.DisplaySequence = sqlDataReader.GetInt32(4);
                        validationTestCriterion.Add(testCriterion);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TestCriterion error = new TestCriterion();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    validationTestCriterion.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestCriterion.ToArray();
        }

        public TestCriterion Insert(TestCriterion pTestCriterion, int pValidationTestTypeID)
        {
            TestCriterion validationTestCriterion = new TestCriterion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestCriteria_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestTypeID", pValidationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaGroupID", pTestCriterion.TestCriteriaGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaID", pTestCriterion.TestCriteriaID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pTestCriterion.DisplaySequence));
                    SqlParameter validationTestCriteriaID = sqlCommand.Parameters.Add("@ValidationTestCriteriaID", SqlDbType.Int);
                    validationTestCriteriaID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    validationTestCriterion = new TestCriterion((Int32)validationTestCriteriaID.Value);
                    validationTestCriterion.TestCriteriaGroupID = pTestCriterion.TestCriteriaGroupID;
                    validationTestCriterion.TestCriteriaID = pTestCriterion.TestCriteriaID;
                    validationTestCriterion.DisplaySequence = pTestCriterion.DisplaySequence;
                }
                catch (Exception exc)
                {
                    validationTestCriterion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTestCriterion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestCriterion;
        }

        public TestCriterion Update(TestCriterion pTestCriterion, int pValidationTestTypeID)
        {
            TestCriterion validationTestCriterion = new TestCriterion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestCriteria_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestCriteriaID", pTestCriterion.TestCriterionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestTypeID", pValidationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaGroupID", pTestCriterion.TestCriteriaGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaID", pTestCriterion.TestCriteriaID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pTestCriterion.DisplaySequence));

                    sqlCommand.ExecuteNonQuery();

                    validationTestCriterion = pTestCriterion;
                }
                catch (Exception exc)
                {
                    validationTestCriterion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTestCriterion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestCriterion;
        }

        public TestCriterion Delete(TestCriterion pTestCriterion)
        {
            TestCriterion validationTestCriterion = new TestCriterion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[ValidationTestCriteria_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ValidationTestCriteriaID", pTestCriterion.TestCriterionID));

                    sqlCommand.ExecuteNonQuery();

                    validationTestCriterion = pTestCriterion;
                }
                catch (Exception exc)
                {
                    validationTestCriterion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    validationTestCriterion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return validationTestCriterion;
        }
    }
}
