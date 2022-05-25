using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces
{
    public class GeographicDetailTypeDOL : BaseDOL
    {
        public GeographicDetailTypeDOL() : base()
        {
        }

        public GeographicDetailTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public GeographicDetailType Get(int pGeographicDetailTypeID, int pLanguageID)
        {
            GeographicDetailType geographicDetailType = new GeographicDetailType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeographicDetailType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GeographicDetailTypeID", pGeographicDetailTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        geographicDetailType = new GeographicDetailType(sqlDataReader.GetInt32(0));
                        geographicDetailType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    geographicDetailType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geographicDetailType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geographicDetailType;
        }

        public GeographicDetailType GetByAlias(string pAlias, int pLanguageID)
        {
            GeographicDetailType geographicDetailType = new GeographicDetailType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeographicDetailType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        geographicDetailType = new GeographicDetailType(sqlDataReader.GetInt32(0));
                        geographicDetailType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    geographicDetailType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geographicDetailType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geographicDetailType;
        }

        public GeographicDetailType[] List(int pLanguageID)
        {
            List<GeographicDetailType> geographicDetailTypes = new List<GeographicDetailType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeographicDetailType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GeographicDetailType geographicDetailType = new GeographicDetailType(sqlDataReader.GetInt32(0));
                        geographicDetailType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        geographicDetailTypes.Add(geographicDetailType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    GeographicDetailType geographicDetailType = new GeographicDetailType();
                    geographicDetailType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geographicDetailType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    geographicDetailTypes.Add(geographicDetailType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geographicDetailTypes.ToArray();
        }

        public GeographicDetailType Insert(GeographicDetailType pGeographicDetailType)
        {
            GeographicDetailType geographicDetailType = new GeographicDetailType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeographicDetailType_Insert]");
                try
                {
                    pGeographicDetailType.Detail = base.InsertTranslation(pGeographicDetailType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pGeographicDetailType.Detail.TranslationID));
                    SqlParameter geographicDetailTypeID = sqlCommand.Parameters.Add("@GeographicDetailTypeID", SqlDbType.Int);
                    geographicDetailTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    geographicDetailType = new GeographicDetailType((Int32)geographicDetailTypeID.Value);
                    geographicDetailType.Detail = new Translation(pGeographicDetailType.Detail.TranslationID);
                    geographicDetailType.Detail.Alias = pGeographicDetailType.Detail.Alias;
                    geographicDetailType.Detail.Description = pGeographicDetailType.Detail.Description;
                    geographicDetailType.Detail.Name = pGeographicDetailType.Detail.Name;
                }
                catch (Exception exc)
                {
                    geographicDetailType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geographicDetailType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geographicDetailType;
        }

        public GeographicDetailType Update(GeographicDetailType pGeographicDetailType)
        {
            GeographicDetailType geographicDetailType = new GeographicDetailType();

            pGeographicDetailType.Detail = base.UpdateTranslation(pGeographicDetailType.Detail);

            geographicDetailType = new GeographicDetailType(pGeographicDetailType.GeographicDetailTypeID);
            geographicDetailType.Detail = new Translation(pGeographicDetailType.Detail.TranslationID);
            geographicDetailType.Detail.Alias = pGeographicDetailType.Detail.Alias;
            geographicDetailType.Detail.Description = pGeographicDetailType.Detail.Description;
            geographicDetailType.Detail.Name = pGeographicDetailType.Detail.Name;

            return geographicDetailType;
        }

        public GeographicDetailType Delete(GeographicDetailType pGeographicDetailType)
        {
            GeographicDetailType geographicDetailType = new GeographicDetailType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeographicDetailType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GeographicDetailTypeID", pGeographicDetailType.GeographicDetailTypeID));

                    sqlCommand.ExecuteNonQuery();

                    geographicDetailType = new GeographicDetailType(pGeographicDetailType.GeographicDetailTypeID);
                    base.DeleteAllTranslations(pGeographicDetailType.Detail);
                }
                catch (Exception exc)
                {
                    geographicDetailType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geographicDetailType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geographicDetailType;
        }
    }
}
