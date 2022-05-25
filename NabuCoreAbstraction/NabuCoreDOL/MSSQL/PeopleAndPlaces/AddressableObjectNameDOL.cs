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
    public class AddressableObjectNameDOL : BaseDOL
    {
        public AddressableObjectNameDOL() : base()
        {
        }

        public AddressableObjectNameDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AddressableObjectName Get(int pAddressableObjectNameID, int pLanguageID)
        {
            AddressableObjectName addressableObjectName = new AddressableObjectName();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[AddressableObjectName_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AddressableObjectNameID", pAddressableObjectNameID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        addressableObjectName = new AddressableObjectName(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            addressableObjectName.Description = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(1) == false)
                            addressableObjectName.StartNumber = sqlDataReader.GetInt32(2);
                        if (sqlDataReader.IsDBNull(1) == false)
                            addressableObjectName.StartNumberSuffix = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(1) == false)
                            addressableObjectName.EndNumber = sqlDataReader.GetInt32(4);
                        if (sqlDataReader.IsDBNull(1) == false)
                            addressableObjectName.EndNumberSuffix = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(1) == false)
                            addressableObjectName.FromDate = sqlDataReader.GetDateTime(6);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    addressableObjectName.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    addressableObjectName.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return addressableObjectName;
        }

        public AddressableObjectName Insert(AddressableObjectName pAddressableObjectName)
        {
            AddressableObjectName addressableObjectName = new AddressableObjectName();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[AddressableObjectName_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pAddressableObjectName.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartNumber", pAddressableObjectName.StartNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartNumberSuffix", pAddressableObjectName.StartNumberSuffix));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndNumber", pAddressableObjectName.EndNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndNumberSuffix", pAddressableObjectName.EndNumberSuffix));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pAddressableObjectName.FromDate));
                    SqlParameter addressableObjectNameID = sqlCommand.Parameters.Add("@AddressableObjectNameID", SqlDbType.Int);
                    addressableObjectNameID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    addressableObjectName = new AddressableObjectName((Int32)addressableObjectNameID.Value);
                    addressableObjectName.Description = pAddressableObjectName.Description;
                    addressableObjectName.EndNumber = pAddressableObjectName.EndNumber;
                    addressableObjectName.EndNumberSuffix = pAddressableObjectName.EndNumberSuffix;
                    addressableObjectName.FromDate = pAddressableObjectName.FromDate;
                    addressableObjectName.StartNumber = pAddressableObjectName.StartNumber;
                    addressableObjectName.StartNumberSuffix = pAddressableObjectName.StartNumberSuffix;
                }
                catch (Exception exc)
                {
                    addressableObjectName.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    addressableObjectName.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return addressableObjectName;
        }

        public AddressableObjectName Update(AddressableObjectName pAddressableObjectName)
        {
            AddressableObjectName addressableObjectName = new AddressableObjectName();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[AddressableObjectName_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AddressableObjectNameID", pAddressableObjectName.AddressableObjectNameID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pAddressableObjectName.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartNumber", pAddressableObjectName.StartNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartNumberSuffix", pAddressableObjectName.StartNumberSuffix));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndNumber", pAddressableObjectName.EndNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndNumberSuffix", pAddressableObjectName.EndNumberSuffix));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pAddressableObjectName.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    addressableObjectName = new AddressableObjectName(pAddressableObjectName.AddressableObjectNameID);
                    addressableObjectName.Description = pAddressableObjectName.Description;
                    addressableObjectName.EndNumber = pAddressableObjectName.EndNumber;
                    addressableObjectName.EndNumberSuffix = pAddressableObjectName.EndNumberSuffix;
                    addressableObjectName.FromDate = pAddressableObjectName.FromDate;
                    addressableObjectName.StartNumber = pAddressableObjectName.StartNumber;
                    addressableObjectName.StartNumberSuffix = pAddressableObjectName.StartNumberSuffix;
                }
                catch (Exception exc)
                {
                    addressableObjectName.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    addressableObjectName.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return addressableObjectName;
        }

        public AddressableObjectName Delete(AddressableObjectName pAddressableObjectName)
        {
            AddressableObjectName addressableObjectName = new AddressableObjectName();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[AddressableObjectName_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AddressableObjectNameID", pAddressableObjectName.AddressableObjectNameID));

                    sqlCommand.ExecuteNonQuery();

                    addressableObjectName = new AddressableObjectName(pAddressableObjectName.AddressableObjectNameID);
                }
                catch (Exception exc)
                {
                    addressableObjectName.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    addressableObjectName.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return addressableObjectName;
        }
    }
}
