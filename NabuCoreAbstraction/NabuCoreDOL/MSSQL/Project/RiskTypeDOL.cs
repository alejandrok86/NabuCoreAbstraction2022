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
    public class RiskTypeDOL : BaseDOL
    {
        public RiskTypeDOL() : base()
        {
        }

        public RiskTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public RiskType Get(int pRiskTypeID, int pLanguageID)
        {
            RiskType riskType = new RiskType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[RiskType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskTypeID", pRiskTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        riskType = new RiskType(sqlDataReader.GetInt32(0));
                        riskType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    riskType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskType;
        }

        public RiskType GetByAlias(string pAlias, int pLanguageID)
        {
            RiskType riskType = new RiskType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[RiskType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        riskType = new RiskType(sqlDataReader.GetInt32(0));
                        riskType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    riskType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskType;
        }

        public RiskType[] List(int pLanguageID)
        {
            List<RiskType> riskTypes = new List<RiskType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[RiskType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RiskType riskType = new RiskType(sqlDataReader.GetInt32(0));
                        riskType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        riskTypes.Add(riskType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RiskType riskType = new RiskType();
                    riskType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    riskTypes.Add(riskType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskTypes.ToArray();
        }

        public RiskType Insert(RiskType pRiskType)
        {
            RiskType riskType = new RiskType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[RiskType_Insert]");
                try
                {
                    pRiskType.Detail = base.InsertTranslation(pRiskType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pRiskType.Detail.TranslationID));
                    SqlParameter riskTypeID = sqlCommand.Parameters.Add("@RiskTypeID", SqlDbType.Int);
                    riskTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    riskType = new RiskType((Int32)riskTypeID.Value);
                    riskType.Detail = new Translation(pRiskType.Detail.TranslationID);
                    riskType.Detail.Alias = pRiskType.Detail.Alias;
                    riskType.Detail.Description = pRiskType.Detail.Description;
                    riskType.Detail.Name = pRiskType.Detail.Name;
                }
                catch (Exception exc)
                {
                    riskType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskType;
        }

        public RiskType Update(RiskType pRiskType)
        {
            RiskType riskType = new RiskType();

            pRiskType.Detail = base.UpdateTranslation(pRiskType.Detail);

            riskType = new RiskType(pRiskType.RiskTypeID);
            riskType.Detail = new Translation(pRiskType.Detail.TranslationID);
            riskType.Detail.Alias = pRiskType.Detail.Alias;
            riskType.Detail.Description = pRiskType.Detail.Description;
            riskType.Detail.Name = pRiskType.Detail.Name;

            return riskType;
        }

        public RiskType Delete(RiskType pRiskType)
        {
            RiskType riskType = new RiskType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[RiskType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskTypeID", pRiskType.RiskTypeID));

                    sqlCommand.ExecuteNonQuery();

                    riskType = new RiskType(pRiskType.RiskTypeID);
                    base.DeleteAllTranslations(pRiskType.Detail);
                }
                catch (Exception exc)
                {
                    riskType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    riskType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return riskType;
        }
    }
}
