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
    public class ElectronicAddressDOL : BaseDOL
    {
        public ElectronicAddressDOL() : base()
        {
        }

        public ElectronicAddressDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ElectronicAddress Get(int pElectronicAddressID, int pLanguageID)
        {
            ElectronicAddress electronicAddress = new ElectronicAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ElectronicAddress_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ElectronicAddressID", pElectronicAddressID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        electronicAddress = new ElectronicAddress(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(1)==false)
                            electronicAddress.ElectronicAddressDetail = sqlDataReader.GetString(1);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    electronicAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    electronicAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return electronicAddress;
        }

        public ElectronicAddress GetByAddressDetail(string pElectronicAddressDetail, int pLanguageID)
        {
            ElectronicAddress electronicAddress = new ElectronicAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ElectronicAddress_GetByAddressDetail]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ElectronicAddressDetail", pElectronicAddressDetail));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        electronicAddress = new ElectronicAddress(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            electronicAddress.ElectronicAddressDetail = sqlDataReader.GetString(1);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    electronicAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    electronicAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return electronicAddress;
        }

        public ElectronicAddress Insert(ElectronicAddress pElectronicAddress)
        {
            ElectronicAddress electronicAddress = new ElectronicAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ElectronicAddress_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ElectronicAddressID", pElectronicAddress.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ElectronicAddressDetail", pElectronicAddress.ElectronicAddressDetail));

                    sqlCommand.ExecuteNonQuery();

                    electronicAddress = new ElectronicAddress(pElectronicAddress.ContactMechanismID);
                    electronicAddress.ElectronicAddressDetail = pElectronicAddress.ElectronicAddressDetail;
                    electronicAddress.ContactMechanismType = pElectronicAddress.ContactMechanismType;
                    electronicAddress.FromDate = pElectronicAddress.FromDate;
                }
                catch (Exception exc)
                {
                    electronicAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    electronicAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return electronicAddress;
        }

        public ElectronicAddress Update(ElectronicAddress pElectronicAddress)
        {
            ElectronicAddress electronicAddress = new ElectronicAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ElectronicAddress_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ElectronicAddressID", pElectronicAddress.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ElectronicAddressDetail", pElectronicAddress.ElectronicAddressDetail));

                    sqlCommand.ExecuteNonQuery();

                    electronicAddress = new ElectronicAddress(pElectronicAddress.ContactMechanismID);
                    electronicAddress.ElectronicAddressDetail = pElectronicAddress.ElectronicAddressDetail;
                    electronicAddress.ContactMechanismType = pElectronicAddress.ContactMechanismType;
                    electronicAddress.FromDate = pElectronicAddress.FromDate;
                }
                catch (Exception exc)
                {
                    electronicAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    electronicAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return electronicAddress;
        }

        public ElectronicAddress Delete(ElectronicAddress pElectronicAddress)
        {
            ElectronicAddress electronicAddress = new ElectronicAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ElectronicAddress_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ElectronicAddressID", pElectronicAddress.ContactMechanismID));

                    sqlCommand.ExecuteNonQuery();

                    electronicAddress = new ElectronicAddress(pElectronicAddress.ContactMechanismID);
                }
                catch (Exception exc)
                {
                    electronicAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    electronicAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return electronicAddress;
        }
    }
}

