using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class EducationProviderDOL : BaseDOL
    {
        public EducationProviderDOL() : base()
        {
        }

        public EducationProviderDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public EducationProvider Get(int pEducationProviderID, int pLanguageID)
        {
            EducationProvider educationProvider = new EducationProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProvider_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProviderID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        educationProvider = new EducationProvider(sqlDataReader.GetInt32(0));
                        educationProvider.Name = sqlDataReader.GetString(1);
                        educationProvider.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(2));
                        educationProvider.PartyType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(3));
                        educationProvider.PartyType.Detail.Alias = sqlDataReader.GetString(4);
                        educationProvider.PartyType.Detail.Name = sqlDataReader.GetString(5);
                        educationProvider.PartyType.Detail.Description = sqlDataReader.GetString(6);
                        educationProvider.ProviderReference = sqlDataReader.GetString(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    educationProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    educationProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return educationProvider;
        }

        public EducationProvider[] List(int pLanguageID)
        {
            List<EducationProvider> educationProviders = new List<EducationProvider>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProvider_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        EducationProvider educationProvider = new EducationProvider(sqlDataReader.GetInt32(0));
                        educationProvider.Name = sqlDataReader.GetString(1);
                        educationProvider.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(2));
                        educationProvider.PartyType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(3));
                        educationProvider.PartyType.Detail.Alias = sqlDataReader.GetString(4);
                        educationProvider.PartyType.Detail.Name = sqlDataReader.GetString(5);
                        educationProvider.PartyType.Detail.Description = sqlDataReader.GetString(6);
                        educationProvider.ProviderReference = sqlDataReader.GetString(7);
                        educationProviders.Add(educationProvider);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    EducationProvider educationProvider = new EducationProvider();
                    educationProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    educationProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    educationProviders.Add(educationProvider);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return educationProviders.ToArray();
        }

        public EducationProvider Insert(EducationProvider pEducationProvider)
        {
            EducationProvider educationProvider = new EducationProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProvider_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pEducationProvider.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pEducationProvider.PartyType.PartyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProviderReference", pEducationProvider.ProviderReference));
                    SqlParameter educationProviderID = sqlCommand.Parameters.Add("@EducationProviderID", SqlDbType.Int);
                    educationProviderID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    educationProvider = new EducationProvider((Int32)educationProviderID.Value);
                    educationProvider.Name = pEducationProvider.Name;
                    educationProvider.PartyType = new Entities.Core.PartyType(pEducationProvider.PartyType.PartyTypeID);
                    educationProvider.ProviderReference = pEducationProvider.ProviderReference;
                }
                catch (Exception exc)
                {
                    educationProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    educationProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return educationProvider;
        }

        public EducationProvider Update(EducationProvider pEducationProvider)
        {
            EducationProvider educationProvider = new EducationProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProvider_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pEducationProvider.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pEducationProvider.PartyType.PartyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProviderReference", pEducationProvider.ProviderReference));

                    sqlCommand.ExecuteNonQuery();

                    educationProvider = new EducationProvider(pEducationProvider.PartyID);
                    educationProvider.Name = pEducationProvider.Name;
                    educationProvider.PartyType = new Entities.Core.PartyType(pEducationProvider.PartyType.PartyTypeID);
                    educationProvider.ProviderReference = pEducationProvider.ProviderReference;
                }
                catch (Exception exc)
                {
                    educationProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    educationProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return educationProvider;
        }

        public EducationProvider Delete(EducationProvider pEducationProvider)
        {
            EducationProvider educationProvider = new EducationProvider();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProvider_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    educationProvider = new EducationProvider(pEducationProvider.PartyID);
                }
                catch (Exception exc)
                {
                    educationProvider.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    educationProvider.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return educationProvider;
        }

        public Entities.BaseBoolean Assign(EducationProvider pEducationProvider, Entities.Core.PartyRoleType pPartyRoleType)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProviderPartyRoleType_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleTypeID", pPartyRoleType.PartyRoleTypeID));

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
        public Entities.BaseBoolean Remove(EducationProvider pEducationProvider, Entities.Core.PartyRoleType pPartyRoleType)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProviderPartyRoleType_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleTypeID", pPartyRoleType.PartyRoleTypeID));

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
