using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class AssessingOrganisationDOL : BaseDOL
    {
        public AssessingOrganisationDOL() : base()
        {
        }

        public AssessingOrganisationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AssessingOrganisation Get(int pAssessingOrganisationID)
        {
            AssessingOrganisation AssessingOrganisation = new AssessingOrganisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AssessingOrganisation_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessingOrganisationID", pAssessingOrganisationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        AssessingOrganisation = new AssessingOrganisation(sqlDataReader.GetInt32(0));
                        AssessingOrganisation.Name = sqlDataReader.GetString(1);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssessingOrganisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    AssessingOrganisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return AssessingOrganisation;
        }

        public AssessingOrganisation[] List()
        {
            List<AssessingOrganisation> AssessingOrganisations = new List<AssessingOrganisation>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AssessingOrganisation_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AssessingOrganisation AssessingOrganisation = new AssessingOrganisation(sqlDataReader.GetInt32(0));
                        AssessingOrganisation.Name = sqlDataReader.GetString(1);

                        AssessingOrganisations.Add(AssessingOrganisation);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssessingOrganisation AssessingOrganisation = new AssessingOrganisation();
                    AssessingOrganisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    AssessingOrganisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    AssessingOrganisations.Add(AssessingOrganisation);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return AssessingOrganisations.ToArray();
        }

        public AssessingOrganisation Insert(AssessingOrganisation pAssessingOrganisation)
        {
            AssessingOrganisation AssessingOrganisation = new AssessingOrganisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AssessingOrganisation_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessingOrganisationID", pAssessingOrganisation.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    AssessingOrganisation = new AssessingOrganisation(pAssessingOrganisation.PartyID);
                }
                catch (Exception exc)
                {
                    AssessingOrganisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    AssessingOrganisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return AssessingOrganisation;
        }

        public AssessingOrganisation Delete(AssessingOrganisation pAssessingOrganisation)
        {
            AssessingOrganisation AssessingOrganisation = new AssessingOrganisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AssessingOrganisation_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessingOrganisationID", pAssessingOrganisation.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    AssessingOrganisation = new AssessingOrganisation(pAssessingOrganisation.PartyID);
                }
                catch (Exception exc)
                {
                    AssessingOrganisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    AssessingOrganisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return AssessingOrganisation;
        }
    }
}
