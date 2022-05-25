using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class AssessmentProviderDOL : BaseDOL
    {
        public AssessmentProviderDOL() : base()
        {
        }

        public AssessmentProviderDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public AssessmentProvider Get(int? pAssessmentProviderID)
        {
            AssessmentProvider assessmentProvider = new AssessmentProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentProvider_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentProviderID", pAssessmentProviderID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        assessmentProvider = new AssessmentProvider(sqlDataReader.GetInt32(0));
                        assessmentProvider.ProviderReference = sqlDataReader.GetString(1);
                        assessmentProvider.Name = sqlDataReader.GetString(2);
                        assessmentProvider.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(3));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assessmentProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentProvider;
        }

        public AssessmentProvider GetByProviderReference(string pProviderReference)
        {
            AssessmentProvider assessmentProvider = new AssessmentProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentProvider_GetByProviderReference]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProviderReference", pProviderReference));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        assessmentProvider = new AssessmentProvider(sqlDataReader.GetInt32(0));
                        assessmentProvider.ProviderReference = sqlDataReader.GetString(1);
                        assessmentProvider.Name = sqlDataReader.GetString(2);
                        assessmentProvider.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(3));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assessmentProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentProvider;
        }

        public AssessmentProvider[] List()
        {
            List<AssessmentProvider> assessmentProviders = new List<AssessmentProvider>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentProvider_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AssessmentProvider assessmentProvider = new AssessmentProvider(sqlDataReader.GetInt32(0));
                        assessmentProvider.ProviderReference = sqlDataReader.GetString(1);
                        assessmentProvider.Name = sqlDataReader.GetString(2);
                        assessmentProvider.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(3));
                        assessmentProviders.Add(assessmentProvider);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssessmentProvider error = new AssessmentProvider();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assessmentProviders.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentProviders.ToArray();
        }

        public AssessmentProvider Insert(AssessmentProvider pAssessmentProvider)
        {
            AssessmentProvider assessmentProvider = new AssessmentProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentProvider_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProviderReference", pAssessmentProvider.ProviderReference));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pAssessmentProvider.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pAssessmentProvider.PartyType.PartyTypeID));
                    SqlParameter assessmentProviderID = sqlCommand.Parameters.Add("@AssessmentProviderID", SqlDbType.Int);
                    assessmentProviderID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    assessmentProvider = new AssessmentProvider((Int32)assessmentProviderID.Value);
                    assessmentProvider.ProviderReference = pAssessmentProvider.ProviderReference;
                    assessmentProvider.Name = pAssessmentProvider.Name;
                    assessmentProvider.PartyType = new Entities.Core.PartyType(pAssessmentProvider.PartyType.PartyTypeID);
                }
                catch (Exception exc)
                {
                    assessmentProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentProvider;
        }

        public AssessmentProvider Update(AssessmentProvider pAssessmentProvider)
        {
            AssessmentProvider assessmentProvider = new AssessmentProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentProvider_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentProviderID", pAssessmentProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProviderReference", pAssessmentProvider.ProviderReference));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pAssessmentProvider.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pAssessmentProvider.PartyType.PartyTypeID));

                    sqlCommand.ExecuteNonQuery();

                    assessmentProvider = new AssessmentProvider(pAssessmentProvider.PartyID);
                    assessmentProvider.ProviderReference = pAssessmentProvider.ProviderReference;
                    assessmentProvider.Name = pAssessmentProvider.Name;
                    assessmentProvider.PartyType = new Entities.Core.PartyType(pAssessmentProvider.PartyType.PartyTypeID);
                }
                catch (Exception exc)
                {
                    assessmentProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentProvider;
        }

        public AssessmentProvider Delete(AssessmentProvider pAssessmentProvider)
        {
            AssessmentProvider assessmentProvider = new AssessmentProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentProvider_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentProviderID", pAssessmentProvider.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    assessmentProvider = new AssessmentProvider(pAssessmentProvider.PartyID);
                }
                catch (Exception exc)
                {
                    assessmentProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentProvider;
        }

        public Entities.BaseBoolean Assign(int pEducationProviderID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentProvider_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProviderID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public Entities.BaseBoolean Remove(int pEducationProviderID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentProvider_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProviderID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}
