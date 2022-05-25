using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare
{
    public class ClinicalTrialDOL : BaseDOL
    {
        public ClinicalTrialDOL() : base ()
        {
        }

        public ClinicalTrialDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ClinicalTrial Get(int? pClinicalTrialID)
        {
            ClinicalTrial clinicalTrial = new ClinicalTrial();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalTrial_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        clinicalTrial = new ClinicalTrial(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            clinicalTrial.ProtocolNumber = sqlDataReader.GetString(1);
                        clinicalTrial.TrialDuration = new Duration(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            clinicalTrial.TrialDuration.PlannedStart = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            clinicalTrial.TrialDuration.ForecastStart = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            clinicalTrial.TrialDuration.ActualStart = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            clinicalTrial.TrialDuration.PlannedEnd = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            clinicalTrial.TrialDuration.ForecastEnd = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            clinicalTrial.TrialDuration.PlannedEnd = sqlDataReader.GetDateTime(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    clinicalTrial.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalTrial.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalTrial;
        }

        public ClinicalTrial[] List(int pHealthOrganisationID)
        {
            List<ClinicalTrial> clinicalTrials = new List<ClinicalTrial>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalTrial_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@HealthOrganisationID", pHealthOrganisationID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ClinicalTrial clinicalTrial = new ClinicalTrial(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            clinicalTrial.ProtocolNumber = sqlDataReader.GetString(1);
                        clinicalTrial.TrialDuration = new Duration(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            clinicalTrial.TrialDuration.PlannedStart = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            clinicalTrial.TrialDuration.ForecastStart = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            clinicalTrial.TrialDuration.ActualStart = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            clinicalTrial.TrialDuration.PlannedEnd = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            clinicalTrial.TrialDuration.ForecastEnd = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            clinicalTrial.TrialDuration.PlannedEnd = sqlDataReader.GetDateTime(8);
                        clinicalTrials.Add(clinicalTrial);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ClinicalTrial clinicalTrial = new ClinicalTrial();
                    clinicalTrial.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalTrial.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    clinicalTrials.Add(clinicalTrial);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalTrials.ToArray();
        }

        public ClinicalTrial Insert(ClinicalTrial pClinicalTrial, int pHealthOrganisationID)
        {
            ClinicalTrial clinicalTrial = new ClinicalTrial();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalTrial_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@HealthOrganisationID", pHealthOrganisationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProtocolNumber", pClinicalTrial.ProtocolNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationID", pClinicalTrial.TrialDuration.DurationID));
                    SqlParameter clinicalTrialID = sqlCommand.Parameters.Add("@ClinicalTrialID", SqlDbType.Int);
                    clinicalTrialID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    clinicalTrial = new ClinicalTrial((Int32)clinicalTrialID.Value);
                    clinicalTrial.ProtocolNumber = pClinicalTrial.ProtocolNumber;
                    clinicalTrial.TrialDuration = new Duration(pClinicalTrial.TrialDuration.DurationID);
                }
                catch (Exception exc)
                {
                    clinicalTrial.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalTrial.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalTrial;
        }

        public ClinicalTrial Update(ClinicalTrial pClinicalTrial, int pHealthOrganisationID)
        {
            ClinicalTrial clinicalTrial = new ClinicalTrial();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalTrial_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrial.ClinicalTrialID));
                    sqlCommand.Parameters.Add(new SqlParameter("@HealthOrganisationID", pHealthOrganisationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProtocolNumber", pClinicalTrial.ProtocolNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationID", pClinicalTrial.TrialDuration.DurationID));

                    sqlCommand.ExecuteNonQuery();

                    clinicalTrial = new ClinicalTrial(pClinicalTrial.ClinicalTrialID);
                    clinicalTrial.ProtocolNumber = pClinicalTrial.ProtocolNumber;
                    clinicalTrial.TrialDuration = new Duration(pClinicalTrial.TrialDuration.DurationID);
                }
                catch (Exception exc)
                {
                    clinicalTrial.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalTrial.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalTrial;
        }

        public ClinicalTrial Delete(ClinicalTrial pClinicalTrial)
        {
            ClinicalTrial clinicalTrial = new ClinicalTrial();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalTrial_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrial.ClinicalTrialID));

                    sqlCommand.ExecuteNonQuery();

                    clinicalTrial = new ClinicalTrial(pClinicalTrial.ClinicalTrialID);
                }
                catch (Exception exc)
                {
                    clinicalTrial.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalTrial.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalTrial;
        }

        public BaseBoolean AssignContent(int pClinicalTrialID, int pContentID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalTrialContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListContent(int pClinicalTrialID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> contents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalTrialContent_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        content.Name = sqlDataReader.GetString(1);
                        content.Description = sqlDataReader.GetString(2);
                        content.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            content.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        contents.Add(content);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content content = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    content.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    content.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contents.Add(content);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contents.ToArray();
        }

        public BaseBoolean RemoveContent(int pClinicalTrialID, int pContentID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalTrialContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}
