using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class EnrollmentDOL : BaseDOL
    {
        public EnrollmentDOL() : base()
        {
        }

        public EnrollmentDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Enrollment Get(int? pEnrollmentID)
        {
            Enrollment enrollment = new Enrollment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Enrollment_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EnrollmentID", pEnrollmentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        enrollment = new Enrollment(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            enrollment.EducationProviderID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            enrollment.LearnerID = sqlDataReader.GetInt32(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            enrollment.Period = new AcademicPeriod(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            enrollment.Stage = new AcademicStage(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            enrollment.Cycle = new AcademicCycle(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            enrollment.Level = new AcademicLevel(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            enrollment.Modality = new AcademicModality(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            enrollment.Class = new ClassGroup(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            enrollment.Status = new EnrollmentStatus(sqlDataReader.GetInt32(9));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    enrollment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    enrollment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollment;
        }

        public Enrollment[] ListByLearer(int pLearnerID)
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Enrollment_ListByLearner]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerID", pLearnerID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Enrollment enrollment = new Enrollment(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            enrollment.EducationProviderID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            enrollment.LearnerID = sqlDataReader.GetInt32(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            enrollment.Period = new AcademicPeriod(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            enrollment.Stage = new AcademicStage(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            enrollment.Cycle = new AcademicCycle(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            enrollment.Level = new AcademicLevel(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            enrollment.Modality = new AcademicModality(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            enrollment.Class = new ClassGroup(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            enrollment.Status = new EnrollmentStatus(sqlDataReader.GetInt32(9));
                        enrollments.Add(enrollment);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Enrollment error = new Enrollment();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    enrollments.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollments.ToArray();
        }

        public Enrollment[] ListByEducationProviderForPeriod(int pEducationProviderID, int pAcademicPeriodID, int pAcademicStageID)
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Enrollment_ListByEducationProviderForPeriod]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProviderID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicPeriodID", pAcademicPeriodID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Enrollment enrollment = new Enrollment(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            enrollment.EducationProviderID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            enrollment.LearnerID = sqlDataReader.GetInt32(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            enrollment.Period = new AcademicPeriod(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            enrollment.Stage = new AcademicStage(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            enrollment.Cycle = new AcademicCycle(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            enrollment.Level = new AcademicLevel(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            enrollment.Modality = new AcademicModality(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            enrollment.Class = new ClassGroup(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            enrollment.Status = new EnrollmentStatus(sqlDataReader.GetInt32(9));
                        enrollments.Add(enrollment);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Enrollment error = new Enrollment();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    enrollments.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollments.ToArray();
        }

        public Enrollment[] ListByCycle(int pEducationProviderID, int pAcademicPeriodID, int pAcademicStageID, int pAcademicCycleID)
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Enrollment_ListByCycle]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProviderID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicPeriodID", pAcademicPeriodID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicCycleID", pAcademicCycleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Enrollment enrollment = new Enrollment(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            enrollment.EducationProviderID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            enrollment.LearnerID = sqlDataReader.GetInt32(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            enrollment.Period = new AcademicPeriod(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            enrollment.Stage = new AcademicStage(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            enrollment.Cycle = new AcademicCycle(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            enrollment.Level = new AcademicLevel(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            enrollment.Modality = new AcademicModality(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            enrollment.Class = new ClassGroup(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            enrollment.Status = new EnrollmentStatus(sqlDataReader.GetInt32(9));
                        enrollments.Add(enrollment);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Enrollment error = new Enrollment();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    enrollments.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollments.ToArray();
        }

        public Enrollment[] ListByLevel(int pEducationProviderID, int pAcademicPeriodID, int pAcademicStageID, int pAcademicLevelID)
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Enrollment_ListByLevel]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProviderID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicPeriodID", pAcademicPeriodID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", pAcademicLevelID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Enrollment enrollment = new Enrollment(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            enrollment.EducationProviderID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            enrollment.LearnerID = sqlDataReader.GetInt32(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            enrollment.Period = new AcademicPeriod(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            enrollment.Stage = new AcademicStage(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            enrollment.Cycle = new AcademicCycle(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            enrollment.Level = new AcademicLevel(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            enrollment.Modality = new AcademicModality(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            enrollment.Class = new ClassGroup(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            enrollment.Status = new EnrollmentStatus(sqlDataReader.GetInt32(9));
                        enrollments.Add(enrollment);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Enrollment error = new Enrollment();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    enrollments.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollments.ToArray();
        }

        public Enrollment[] ListByModality(int pEducationProviderID, int pAcademicPeriodID, int pAcademicStageID, int pAcademicLevelID, int pAcademicModalityID)
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Enrollment_ListByModality]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProviderID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicPeriodID", pAcademicPeriodID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", pAcademicLevelID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicModalityID", pAcademicModalityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Enrollment enrollment = new Enrollment(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            enrollment.EducationProviderID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            enrollment.LearnerID = sqlDataReader.GetInt32(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            enrollment.Period = new AcademicPeriod(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            enrollment.Stage = new AcademicStage(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            enrollment.Cycle = new AcademicCycle(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            enrollment.Level = new AcademicLevel(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            enrollment.Modality = new AcademicModality(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            enrollment.Class = new ClassGroup(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            enrollment.Status = new EnrollmentStatus(sqlDataReader.GetInt32(9));
                        enrollments.Add(enrollment);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Enrollment error = new Enrollment();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    enrollments.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollments.ToArray();
        }

        public Enrollment[] ListByClass(int pEducationProviderID, int pAcademicPeriodID, int pAcademicStageID, int pAcademicLevelID, int pClassGroupID)
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Enrollment_ListByClass]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProviderID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicPeriodID", pAcademicPeriodID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", pAcademicLevelID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClassGroupID", pClassGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Enrollment enrollment = new Enrollment(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            enrollment.EducationProviderID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            enrollment.LearnerID = sqlDataReader.GetInt32(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            enrollment.Period = new AcademicPeriod(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            enrollment.Stage = new AcademicStage(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            enrollment.Cycle = new AcademicCycle(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            enrollment.Level = new AcademicLevel(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            enrollment.Modality = new AcademicModality(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            enrollment.Class = new ClassGroup(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            enrollment.Status = new EnrollmentStatus(sqlDataReader.GetInt32(9));
                        enrollments.Add(enrollment);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Enrollment error = new Enrollment();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    enrollments.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollments.ToArray();
        }

        public Enrollment Insert(Enrollment pEnrollment)
        {
            Enrollment enrollment = new Enrollment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Enrollment_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEnrollment.EducationProviderID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerID", pEnrollment.LearnerID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pEnrollment.Stage.AcademicStageID.Value));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicPeriodID", pEnrollment.Period.AcademicPeriodID.Value));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicCycleID", (pEnrollment.Cycle != null && pEnrollment.Cycle.AcademicCycleID.HasValue) ? pEnrollment.Cycle.AcademicCycleID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", (pEnrollment.Level != null && pEnrollment.Level.AcademicLevelID.HasValue) ? pEnrollment.Level.AcademicLevelID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicModalityID", (pEnrollment.Modality != null && pEnrollment.Modality.AcademicModalityID.HasValue) ? pEnrollment.Modality.AcademicModalityID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClassGroupID", (pEnrollment.Class != null && pEnrollment.Class.ClassGroupID.HasValue) ? pEnrollment.Class.ClassGroupID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@EnrollmentStatusID", (pEnrollment.Status != null && pEnrollment.Status.EnrollmentStatusID.HasValue) ? pEnrollment.Status.EnrollmentStatusID : null));
                    SqlParameter enrollmentID = sqlCommand.Parameters.Add("@EnrollmentID", SqlDbType.Int);
                    enrollmentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    enrollment = new Enrollment((Int32)enrollmentID.Value);
                    enrollment.EducationProviderID = pEnrollment.EducationProviderID;
                    enrollment.LearnerID = pEnrollment.LearnerID;
                    enrollment.Stage = pEnrollment.Stage;
                    enrollment.Period = pEnrollment.Period;
                    enrollment.Cycle = pEnrollment.Cycle;
                    enrollment.Level = pEnrollment.Level;
                    enrollment.Modality = pEnrollment.Modality;
                    enrollment.Class = pEnrollment.Class;
                    enrollment.Status = pEnrollment.Status;
                }
                catch (Exception exc)
                {
                    enrollment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    enrollment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollment;
        }

        public Enrollment Update(Enrollment pEnrollment)
        {
            Enrollment enrollment = new Enrollment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Enrollment_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EnrollmentID", pEnrollment.EnrollmentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEnrollment.EducationProviderID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerID", pEnrollment.LearnerID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pEnrollment.Stage.AcademicStageID.Value));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicPeriodID", pEnrollment.Period.AcademicPeriodID.Value));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicCycleID", (pEnrollment.Cycle != null && pEnrollment.Cycle.AcademicCycleID.HasValue) ? pEnrollment.Cycle.AcademicCycleID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", (pEnrollment.Level != null && pEnrollment.Level.AcademicLevelID.HasValue) ? pEnrollment.Level.AcademicLevelID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicModalityID", (pEnrollment.Modality != null && pEnrollment.Modality.AcademicModalityID.HasValue) ? pEnrollment.Modality.AcademicModalityID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClassGroupID", (pEnrollment.Class != null && pEnrollment.Class.ClassGroupID.HasValue) ? pEnrollment.Class.ClassGroupID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@EnrollmentStatusID", (pEnrollment.Status != null && pEnrollment.Status.EnrollmentStatusID.HasValue) ? pEnrollment.Status.EnrollmentStatusID : null));

                    sqlCommand.ExecuteNonQuery();

                    enrollment = new Enrollment(pEnrollment.EnrollmentID);
                    enrollment.EducationProviderID = pEnrollment.EducationProviderID;
                    enrollment.LearnerID = pEnrollment.LearnerID;
                    enrollment.Period = pEnrollment.Period;
                    enrollment.Cycle = pEnrollment.Cycle;
                    enrollment.Level = pEnrollment.Level;
                    enrollment.Modality = pEnrollment.Modality;
                    enrollment.Class = pEnrollment.Class;
                    enrollment.Status = pEnrollment.Status;
                }
                catch (Exception exc)
                {
                    enrollment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    enrollment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollment;
        }

        public Enrollment Delete(Enrollment pEnrollment)
        {
            Enrollment enrollment = new Enrollment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Enrollment_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EnrollmentID", pEnrollment.EnrollmentID));

                    sqlCommand.ExecuteNonQuery();

                    enrollment = new Enrollment(pEnrollment.EnrollmentID);
                }
                catch (Exception exc)
                {
                    enrollment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    enrollment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollment;
        }
    }
}
