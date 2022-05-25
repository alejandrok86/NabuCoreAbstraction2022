using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Authentication;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication
{
    public class LicenseDOL : BaseDOL
    {
        public LicenseDOL() : base ()
        {
        }

        public LicenseDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public License Get(int pLicenseID)
        {
            License license = new License();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[License_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LicenseID", pLicenseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        license = new License(sqlDataReader.GetInt32(0));
                        license.LicenseKey = sqlDataReader.GetString(1);
                        license.ActiveFrom = sqlDataReader.GetDateTime(2);
                        if(sqlDataReader.IsDBNull(3)==false)
                            license.ActiveTo = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    license.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    license.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return license;
        }

        public License GetByKey(string pLicenseKey)
        {
            License license = new License();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[License_GetByKey]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LicenseKey", pLicenseKey));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        license = new License(sqlDataReader.GetInt32(0));
                        license.LicenseKey = sqlDataReader.GetString(1);
                        license.ActiveFrom = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            license.ActiveTo = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    license.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    license.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return license;
        }
        public License[] List()
        {
            List<License> licenses = new List<License>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[License_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        License license = new License(sqlDataReader.GetInt32(0));
                        license.LicenseKey = sqlDataReader.GetString(1);
                        license.ActiveFrom = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            license.ActiveTo = sqlDataReader.GetDateTime(3);
                        licenses.Add(license);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    License license = new License();
                    license.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    license.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    licenses.Add(license);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return licenses.ToArray();
        }

        public License Insert(License pLicense)
        {
            License license = new License();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[License_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LicenseKey", pLicense.LicenseKey));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActiveFrom", pLicense.ActiveFrom));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActiveTo", ((pLicense.ActiveTo.HasValue)?pLicense.ActiveTo : null)));
                    SqlParameter licenseID = sqlCommand.Parameters.Add("@LicenseID", SqlDbType.Int);
                    licenseID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    license = new License((Int32)licenseID.Value);
                    license.LicenseKey = pLicense.LicenseKey;
                    license.ActiveFrom = pLicense.ActiveFrom;
                    license.ActiveTo = pLicense.ActiveTo;
                }
                catch (Exception exc)
                {
                    license.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    license.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return license;
        }

        public License Update(License pLicense)
        {
            License license = new License();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[License_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LicenseID",pLicense.LicenseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LicenseKey", pLicense.LicenseKey));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActiveFrom", pLicense.ActiveFrom));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActiveTo", ((pLicense.ActiveTo.HasValue) ? pLicense.ActiveTo : null)));

                    sqlCommand.ExecuteNonQuery();

                    license = new License(pLicense.LicenseID);
                    license.LicenseKey = pLicense.LicenseKey;
                    license.ActiveFrom = pLicense.ActiveFrom;
                    license.ActiveTo = pLicense.ActiveTo;
                }
                catch (Exception exc)
                {
                    license.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    license.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return license;
        }

        public License Delete(License pLicense)
        {
            License license = new License();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[License_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LicenseID", pLicense.LicenseID));

                    sqlCommand.ExecuteNonQuery();

                    license = new License(pLicense.LicenseID);
                }
                catch (Exception exc)
                {
                    license.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    license.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return license;
        }
    }
}

