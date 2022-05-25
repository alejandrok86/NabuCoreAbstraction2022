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
    public class SimplePostalAddressDOL : BaseDOL
    {
        public SimplePostalAddressDOL() : base()
        {
        }

        public SimplePostalAddressDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public SimplePostalAddress Get(int pSimpleAddressID, int pLanguageID)
        {
            SimplePostalAddress postalAddress = new SimplePostalAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[SimplePostalAddress_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SimpleAddressID", pSimpleAddressID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        postalAddress = new SimplePostalAddress(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            postalAddress.AddressLine1 = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            postalAddress.AddressLine2 = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            postalAddress.AddressLine3 = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            postalAddress.AddressLine4 = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            postalAddress.PostCode = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                        {
                            postalAddress.Country = new Country(sqlDataReader.GetInt32(6));
                            if (sqlDataReader.IsDBNull(7) == false)
                                postalAddress.Country.Detail = base.GetTranslation(sqlDataReader.GetInt32(7), pLanguageID);
                            if (sqlDataReader.IsDBNull(8) == false)
                                postalAddress.Country.Continent = sqlDataReader.GetString(8);
                        }
                        if (sqlDataReader.IsDBNull(9) == false)
                            postalAddress.ContactMechanismType = new ContactMechanismType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            postalAddress.FromDate = sqlDataReader.GetDateTime(10);
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

        public SimplePostalAddress[] List(int pPartyID, int pLanguageID)
        {
            List<SimplePostalAddress> postalAddresses = new List<SimplePostalAddress>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[SimplePostalAddress_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        SimplePostalAddress postalAddress = new SimplePostalAddress(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            postalAddress.AddressLine1 = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            postalAddress.AddressLine2 = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            postalAddress.AddressLine3 = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            postalAddress.AddressLine4 = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            postalAddress.PostCode = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                        {
                            postalAddress.Country = new Country(sqlDataReader.GetInt32(6));
                            if (sqlDataReader.IsDBNull(7) == false)
                                postalAddress.Country.Detail = base.GetTranslation(sqlDataReader.GetInt32(7), pLanguageID);
                            if (sqlDataReader.IsDBNull(8) == false)
                                postalAddress.Country.Continent = sqlDataReader.GetString(8);
                        }
                        if (sqlDataReader.IsDBNull(9) == false)
                            postalAddress.ContactMechanismType = new ContactMechanismType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            postalAddress.FromDate = sqlDataReader.GetDateTime(10);
                        postalAddresses.Add(postalAddress);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    SimplePostalAddress error = new SimplePostalAddress();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    postalAddresses.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return postalAddresses.ToArray();
        }

        public SimplePostalAddress Insert(SimplePostalAddress pPostalAddress)
        {
            SimplePostalAddress postalAddress = new SimplePostalAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[SimplePostalAddress_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismTypeID", pPostalAddress.ContactMechanismType.ContactMechanismTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AddressLine1", pPostalAddress.AddressLine1));
                    sqlCommand.Parameters.Add(new SqlParameter("@AddressLine2", pPostalAddress.AddressLine2));
                    sqlCommand.Parameters.Add(new SqlParameter("@AddressLine3", pPostalAddress.AddressLine3));
                    sqlCommand.Parameters.Add(new SqlParameter("@AddressLine4", pPostalAddress.AddressLine4));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostCode", pPostalAddress.PostCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pPostalAddress.Country.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPostalAddress.FromDate));
                    SqlParameter simpleAddressID = sqlCommand.Parameters.Add("@SimpleAddressID", SqlDbType.Int);
                    simpleAddressID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    postalAddress = new SimplePostalAddress((Int32)simpleAddressID.Value);
                    postalAddress.AddressLine1 = pPostalAddress.AddressLine1;
                    postalAddress.AddressLine2 = pPostalAddress.AddressLine2;
                    postalAddress.AddressLine3 = pPostalAddress.AddressLine3;
                    postalAddress.AddressLine4 = pPostalAddress.AddressLine4;
                    postalAddress.ContactMechanismType = pPostalAddress.ContactMechanismType;
                    postalAddress.Country = pPostalAddress.Country;
                    postalAddress.FromDate = pPostalAddress.FromDate;
                    postalAddress.PostCode = pPostalAddress.PostCode;
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

        public SimplePostalAddress Update(SimplePostalAddress pPostalAddress)
        {
            SimplePostalAddress postalAddress = new SimplePostalAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[SimplePostalAddress_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SimpleAddressID", pPostalAddress.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AddressLine1", pPostalAddress.AddressLine1));
                    sqlCommand.Parameters.Add(new SqlParameter("@AddressLine2", pPostalAddress.AddressLine2));
                    sqlCommand.Parameters.Add(new SqlParameter("@AddressLine3", pPostalAddress.AddressLine3));
                    sqlCommand.Parameters.Add(new SqlParameter("@AddressLine4", pPostalAddress.AddressLine4));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostCode", pPostalAddress.PostCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pPostalAddress.Country.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPostalAddress.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    postalAddress = new SimplePostalAddress(pPostalAddress.ContactMechanismID);
                    postalAddress.AddressLine1 = pPostalAddress.AddressLine1;
                    postalAddress.AddressLine2 = pPostalAddress.AddressLine2;
                    postalAddress.AddressLine3 = pPostalAddress.AddressLine3;
                    postalAddress.AddressLine4 = pPostalAddress.AddressLine4;
                    postalAddress.ContactMechanismType = pPostalAddress.ContactMechanismType;
                    postalAddress.Country = pPostalAddress.Country;
                    postalAddress.FromDate = pPostalAddress.FromDate;
                    postalAddress.PostCode = pPostalAddress.PostCode;
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

        public SimplePostalAddress Delete(SimplePostalAddress pPostalAddress)
        {
            SimplePostalAddress postalAddress = new SimplePostalAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[SimplePostalAddress_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SimpleAddressID", pPostalAddress.ContactMechanismID));

                    sqlCommand.ExecuteNonQuery();

                    postalAddress = new SimplePostalAddress(pPostalAddress.ContactMechanismID);
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



