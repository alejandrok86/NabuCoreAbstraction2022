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
    public class PostalCodeDOL : BaseDOL
    {
        public PostalCodeDOL() : base()
        {
        }

        public PostalCodeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PostalCode Get(int pPostalCodeID, int pLanguageID)
        {
            PostalCode postalCode = new PostalCode();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PostalCode_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostalCodeID", pPostalCodeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        postalCode = new PostalCode(sqlDataReader.GetInt32(0));
                        postalCode.City = new City(sqlDataReader.GetInt32(1));
                        postalCode.PostCode = sqlDataReader.GetString(2);
                        postalCode.PostalTown = sqlDataReader.GetString(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    postalCode.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    postalCode.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return postalCode;
        }

        public PostalCode[] List(int pCityID)
        {
            List<PostalCode> postalCodes = new List<PostalCode>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PostalCode_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CityID", pCityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PostalCode postalCode = new PostalCode(sqlDataReader.GetInt32(0));
                        postalCode.City = new City(sqlDataReader.GetInt32(1));
                        postalCode.PostCode = sqlDataReader.GetString(2);
                        postalCode.PostalTown = sqlDataReader.GetString(3);

                        postalCodes.Add(postalCode);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PostalCode postalCode = new PostalCode();
                    postalCode.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    postalCode.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    postalCodes.Add(postalCode);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return postalCodes.ToArray();
        }

        public PostalCode Insert(PostalCode pPostalCode, int pCityID)
        {
            PostalCode postalCode = new PostalCode();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PostalCode_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostalCodeID", pPostalCode.GeographicDetailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CityID", pCityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostCode", pPostalCode.PostCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostalTown", pPostalCode.PostalTown));

                    sqlCommand.ExecuteNonQuery();

                    postalCode = new PostalCode(pPostalCode.GeographicDetailID);
                    postalCode.City = new City(pPostalCode.City.GeographicDetailID);
                    postalCode.PostCode = pPostalCode.PostCode;
                    postalCode.PostalTown = pPostalCode.PostalTown;
                }
                catch (Exception exc)
                {
                    postalCode.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    postalCode.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return postalCode;
        }

        public PostalCode Update(PostalCode pPostalCode, int pCityID)
        {
            PostalCode postalCode = new PostalCode();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PostalCode_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostalCodeID", pPostalCode.GeographicDetailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CityID", pCityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostCode", pPostalCode.PostCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostalTown", pPostalCode.PostalTown));

                    sqlCommand.ExecuteNonQuery();

                    postalCode = new PostalCode(pPostalCode.GeographicDetailID);
                    postalCode.City = new City(pPostalCode.City.GeographicDetailID);
                    postalCode.PostCode = pPostalCode.PostCode;
                    postalCode.PostalTown = pPostalCode.PostalTown;
                }
                catch (Exception exc)
                {
                    postalCode.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    postalCode.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return postalCode;
        }

        public PostalCode Delete(PostalCode pPostalCode)
        {
            PostalCode postalCode = new PostalCode();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PostalCode_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostalCodeID", pPostalCode.GeographicDetailID));

                    sqlCommand.ExecuteNonQuery();

                    postalCode = new PostalCode(pPostalCode.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    postalCode.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    postalCode.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return postalCode;
        }
    }
}

