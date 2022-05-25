using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class AcademicPeriodDOL : BaseDOL
    {
        public AcademicPeriodDOL() : base()
        {
        }

        public AcademicPeriodDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public AcademicPeriod Get(int? pAcademicPeriodID)
        {
            AcademicPeriod academicPeriod = new AcademicPeriod();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicPeriod_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicPeriodID", pAcademicPeriodID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        academicPeriod = new AcademicPeriod(sqlDataReader.GetInt32(0));
                        academicPeriod.StartDate = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            academicPeriod.EndDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            academicPeriod.Description = sqlDataReader.GetString(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    academicPeriod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicPeriod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicPeriod;
        }

        public AcademicPeriod[] List(int pEducationProviderID)
        {
            List<AcademicPeriod> academicPeriods = new List<AcademicPeriod>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicPeriod_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProviderID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AcademicPeriod academicPeriod = new AcademicPeriod(sqlDataReader.GetInt32(0));
                        academicPeriod.StartDate = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            academicPeriod.EndDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            academicPeriod.Description = sqlDataReader.GetString(3);
                        academicPeriods.Add(academicPeriod);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AcademicPeriod error = new AcademicPeriod();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    academicPeriods.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicPeriods.ToArray();
        }

        public AcademicPeriod Insert(AcademicPeriod pAcademicPeriod, int pEducationProviderID)
        {
            AcademicPeriod academicPeriod = new AcademicPeriod();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicPeriod_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProviderID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pAcademicPeriod.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", ((pAcademicPeriod.EndDate.HasValue) ? pAcademicPeriod.EndDate : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pAcademicPeriod.Description));
                    SqlParameter academicPeriodID = sqlCommand.Parameters.Add("@AcademicPeriodID", SqlDbType.Int);
                    academicPeriodID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    academicPeriod = new AcademicPeriod((Int32)academicPeriodID.Value);
                    academicPeriod.StartDate = pAcademicPeriod.StartDate;
                    if (pAcademicPeriod.EndDate.HasValue)
                        academicPeriod.EndDate = pAcademicPeriod.EndDate;
                    academicPeriod.Description = pAcademicPeriod.Description;
                }
                catch (Exception exc)
                {
                    academicPeriod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicPeriod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicPeriod;
        }

        public AcademicPeriod Update(AcademicPeriod pAcademicPeriod)
        {
            AcademicPeriod academicPeriod = new AcademicPeriod();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicPeriod_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicPeriodID", pAcademicPeriod.AcademicPeriodID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pAcademicPeriod.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", ((pAcademicPeriod.EndDate.HasValue) ? pAcademicPeriod.EndDate : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pAcademicPeriod.Description));

                    sqlCommand.ExecuteNonQuery();

                    academicPeriod = new AcademicPeriod(pAcademicPeriod.AcademicPeriodID);
                    academicPeriod.StartDate = pAcademicPeriod.StartDate;
                    if (pAcademicPeriod.EndDate.HasValue)
                        academicPeriod.EndDate = pAcademicPeriod.EndDate;
                    academicPeriod.Description = pAcademicPeriod.Description;
                }
                catch (Exception exc)
                {
                    academicPeriod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicPeriod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicPeriod;
        }

        public AcademicPeriod Delete(AcademicPeriod pAcademicPeriod)
        {
            AcademicPeriod academicPeriod = new AcademicPeriod();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicPeriod_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicPeriodID", pAcademicPeriod.AcademicPeriodID));

                    sqlCommand.ExecuteNonQuery();

                    academicPeriod = new AcademicPeriod(pAcademicPeriod.AcademicPeriodID);
                }
                catch (Exception exc)
                {
                    academicPeriod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicPeriod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicPeriod;
        }
    }
}
