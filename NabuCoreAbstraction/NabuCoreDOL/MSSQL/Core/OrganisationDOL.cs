using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core
{
    public class OrganisationDOL : BaseDOL
    {
        public OrganisationDOL() : base()
        {
        }

        public OrganisationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Organisation Get(int pOrganisationID, int pLanguageID)
        {
            Organisation organisation = new Organisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Organisation_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrganisationID", pOrganisationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        organisation = new Organisation(sqlDataReader.GetInt32(0));
                        organisation.Name = sqlDataReader.GetString(1);
                        organisation.PartyType = new PartyType(sqlDataReader.GetInt32(2));
                        organisation.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    organisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    organisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return organisation;
        }

        public Organisation[] List(int pLanguageID)
        {
            List<Organisation> organisations = new List<Organisation>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Organisation_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Organisation organisation = new Organisation(sqlDataReader.GetInt32(0));
                        organisation.Name = sqlDataReader.GetString(1);
                        organisation.PartyType = new PartyType(sqlDataReader.GetInt32(2));
                        organisation.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);

                        organisations.Add(organisation);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Organisation organisation = new Organisation();
                    organisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    organisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    organisations.Add(organisation);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return organisations.ToArray();
        }

        public Organisation[] ListByPartyTypeAlias(string pAlias, int pLanguageID)
        {
            List<Organisation> organisations = new List<Organisation>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Organisation_ListByPartyTypeAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Organisation organisation = new Organisation(sqlDataReader.GetInt32(0));
                        organisation.Name = sqlDataReader.GetString(1);
                        organisation.PartyType = new PartyType(sqlDataReader.GetInt32(2));
                        organisation.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);

                        organisations.Add(organisation);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Organisation organisation = new Organisation();
                    organisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    organisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    organisations.Add(organisation);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return organisations.ToArray();
        }

        public Organisation Insert(Organisation pOrganisation)
        {
            Organisation organisation = new Organisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Organisation_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pOrganisation.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pOrganisation.PartyType.PartyTypeID));
                    SqlParameter organisationID = sqlCommand.Parameters.Add("@OrganisationID", SqlDbType.Int);
                    organisationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    organisation = new Organisation((Int32)organisationID.Value);
                    organisation.Name = pOrganisation.Name;
                    organisation.PartyType = new PartyType(pOrganisation.PartyType.PartyTypeID);
                }
                catch (Exception exc)
                {
                    organisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    organisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return organisation;
        }

        public Organisation Update(Organisation pOrganisation)
        {
            Organisation organisation = new Organisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Organisation_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrganisationID", pOrganisation.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pOrganisation.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pOrganisation.PartyType.PartyTypeID));

                    sqlCommand.ExecuteNonQuery();

                    organisation = new Organisation(pOrganisation.PartyID);
                    organisation.Name = pOrganisation.Name;
                    organisation.PartyType = new PartyType(pOrganisation.PartyType.PartyTypeID);
                }
                catch (Exception exc)
                {
                    organisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    organisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return organisation;
        }

        public Organisation Delete(Organisation pOrganisation)
        {
            Organisation organisation = new Organisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Organisation_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrganisationID", pOrganisation.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    organisation = new Organisation(pOrganisation.PartyID);
                }
                catch (Exception exc)
                {
                    organisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    organisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return organisation;
        }
    }
}

