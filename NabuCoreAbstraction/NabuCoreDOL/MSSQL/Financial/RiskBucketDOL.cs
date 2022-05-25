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
    public class RiskBucketDOL : BaseDOL
    {
        public RiskBucketDOL() : base()
        {
        }

        public RiskBucketDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public RiskBucket Get(int pRiskBucketID, int pLanguageID)
        {
            RiskBucket riskBucket = new RiskBucket();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RiskBucket_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskBucketID", pRiskBucketID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        riskBucket = new RiskBucket(sqlDataReader.GetInt32(0));
                        riskBucket.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    riskBucket.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskBucket.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskBucket;
        }

        public RiskBucket GetByAlias(string pAlias, int pLanguageID)
        {
            RiskBucket riskBucket = new RiskBucket();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RiskBucket_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        riskBucket = new RiskBucket(sqlDataReader.GetInt32(0));
                        riskBucket.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    riskBucket.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskBucket.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskBucket;
        }

        public RiskBucket[] List(int pLanguageID)
        {
            List<RiskBucket> riskBuckets = new List<RiskBucket>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RiskBucket_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RiskBucket riskBucket = new RiskBucket(sqlDataReader.GetInt32(0));
                        riskBucket.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        riskBuckets.Add(riskBucket);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RiskBucket riskBucket = new RiskBucket();
                    riskBucket.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskBucket.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    riskBuckets.Add(riskBucket);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskBuckets.ToArray();
        }

        public RiskBucket Insert(RiskBucket pRiskBucket)
        {
            RiskBucket riskBucket = new RiskBucket();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RiskBucket_Insert]");
                try
                {
                    pRiskBucket.Detail = base.InsertTranslation(pRiskBucket.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pRiskBucket.Detail.TranslationID));
                    SqlParameter riskBucketID = sqlCommand.Parameters.Add("@RiskBucketID", SqlDbType.Int);
                    riskBucketID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    riskBucket = new RiskBucket((Int32)riskBucketID.Value);
                    riskBucket.Detail = new Translation(pRiskBucket.Detail.TranslationID);
                    riskBucket.Detail.Alias = pRiskBucket.Detail.Alias;
                    riskBucket.Detail.Description = pRiskBucket.Detail.Description;
                    riskBucket.Detail.Name = pRiskBucket.Detail.Name;
                }
                catch (Exception exc)
                {
                    riskBucket.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskBucket.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskBucket;
        }

        public RiskBucket Update(RiskBucket pRiskBucket)
        {
            RiskBucket riskBucket = new RiskBucket();

            pRiskBucket.Detail = base.UpdateTranslation(pRiskBucket.Detail);

            riskBucket = new RiskBucket(pRiskBucket.RiskBucketID);
            riskBucket.Detail = new Translation(pRiskBucket.Detail.TranslationID);
            riskBucket.Detail.Alias = pRiskBucket.Detail.Alias;
            riskBucket.Detail.Description = pRiskBucket.Detail.Description;
            riskBucket.Detail.Name = pRiskBucket.Detail.Name;

            return riskBucket;
        }

        public RiskBucket Delete(RiskBucket pRiskBucket)
        {
            RiskBucket riskBucket = new RiskBucket();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RiskBucket_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskBucketID", pRiskBucket.RiskBucketID));

                    sqlCommand.ExecuteNonQuery();

                    riskBucket = new RiskBucket(pRiskBucket.RiskBucketID);
                    base.DeleteAllTranslations(pRiskBucket.Detail);
                }
                catch (Exception exc)
                {
                    riskBucket.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskBucket.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskBucket;
        }
    }
}
