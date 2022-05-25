using Octavo.Gate.Nabu.CORE.Entities.Education;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class SpecificationPartyRoleDOL : BaseDOL
    {
        public SpecificationPartyRoleDOL() : base ()
        {
        }

        public SpecificationPartyRoleDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public SpecificationPartyRole Get(int? pSpecificationID, int? pPartyRoleID, int pLanguageID)
        {
            SpecificationPartyRole specificationPartyRole = new SpecificationPartyRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SpecificationPartyRole_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleID", pPartyRoleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
		                specificationPartyRole = new SpecificationPartyRole();
                        specificationPartyRole.fromDate = sqlDataReader.GetDateTime(0);
                        if (sqlDataReader.IsDBNull(1) == false)
                            specificationPartyRole.toDate = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2)==false)
                            specificationPartyRole.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(2));

                        specificationPartyRole.partyID = sqlDataReader.GetInt32(3);
                        specificationPartyRole.partyRole = new Entities.Core.PartyRole(sqlDataReader.GetInt32(4));
                        specificationPartyRole.partyRole.PartyRoleType = new Entities.Core.PartyRoleType(sqlDataReader.GetInt32(5));
                        specificationPartyRole.partyRole.PartyRoleType.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        if (sqlDataReader.IsDBNull(7) == false)
                            specificationPartyRole.partyRole.FromDate = sqlDataReader.GetDateTime(7);

                        specificationPartyRole.specification = new Specification(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            specificationPartyRole.specification.Organisation = new Entities.Core.FormalOrganisation(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            specificationPartyRole.specification.Qualification = new Qualification(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            specificationPartyRole.specification.Detail = base.GetTranslation(sqlDataReader.GetInt32(11), pLanguageID);
                        if (sqlDataReader.IsDBNull(12) == false)
                            specificationPartyRole.specification.NationalClassificationCode = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            specificationPartyRole.specification.StartDate = sqlDataReader.GetDateTime(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            specificationPartyRole.specification.EndDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            specificationPartyRole.specification.IsPublicallyAvailable = sqlDataReader.GetBoolean(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            specificationPartyRole.specification.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(16));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    specificationPartyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specificationPartyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specificationPartyRole;
        }

        public SpecificationPartyRole[] List(Specification pSpecification, int pLanguageID)
        {
            List<SpecificationPartyRole> specificationPartyRoles = new List<SpecificationPartyRole>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SpecificationPartyRole_ListBySpecification]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        SpecificationPartyRole specificationPartyRole = new SpecificationPartyRole();
                        specificationPartyRole.fromDate = sqlDataReader.GetDateTime(0);
                        if (sqlDataReader.IsDBNull(1) == false)
                            specificationPartyRole.toDate = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            specificationPartyRole.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(2));

                        specificationPartyRole.partyID = sqlDataReader.GetInt32(3);
                        specificationPartyRole.partyRole = new Entities.Core.PartyRole(sqlDataReader.GetInt32(4));
                        specificationPartyRole.partyRole.PartyRoleType = new Entities.Core.PartyRoleType(sqlDataReader.GetInt32(5));
                        specificationPartyRole.partyRole.PartyRoleType.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        if (sqlDataReader.IsDBNull(7) == false)
                            specificationPartyRole.partyRole.FromDate = sqlDataReader.GetDateTime(7);

                        specificationPartyRole.specification = new Specification(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            specificationPartyRole.specification.Organisation = new Entities.Core.FormalOrganisation(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            specificationPartyRole.specification.Qualification = new Qualification(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            specificationPartyRole.specification.Detail = base.GetTranslation(sqlDataReader.GetInt32(11), pLanguageID);
                        if (sqlDataReader.IsDBNull(12) == false)
                            specificationPartyRole.specification.NationalClassificationCode = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            specificationPartyRole.specification.StartDate = sqlDataReader.GetDateTime(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            specificationPartyRole.specification.EndDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            specificationPartyRole.specification.IsPublicallyAvailable = sqlDataReader.GetBoolean(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            specificationPartyRole.specification.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(16));

                        specificationPartyRoles.Add(specificationPartyRole);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    SpecificationPartyRole specificationPartyRole = new SpecificationPartyRole();
                    specificationPartyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specificationPartyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specificationPartyRoles.Add(specificationPartyRole);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specificationPartyRoles.ToArray();
        }

        public SpecificationPartyRole[] List(Entities.Core.PartyRole pPartyRole, int pLanguageID)
        {
            List<SpecificationPartyRole> specificationPartyRoles = new List<SpecificationPartyRole>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SpecificationPartyRole_ListByPartyRole]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleID", pPartyRole.PartyRoleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        SpecificationPartyRole specificationPartyRole = new SpecificationPartyRole();
                        specificationPartyRole.fromDate = sqlDataReader.GetDateTime(0);
                        if (sqlDataReader.IsDBNull(1) == false)
                            specificationPartyRole.toDate = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            specificationPartyRole.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(2));

                        specificationPartyRole.partyID = sqlDataReader.GetInt32(3);
                        specificationPartyRole.partyRole = new Entities.Core.PartyRole(sqlDataReader.GetInt32(4));
                        specificationPartyRole.partyRole.PartyRoleType = new Entities.Core.PartyRoleType(sqlDataReader.GetInt32(5));
                        specificationPartyRole.partyRole.PartyRoleType.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        if (sqlDataReader.IsDBNull(7) == false)
                            specificationPartyRole.partyRole.FromDate = sqlDataReader.GetDateTime(7);

                        specificationPartyRole.specification = new Specification(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            specificationPartyRole.specification.Organisation = new Entities.Core.FormalOrganisation(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            specificationPartyRole.specification.Qualification = new Qualification(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            specificationPartyRole.specification.Detail = base.GetTranslation(sqlDataReader.GetInt32(11), pLanguageID);
                        if (sqlDataReader.IsDBNull(12) == false)
                            specificationPartyRole.specification.NationalClassificationCode = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            specificationPartyRole.specification.StartDate = sqlDataReader.GetDateTime(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            specificationPartyRole.specification.EndDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            specificationPartyRole.specification.IsPublicallyAvailable = sqlDataReader.GetBoolean(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            specificationPartyRole.specification.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(16));

                        specificationPartyRoles.Add(specificationPartyRole);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    SpecificationPartyRole specificationPartyRole = new SpecificationPartyRole();
                    specificationPartyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specificationPartyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specificationPartyRoles.Add(specificationPartyRole);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specificationPartyRoles.ToArray();
        }

        public SpecificationPartyRole[] List(Entities.Core.Party pParty, int pLanguageID)
        {
            List<SpecificationPartyRole> specificationPartyRoles = new List<SpecificationPartyRole>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SpecificationPartyRole_ListByParty]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pParty.PartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        SpecificationPartyRole specificationPartyRole = new SpecificationPartyRole();
                        specificationPartyRole.fromDate = sqlDataReader.GetDateTime(0);
                        if (sqlDataReader.IsDBNull(1) == false)
                            specificationPartyRole.toDate = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            specificationPartyRole.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(2));

                        specificationPartyRole.partyID = sqlDataReader.GetInt32(3);
                        specificationPartyRole.partyRole = new Entities.Core.PartyRole(sqlDataReader.GetInt32(4));
                        specificationPartyRole.partyRole.PartyRoleType = new Entities.Core.PartyRoleType(sqlDataReader.GetInt32(5));
                        specificationPartyRole.partyRole.PartyRoleType.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        if (sqlDataReader.IsDBNull(7) == false)
                            specificationPartyRole.partyRole.FromDate = sqlDataReader.GetDateTime(7);

                        specificationPartyRole.specification = new Specification(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            specificationPartyRole.specification.Organisation = new Entities.Core.FormalOrganisation(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            specificationPartyRole.specification.Qualification = new Qualification(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            specificationPartyRole.specification.Detail = base.GetTranslation(sqlDataReader.GetInt32(11), pLanguageID);
                        if (sqlDataReader.IsDBNull(12) == false)
                            specificationPartyRole.specification.NationalClassificationCode = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            specificationPartyRole.specification.StartDate = sqlDataReader.GetDateTime(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            specificationPartyRole.specification.EndDate = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            specificationPartyRole.specification.IsPublicallyAvailable = sqlDataReader.GetBoolean(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            specificationPartyRole.specification.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(16));

                        specificationPartyRoles.Add(specificationPartyRole);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    SpecificationPartyRole specificationPartyRole = new SpecificationPartyRole();
                    specificationPartyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specificationPartyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specificationPartyRoles.Add(specificationPartyRole);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specificationPartyRoles.ToArray();
        }

        public SpecificationPartyRole Insert(SpecificationPartyRole pSpecificationPartyRole)
        {
            SpecificationPartyRole specificationPartyRole = new SpecificationPartyRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SpecificationPartyRole_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationPartyRole.specification.SpecificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleID", pSpecificationPartyRole.partyRole.PartyRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pSpecificationPartyRole.fromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", pSpecificationPartyRole.toDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", ((pSpecificationPartyRole.Attributes != null) ? pSpecificationPartyRole.Attributes.ToXMLFragment() : null)));

                    sqlCommand.ExecuteNonQuery();

                    specificationPartyRole.specification = pSpecificationPartyRole.specification;
                    specificationPartyRole.partyRole = pSpecificationPartyRole.partyRole;
                    specificationPartyRole.fromDate = pSpecificationPartyRole.fromDate;
                    specificationPartyRole.toDate = pSpecificationPartyRole.toDate;
                    if (pSpecificationPartyRole.Attributes != null)
                        specificationPartyRole.Attributes = new Entities.Utility.EntityAttributeCollection(pSpecificationPartyRole.Attributes.ToXMLFragment());
                }
                catch (Exception exc)
                {
                    specificationPartyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specificationPartyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specificationPartyRole;
        }

        public SpecificationPartyRole Update(SpecificationPartyRole pSpecificationPartyRole)
        {
            SpecificationPartyRole specificationPartyRole = new SpecificationPartyRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SpecificationPartyRole_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationPartyRole.specification.SpecificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleID", pSpecificationPartyRole.partyRole.PartyRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pSpecificationPartyRole.fromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", pSpecificationPartyRole.toDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", ((pSpecificationPartyRole.Attributes != null) ? pSpecificationPartyRole.Attributes.ToXMLFragment() : null)));

                    sqlCommand.ExecuteNonQuery();

                    specificationPartyRole.specification = pSpecificationPartyRole.specification;
                    specificationPartyRole.partyRole = pSpecificationPartyRole.partyRole;
                    specificationPartyRole.fromDate = pSpecificationPartyRole.fromDate;
                    specificationPartyRole.toDate = pSpecificationPartyRole.toDate;
                    if (pSpecificationPartyRole.Attributes != null)
                        specificationPartyRole.Attributes = new Entities.Utility.EntityAttributeCollection(pSpecificationPartyRole.Attributes.ToXMLFragment());
                }
                catch (Exception exc)
                {
                    specificationPartyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specificationPartyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specificationPartyRole;
        }

        public SpecificationPartyRole Delete(SpecificationPartyRole pSpecificationPartyRole)
        {
            SpecificationPartyRole specificationPartyRole = new SpecificationPartyRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SpecificationPartyRole_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationPartyRole.specification.SpecificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyRoleID", pSpecificationPartyRole.partyRole.PartyRoleID));

                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    specificationPartyRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specificationPartyRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specificationPartyRole;
        }
    }
}
