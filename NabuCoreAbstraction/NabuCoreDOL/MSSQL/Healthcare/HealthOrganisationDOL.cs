using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare
{
    public class HealthOrganisationDOL : BaseDOL
    {
        public HealthOrganisationDOL() : base ()
        {
        }

        public HealthOrganisationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public HealthOrganisation Get(int? pHealthOrganisationID, int pLanguageID)
        {
            HealthOrganisation healthOrganisation = new HealthOrganisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[HealthOrganisation_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@HealthOrganisationID", pHealthOrganisationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        healthOrganisation = new HealthOrganisation(sqlDataReader.GetInt32(0));
                        healthOrganisation.Name = sqlDataReader.GetString(1);
                        healthOrganisation.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(2));
                        healthOrganisation.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    healthOrganisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    healthOrganisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return healthOrganisation;
        }

        public HealthOrganisation[] List(int pLanguageID)
        {
            List<HealthOrganisation> healthOrganisations = new List<HealthOrganisation>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[HealthOrganisation_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        HealthOrganisation healthOrganisation = new HealthOrganisation(sqlDataReader.GetInt32(0));
                        healthOrganisation.Name = sqlDataReader.GetString(1);
                        healthOrganisation.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(2));
                        healthOrganisation.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        healthOrganisations.Add(healthOrganisation);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    HealthOrganisation healthOrganisation = new HealthOrganisation();
                    healthOrganisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    healthOrganisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    healthOrganisations.Add(healthOrganisation);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return healthOrganisations.ToArray();
        }

        public HealthOrganisation Insert(HealthOrganisation pHealthOrganisation)
        {
            HealthOrganisation healthOrganisation = new HealthOrganisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[HealthOrganisation_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@HealthOrganisationID", pHealthOrganisation.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    healthOrganisation = new HealthOrganisation(pHealthOrganisation.PartyID);
                }
                catch (Exception exc)
                {
                    healthOrganisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    healthOrganisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return healthOrganisation;
        }

        public HealthOrganisation Delete(HealthOrganisation pHealthOrganisation)
        {
            HealthOrganisation healthOrganisation = new HealthOrganisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[HealthOrganisation_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@HealthOrganisationID", pHealthOrganisation.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    healthOrganisation = new HealthOrganisation(pHealthOrganisation.PartyID);
                }
                catch (Exception exc)
                {
                    healthOrganisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    healthOrganisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return healthOrganisation;
        }
    }
}
