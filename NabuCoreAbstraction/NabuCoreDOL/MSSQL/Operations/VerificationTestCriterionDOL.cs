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
    public class VerificationTestCriterionDOL : BaseDOL
    {
        public VerificationTestCriterionDOL()
            : base()
        {
        }

        public VerificationTestCriterionDOL(string pConnectionString, string pErrorLogFile)
            : base(pConnectionString, pErrorLogFile)
        {
        }

        public TestCriterion Get(int pVerificationTestCriteriaID)
        {
            TestCriterion verificationTestCriterion = new TestCriterion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestCriteria_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestCriteriaID", pVerificationTestCriteriaID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        verificationTestCriterion = new TestCriterion(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            verificationTestCriterion.TestCriteriaGroupID = sqlDataReader.GetInt32(2);
                        verificationTestCriterion.TestCriteriaID = sqlDataReader.GetInt32(3);
                        verificationTestCriterion.DisplaySequence = sqlDataReader.GetInt32(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    verificationTestCriterion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTestCriterion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestCriterion;
        }


        public TestCriterion[] List(int pVerificationTestTypeID)
        {
            List<TestCriterion> verificationTestCriterion = new List<TestCriterion>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestCriteria_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestTypeID", pVerificationTestTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TestCriterion testCriterion = new TestCriterion(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            testCriterion.TestCriteriaGroupID = sqlDataReader.GetInt32(2);
                        testCriterion.TestCriteriaID = sqlDataReader.GetInt32(3);
                        testCriterion.DisplaySequence = sqlDataReader.GetInt32(4);
                        verificationTestCriterion.Add(testCriterion);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TestCriterion error = new TestCriterion();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    verificationTestCriterion.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestCriterion.ToArray();
        }

        public TestCriterion Insert(TestCriterion pTestCriterion, int pVerificationTestTypeID)
        {
            TestCriterion verificationTestCriterion = new TestCriterion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestCriteria_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestTypeID", pVerificationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaGroupID", pTestCriterion.TestCriteriaGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaID", pTestCriterion.TestCriteriaID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pTestCriterion.DisplaySequence));
                    SqlParameter verificationTestCriteriaID = sqlCommand.Parameters.Add("@VerificationTestCriteriaID", SqlDbType.Int);
                    verificationTestCriteriaID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    verificationTestCriterion = new TestCriterion((Int32)verificationTestCriteriaID.Value);
                    verificationTestCriterion.TestCriteriaGroupID = pTestCriterion.TestCriteriaGroupID;
                    verificationTestCriterion.TestCriteriaID = pTestCriterion.TestCriteriaID;
                    verificationTestCriterion.DisplaySequence = pTestCriterion.DisplaySequence;
                }
                catch (Exception exc)
                {
                    verificationTestCriterion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTestCriterion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestCriterion;
        }

        public TestCriterion Update(TestCriterion pTestCriterion, int pVerificationTestTypeID)
        {
            TestCriterion verificationTestCriterion = new TestCriterion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestCriteria_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestCriteriaID", pTestCriterion.TestCriterionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestTypeID", pVerificationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaGroupID", pTestCriterion.TestCriteriaGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaID", pTestCriterion.TestCriteriaID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pTestCriterion.DisplaySequence));

                    sqlCommand.ExecuteNonQuery();

                    verificationTestCriterion = pTestCriterion;
                }
                catch (Exception exc)
                {
                    verificationTestCriterion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTestCriterion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestCriterion;
        }

        public TestCriterion Delete(TestCriterion pTestCriterion)
        {
            TestCriterion verificationTestCriterion = new TestCriterion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[VerificationTestCriteria_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@VerificationTestCriteriaID", pTestCriterion.TestCriterionID));

                    sqlCommand.ExecuteNonQuery();

                    verificationTestCriterion = pTestCriterion;
                }
                catch (Exception exc)
                {
                    verificationTestCriterion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    verificationTestCriterion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return verificationTestCriterion;
        }
    }
}
