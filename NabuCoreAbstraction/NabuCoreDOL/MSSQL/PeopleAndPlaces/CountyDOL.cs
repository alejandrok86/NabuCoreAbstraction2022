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
    public class CountyDOL : BaseDOL
    {
        public CountyDOL() : base()
        {
        }

        public CountyDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public County Get(int pCountyID, int pLanguageID)
        {
            County county = new County();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[County_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountyID", pCountyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        county = new County(sqlDataReader.GetInt32(0));
                        county.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    county.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    county.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return county;
        }

        public County[] List(int pCountryRegionID, int pLanguageID)
        {
            List<County> countys = new List<County>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[County_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryRegionID", pCountryRegionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        County county = new County(sqlDataReader.GetInt32(0));
                        county.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);

                        countys.Add(county);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    County county = new County();
                    county.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    county.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    countys.Add(county);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return countys.ToArray();
        }

        public County Insert(County pCounty, int pCountryRegionID)
        {
            County county = new County();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[County_Insert]");
                try
                {
                    pCounty.Detail = base.InsertTranslation(pCounty.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountyID", pCounty.GeographicDetailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryRegionID", pCountryRegionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pCounty.Detail.TranslationID));

                    sqlCommand.ExecuteNonQuery();

                    county = new County(pCounty.GeographicDetailID);
                    county.Detail = new Translation(pCounty.Detail.TranslationID);
                    county.Detail.Alias = pCounty.Detail.Alias;
                    county.Detail.Description = pCounty.Detail.Description;
                    county.Detail.Name = pCounty.Detail.Name;
                }
                catch (Exception exc)
                {
                    county.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    county.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return county;
        }

        public County Update(County pCounty, int pCountryRegionID)
        {
            County county = new County();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[County_Update]");
                try
                {
                    pCounty.Detail = base.UpdateTranslation(pCounty.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountyID", pCounty.GeographicDetailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryRegionID", pCountryRegionID));

                    sqlCommand.ExecuteNonQuery();

                    county = new County(pCounty.GeographicDetailID);
                    county.Detail = new Translation(pCounty.Detail.TranslationID);
                    county.Detail.Alias = pCounty.Detail.Alias;
                    county.Detail.Description = pCounty.Detail.Description;
                    county.Detail.Name = pCounty.Detail.Name;
                }
                catch (Exception exc)
                {
                    county.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    county.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return county;
        }

        public County Delete(County pCounty)
        {
            County county = new County();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[County_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountyID", pCounty.GeographicDetailID));

                    sqlCommand.ExecuteNonQuery();

                    county = new County(pCounty.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    county.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    county.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return county;
        }
    }
}

