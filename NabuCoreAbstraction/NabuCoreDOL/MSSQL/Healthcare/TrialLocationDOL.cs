using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare
{
    public class TrialLocationDOL : BaseDOL
    {
        public TrialLocationDOL() : base ()
        {
        }

        public TrialLocationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TrialLocation Get(int? pTrialLocationID)
        {
            TrialLocation trialLocation = new TrialLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialLocation_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrialLocationID", pTrialLocationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        trialLocation = new TrialLocation(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            trialLocation.LocationIdentifier = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            trialLocation.JoinedTrial = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            trialLocation.LeftTrial = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    trialLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialLocation;
        }

        public TrialLocation Get(int? pHealthOrganisationID, int? pClinicalTrialID)
        {
            TrialLocation trialLocation = new TrialLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialLocation_GetByTrialAndOrganisation]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));
                    sqlCommand.Parameters.Add(new SqlParameter("@HealthOrganisationID", pHealthOrganisationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        trialLocation = new TrialLocation(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            trialLocation.LocationIdentifier = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            trialLocation.JoinedTrial = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            trialLocation.LeftTrial = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    trialLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialLocation;
        }
        public TrialLocation GetByLocationIdentifier(int? pClinicalTrialID, string pLocationIdentifier)
        {
            TrialLocation trialLocation = new TrialLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialLocation_GetByLocationIdentifier]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationIdentifier", pLocationIdentifier));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        trialLocation = new TrialLocation(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            trialLocation.LocationIdentifier = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            trialLocation.JoinedTrial = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            trialLocation.LeftTrial = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    trialLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialLocation;
        }

        public TrialLocation[] List(int pClinicalTrialID)
        {
            List<TrialLocation> trialLocations = new List<TrialLocation>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialLocation_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TrialLocation trialLocation = new TrialLocation(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            trialLocation.LocationIdentifier = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            trialLocation.JoinedTrial = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            trialLocation.LeftTrial = sqlDataReader.GetDateTime(3);
                        trialLocations.Add(trialLocation);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TrialLocation trialLocation = new TrialLocation();
                    trialLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    trialLocations.Add(trialLocation);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialLocations.ToArray();
        }

        public TrialLocation Insert(TrialLocation pTrialLocation, int pHealthOrganisationID, int pClinicalTrialID)
        {
            TrialLocation trialLocation = new TrialLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialLocation_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@HealthOrganisationID", pHealthOrganisationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationIdentifier", pTrialLocation.LocationIdentifier));
                    sqlCommand.Parameters.Add(new SqlParameter("@JoinedTrial", pTrialLocation.JoinedTrial));
                    SqlParameter trialLocationID = sqlCommand.Parameters.Add("@TrialLocationID", SqlDbType.Int);
                    trialLocationID.Direction = ParameterDirection.Output;
    
                    sqlCommand.ExecuteNonQuery();

                    trialLocation = new TrialLocation((Int32)trialLocationID.Value);
                    trialLocation.LocationIdentifier = pTrialLocation.LocationIdentifier;
                    trialLocation.JoinedTrial = pTrialLocation.JoinedTrial;
                }
                catch (Exception exc)
                {
                    trialLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialLocation;
        }

        public TrialLocation Update(TrialLocation pTrialLocation, int pHealthOrganisationID, int pClinicalTrialID)
        {
            TrialLocation trialLocation = new TrialLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialLocation_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@HealthOrganisationID", pHealthOrganisationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LocationIdentifier", pTrialLocation.LocationIdentifier));
                    sqlCommand.Parameters.Add(new SqlParameter("@JoinedTrial", pTrialLocation.JoinedTrial));
                    sqlCommand.Parameters.Add(new SqlParameter("@LeftTrial", ((pTrialLocation.LeftTrial.HasValue == true) ? pTrialLocation.LeftTrial : null)));

                    sqlCommand.ExecuteNonQuery();

                    trialLocation = new TrialLocation(pTrialLocation.TrialLocationID);
                    trialLocation.LocationIdentifier = pTrialLocation.LocationIdentifier;
                    trialLocation.JoinedTrial = pTrialLocation.JoinedTrial;
                    trialLocation.LeftTrial = pTrialLocation.LeftTrial;
                }
                catch (Exception exc)
                {
                    trialLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialLocation;
        }

        public TrialLocation Delete(int? pTrialLocationID)
        {
            TrialLocation trialLocation = new TrialLocation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialLocation_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrialLocationID", pTrialLocationID));

                    sqlCommand.ExecuteNonQuery();

                    trialLocation = new TrialLocation(pTrialLocationID);
                }
                catch (Exception exc)
                {
                    trialLocation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialLocation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialLocation;
        }
    }
}
