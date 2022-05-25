using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class RatingAgencyDOL : BaseDOL
    {
        public RatingAgencyDOL() : base()
        {
        }

        public RatingAgencyDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public RatingAgency Get(int pRatingAgencyID, int pLanguageID)
        {
            RatingAgency RatingAgency = new RatingAgency();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingAgency_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingAgencyID", pRatingAgencyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        RatingAgency = new RatingAgency(sqlDataReader.GetInt32(0));
                        RatingAgency.Name = sqlDataReader.GetString(1);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RatingAgency.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    RatingAgency.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return RatingAgency;
        }

        public RatingAgency[] List()
        {
            List<RatingAgency> RatingAgencys = new List<RatingAgency>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingAgency_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RatingAgency RatingAgency = new RatingAgency(sqlDataReader.GetInt32(0));
                        RatingAgency.Name = sqlDataReader.GetString(1);

                        RatingAgencys.Add(RatingAgency);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RatingAgency RatingAgency = new RatingAgency();
                    RatingAgency.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    RatingAgency.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    RatingAgencys.Add(RatingAgency);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return RatingAgencys.ToArray();
        }

        public RatingAgency Insert(RatingAgency pRatingAgency)
        {
            RatingAgency RatingAgency = new RatingAgency();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingAgency_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingAgencyID", pRatingAgency.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    RatingAgency = new RatingAgency(pRatingAgency.PartyID);
                }
                catch (Exception exc)
                {
                    RatingAgency.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    RatingAgency.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return RatingAgency;
        }

        public RatingAgency Update(RatingAgency pRatingAgency)
        {
            RatingAgency RatingAgency = new RatingAgency();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingAgency_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingAgencyID", pRatingAgency.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    RatingAgency = new RatingAgency(pRatingAgency.PartyID);
                }
                catch (Exception exc)
                {
                    RatingAgency.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    RatingAgency.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return RatingAgency;
        }

        public RatingAgency Delete(RatingAgency pRatingAgency)
        {
            RatingAgency RatingAgency = new RatingAgency();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingAgency_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingAgencyID", pRatingAgency.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    RatingAgency = new RatingAgency(pRatingAgency.PartyID);
                }
                catch (Exception exc)
                {
                    RatingAgency.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    RatingAgency.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return RatingAgency;
        }
    }
}
