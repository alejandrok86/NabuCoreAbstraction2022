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
    public class GeoPhysicalLocationDOL : BaseDOL
    {
        public GeoPhysicalLocationDOL() : base()
        {
        }

        public GeoPhysicalLocationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public GeoPhysicalLocation Get(int pGeoPhysicalLocationID, int pLanguageID)
        {
            GeoPhysicalLocation geoPhysicalLocation = new GeoPhysicalLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeoPhysicalLocation_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GeoPhysicalLocationID", pGeoPhysicalLocationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        geoPhysicalLocation = new GeoPhysicalLocation(sqlDataReader.GetInt32(0));
                        geoPhysicalLocation.Easting = sqlDataReader.GetDecimal(1);
                        geoPhysicalLocation.Northing = sqlDataReader.GetDecimal(2);
                        geoPhysicalLocation.Latitude = sqlDataReader.GetDecimal(3);
                        geoPhysicalLocation.Longitude = sqlDataReader.GetDecimal(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    geoPhysicalLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geoPhysicalLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geoPhysicalLocation;
        }

        public GeoPhysicalLocation GetByLatitudeLongitude(decimal pLatitude, decimal pLongitude)
        {
            GeoPhysicalLocation geoPhysicalLocation = new GeoPhysicalLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeoPhysicalLocation_GetByLatitudeLongitude]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Latitude", pLatitude));
                    sqlCommand.Parameters.Add(new SqlParameter("@Longitude", pLongitude));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        geoPhysicalLocation = new GeoPhysicalLocation(sqlDataReader.GetInt32(0));
                        geoPhysicalLocation.Easting = sqlDataReader.GetDecimal(1);
                        geoPhysicalLocation.Northing = sqlDataReader.GetDecimal(2);
                        geoPhysicalLocation.Latitude = sqlDataReader.GetDecimal(3);
                        geoPhysicalLocation.Longitude = sqlDataReader.GetDecimal(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    geoPhysicalLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geoPhysicalLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geoPhysicalLocation;
        }

        public GeoPhysicalLocation Insert(GeoPhysicalLocation pGeoPhysicalLocation)
        {
            GeoPhysicalLocation geoPhysicalLocation = new GeoPhysicalLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeoPhysicalLocation_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GeoPhysicalLocationID", pGeoPhysicalLocation.GeographicDetailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Easting", pGeoPhysicalLocation.Easting));
                    sqlCommand.Parameters.Add(new SqlParameter("@Northing", pGeoPhysicalLocation.Northing));
                    sqlCommand.Parameters.Add(new SqlParameter("@Latitude", pGeoPhysicalLocation.Latitude));
                    sqlCommand.Parameters.Add(new SqlParameter("@Longitude", pGeoPhysicalLocation.Longitude));

                    sqlCommand.ExecuteNonQuery();

                    geoPhysicalLocation = new GeoPhysicalLocation(pGeoPhysicalLocation.GeographicDetailID);
                    geoPhysicalLocation.Easting = pGeoPhysicalLocation.Easting;
                    geoPhysicalLocation.Northing = pGeoPhysicalLocation.Northing;
                    geoPhysicalLocation.Latitude = pGeoPhysicalLocation.Latitude;
                    geoPhysicalLocation.Longitude = pGeoPhysicalLocation.Longitude;
                }
                catch (Exception exc)
                {
                    geoPhysicalLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geoPhysicalLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geoPhysicalLocation;
        }

        public GeoPhysicalLocation Update(GeoPhysicalLocation pGeoPhysicalLocation)
        {
            GeoPhysicalLocation geoPhysicalLocation = new GeoPhysicalLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeoPhysicalLocation_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GeoPhysicalLocationID", pGeoPhysicalLocation.GeographicDetailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Easting", pGeoPhysicalLocation.Easting));
                    sqlCommand.Parameters.Add(new SqlParameter("@Northing", pGeoPhysicalLocation.Northing));
                    sqlCommand.Parameters.Add(new SqlParameter("@Latitude", pGeoPhysicalLocation.Latitude));
                    sqlCommand.Parameters.Add(new SqlParameter("@Longitude", pGeoPhysicalLocation.Longitude));

                    sqlCommand.ExecuteNonQuery();

                    geoPhysicalLocation = new GeoPhysicalLocation(pGeoPhysicalLocation.GeographicDetailID);
                    geoPhysicalLocation.Easting = pGeoPhysicalLocation.Easting;
                    geoPhysicalLocation.Northing = pGeoPhysicalLocation.Northing;
                    geoPhysicalLocation.Latitude = pGeoPhysicalLocation.Latitude;
                    geoPhysicalLocation.Longitude = pGeoPhysicalLocation.Longitude;
                }
                catch (Exception exc)
                {
                    geoPhysicalLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geoPhysicalLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geoPhysicalLocation;
        }

        public GeoPhysicalLocation Delete(GeoPhysicalLocation pGeoPhysicalLocation)
        {
            GeoPhysicalLocation geoPhysicalLocation = new GeoPhysicalLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[GeoPhysicalLocation_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GeoPhysicalLocationID", pGeoPhysicalLocation.GeographicDetailID));

                    sqlCommand.ExecuteNonQuery();

                    geoPhysicalLocation = new GeoPhysicalLocation(pGeoPhysicalLocation.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    geoPhysicalLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    geoPhysicalLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return geoPhysicalLocation;
        }
    }
}

