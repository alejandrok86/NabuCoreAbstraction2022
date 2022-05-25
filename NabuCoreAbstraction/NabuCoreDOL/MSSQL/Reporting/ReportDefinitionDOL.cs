using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Reporting;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Reporting
{
    public class ReportDefinitionDOL : BaseDOL
    {
        public ReportDefinitionDOL() : base ()
        {
        }

        public ReportDefinitionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ReportDefinition Get(int pReportDefinitionID, int pLanguageID)
        {
            ReportDefinition reportDefinition = new ReportDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchReporting].[ReportDefinition_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ReportDefinitionID", pReportDefinitionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        reportDefinition = new ReportDefinition(sqlDataReader.GetInt32(0));
                        reportDefinition.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            reportDefinition.OwnedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        reportDefinition.FromXML(sqlDataReader.GetString(3));
                        reportDefinition.RequiresParameters = sqlDataReader.GetBoolean(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    reportDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    reportDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return reportDefinition;
        }

        public ReportDefinition[] ListPublic(int pLanguageID)
        {
            List<ReportDefinition> reportDefinitions = new List<ReportDefinition>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchReporting].[ReportDefinition_ListPublic]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ReportDefinition reportDefinition = new ReportDefinition(sqlDataReader.GetInt32(0));
                        reportDefinition.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            reportDefinition.OwnedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        reportDefinition.FromXML(sqlDataReader.GetString(3));
                        reportDefinitions.Add(reportDefinition);
                        reportDefinition.RequiresParameters = sqlDataReader.GetBoolean(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ReportDefinition reportDefinition = new ReportDefinition();
                    reportDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    reportDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    reportDefinitions.Add(reportDefinition);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return reportDefinitions.ToArray();
        }

        public ReportDefinition[] ListPrivate(int pPartyID, int pLanguageID)
        {
            List<ReportDefinition> reportDefinitions = new List<ReportDefinition>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchReporting].[ReportDefinition_ListPrivate]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ReportDefinition reportDefinition = new ReportDefinition(sqlDataReader.GetInt32(0));
                        reportDefinition.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            reportDefinition.OwnedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        reportDefinition.FromXML(sqlDataReader.GetString(3));
                        reportDefinition.RequiresParameters = sqlDataReader.GetBoolean(4);
                        reportDefinitions.Add(reportDefinition);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ReportDefinition reportDefinition = new ReportDefinition();
                    reportDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    reportDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    reportDefinitions.Add(reportDefinition);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return reportDefinitions.ToArray();
        }

        public ReportDefinition Insert(ReportDefinition pReportDefinition)
        {
            ReportDefinition reportDefinition = new ReportDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchReporting].[ReportDefinition_Insert]");
                try
                {
                    pReportDefinition.Detail = base.InsertTranslation(pReportDefinition.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pReportDefinition.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnedByPartyID", ((pReportDefinition != null) ? pReportDefinition.OwnedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ReportDefinitionXML", pReportDefinition.ToXML()));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequiresParameters", pReportDefinition.RequiresParameters));
                    SqlParameter reportDefinitionID = sqlCommand.Parameters.Add("@ReportDefinitionID", SqlDbType.Int);
                    reportDefinitionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    reportDefinition = new ReportDefinition((Int32)reportDefinitionID.Value);
                    reportDefinition.Detail = new Translation(pReportDefinition.Detail.TranslationID);
                    reportDefinition.Detail.Alias = pReportDefinition.Detail.Alias;
                    reportDefinition.Detail.Description = pReportDefinition.Detail.Description;
                    reportDefinition.Detail.Name = pReportDefinition.Detail.Name;
                    if (pReportDefinition.OwnedBy != null)
                        reportDefinition.OwnedBy = new Entities.Core.Party(pReportDefinition.OwnedBy.PartyID);
                    reportDefinition.FromXML(pReportDefinition.ToXML());
                }
                catch (Exception exc)
                {
                    reportDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    reportDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return reportDefinition;
        }

        public ReportDefinition Update(ReportDefinition pReportDefinition)
        {
            ReportDefinition reportDefinition = new ReportDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchReporting].[ReportDefinition_Update]");
                try
                {
                    pReportDefinition.Detail = base.UpdateTranslation(pReportDefinition.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ReportDefinitionID", pReportDefinition.ReportDefinitionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pReportDefinition.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnedByPartyID", ((pReportDefinition != null) ? pReportDefinition.OwnedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ReportDefinitionXML", pReportDefinition.ToXML()));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequiresParameters", pReportDefinition.RequiresParameters));

                    sqlCommand.ExecuteNonQuery();

                    reportDefinition = new ReportDefinition(pReportDefinition.ReportDefinitionID);
                    reportDefinition.Detail = new Translation(pReportDefinition.Detail.TranslationID);
                    reportDefinition.Detail.Alias = pReportDefinition.Detail.Alias;
                    reportDefinition.Detail.Description = pReportDefinition.Detail.Description;
                    reportDefinition.Detail.Name = pReportDefinition.Detail.Name;
                    if (pReportDefinition.OwnedBy != null)
                        reportDefinition.OwnedBy = new Entities.Core.Party(pReportDefinition.OwnedBy.PartyID);
                    reportDefinition.FromXML(pReportDefinition.ToXML());
                }
                catch (Exception exc)
                {
                    reportDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    reportDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return reportDefinition;
        }

        public ReportDefinition Delete(ReportDefinition pReportDefinition)
        {
            ReportDefinition reportDefinition = new ReportDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchReporting].[ReportDefinition_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ReportDefinitionID", pReportDefinition.ReportDefinitionID));

                    sqlCommand.ExecuteNonQuery();

                    reportDefinition = new ReportDefinition(pReportDefinition.ReportDefinitionID);
                }
                catch (Exception exc)
                {
                    reportDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    reportDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return reportDefinition;
        }
    }
}

