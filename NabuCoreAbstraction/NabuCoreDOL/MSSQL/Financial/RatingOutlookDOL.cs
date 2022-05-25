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
    public class RatingOutlookDOL : BaseDOL
    {
        public RatingOutlookDOL() : base()
        {
        }

        public RatingOutlookDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public RatingOutlook Get(int pRatingOutlookID, int pLanguageID)
        {
            RatingOutlook ratingOutlook = new RatingOutlook();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingOutlook_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingOutlookID", pRatingOutlookID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        ratingOutlook = new RatingOutlook(sqlDataReader.GetInt32(0));
                        ratingOutlook.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ratingOutlook.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingOutlook.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingOutlook;
        }

        public RatingOutlook GetByAlias(string pAlias, int pLanguageID)
        {
            RatingOutlook ratingOutlook = new RatingOutlook();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingOutlook_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        ratingOutlook = new RatingOutlook(sqlDataReader.GetInt32(0));
                        ratingOutlook.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ratingOutlook.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingOutlook.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingOutlook;
        }

        public RatingOutlook[] List(int pLanguageID)
        {
            List<RatingOutlook> ratingOutlooks = new List<RatingOutlook>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingOutlook_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RatingOutlook ratingOutlook = new RatingOutlook(sqlDataReader.GetInt32(0));
                        ratingOutlook.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        ratingOutlooks.Add(ratingOutlook);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RatingOutlook ratingOutlook = new RatingOutlook();
                    ratingOutlook.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingOutlook.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    ratingOutlooks.Add(ratingOutlook);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingOutlooks.ToArray();
        }

        public RatingOutlook Insert(RatingOutlook pRatingOutlook)
        {
            RatingOutlook ratingOutlook = new RatingOutlook();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingOutlook_Insert]");
                try
                {
                    pRatingOutlook.Detail = base.InsertTranslation(pRatingOutlook.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pRatingOutlook.Detail.TranslationID));
                    SqlParameter ratingOutlookID = sqlCommand.Parameters.Add("@RatingOutlookID", SqlDbType.Int);
                    ratingOutlookID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    ratingOutlook = new RatingOutlook((Int32)ratingOutlookID.Value);
                    ratingOutlook.Detail = new Translation(pRatingOutlook.Detail.TranslationID);
                    ratingOutlook.Detail.Alias = pRatingOutlook.Detail.Alias;
                    ratingOutlook.Detail.Description = pRatingOutlook.Detail.Description;
                    ratingOutlook.Detail.Name = pRatingOutlook.Detail.Name;
                }
                catch (Exception exc)
                {
                    ratingOutlook.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingOutlook.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingOutlook;
        }

        public RatingOutlook Update(RatingOutlook pRatingOutlook)
        {
            RatingOutlook ratingOutlook = new RatingOutlook();

            pRatingOutlook.Detail = base.UpdateTranslation(pRatingOutlook.Detail);

            ratingOutlook = new RatingOutlook(pRatingOutlook.RatingOutlookID);
            ratingOutlook.Detail = new Translation(pRatingOutlook.Detail.TranslationID);
            ratingOutlook.Detail.Alias = pRatingOutlook.Detail.Alias;
            ratingOutlook.Detail.Description = pRatingOutlook.Detail.Description;
            ratingOutlook.Detail.Name = pRatingOutlook.Detail.Name;

            return ratingOutlook;
        }

        public RatingOutlook Delete(RatingOutlook pRatingOutlook)
        {
            RatingOutlook ratingOutlook = new RatingOutlook();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingOutlook_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingOutlookID", pRatingOutlook.RatingOutlookID));

                    sqlCommand.ExecuteNonQuery();

                    ratingOutlook = new RatingOutlook(pRatingOutlook.RatingOutlookID);
                    base.DeleteAllTranslations(pRatingOutlook.Detail);
                }
                catch (Exception exc)
                {
                    ratingOutlook.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingOutlook.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingOutlook;
        }
    }
}
