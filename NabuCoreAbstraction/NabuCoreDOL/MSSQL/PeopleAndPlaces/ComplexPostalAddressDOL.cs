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
    public class ComplexPostalAddressDOL : BaseDOL
    {
        public ComplexPostalAddressDOL() : base()
        {
        }

        public ComplexPostalAddressDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ComplexPostalAddress Get(int pPostalAddressID, int pLanguageID)
        {
            ComplexPostalAddress postalAddress = new ComplexPostalAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PostalAddress_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostalAddressID", pPostalAddressID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        postalAddress = new ComplexPostalAddress(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            postalAddress.PrimaryAddressableObjectName = new AddressableObjectName(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            postalAddress.SecondaryAddressableObjectName = new AddressableObjectName(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            postalAddress.StreetName = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            postalAddress.Locality = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            postalAddress.UniquePropertyReferenceNumber = sqlDataReader.GetDouble(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            postalAddress.UniqueStreetReferenceNumber = sqlDataReader.GetDouble(6);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    postalAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    postalAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return postalAddress;
        }

        public ComplexPostalAddress Insert(ComplexPostalAddress pPostalAddress)
        {
            ComplexPostalAddress postalAddress = new ComplexPostalAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PostalAddress_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostalAddressID", pPostalAddress.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PrimaryAddressableObjectNameID", pPostalAddress.PrimaryAddressableObjectName.AddressableObjectNameID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SecondaryAddressableObjectNameID", ((pPostalAddress.SecondaryAddressableObjectName != null) ? pPostalAddress.SecondaryAddressableObjectName.AddressableObjectNameID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@StreetName", pPostalAddress.StreetName));
                    sqlCommand.Parameters.Add(new SqlParameter("@Locality", pPostalAddress.Locality));
                    sqlCommand.Parameters.Add(new SqlParameter("@UniquePropertyReferenceNumber", pPostalAddress.UniquePropertyReferenceNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@UniqueStreetReferenceNumber", pPostalAddress.UniqueStreetReferenceNumber));

                    sqlCommand.ExecuteNonQuery();

                    postalAddress = new ComplexPostalAddress(pPostalAddress.ContactMechanismID);
                    if (pPostalAddress.PrimaryAddressableObjectName != null)
                        postalAddress.PrimaryAddressableObjectName = new AddressableObjectName(pPostalAddress.PrimaryAddressableObjectName.AddressableObjectNameID);
                    if(pPostalAddress.SecondaryAddressableObjectName != null)
                        postalAddress.SecondaryAddressableObjectName = new AddressableObjectName(pPostalAddress.SecondaryAddressableObjectName.AddressableObjectNameID);
                    postalAddress.StreetName = pPostalAddress.StreetName;
                    postalAddress.Locality = pPostalAddress.Locality;
                    postalAddress.UniquePropertyReferenceNumber = pPostalAddress.UniquePropertyReferenceNumber;
                    postalAddress.UniqueStreetReferenceNumber = pPostalAddress.UniqueStreetReferenceNumber;
                }
                catch (Exception exc)
                {
                    postalAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    postalAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return postalAddress;
        }

        public ComplexPostalAddress Update(ComplexPostalAddress pPostalAddress)
        {
            ComplexPostalAddress postalAddress = new ComplexPostalAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PostalAddress_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostalAddressID", pPostalAddress.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PrimaryAddressableObjectNameID", pPostalAddress.PrimaryAddressableObjectName.AddressableObjectNameID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SecondaryAddressableObjectNameID", ((pPostalAddress.SecondaryAddressableObjectName != null) ? pPostalAddress.SecondaryAddressableObjectName.AddressableObjectNameID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@StreetName", pPostalAddress.StreetName));
                    sqlCommand.Parameters.Add(new SqlParameter("@Locality", pPostalAddress.Locality));
                    sqlCommand.Parameters.Add(new SqlParameter("@UniquePropertyReferenceNumber", pPostalAddress.UniquePropertyReferenceNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@UniqueStreetReferenceNumber", pPostalAddress.UniqueStreetReferenceNumber));

                    sqlCommand.ExecuteNonQuery();

                    postalAddress = new ComplexPostalAddress(pPostalAddress.ContactMechanismID);
                    if (pPostalAddress.PrimaryAddressableObjectName != null)
                        postalAddress.PrimaryAddressableObjectName = new AddressableObjectName(pPostalAddress.PrimaryAddressableObjectName.AddressableObjectNameID);
                    if (pPostalAddress.SecondaryAddressableObjectName != null)
                        postalAddress.SecondaryAddressableObjectName = new AddressableObjectName(pPostalAddress.SecondaryAddressableObjectName.AddressableObjectNameID);
                    postalAddress.StreetName = pPostalAddress.StreetName;
                    postalAddress.Locality = pPostalAddress.Locality;
                    postalAddress.UniquePropertyReferenceNumber = pPostalAddress.UniquePropertyReferenceNumber;
                    postalAddress.UniqueStreetReferenceNumber = pPostalAddress.UniqueStreetReferenceNumber;

                }
                catch (Exception exc)
                {
                    postalAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    postalAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return postalAddress;
        }

        public ComplexPostalAddress Delete(ComplexPostalAddress pPostalAddress)
        {
            ComplexPostalAddress postalAddress = new ComplexPostalAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PostalAddress_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostalAddressID", pPostalAddress.ContactMechanismID));

                    sqlCommand.ExecuteNonQuery();

                    postalAddress = new ComplexPostalAddress(pPostalAddress.ContactMechanismID);
                }
                catch (Exception exc)
                {
                    postalAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    postalAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return postalAddress;
        }

        public ComplexPostalAddress AssignGeographicDetail(int pPostalAddressID, int pGeographicDetailID)
        {
            ComplexPostalAddress postalAddress = new ComplexPostalAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PostalAddressGeographicDetail_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostalAddressID", pPostalAddressID));
                    sqlCommand.Parameters.Add(new SqlParameter("@GeographicDetailID", pGeographicDetailID));

                    sqlCommand.ExecuteNonQuery();

                    postalAddress = new ComplexPostalAddress(pPostalAddressID);
                }
                catch (Exception exc)
                {
                    postalAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    postalAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return postalAddress;
        }
        
        public ComplexPostalAddress RemoveGeographicDetail(int pPostalAddressID, int pGeographicDetailID)
        {
            ComplexPostalAddress postalAddress = new ComplexPostalAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PostalAddressGeographicDetail_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostalAddressID", pPostalAddressID));
                    sqlCommand.Parameters.Add(new SqlParameter("@GeographicDetailID", pGeographicDetailID));

                    sqlCommand.ExecuteNonQuery();

                    postalAddress = new ComplexPostalAddress(pPostalAddressID);
                }
                catch (Exception exc)
                {
                    postalAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    postalAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return postalAddress;
        }
    }
}



