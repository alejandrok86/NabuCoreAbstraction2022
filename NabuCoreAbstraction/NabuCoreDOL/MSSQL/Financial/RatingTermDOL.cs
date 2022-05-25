using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class RatingTermDOL : BaseDOL
    {
        public RatingTermDOL() : base()
        {
        }

        public RatingTermDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public RatingTerm Get(int pRatingTermID, int pLanguageID)
        {
            RatingTerm ratingTerm = new RatingTerm();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingTerm_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingTermID", pRatingTermID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        ratingTerm = new RatingTerm(sqlDataReader.GetInt32(0));
                        ratingTerm.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ratingTerm.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingTerm.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingTerm;
        }

        public RatingTerm GetForRating(int pRatingID, int pLanguageID)
        {
            RatingTerm ratingTerm = new RatingTerm();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingTerm_GetForRating]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingID", pRatingID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        ratingTerm = new RatingTerm(sqlDataReader.GetInt32(0));
                        ratingTerm.Detail = new Translation(sqlDataReader.GetInt32(1));
                        ratingTerm.Detail.TranslationLanguage = new Language(pLanguageID);
                        ratingTerm.Detail.Alias = sqlDataReader.GetString(2);
                        ratingTerm.Detail.Name = sqlDataReader.GetString(3);
                        ratingTerm.Detail.Description = sqlDataReader.GetString(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ratingTerm.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingTerm.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingTerm;
        }

        public RatingTerm GetByAlias(string pAlias, int pLanguageID)
        {
            RatingTerm ratingTerm = new RatingTerm();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingTerm_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        ratingTerm = new RatingTerm(sqlDataReader.GetInt32(0));
                        ratingTerm.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ratingTerm.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingTerm.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingTerm;
        }

        public RatingTerm[] List(int pLanguageID)
        {
            List<RatingTerm> ratingTerms = new List<RatingTerm>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingTerm_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RatingTerm ratingTerm = new RatingTerm(sqlDataReader.GetInt32(0));
                        ratingTerm.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        ratingTerms.Add(ratingTerm);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RatingTerm ratingTerm = new RatingTerm();
                    ratingTerm.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingTerm.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    ratingTerms.Add(ratingTerm);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingTerms.ToArray();
        }

        public RatingTerm Insert(RatingTerm pRatingTerm)
        {
            RatingTerm ratingTerm = new RatingTerm();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingTerm_Insert]");
                try
                {
                    pRatingTerm.Detail = base.InsertTranslation(pRatingTerm.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pRatingTerm.Detail.TranslationID));
                    SqlParameter ratingTermID = sqlCommand.Parameters.Add("@RatingTermID", SqlDbType.Int);
                    ratingTermID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    ratingTerm = new RatingTerm((Int32)ratingTermID.Value);
                    ratingTerm.Detail = new Translation(pRatingTerm.Detail.TranslationID);
                    ratingTerm.Detail.Alias = pRatingTerm.Detail.Alias;
                    ratingTerm.Detail.Description = pRatingTerm.Detail.Description;
                    ratingTerm.Detail.Name = pRatingTerm.Detail.Name;
                }
                catch (Exception exc)
                {
                    ratingTerm.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingTerm.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingTerm;
        }

        public RatingTerm Update(RatingTerm pRatingTerm)
        {
            RatingTerm ratingTerm = new RatingTerm();

            pRatingTerm.Detail = base.UpdateTranslation(pRatingTerm.Detail);

            ratingTerm = new RatingTerm(pRatingTerm.RatingTermID);
            ratingTerm.Detail = new Translation(pRatingTerm.Detail.TranslationID);
            ratingTerm.Detail.Alias = pRatingTerm.Detail.Alias;
            ratingTerm.Detail.Description = pRatingTerm.Detail.Description;
            ratingTerm.Detail.Name = pRatingTerm.Detail.Name;

            return ratingTerm;
        }

        public RatingTerm Delete(RatingTerm pRatingTerm)
        {
            RatingTerm ratingTerm = new RatingTerm();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingTerm_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingTermID", pRatingTerm.RatingTermID));

                    sqlCommand.ExecuteNonQuery();

                    ratingTerm = new RatingTerm(pRatingTerm.RatingTermID);
                    base.DeleteAllTranslations(pRatingTerm.Detail);
                }
                catch (Exception exc)
                {
                    ratingTerm.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingTerm.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingTerm;
        }
    }
}
