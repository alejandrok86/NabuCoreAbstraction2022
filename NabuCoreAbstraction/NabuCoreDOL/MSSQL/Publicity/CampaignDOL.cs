using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octavo.Gate.Nabu.CORE.Entities.Publicity;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity
{
    public class CampaignDOL : BaseDOL
    {
        public CampaignDOL() : base ()
        {
        }

        public CampaignDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Campaign Get(int pCampaignID, int pLanguageID)
        {
            Campaign campaign = new Campaign();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Campaign_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CampaignID", pCampaignID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        campaign = new Campaign(sqlDataReader.GetInt32(0));
                        campaign.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if(sqlDataReader.IsDBNull(2)==false)
                            campaign.FromDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            campaign.ToDate = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    campaign.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    campaign.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return campaign;
        }

        public Campaign GetByAlias(string pAlias, int pLanguageID)
        {
            Campaign campaign = new Campaign();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Campaign_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        campaign = new Campaign(sqlDataReader.GetInt32(0));
                        campaign.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            campaign.FromDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            campaign.ToDate = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    campaign.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    campaign.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return campaign;
        }

        public Campaign[] List(int pAdvertiserID, int pLanguageID)
        {
            List<Campaign> campaigns = new List<Campaign>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Campaign_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertiserID", pAdvertiserID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Campaign campaign = new Campaign(sqlDataReader.GetInt32(0));
                        campaign.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            campaign.FromDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            campaign.ToDate = sqlDataReader.GetDateTime(3);
                        campaigns.Add(campaign);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Campaign campaign = new Campaign();
                    campaign.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    campaign.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    campaigns.Add(campaign);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return campaigns.ToArray();
        }

        public Campaign Insert(Campaign pCampaign, int pAdvertiserID)
        {
            Campaign campaign = new Campaign();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Campaign_Insert]");
                try
                {
                    pCampaign.Detail = base.InsertTranslation(pCampaign.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertiserID", pAdvertiserID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pCampaign.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", ((pCampaign.FromDate.HasValue) ? pCampaign.FromDate : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", ((pCampaign.ToDate.HasValue) ? pCampaign.ToDate : null)));
                    SqlParameter campaignID = sqlCommand.Parameters.Add("@CampaignID", SqlDbType.Int);
                    campaignID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    campaign = new Campaign((Int32)campaignID.Value);
                    campaign.Detail = new Translation(pCampaign.Detail.TranslationID);
                    campaign.Detail.Alias = pCampaign.Detail.Alias;
                    campaign.Detail.Description = pCampaign.Detail.Description;
                    campaign.Detail.Name = pCampaign.Detail.Name;
                    if (pCampaign.FromDate.HasValue)
                        campaign.FromDate = pCampaign.FromDate;
                    if (pCampaign.ToDate.HasValue)
                        campaign.ToDate = pCampaign.ToDate;
                }
                catch (Exception exc)
                {
                    campaign.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    campaign.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return campaign;
        }

        public Campaign Update(Campaign pCampaign)
        {
            Campaign campaign = new Campaign();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Campaign_Update]");
                try
                {
                    pCampaign.Detail = base.UpdateTranslation(pCampaign.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CampaignID", pCampaign.CampaignID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", ((pCampaign.FromDate.HasValue) ? pCampaign.FromDate : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", ((pCampaign.ToDate.HasValue) ? pCampaign.ToDate : null)));

                    sqlCommand.ExecuteNonQuery();

                    campaign = new Campaign(pCampaign.CampaignID);
                    campaign.Detail = new Translation(pCampaign.Detail.TranslationID);
                    campaign.Detail.Alias = pCampaign.Detail.Alias;
                    campaign.Detail.Description = pCampaign.Detail.Description;
                    campaign.Detail.Name = pCampaign.Detail.Name;
                    if (pCampaign.FromDate.HasValue)
                        campaign.FromDate = pCampaign.FromDate;
                    if (pCampaign.ToDate.HasValue)
                        campaign.ToDate = pCampaign.ToDate;
                }
                catch (Exception exc)
                {
                    campaign.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    campaign.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return campaign;
        }

        public Campaign Delete(Campaign pCampaign)
        {
            Campaign campaign = new Campaign();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Campaign_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CampaignID", pCampaign.CampaignID));

                    sqlCommand.ExecuteNonQuery();

                    campaign = new Campaign(pCampaign.CampaignID);
                    base.DeleteAllTranslations(pCampaign.Detail);
                }
                catch (Exception exc)
                {
                    campaign.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    campaign.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return campaign;
        }
    }
}
