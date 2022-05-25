using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class LearningProviderDOL : BaseDOL
    {
        public LearningProviderDOL() : base ()
        {
        }

        public LearningProviderDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public LearningProvider Get(int? pLearningProviderID)
        {
            LearningProvider learningProvider = new LearningProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningProvider_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningProviderID", pLearningProviderID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        learningProvider = new LearningProvider(sqlDataReader.GetInt32(0));
                        learningProvider.ProviderReference = sqlDataReader.GetString(1);
                        learningProvider.Name = sqlDataReader.GetString(2);
                        learningProvider.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(3));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    learningProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningProvider;
        }

        public LearningProvider GetByProviderReference(string pProviderReference)
        {
            LearningProvider learningProvider = new LearningProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningProvider_GetByProviderReference]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProviderReference", pProviderReference));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        learningProvider = new LearningProvider(sqlDataReader.GetInt32(0));
                        learningProvider.ProviderReference = sqlDataReader.GetString(1);
                        learningProvider.Name = sqlDataReader.GetString(2);
                        learningProvider.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(3));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    learningProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningProvider;
        }

        public LearningProvider[] List()
        {
            List<LearningProvider> learningProviders = new List<LearningProvider>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningProvider_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LearningProvider learningProvider = new LearningProvider(sqlDataReader.GetInt32(0));
                        learningProvider.ProviderReference = sqlDataReader.GetString(1);
                        learningProvider.Name = sqlDataReader.GetString(2);
                        learningProvider.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(3));
                        learningProviders.Add(learningProvider);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LearningProvider error = new LearningProvider();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    learningProviders.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningProviders.ToArray();
        }

        public LearningProvider Insert(LearningProvider pLearningProvider)
        {
            LearningProvider learningProvider = new LearningProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningProvider_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProviderReference", pLearningProvider.ProviderReference));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pLearningProvider.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pLearningProvider.PartyType.PartyTypeID));
                    SqlParameter learningProviderID = sqlCommand.Parameters.Add("@LearningProviderID", SqlDbType.Int);
                    learningProviderID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    learningProvider = new LearningProvider((Int32)learningProviderID.Value);
                    learningProvider.ProviderReference = pLearningProvider.ProviderReference;
                    learningProvider.Name = pLearningProvider.Name;
                    learningProvider.PartyType = new Entities.Core.PartyType(pLearningProvider.PartyType.PartyTypeID);
                }
                catch (Exception exc)
                {
                    learningProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningProvider;
        }

        public LearningProvider Update(LearningProvider pLearningProvider)
        {
            LearningProvider learningProvider = new LearningProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningProvider_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningProviderID", pLearningProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProviderReference", pLearningProvider.ProviderReference));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pLearningProvider.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pLearningProvider.PartyType.PartyTypeID));

                    sqlCommand.ExecuteNonQuery();

                    learningProvider = new LearningProvider(pLearningProvider.PartyID);
                    learningProvider.ProviderReference = pLearningProvider.ProviderReference;
                    learningProvider.Name = pLearningProvider.Name;
                    learningProvider.PartyType = new Entities.Core.PartyType(pLearningProvider.PartyType.PartyTypeID);
                }
                catch (Exception exc)
                {
                    learningProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningProvider;
        }

        public LearningProvider Delete(LearningProvider pLearningProvider)
        {
            LearningProvider learningProvider = new LearningProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningProvider_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningProviderID", pLearningProvider.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    learningProvider = new LearningProvider(pLearningProvider.PartyID);
                }
                catch (Exception exc)
                {
                    learningProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningProvider;
        }

        public Entities.BaseBoolean Assign(int pEducationProviderID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningProvider_Assign]");
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
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningProvider_Remove]");
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
