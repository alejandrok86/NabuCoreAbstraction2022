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
    public class CalibrationTestCriterionDOL : BaseDOL
    {
        public CalibrationTestCriterionDOL()
            : base()
        {
        }

        public CalibrationTestCriterionDOL(string pConnectionString, string pErrorLogFile)
            : base(pConnectionString, pErrorLogFile)
        {
        }

        public TestCriterion Get(int pCalibrationTestCriteriaID)
        {
            TestCriterion calibrationTestCriterion = new TestCriterion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestCriteria_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestCriteriaID", pCalibrationTestCriteriaID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        calibrationTestCriterion = new TestCriterion(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            calibrationTestCriterion.TestCriteriaGroupID = sqlDataReader.GetInt32(2);
                        calibrationTestCriterion.TestCriteriaID = sqlDataReader.GetInt32(3);
                        calibrationTestCriterion.DisplaySequence = sqlDataReader.GetInt32(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    calibrationTestCriterion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTestCriterion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestCriterion;
        }


        public TestCriterion[] List(int pCalibrationTestTypeID)
        {
            List<TestCriterion> calibrationTestCriterion = new List<TestCriterion>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestCriteria_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestTypeID", pCalibrationTestTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TestCriterion testCriterion = new TestCriterion(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            testCriterion.TestCriteriaGroupID = sqlDataReader.GetInt32(2);
                        testCriterion.TestCriteriaID = sqlDataReader.GetInt32(3);
                        testCriterion.DisplaySequence = sqlDataReader.GetInt32(4);
                        calibrationTestCriterion.Add(testCriterion);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TestCriterion error = new TestCriterion();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    calibrationTestCriterion.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestCriterion.ToArray();
        }

        public TestCriterion Insert(TestCriterion pTestCriterion, int pCalibrationTestTypeID)
        {
            TestCriterion calibrationTestCriterion = new TestCriterion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestCriteria_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestTypeID", pCalibrationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaGroupID", pTestCriterion.TestCriteriaGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaID", pTestCriterion.TestCriteriaID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pTestCriterion.DisplaySequence));
                    SqlParameter calibrationTestCriteriaID = sqlCommand.Parameters.Add("@CalibrationTestCriteriaID", SqlDbType.Int);
                    calibrationTestCriteriaID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    calibrationTestCriterion = new TestCriterion((Int32)calibrationTestCriteriaID.Value);
                    calibrationTestCriterion.TestCriteriaGroupID = pTestCriterion.TestCriteriaGroupID;
                    calibrationTestCriterion.TestCriteriaID = pTestCriterion.TestCriteriaID;
                    calibrationTestCriterion.DisplaySequence = pTestCriterion.DisplaySequence;
                }
                catch (Exception exc)
                {
                    calibrationTestCriterion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTestCriterion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestCriterion;
        }

        public TestCriterion Update(TestCriterion pTestCriterion, int pCalibrationTestTypeID)
        {
            TestCriterion calibrationTestCriterion = new TestCriterion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestCriteria_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestCriteriaID", pTestCriterion.TestCriterionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestTypeID", pCalibrationTestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaGroupID", pTestCriterion.TestCriteriaGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestCriteriaID", pTestCriterion.TestCriteriaID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pTestCriterion.DisplaySequence));

                    sqlCommand.ExecuteNonQuery();

                    calibrationTestCriterion = pTestCriterion;
                }
                catch (Exception exc)
                {
                    calibrationTestCriterion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTestCriterion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestCriterion;
        }

        public TestCriterion Delete(TestCriterion pTestCriterion)
        {
            TestCriterion calibrationTestCriterion = new TestCriterion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTestCriteria_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestCriteriaID", pTestCriterion.TestCriterionID));

                    sqlCommand.ExecuteNonQuery();

                    calibrationTestCriterion = pTestCriterion;
                }
                catch (Exception exc)
                {
                    calibrationTestCriterion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTestCriterion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTestCriterion;
        }
    }
}
