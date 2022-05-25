using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class ShareLocationDOL : BaseDOL
    {
        public ShareLocationDOL() : base ()
        {
        }

        public ShareLocationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ShareLocation Get(int pShareLocationID)
        {
            ShareLocation shareLocation = new ShareLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocation_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationID", pShareLocationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        shareLocation = new ShareLocation(sqlDataReader.GetInt32(0));
                        shareLocation.SharingParty = new Octavo.Gate.Nabu.CORE.Entities.Core.Party(sqlDataReader.GetInt32(1));
                        shareLocation.ShareLocationType = new ShareLocationType(sqlDataReader.GetInt32(2));
                        shareLocation.ShareDate = sqlDataReader.GetDateTime(3);
                        shareLocation.Latitude = sqlDataReader.GetDecimal(4);
                        shareLocation.Longitude = sqlDataReader.GetDecimal(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    shareLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareLocation;
        }

        public MyLocation GetMyLocation(int pPartyID)
        {
            MyLocation myLocation = new MyLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[MyLocation_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        myLocation = new MyLocation(sqlDataReader.GetInt32(0));
                        myLocation.SharingParty = new Octavo.Gate.Nabu.CORE.Entities.Core.Party(sqlDataReader.GetInt32(1));
                        myLocation.ShareLocationType = new ShareLocationType(sqlDataReader.GetInt32(2));
                        myLocation.ShareDate = sqlDataReader.GetDateTime(3);
                        myLocation.Latitude = sqlDataReader.GetDecimal(4);
                        myLocation.Longitude = sqlDataReader.GetDecimal(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    myLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    myLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return myLocation;
        }

        public ShareLocation[] List(int pPartyID)
        {
            List<ShareLocation> shareLocations = new List<ShareLocation>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocation_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ShareLocation shareLocation = new ShareLocation(sqlDataReader.GetInt32(0));
                        shareLocation.SharingParty = new Octavo.Gate.Nabu.CORE.Entities.Core.Party(sqlDataReader.GetInt32(1));
                        shareLocation.ShareLocationType = new ShareLocationType(sqlDataReader.GetInt32(2));
                        shareLocation.ShareDate = sqlDataReader.GetDateTime(3);
                        shareLocation.Latitude = sqlDataReader.GetDecimal(4);
                        shareLocation.Longitude = sqlDataReader.GetDecimal(5);
                        shareLocations.Add(shareLocation);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ShareLocation shareLocation = new ShareLocation();
                    shareLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    shareLocations.Add(shareLocation);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareLocations.ToArray();
        }

        public ShareLocation Insert(ShareLocation pShareLocation)
        {
            ShareLocation shareLocation = new ShareLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocation_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SharingPartyID", pShareLocation.SharingParty.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationTypeID", pShareLocation.ShareLocationType.ShareLocationTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareDate", pShareLocation.ShareDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@Latitude", pShareLocation.Latitude));
                    sqlCommand.Parameters.Add(new SqlParameter("@Longitude", pShareLocation.Longitude));
                    SqlParameter ShareLocationID = sqlCommand.Parameters.Add("@ShareLocationID", SqlDbType.Int);
                    ShareLocationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    shareLocation = new ShareLocation((Int32)ShareLocationID.Value);
                    shareLocation.SharingParty = pShareLocation.SharingParty;
                    shareLocation.ShareLocationType = pShareLocation.ShareLocationType;
                    shareLocation.ShareDate = pShareLocation.ShareDate;
                    shareLocation.Latitude = pShareLocation.Latitude;
                    shareLocation.Longitude = pShareLocation.Longitude;
                }
                catch (Exception exc)
                {
                    shareLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareLocation;
        }

        public ShareLocation Update(ShareLocation pShareLocation)
        {
            ShareLocation shareLocation = new ShareLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocation_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationID", pShareLocation.ShareLocationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SharingPartyID", pShareLocation.SharingParty.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationTypeID", pShareLocation.ShareLocationType.ShareLocationTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareDate", pShareLocation.ShareDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@Latitude", pShareLocation.Latitude));
                    sqlCommand.Parameters.Add(new SqlParameter("@Longitude", pShareLocation.Longitude));

                    sqlCommand.ExecuteNonQuery();

                    shareLocation = new ShareLocation(pShareLocation.ShareLocationID);
                    shareLocation.SharingParty = pShareLocation.SharingParty;
                    shareLocation.ShareLocationType = pShareLocation.ShareLocationType;
                    shareLocation.ShareDate = pShareLocation.ShareDate;
                    shareLocation.Latitude = pShareLocation.Latitude;
                    shareLocation.Longitude = pShareLocation.Longitude;
                }
                catch (Exception exc)
                {
                    shareLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareLocation;
        }

        public ShareLocation Delete(ShareLocation pShareLocation)
        {
            ShareLocation shareLocation = new ShareLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[ShareLocation_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareLocationID", pShareLocation.ShareLocationID));

                    sqlCommand.ExecuteNonQuery();

                    shareLocation = new ShareLocation(pShareLocation.ShareLocationID);
                }
                catch (Exception exc)
                {
                    shareLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareLocation;
        }
    }
}

