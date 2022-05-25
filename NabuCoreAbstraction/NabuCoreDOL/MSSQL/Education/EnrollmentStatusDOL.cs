using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class EnrollmentStatusDOL : BaseDOL
    {
        public EnrollmentStatusDOL() : base()
        {
        }

        public EnrollmentStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Education.EnrollmentStatus Get(int pEnrollmentStatusID, int pLanguageID)
        {
            Entities.Education.EnrollmentStatus enrollmentStatus = new Entities.Education.EnrollmentStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EnrollmentStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EnrollmentStatusID", pEnrollmentStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        enrollmentStatus = new Entities.Education.EnrollmentStatus(sqlDataReader.GetInt32(0));
                        enrollmentStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    enrollmentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    enrollmentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollmentStatus;
        }

        public Entities.Education.EnrollmentStatus GetByAlias(string pAlias, int pLanguageID)
        {
            Entities.Education.EnrollmentStatus enrollmentStatus = new Entities.Education.EnrollmentStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EnrollmentStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        enrollmentStatus = new Entities.Education.EnrollmentStatus(sqlDataReader.GetInt32(0));
                        enrollmentStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string errorMessage = exc.Message;
                    if (exc.Message.Contains("Object reference not set to an instance of an object"))
                        errorMessage += " [" + pAlias + "] " + exc.StackTrace;
                    enrollmentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, errorMessage);

                    enrollmentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + errorMessage));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollmentStatus;
        }

        public Entities.Education.EnrollmentStatus[] List(int pLanguageID)
        {
            List<Entities.Education.EnrollmentStatus> enrollmentStatuses = new List<Entities.Education.EnrollmentStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EnrollmentStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Education.EnrollmentStatus enrollmentStatus = new Entities.Education.EnrollmentStatus(sqlDataReader.GetInt32(0));
                        enrollmentStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        enrollmentStatuses.Add(enrollmentStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.EnrollmentStatus enrollmentStatus = new Entities.Education.EnrollmentStatus();
                    enrollmentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    enrollmentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    enrollmentStatuses.Add(enrollmentStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollmentStatuses.ToArray();
        }

        public Entities.Education.EnrollmentStatus Insert(Entities.Education.EnrollmentStatus pEnrollmentStatus)
        {
            Entities.Education.EnrollmentStatus enrollmentStatus = new Entities.Education.EnrollmentStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EnrollmentStatus_Insert]");
                try
                {
                    pEnrollmentStatus.Detail = base.InsertTranslation(pEnrollmentStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pEnrollmentStatus.Detail.TranslationID));
                    SqlParameter enrollmentStatusID = sqlCommand.Parameters.Add("@EnrollmentStatusID", SqlDbType.Int);
                    enrollmentStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    enrollmentStatus = new Entities.Education.EnrollmentStatus((Int32)enrollmentStatusID.Value);
                    enrollmentStatus.Detail = new Translation(pEnrollmentStatus.Detail.TranslationID);
                    enrollmentStatus.Detail.Alias = pEnrollmentStatus.Detail.Alias;
                    enrollmentStatus.Detail.Description = pEnrollmentStatus.Detail.Description;
                    enrollmentStatus.Detail.Name = pEnrollmentStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    enrollmentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    enrollmentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollmentStatus;
        }

        public Entities.Education.EnrollmentStatus Update(Entities.Education.EnrollmentStatus pEnrollmentStatus)
        {
            Entities.Education.EnrollmentStatus enrollmentStatus = new Entities.Education.EnrollmentStatus();

            pEnrollmentStatus.Detail = base.UpdateTranslation(pEnrollmentStatus.Detail);

            enrollmentStatus = new Entities.Education.EnrollmentStatus(pEnrollmentStatus.EnrollmentStatusID);
            enrollmentStatus.Detail = new Translation(pEnrollmentStatus.Detail.TranslationID);
            enrollmentStatus.Detail.Alias = pEnrollmentStatus.Detail.Alias;
            enrollmentStatus.Detail.Description = pEnrollmentStatus.Detail.Description;
            enrollmentStatus.Detail.Name = pEnrollmentStatus.Detail.Name;

            return enrollmentStatus;
        }

        public Entities.Education.EnrollmentStatus Delete(Entities.Education.EnrollmentStatus pEnrollmentStatus)
        {
            Entities.Education.EnrollmentStatus enrollmentStatus = new Entities.Education.EnrollmentStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EnrollmentStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EnrollmentStatusID", pEnrollmentStatus.EnrollmentStatusID));

                    sqlCommand.ExecuteNonQuery();

                    enrollmentStatus = new Entities.Education.EnrollmentStatus(pEnrollmentStatus.EnrollmentStatusID);
                    base.DeleteAllTranslations(pEnrollmentStatus.Detail);
                }
                catch (Exception exc)
                {
                    enrollmentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    enrollmentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return enrollmentStatus;
        }
    }
}
