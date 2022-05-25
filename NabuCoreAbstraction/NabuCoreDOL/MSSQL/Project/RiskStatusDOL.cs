using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Project;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class RiskStatusDOL : BaseDOL
    {
        public RiskStatusDOL() : base()
        {
        }

        public RiskStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public RiskStatus Get(int pRiskStatusID, int pLanguageID)
        {
            RiskStatus riskStatus = new RiskStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[RiskStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskStatusID", pRiskStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        riskStatus = new RiskStatus(sqlDataReader.GetInt32(0));
                        riskStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    riskStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskStatus;
        }

        public RiskStatus GetByAlias(string pAlias, int pLanguageID)
        {
            RiskStatus riskStatus = new RiskStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[RiskStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        riskStatus = new RiskStatus(sqlDataReader.GetInt32(0));
                        riskStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    riskStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskStatus;
        }

        public RiskStatus[] List(int pLanguageID)
        {
            List<RiskStatus> riskStatuss = new List<RiskStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[RiskStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RiskStatus riskStatus = new RiskStatus(sqlDataReader.GetInt32(0));
                        riskStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        riskStatuss.Add(riskStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RiskStatus riskStatus = new RiskStatus();
                    riskStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    riskStatuss.Add(riskStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskStatuss.ToArray();
        }

        public RiskStatus Insert(RiskStatus pRiskStatus)
        {
            RiskStatus riskStatus = new RiskStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[RiskStatus_Insert]");
                try
                {
                    pRiskStatus.Detail = base.InsertTranslation(pRiskStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pRiskStatus.Detail.TranslationID));
                    SqlParameter riskStatusID = sqlCommand.Parameters.Add("@RiskStatusID", SqlDbType.Int);
                    riskStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    riskStatus = new RiskStatus((Int32)riskStatusID.Value);
                    riskStatus.Detail = new Translation(pRiskStatus.Detail.TranslationID);
                    riskStatus.Detail.Alias = pRiskStatus.Detail.Alias;
                    riskStatus.Detail.Description = pRiskStatus.Detail.Description;
                    riskStatus.Detail.Name = pRiskStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    riskStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskStatus;
        }

        public RiskStatus Update(RiskStatus pRiskStatus)
        {
            RiskStatus riskStatus = new RiskStatus();

            pRiskStatus.Detail = base.UpdateTranslation(pRiskStatus.Detail);

            riskStatus = new RiskStatus(pRiskStatus.RiskStatusID);
            riskStatus.Detail = new Translation(pRiskStatus.Detail.TranslationID);
            riskStatus.Detail.Alias = pRiskStatus.Detail.Alias;
            riskStatus.Detail.Description = pRiskStatus.Detail.Description;
            riskStatus.Detail.Name = pRiskStatus.Detail.Name;

            return riskStatus;
        }

        public RiskStatus Delete(RiskStatus pRiskStatus)
        {
            RiskStatus riskStatus = new RiskStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[RiskStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskStatusID", pRiskStatus.RiskStatusID));

                    sqlCommand.ExecuteNonQuery();

                    riskStatus = new RiskStatus(pRiskStatus.RiskStatusID);
                    base.DeleteAllTranslations(pRiskStatus.Detail);
                }
                catch (Exception exc)
                {
                    riskStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskStatus;
        }
    }
}
