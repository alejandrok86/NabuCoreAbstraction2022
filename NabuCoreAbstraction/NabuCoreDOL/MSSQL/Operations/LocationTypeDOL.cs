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
    public class LocationTypeDOL : BaseDOL
    {
        public LocationTypeDOL() : base ()
        {
        }

        public LocationTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public LocationType Get(int pLocationTypeID, int pLanguageID)
        {
            LocationType locationType = new LocationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[LocationType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationTypeID", pLocationTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        locationType = new LocationType(sqlDataReader.GetInt32(0));
                        locationType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    locationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    locationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locationType;
        }

        public LocationType GetByAlias(string pAlias, int pLanguageID)
        {
            LocationType locationType = new LocationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[LocationType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        locationType = new LocationType(sqlDataReader.GetInt32(0));
                        locationType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    locationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    locationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locationType;
        }

        public LocationType[] List(int pLanguageID)
        {
            List<LocationType> locationTypes = new List<LocationType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[LocationType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LocationType locationType = new LocationType(sqlDataReader.GetInt32(0));
                        locationType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        locationTypes.Add(locationType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LocationType locationType = new LocationType();
                    locationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    locationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    locationTypes.Add(locationType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locationTypes.ToArray();
        }

        public LocationType Insert(LocationType pLocationType)
        {
            LocationType locationType = new LocationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[LocationType_Insert]");
                try
                {
                    pLocationType.Detail = base.InsertTranslation(pLocationType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pLocationType.Detail.TranslationID));
                    SqlParameter locationTypeID = sqlCommand.Parameters.Add("@LocationTypeID", SqlDbType.Int);
                    locationTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    locationType = new LocationType((Int32)locationTypeID.Value);
                    locationType.Detail = new Translation(pLocationType.Detail.TranslationID);
                    locationType.Detail.Alias = pLocationType.Detail.Alias;
                    locationType.Detail.Description = pLocationType.Detail.Description;
                    locationType.Detail.Name = pLocationType.Detail.Name;
                }
                catch (Exception exc)
                {
                    locationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    locationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locationType;
        }

        public LocationType Update(LocationType pLocationType)
        {
            LocationType locationType = new LocationType();

            locationType.Detail = base.UpdateTranslation(pLocationType.Detail);

            return locationType;
        }

        public LocationType Delete(LocationType pLocationType)
        {
            LocationType locationType = new LocationType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[LocationType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationTypeID", pLocationType.LocationTypeID));

                    sqlCommand.ExecuteNonQuery();

                    locationType = new LocationType(pLocationType.LocationTypeID);
                    base.DeleteAllTranslations(pLocationType.Detail);
                }
                catch (Exception exc)
                {
                    locationType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    locationType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locationType;
        }
    }
}
