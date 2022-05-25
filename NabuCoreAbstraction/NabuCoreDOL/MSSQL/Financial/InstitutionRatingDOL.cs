using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class InstitutionRatingDOL : BaseDOL
    {
        public InstitutionRatingDOL() : base()
        {
        }

        public InstitutionRatingDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public InstitutionRating Get(int pInstitutionRatingID)
        {
            InstitutionRating institutionRating = new InstitutionRating();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionRating_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionRatingID", pInstitutionRatingID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        institutionRating = new InstitutionRating(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(1)==false)
                            institutionRating.RiskBucket = new RiskBucket(sqlDataReader.GetInt32(1));
                        institutionRating.RatingAgency = new RatingAgency(sqlDataReader.GetInt32(2));
                        institutionRating.ShortTermRating = new Rating(sqlDataReader.GetInt32(3));
                        institutionRating.LongTermRating = new Rating(sqlDataReader.GetInt32(4));
                        institutionRating.Outlook = new RatingOutlook(sqlDataReader.GetInt32(5));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    institutionRating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionRating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionRating;
        }

        public InstitutionRating[] List(int pInstitutionID, int pLanguageID)
        {
            List<InstitutionRating> institutionRatings = new List<InstitutionRating>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionRating_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        InstitutionRating institutionRating = new InstitutionRating(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(1)==false)
                            institutionRating.RiskBucket = new RiskBucket(sqlDataReader.GetInt32(1));
                        institutionRating.RatingAgency = new RatingAgency(sqlDataReader.GetInt32(2));
                        institutionRating.ShortTermRating = new Rating(sqlDataReader.GetInt32(3));
                        institutionRating.LongTermRating = new Rating(sqlDataReader.GetInt32(4));
                        institutionRating.Outlook = new RatingOutlook(sqlDataReader.GetInt32(5));

                        institutionRating.ShortTermRating.RatingTerm = new RatingTerm(sqlDataReader.GetInt32(6));
                        institutionRating.ShortTermRating.RatingTerm.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(7));
                        institutionRating.ShortTermRating.RatingTerm.Detail.TranslationLanguage = new Entities.Globalisation.Language(pLanguageID);
                        institutionRating.ShortTermRating.RatingTerm.Detail.Alias = sqlDataReader.GetString(8);
                        institutionRating.ShortTermRating.RatingTerm.Detail.Name = sqlDataReader.GetString(9);
                        institutionRating.ShortTermRating.RatingTerm.Detail.Description = sqlDataReader.GetString(10);
                        institutionRatings.Add(institutionRating);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    InstitutionRating institutionRating = new InstitutionRating();
                    institutionRating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionRating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    institutionRatings.Add(institutionRating);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionRatings.ToArray();
        }

        public InstitutionRating Insert(InstitutionRating pInstitutionRating, int pInstitutionID)
        {
            InstitutionRating institutionRating = new InstitutionRating();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionRating_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskBucketID", ((pInstitutionRating.RiskBucket != null && pInstitutionRating.RiskBucket.RiskBucketID != null) ? pInstitutionRating.RiskBucket.RiskBucketID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingAgencyID", pInstitutionRating.RatingAgency.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShortTermRatingID", pInstitutionRating.ShortTermRating.RatingID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LongTermRatingID", pInstitutionRating.LongTermRating.RatingID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingOutlookID", pInstitutionRating.Outlook.RatingOutlookID));
                    SqlParameter institutionRatingID = sqlCommand.Parameters.Add("@InstitutionRatingID", SqlDbType.Int);
                    institutionRatingID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    institutionRating = new InstitutionRating((Int32)institutionRatingID.Value);
                    institutionRating.RiskBucket = pInstitutionRating.RiskBucket;
                    institutionRating.RatingAgency = pInstitutionRating.RatingAgency;
                    institutionRating.ShortTermRating = pInstitutionRating.ShortTermRating;
                    institutionRating.LongTermRating = pInstitutionRating.LongTermRating;
                    institutionRating.Outlook = pInstitutionRating.Outlook;
                }
                catch (Exception exc)
                {
                    institutionRating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionRating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionRating;
        }

        public InstitutionRating Update(InstitutionRating pInstitutionRating)
        {
            InstitutionRating institutionRating = new InstitutionRating();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionRating_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionRatingID", pInstitutionRating.InstitutionRatingID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskBucketID", ((pInstitutionRating.RiskBucket != null && pInstitutionRating.RiskBucket.RiskBucketID != null) ? pInstitutionRating.RiskBucket.RiskBucketID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingAgencyID", pInstitutionRating.RatingAgency.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShortTermRatingID", pInstitutionRating.ShortTermRating.RatingID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LongTermRatingID", pInstitutionRating.LongTermRating.RatingID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingOutlookID", pInstitutionRating.Outlook.RatingOutlookID));

                    sqlCommand.ExecuteNonQuery();

                    institutionRating = new InstitutionRating(pInstitutionRating.InstitutionRatingID);
                    institutionRating.RiskBucket = pInstitutionRating.RiskBucket;
                    institutionRating.RatingAgency = pInstitutionRating.RatingAgency;
                    institutionRating.ShortTermRating = pInstitutionRating.ShortTermRating;
                    institutionRating.LongTermRating = pInstitutionRating.LongTermRating;
                    institutionRating.Outlook = pInstitutionRating.Outlook;
                }
                catch (Exception exc)
                {
                    institutionRating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionRating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionRating;
        }

        public InstitutionRating Delete(InstitutionRating pInstitutionRating)
        {
            InstitutionRating institutionRating = new InstitutionRating();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionRating_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionRatingID", pInstitutionRating.InstitutionRatingID));

                    sqlCommand.ExecuteNonQuery();

                    institutionRating = new InstitutionRating(pInstitutionRating.InstitutionRatingID);
                }
                catch (Exception exc)
                {
                    institutionRating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionRating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionRating;
        }
    }
}
