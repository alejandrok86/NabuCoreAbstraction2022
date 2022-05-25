using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class LocationDOL : BaseDOL
    {
        public LocationDOL() : base ()
        {
        }

        public LocationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Location Get(int pLocationID, int pLanguageID)
        {
            Location location = new Location();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Location_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationID", pLocationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        location = new Location(sqlDataReader.GetInt32(0));
                        location.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if(sqlDataReader.IsDBNull(2)==false)
                            location.LocationType = new LocationType(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            location.TrackingCode = new TrackingCode(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            location.ParentLocationID = sqlDataReader.GetInt32(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    location.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    location.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return location;
        }

        public Location GetForContainer(int pContainerID, int pLanguageID)
        {
            Location location = new Location();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Container_GetLocation]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContainerID", pContainerID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        location = new Location(sqlDataReader.GetInt32(0));
                        location.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            location.LocationType = new LocationType(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            location.TrackingCode = new TrackingCode(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            location.ParentLocationID = sqlDataReader.GetInt32(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            location.FacilityID = sqlDataReader.GetInt32(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    location.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    location.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return location;
        }

        public Location GetByAlias(string pAlias, int pLanguageID)
        {
            Location location = new Location();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Location_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        location = new Location(sqlDataReader.GetInt32(0));
                        location.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            location.LocationType = new LocationType(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            location.TrackingCode = new TrackingCode(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            location.ParentLocationID = sqlDataReader.GetInt32(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    location.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    location.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return location;
        }

        public Location GetByTrackingCode(string pTrackingCode, int pLanguageID)
        {
            Location location = new Location();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Location_GetByTrackingCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", pTrackingCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        location = new Location(sqlDataReader.GetInt32(0));
                        location.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            location.LocationType = new LocationType(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            location.TrackingCode = new TrackingCode(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            location.ParentLocationID = sqlDataReader.GetInt32(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    location.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    location.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return location;
        }

        public Location[] List(int pFacilityID, int pLanguageID)
        {
            List<Location> locations = new List<Location>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Location_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FacilityID", pFacilityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Location location = new Location(sqlDataReader.GetInt32(0));
                        location.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            location.LocationType = new LocationType(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            location.TrackingCode = new TrackingCode(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            location.ParentLocationID = sqlDataReader.GetInt32(4);
                        locations.Add(location);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Location location = new Location();
                    location.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    location.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    locations.Add(location);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locations.ToArray();
        }

        public Location[] List(int pLanguageID)
        {
            List<Location> locations = new List<Location>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Location_ListAll]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Location location = new Location(sqlDataReader.GetInt32(0));
                        location.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            location.LocationType = new LocationType(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            location.TrackingCode = new TrackingCode(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            location.ParentLocationID = sqlDataReader.GetInt32(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            location.FacilityID = sqlDataReader.GetInt32(5);
                        locations.Add(location);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Location location = new Location();
                    location.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    location.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    locations.Add(location);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locations.ToArray();
        }

        public Location[] ListChildren(int pLocationID, int pLanguageID)
        {
            List<Location> locations = new List<Location>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Location_ListChildren]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationID", pLocationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Location location = new Location(sqlDataReader.GetInt32(0));
                        location.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            location.LocationType = new LocationType(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            location.TrackingCode = new TrackingCode(sqlDataReader.GetInt32(3));
                        location.ParentLocationID = pLocationID;
                        locations.Add(location);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Location location = new Location();
                    location.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    location.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    locations.Add(location);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locations.ToArray();
        }

        public Location Insert(Location pLocation, int? pFacilityID)
        {
            Location location = new Location();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Location_Insert]");
                try
                {
                    pLocation.Detail = base.InsertTranslation(pLocation.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pLocation.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationTypeID", pLocation.LocationType.LocationTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TrackingCodeID", ((pLocation.TrackingCode != null && pLocation.TrackingCode.TrackingCodeID.HasValue) ? pLocation.TrackingCode.TrackingCodeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@FacilityID", ((pFacilityID.HasValue) ? pFacilityID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentLocationID", ((pLocation.ParentLocationID.HasValue) ? pLocation.ParentLocationID : null)));
                    SqlParameter locationID = sqlCommand.Parameters.Add("@LocationID", SqlDbType.Int);
                    locationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    location = new Location((Int32)locationID.Value);
                    location.Detail = new Translation(pLocation.Detail.TranslationID);
                    location.Detail.Alias = pLocation.Detail.Alias;
                    location.Detail.Description = pLocation.Detail.Description;
                    location.Detail.Name = pLocation.Detail.Name;
                    location.LocationType = pLocation.LocationType;
                    if(pLocation.TrackingCode != null)
                        location.TrackingCode = pLocation.TrackingCode;
                    if (pLocation.ParentLocationID.HasValue)
                        location.ParentLocationID = pLocation.ParentLocationID;
                }
                catch (Exception exc)
                {
                    location.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    location.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return location;
        }

        public Location Update(Location pLocation)
        {
            Location location = new Location();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Location_Update]");
                try
                {
                    pLocation.Detail = base.UpdateTranslation(pLocation.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationID", pLocation.LocationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationTypeID", pLocation.LocationType.LocationTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TrackingCodeID", ((pLocation.TrackingCode != null && pLocation.TrackingCode.TrackingCodeID.HasValue) ? pLocation.TrackingCode.TrackingCodeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentLocationID", ((pLocation.ParentLocationID.HasValue) ? pLocation.ParentLocationID : null)));

                    sqlCommand.ExecuteNonQuery();

                    location = new Location(pLocation.LocationID);
                    location.Detail = new Translation(pLocation.Detail.TranslationID);
                    location.Detail.Alias = pLocation.Detail.Alias;
                    location.Detail.Description = pLocation.Detail.Description;
                    location.Detail.Name = pLocation.Detail.Name;
                    location.LocationType = pLocation.LocationType;
                    if (pLocation.TrackingCode != null)
                        location.TrackingCode = pLocation.TrackingCode;
                    if (pLocation.ParentLocationID.HasValue)
                        location.ParentLocationID = pLocation.ParentLocationID;
                }
                catch (Exception exc)
                {
                    location.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    location.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return location;
        }

        public Location Delete(Location pLocation)
        {
            Location location = new Location();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Location_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationID", pLocation.LocationID));

                    sqlCommand.ExecuteNonQuery();

                    location = new Location(pLocation.LocationID);
                    base.DeleteAllTranslations(pLocation.Detail);
                }
                catch (Exception exc)
                {
                    location.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    location.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return location;
        }
    }
}
