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
    public class CalibrationTestDOL : BaseDOL
    {
        public CalibrationTestDOL() : base()
        {
        }

        public CalibrationTestDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public CalibrationTest Get(int pCalibrationTestID)
        {
            CalibrationTest calibrationTest = new CalibrationTest();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTest_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestID", pCalibrationTestID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        calibrationTest = new CalibrationTest(sqlDataReader.GetInt32(0));
                        calibrationTest.PartTested = new Part(sqlDataReader.GetInt32(1));
                        calibrationTest.TestedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        calibrationTest.TestStarted = sqlDataReader.GetDateTime(3);
                        if(sqlDataReader.IsDBNull(4)==false)
                            calibrationTest.TestEnded = sqlDataReader.GetDateTime(4);
                        calibrationTest.Status = new TestStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            calibrationTest.Outcome = new TestOutcome(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            calibrationTest.TestType = new CalibrationTestType(sqlDataReader.GetInt32(7));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    calibrationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTest;
        }

        public CalibrationTest[] List(int pPartID)
        {
            List<CalibrationTest> calibrationTests = new List<CalibrationTest>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTest_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        CalibrationTest calibrationTest = new CalibrationTest(sqlDataReader.GetInt32(0));
                        calibrationTest.PartTested = new Part(sqlDataReader.GetInt32(1));
                        calibrationTest.TestedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        calibrationTest.TestStarted = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            calibrationTest.TestEnded = sqlDataReader.GetDateTime(4);
                        calibrationTest.Status = new TestStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            calibrationTest.Outcome = new TestOutcome(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            calibrationTest.TestType = new CalibrationTestType(sqlDataReader.GetInt32(7));
                        calibrationTests.Add(calibrationTest);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    CalibrationTest calibrationTest = new CalibrationTest();
                    calibrationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    calibrationTests.Add(calibrationTest);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTests.ToArray();
        }

        public CalibrationTest Insert(CalibrationTest pCalibrationTest, int pPartID)
        {
            CalibrationTest calibrationTest = new CalibrationTest();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTest_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestTypeID", pCalibrationTest.TestType.TestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestedByPartyID", pCalibrationTest.TestedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStarted", pCalibrationTest.TestStarted));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestEnded", ((pCalibrationTest.TestEnded.HasValue) ? pCalibrationTest.TestEnded : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStatusID", pCalibrationTest.Status.TestStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestOutcomeID", pCalibrationTest.Outcome.TestOutcomeID));
                    SqlParameter calibrationTestID = sqlCommand.Parameters.Add("@CalibrationTestID", SqlDbType.Int);
                    calibrationTestID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    calibrationTest = new CalibrationTest((Int32)calibrationTestID.Value);
                    calibrationTest.PartTested = new Part(pPartID);
                    calibrationTest.TestedBy = pCalibrationTest.TestedBy;
                    calibrationTest.TestStarted = pCalibrationTest.TestStarted;
                    calibrationTest.TestEnded = pCalibrationTest.TestEnded;
                    calibrationTest.Status = pCalibrationTest.Status;
                    calibrationTest.Outcome = pCalibrationTest.Outcome;
                    calibrationTest.TestType = pCalibrationTest.TestType;
                }
                catch (Exception exc)
                {
                    calibrationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTest;
        }

        public CalibrationTest Update(CalibrationTest pCalibrationTest)
        {
            CalibrationTest calibrationTest = new CalibrationTest();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTest_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestID", pCalibrationTest.TestID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestTypeID", pCalibrationTest.TestType.TestTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pCalibrationTest.PartTested.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestedByPartyID", pCalibrationTest.TestedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStarted", pCalibrationTest.TestStarted));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestEnded", ((pCalibrationTest.TestEnded.HasValue) ? pCalibrationTest.TestEnded : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestStatusID", pCalibrationTest.Status.TestStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TestOutcomeID", pCalibrationTest.Outcome.TestOutcomeID));

                    sqlCommand.ExecuteNonQuery();

                    calibrationTest = new CalibrationTest(pCalibrationTest.TestID);
                    calibrationTest.PartTested = pCalibrationTest.PartTested;
                    calibrationTest.TestedBy = pCalibrationTest.TestedBy;
                    calibrationTest.TestStarted = pCalibrationTest.TestStarted;
                    calibrationTest.TestEnded = pCalibrationTest.TestEnded;
                    calibrationTest.Status = pCalibrationTest.Status;
                    calibrationTest.Outcome = pCalibrationTest.Outcome;
                    calibrationTest.TestType = pCalibrationTest.TestType;
                }
                catch (Exception exc)
                {
                    calibrationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTest;
        }

        public CalibrationTest Delete(CalibrationTest pCalibrationTest)
        {
            CalibrationTest calibrationTest = new CalibrationTest();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[CalibrationTest_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CalibrationTestID", pCalibrationTest.TestID));

                    sqlCommand.ExecuteNonQuery();

                    calibrationTest = new CalibrationTest(pCalibrationTest.TestID);
                }
                catch (Exception exc)
                {
                    calibrationTest.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    calibrationTest.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return calibrationTest;
        }
    }
}
