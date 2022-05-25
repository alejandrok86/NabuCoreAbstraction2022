using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class RiskDOL : BaseDOL
    {
        public RiskDOL() : base()
        {
        }

        public RiskDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Project.Risk Get(int? pRiskID)
        {
            Entities.Project.Risk risk = new Entities.Project.Risk();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Risk_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskID", pRiskID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        risk = new Entities.Project.Risk(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            risk.RiskType = new Entities.Project.RiskType(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            risk.Author = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            risk.DateIdentified = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            risk.RiskStatus = new Entities.Project.RiskStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            risk.DateStatusChanged = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            risk.Description = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            risk.Likelihood = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            risk.Severity = sqlDataReader.GetInt32(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            risk.Responsible = new Entities.Core.Party(sqlDataReader.GetInt32(9));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    risk.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    risk.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return risk;
        }

        public Entities.Project.Risk[] List(int pRiskLogID)
        {
            List<Entities.Project.Risk> risks = new List<Entities.Project.Risk>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Risk_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskLogID", pRiskLogID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Project.Risk risk = new Entities.Project.Risk(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            risk.RiskType = new Entities.Project.RiskType(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            risk.Author = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            risk.DateIdentified = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            risk.RiskStatus = new Entities.Project.RiskStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            risk.DateStatusChanged = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            risk.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            risk.Likelihood = sqlDataReader.GetInt32(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            risk.Severity = sqlDataReader.GetInt32(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            risk.Responsible = new Entities.Core.Party(sqlDataReader.GetInt32(10));
                        risks.Add(risk);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Project.Risk risk = new Entities.Project.Risk();
                    risk.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    risk.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    risks.Add(risk);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return risks.ToArray();
        }

        public Entities.Project.Risk[] ListByResponsible(int pRiskLogID, int pResponsiblePartyID)
        {
            List<Entities.Project.Risk> risks = new List<Entities.Project.Risk>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Risk_ListByResponsiblePartyIDForRiskLogID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskLogID", pRiskLogID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponsiblePartyID", pResponsiblePartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Project.Risk risk = new Entities.Project.Risk(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            risk.RiskType = new Entities.Project.RiskType(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            risk.Author = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            risk.DateIdentified = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            risk.RiskStatus = new Entities.Project.RiskStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            risk.DateStatusChanged = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            risk.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            risk.Likelihood = sqlDataReader.GetInt32(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            risk.Severity = sqlDataReader.GetInt32(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            risk.Responsible = new Entities.Core.Party(sqlDataReader.GetInt32(10));
                        risks.Add(risk);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Project.Risk risk = new Entities.Project.Risk();
                    risk.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    risk.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    risks.Add(risk);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return risks.ToArray();
        }

        public Entities.Project.Risk[] ListByResponsible(int pResponsiblePartyID)
        {
            List<Entities.Project.Risk> risks = new List<Entities.Project.Risk>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Risk_ListByResponsiblePartyID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponsiblePartyID", pResponsiblePartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Project.Risk risk = new Entities.Project.Risk(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            risk.RiskType = new Entities.Project.RiskType(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            risk.Author = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            risk.DateIdentified = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            risk.RiskStatus = new Entities.Project.RiskStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            risk.DateStatusChanged = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            risk.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            risk.Likelihood = sqlDataReader.GetInt32(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            risk.Severity = sqlDataReader.GetInt32(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            risk.Responsible = new Entities.Core.Party(sqlDataReader.GetInt32(10));
                        risks.Add(risk);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Project.Risk risk = new Entities.Project.Risk();
                    risk.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    risk.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    risks.Add(risk);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return risks.ToArray();
        }

        public Entities.Project.Risk Insert(Entities.Project.Risk pRisk, int pRiskLogID)
        {
            Entities.Project.Risk risk = new Entities.Project.Risk();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Risk_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskLogID", pRiskLogID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskTypeID", ((pRisk.RiskType != null && pRisk.RiskType.RiskTypeID.HasValue) ? pRisk.RiskType.RiskTypeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthorPartyID", ((pRisk.Author != null && pRisk.Author.PartyID.HasValue) ? pRisk.Author.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateIdentified", pRisk.DateIdentified));
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskStatusID", ((pRisk.RiskStatus != null && pRisk.RiskStatus.RiskStatusID.HasValue) ? pRisk.RiskStatus.RiskStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateStatusChanged", pRisk.DateStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pRisk.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@Likelihood", pRisk.Likelihood));
                    sqlCommand.Parameters.Add(new SqlParameter("@Severity", pRisk.Severity));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponsiblePartyID", ((pRisk.Responsible != null && pRisk.Responsible.PartyID.HasValue) ? pRisk.Responsible.PartyID : null)));
                    SqlParameter riskID = sqlCommand.Parameters.Add("@RiskID", SqlDbType.Int);
                    riskID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    risk = new Entities.Project.Risk((Int32)riskID.Value);
                    risk.RiskType = pRisk.RiskType;
                    risk.Author = pRisk.Author;
                    risk.DateIdentified = pRisk.DateIdentified;
                    risk.RiskStatus = pRisk.RiskStatus;
                    risk.DateStatusChanged = pRisk.DateStatusChanged;
                    risk.Description = pRisk.Description;
                    risk.Likelihood = pRisk.Likelihood;
                    risk.Severity = pRisk.Severity;
                    risk.Responsible = pRisk.Responsible;
                }
                catch (Exception exc)
                {
                    risk.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    risk.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return risk;
        }

        public Entities.Project.Risk Update(Entities.Project.Risk pRisk, int pRiskLogID)
        {
            Entities.Project.Risk risk = new Entities.Project.Risk();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Risk_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskID", pRisk.RiskID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskLogID", pRiskLogID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskTypeID", ((pRisk.RiskType != null && pRisk.RiskType.RiskTypeID.HasValue) ? pRisk.RiskType.RiskTypeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthorPartyID", ((pRisk.Author != null && pRisk.Author.PartyID.HasValue) ? pRisk.Author.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateIdentified", pRisk.DateIdentified));
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskStatusID", ((pRisk.RiskStatus != null && pRisk.RiskStatus.RiskStatusID.HasValue) ? pRisk.RiskStatus.RiskStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateStatusChanged", pRisk.DateStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pRisk.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@Likelihood", pRisk.Likelihood));
                    sqlCommand.Parameters.Add(new SqlParameter("@Severity", pRisk.Severity));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponsiblePartyID", ((pRisk.Responsible != null && pRisk.Responsible.PartyID.HasValue) ? pRisk.Responsible.PartyID : null)));

                    sqlCommand.ExecuteNonQuery();

                    risk = new Entities.Project.Risk(pRisk.RiskID);
                    risk.RiskType = pRisk.RiskType;
                    risk.Author = pRisk.Author;
                    risk.DateIdentified = pRisk.DateIdentified;
                    risk.RiskStatus = pRisk.RiskStatus;
                    risk.DateStatusChanged = pRisk.DateStatusChanged;
                    risk.Description = pRisk.Description;
                    risk.Likelihood = pRisk.Likelihood;
                    risk.Severity = pRisk.Severity;
                    risk.Responsible = pRisk.Responsible;
                }
                catch (Exception exc)
                {
                    risk.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    risk.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return risk;
        }

        public Entities.Project.Risk Update(Entities.Project.Risk pRisk)
        {
            Entities.Project.Risk risk = new Entities.Project.Risk();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Risk_UpdateWithoutLog]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskID", pRisk.RiskID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskTypeID", ((pRisk.RiskType != null && pRisk.RiskType.RiskTypeID.HasValue) ? pRisk.RiskType.RiskTypeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthorPartyID", ((pRisk.Author != null && pRisk.Author.PartyID.HasValue) ? pRisk.Author.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateIdentified", pRisk.DateIdentified));
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskStatusID", ((pRisk.RiskStatus != null && pRisk.RiskStatus.RiskStatusID.HasValue) ? pRisk.RiskStatus.RiskStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateStatusChanged", pRisk.DateStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pRisk.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@Likelihood", pRisk.Likelihood));
                    sqlCommand.Parameters.Add(new SqlParameter("@Severity", pRisk.Severity));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponsiblePartyID", ((pRisk.Responsible != null && pRisk.Responsible.PartyID.HasValue) ? pRisk.Responsible.PartyID : null)));

                    sqlCommand.ExecuteNonQuery();

                    risk = new Entities.Project.Risk(pRisk.RiskID);
                    risk.RiskType = pRisk.RiskType;
                    risk.Author = pRisk.Author;
                    risk.DateIdentified = pRisk.DateIdentified;
                    risk.RiskStatus = pRisk.RiskStatus;
                    risk.DateStatusChanged = pRisk.DateStatusChanged;
                    risk.Description = pRisk.Description;
                    risk.Likelihood = pRisk.Likelihood;
                    risk.Severity = pRisk.Severity;
                    risk.Responsible = pRisk.Responsible;
                }
                catch (Exception exc)
                {
                    risk.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    risk.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return risk;
        }

        public Entities.Project.Risk Delete(Entities.Project.Risk pRisk)
        {
            Entities.Project.Risk risk = new Entities.Project.Risk();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Risk_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskID", pRisk.RiskID));

                    sqlCommand.ExecuteNonQuery();

                    risk = new Entities.Project.Risk(pRisk.RiskID);
                }
                catch (Exception exc)
                {
                    risk.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    risk.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return risk;
        }
    }
}
