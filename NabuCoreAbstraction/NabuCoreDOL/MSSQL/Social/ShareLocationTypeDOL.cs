using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class ShareLocationTypeDOL : BaseDOL
    {
        public ShareLocationTypeDOL() : base ()
        {
        }

        public ShareLocationTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType Get(int pShareLocationTypeID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType responseType = new Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationTypeID", pShareLocationTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        responseType = new Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType(sqlDataReader.GetInt32(0));
                        responseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    responseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType shareLocationType = new Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        shareLocationType = new Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType(sqlDataReader.GetInt32(0));
                        shareLocationType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    shareLocationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareLocationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareLocationType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType> responseTypes = new List<Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType responseType = new Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType(sqlDataReader.GetInt32(0));
                        responseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        responseTypes.Add(responseType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType responseType = new Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType();
                    responseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    responseTypes.Add(responseType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseTypes.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType Insert(Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType pShareLocationType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType responseType = new Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationType_Insert]");
                try
                {
                    pShareLocationType.Detail = base.InsertTranslation(pShareLocationType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pShareLocationType.Detail.TranslationID));
                    SqlParameter responseTypeID = sqlCommand.Parameters.Add("@ShareLocationTypeID", SqlDbType.Int);
                    responseTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    responseType = new Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType((Int32)responseTypeID.Value);
                    responseType.Detail = new Translation(pShareLocationType.Detail.TranslationID);
                    responseType.Detail.Alias = pShareLocationType.Detail.Alias;
                    responseType.Detail.Description = pShareLocationType.Detail.Description;
                    responseType.Detail.Name = pShareLocationType.Detail.Name;
                }
                catch (Exception exc)
                {
                    responseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType Update(Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType pShareLocationType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType responseType = new Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType();

            pShareLocationType.Detail = base.UpdateTranslation(pShareLocationType.Detail);

            responseType = new Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType(pShareLocationType.ShareLocationTypeID);
            responseType.Detail = new Translation(pShareLocationType.Detail.TranslationID);
            responseType.Detail.Alias = pShareLocationType.Detail.Alias;
            responseType.Detail.Description = pShareLocationType.Detail.Description;
            responseType.Detail.Name = pShareLocationType.Detail.Name;

            return responseType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType Delete(Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType pShareLocationType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType responseType = new Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocationType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationTypeID", pShareLocationType.ShareLocationTypeID));

                    sqlCommand.ExecuteNonQuery();

                    responseType = new Octavo.Gate.Nabu.CORE.Entities.Social.ShareLocationType(pShareLocationType.ShareLocationTypeID);
                    base.DeleteAllTranslations(pShareLocationType.Detail);
                }
                catch (Exception exc)
                {
                    responseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseType;
        }
    }
}

