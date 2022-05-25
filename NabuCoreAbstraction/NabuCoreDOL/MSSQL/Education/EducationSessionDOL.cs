using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class EducationSessionDOL : BaseDOL
    {
        public EducationSessionDOL() : base()
        {
        }

        public EducationSessionDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public EducationSession Get(int? pEducationSessionID)
        {
            EducationSession educationSession = new EducationSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationSession_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationSessionID", pEducationSessionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        educationSession = new EducationSession(sqlDataReader.GetInt32(0));
                        educationSession.Specification = new Specification(sqlDataReader.GetInt32(1));
                        educationSession.StartDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            educationSession.EndDate = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    educationSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    educationSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return educationSession;
        }

        public EducationSession GetBySpecification(int pSpecificationID)
        {
            EducationSession educationSession = new EducationSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationSession_GetBySpecification]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        educationSession = new EducationSession(sqlDataReader.GetInt32(0));
                        educationSession.Specification = new Specification(sqlDataReader.GetInt32(1));
                        educationSession.StartDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            educationSession.EndDate = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    educationSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    educationSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return educationSession;
        }

        public EducationSession[] List()
        {
            List<EducationSession> educationSessions = new List<EducationSession>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationSession_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        EducationSession educationSession = new EducationSession(sqlDataReader.GetInt32(0));
                        educationSession.Specification = new Specification(sqlDataReader.GetInt32(1));
                        educationSession.StartDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            educationSession.EndDate = sqlDataReader.GetDateTime(3);
                        educationSessions.Add(educationSession);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    EducationSession error = new EducationSession();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    educationSessions.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return educationSessions.ToArray();
        }

        public EducationSession[] List(Specification pSpecification)
        {
            List<EducationSession> educationSessions = new List<EducationSession>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationSession_ListForSpecification]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecification.SpecificationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        EducationSession educationSession = new EducationSession(sqlDataReader.GetInt32(0));
                        educationSession.Specification = new Specification(sqlDataReader.GetInt32(1));
                        educationSession.StartDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            educationSession.EndDate = sqlDataReader.GetDateTime(3);
                        educationSessions.Add(educationSession);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    EducationSession error = new EducationSession();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    educationSessions.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return educationSessions.ToArray();
        }

        public EducationSession Insert(EducationSession pEducationSession)
        {
            EducationSession educationSession = new EducationSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationSession_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pEducationSession.Specification.SpecificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pEducationSession.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", ((pEducationSession.EndDate.HasValue) ? pEducationSession.EndDate : null)));
                    SqlParameter educationSessionID = sqlCommand.Parameters.Add("@EducationSessionID", SqlDbType.Int);
                    educationSessionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    educationSession = new EducationSession((Int32)educationSessionID.Value);
                    educationSession.Specification = new Specification(pEducationSession.Specification.SpecificationID);
                    educationSession.StartDate = pEducationSession.StartDate;
                    if (pEducationSession.EndDate.HasValue)
                        educationSession.EndDate = pEducationSession.EndDate;
                }
                catch (Exception exc)
                {
                    educationSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    educationSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return educationSession;
        }

        public EducationSession Update(EducationSession pEducationSession)
        {
            EducationSession educationSession = new EducationSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationSession_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationSessionID", pEducationSession.EducationSessionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pEducationSession.Specification.SpecificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pEducationSession.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", ((pEducationSession.EndDate.HasValue) ? pEducationSession.EndDate : null)));

                    sqlCommand.ExecuteNonQuery();

                    educationSession = new EducationSession(pEducationSession.EducationSessionID);
                    educationSession.Specification = new Specification(pEducationSession.Specification.SpecificationID);
                    educationSession.StartDate = pEducationSession.StartDate;
                    if (pEducationSession.EndDate.HasValue)
                        educationSession.EndDate = pEducationSession.EndDate;
                }
                catch (Exception exc)
                {
                    educationSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    educationSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return educationSession;
        }

        public EducationSession Delete(EducationSession pEducationSession)
        {
            EducationSession educationSession = new EducationSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationSession_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationSessionID", pEducationSession.EducationSessionID));

                    sqlCommand.ExecuteNonQuery();

                    educationSession = new EducationSession(pEducationSession.EducationSessionID);
                }
                catch (Exception exc)
                {
                    educationSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    educationSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return educationSession;
        }
    }
}
