using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octavo.Gate.Nabu.CORE.Entities.Publicity;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Data;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity
{
    public class AdvertisementDOL : BaseDOL
    {
        public AdvertisementDOL() : base ()
        {
        }

        public AdvertisementDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }
        
        public Advertisement Get(int pAdvertisementID)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertisementID", pAdvertisementID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        advertisement = new Advertisement(sqlDataReader.GetInt32(0));
                        advertisement.Name = sqlDataReader.GetString(1);
                        advertisement.Description = sqlDataReader.GetString(2);
                        advertisement.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            advertisement.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }

        public Advertisement GetByRetrievalIdentifier(Guid pUniqueRetrievalID)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_GetByRetrievalIdentifier]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UniqueRetrievalID", pUniqueRetrievalID.ToString()));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        advertisement = new Advertisement(sqlDataReader.GetInt32(0));
                        advertisement.Name = sqlDataReader.GetString(1);
                        advertisement.Description = sqlDataReader.GetString(2);
                        advertisement.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            advertisement.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }

        public Advertisement GetByTagID(int pTagID)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_GetByTagID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TagID", pTagID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        advertisement = new Advertisement(sqlDataReader.GetInt32(0));
                        advertisement.Name = sqlDataReader.GetString(1);
                        advertisement.Description = sqlDataReader.GetString(2);
                        advertisement.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            advertisement.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }

        public Advertisement GetByTagPhrase(string pPhrase, int pLanguageID)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_GetByTagPhrase]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Phrase", pPhrase));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        advertisement = new Advertisement(sqlDataReader.GetInt32(0));
                        advertisement.Name = sqlDataReader.GetString(1);
                        advertisement.Description = sqlDataReader.GetString(2);
                        advertisement.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            advertisement.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }

        public Advertisement[] List()
        {
            List<Advertisement> advertisements = new List<Advertisement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Advertisement advertisement = new Advertisement(sqlDataReader.GetInt32(0));
                        advertisement.Name = sqlDataReader.GetString(1);
                        advertisement.Description = sqlDataReader.GetString(2);
                        advertisement.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            advertisement.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        advertisements.Add(advertisement);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Advertisement advertisement = new Advertisement();
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    advertisements.Add(advertisement);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisements.ToArray();
        }

        public Advertisement[] ListForUnit(int pUnitID)
        {
            List<Advertisement> advertisements = new List<Advertisement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_ListForUnit]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Advertisement advertisement = new Advertisement(sqlDataReader.GetInt32(0));
                        advertisement.Name = sqlDataReader.GetString(1);
                        advertisement.Description = sqlDataReader.GetString(2);
                        advertisement.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            advertisement.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        advertisements.Add(advertisement);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Advertisement advertisement = new Advertisement();
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    advertisements.Add(advertisement);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisements.ToArray();
        }

        public Advertisement[] ListForCampaign(int pCampaignID)
        {
            List<Advertisement> advertisements = new List<Advertisement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_ListForCampaign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CampaignID", pCampaignID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Advertisement advertisement = new Advertisement(sqlDataReader.GetInt32(0));
                        advertisement.Name = sqlDataReader.GetString(1);
                        advertisement.Description = sqlDataReader.GetString(2);
                        advertisement.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            advertisement.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        advertisements.Add(advertisement);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Advertisement advertisement = new Advertisement();
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    advertisements.Add(advertisement);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisements.ToArray();
        }

        public Advertisement[] ListForLocation(int pLocationID)
        {
            List<Advertisement> advertisements = new List<Advertisement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_ListForLocation]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationID", pLocationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Advertisement advertisement = new Advertisement(sqlDataReader.GetInt32(0));
                        advertisement.Name = sqlDataReader.GetString(1);
                        advertisement.Description = sqlDataReader.GetString(2);
                        advertisement.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            advertisement.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        advertisements.Add(advertisement);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Advertisement advertisement = new Advertisement();
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    advertisements.Add(advertisement);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisements.ToArray();
        }

        public Advertisement Insert(Advertisement pContent)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pContent.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pContent.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@UseVersionControls", pContent.UseVersionControls));
                    sqlCommand.Parameters.Add(new SqlParameter("@UniqueRetrievalID", ((pContent.contentGUID == Guid.Empty) ? null : pContent.contentGUID.ToString())));
                    SqlParameter advertisementID = sqlCommand.Parameters.Add("@AdvertisementID", SqlDbType.Int);
                    advertisementID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    advertisement = new Advertisement((Int32)advertisementID.Value);
                    advertisement.Name = pContent.Name;
                    advertisement.Description = pContent.Description;
                    advertisement.UseVersionControls = pContent.UseVersionControls;
                    advertisement.contentGUID = pContent.contentGUID;
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }

        public Advertisement Update(Advertisement pContent)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertisementID", pContent.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pContent.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pContent.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@UseVersionControls", pContent.UseVersionControls));
                    sqlCommand.Parameters.Add(new SqlParameter("@UniqueRetrievalID", ((pContent.contentGUID == Guid.Empty) ? null : pContent.contentGUID.ToString())));

                    sqlCommand.ExecuteNonQuery();

                    advertisement = new Advertisement(pContent.ContentID);
                    advertisement.Name = pContent.Name;
                    advertisement.Description = pContent.Description;
                    advertisement.UseVersionControls = pContent.UseVersionControls;
                    advertisement.contentGUID = pContent.contentGUID;
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }

        public Advertisement DeleteReferences(Advertisement pContent)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertisementID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    advertisement = new Advertisement(pContent.ContentID);
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }

        public Advertisement AssignToCampaign(int pAdvertisementID, int pCampaignID)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_AssignToCampaign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertisementID", pAdvertisementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CampaignID", pCampaignID));

                    sqlCommand.ExecuteNonQuery();

                    advertisement = new Advertisement(pAdvertisementID);
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }

        public Advertisement AssignToUnit(int pAdvertisementID, int pUnitID)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_AssignToUnit]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertisementID", pAdvertisementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));

                    sqlCommand.ExecuteNonQuery();

                    advertisement = new Advertisement(pAdvertisementID);
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }

        public Advertisement AssignToLocation(int pAdvertisementID, int pLocationID)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_AssignToLocation]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertisementID", pAdvertisementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationID", pLocationID));

                    sqlCommand.ExecuteNonQuery();

                    advertisement = new Advertisement(pAdvertisementID);
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }

        public Advertisement RemoveFromCampaign(int pAdvertisementID, int pCampaignID)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_RemoveFromCampaign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertisementID", pAdvertisementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CampaignID", pCampaignID));

                    sqlCommand.ExecuteNonQuery();

                    advertisement = new Advertisement(pAdvertisementID);
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }

        public Advertisement RemoveFromUnit(int pAdvertisementID, int pUnitID)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_RemoveFromUnit]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertisementID", pAdvertisementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));

                    sqlCommand.ExecuteNonQuery();

                    advertisement = new Advertisement(pAdvertisementID);
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }

        public Advertisement RemoveFromLocation(int pAdvertisementID, int pLocationID)
        {
            Advertisement advertisement = new Advertisement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Advertisement_RemoveFromLocation]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertisementID", pAdvertisementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationID", pLocationID));

                    sqlCommand.ExecuteNonQuery();

                    advertisement = new Advertisement(pAdvertisementID);
                }
                catch (Exception exc)
                {
                    advertisement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    advertisement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return advertisement;
        }
    }
}
