using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class SpecificationDOL : BaseDOL
    {
        public SpecificationDOL() : base()
        {
        }

        public SpecificationDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Specification Get(int pSpecificationID, int pLanguageID)
        {
            Specification specification = new Specification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Specification_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        specification = new Specification(sqlDataReader.GetInt32(0));
                        specification.Organisation = new Entities.Core.FormalOrganisation(sqlDataReader.GetInt32(1));
                        if(sqlDataReader.IsDBNull(2) == false)
                            specification.Qualification = new Qualification(sqlDataReader.GetInt32(2));
                        specification.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        if (sqlDataReader.IsDBNull(4) == false)
                            specification.NationalClassificationCode = sqlDataReader.GetString(4);
                        specification.StartDate = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            specification.EndDate = sqlDataReader.GetDateTime(6);
                        specification.IsPublicallyAvailable = sqlDataReader.GetBoolean(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            specification.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    specification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specification;
        }

        public Specification GetByAlias(string pAlias, int pLanguageID)
        {
            Specification specification = new Specification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Specification_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        specification = new Specification(sqlDataReader.GetInt32(0));
                        specification.Organisation = new Entities.Core.FormalOrganisation(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            specification.Qualification = new Qualification(sqlDataReader.GetInt32(2));
                        specification.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        if (sqlDataReader.IsDBNull(4) == false)
                            specification.NationalClassificationCode = sqlDataReader.GetString(4);
                        specification.StartDate = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            specification.EndDate = sqlDataReader.GetDateTime(6);
                        specification.IsPublicallyAvailable = sqlDataReader.GetBoolean(7);
                        if(sqlDataReader.IsDBNull(8) == false)
                            specification.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    specification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specification;
        }

        public Specification[] List(int pLanguageID)
        {
            List<Specification> specifications = new List<Specification>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Specification_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Specification specification = new Specification(sqlDataReader.GetInt32(0));
                        specification.Organisation = new Entities.Core.FormalOrganisation(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            specification.Qualification = new Qualification(sqlDataReader.GetInt32(2));
                        specification.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        if (sqlDataReader.IsDBNull(4) == false)
                            specification.NationalClassificationCode = sqlDataReader.GetString(4);
                        specification.StartDate = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            specification.EndDate = sqlDataReader.GetDateTime(6);
                        specification.IsPublicallyAvailable = sqlDataReader.GetBoolean(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            specification.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                        specifications.Add(specification);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Specification specification = new Specification();
                    specification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specifications.Add(specification);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specifications.ToArray();
        }
        public Specification[] ListMine(int FormalOrganisationID, int pLanguageID)
        {
            List<Specification> specifications = new List<Specification>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Specification_ListMine]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FormalOrganisationID", FormalOrganisationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Specification specification = new Specification(sqlDataReader.GetInt32(0));
                        specification.Organisation = new Entities.Core.FormalOrganisation(sqlDataReader.GetInt32(1));
                        if(sqlDataReader.IsDBNull(2) == false)
                            specification.Qualification = new Qualification(sqlDataReader.GetInt32(2));
                        specification.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        if (sqlDataReader.IsDBNull(4) == false)
                            specification.NationalClassificationCode = sqlDataReader.GetString(4);
                        specification.StartDate = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            specification.EndDate = sqlDataReader.GetDateTime(6);
                        specification.IsPublicallyAvailable = sqlDataReader.GetBoolean(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            specification.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                        specifications.Add(specification);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Specification specification = new Specification();
                    specification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specifications.Add(specification);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specifications.ToArray();
        }

        public Specification[] ListPrivate(int FormalOrganisationID, int pLanguageID)
        {
            List<Specification> specifications = new List<Specification>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Specification_ListPrivate]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FormalOrganisationID", FormalOrganisationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Specification specification = new Specification(sqlDataReader.GetInt32(0));
                        specification.Organisation = new Entities.Core.FormalOrganisation(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            specification.Qualification = new Qualification(sqlDataReader.GetInt32(2));
                        specification.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        if (sqlDataReader.IsDBNull(4) == false)
                            specification.NationalClassificationCode = sqlDataReader.GetString(4);
                        specification.StartDate = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            specification.EndDate = sqlDataReader.GetDateTime(6);
                        specification.IsPublicallyAvailable = sqlDataReader.GetBoolean(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            specification.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                        specifications.Add(specification);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Specification specification = new Specification();
                    specification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specifications.Add(specification);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specifications.ToArray();
        }

        public Specification[] ListPublic(int pLanguageID)
        {
            List<Specification> specifications = new List<Specification>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Specification_ListPublic]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Specification specification = new Specification(sqlDataReader.GetInt32(0));
                        specification.Organisation = new Entities.Core.FormalOrganisation(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            specification.Qualification = new Qualification(sqlDataReader.GetInt32(2));
                        specification.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        if (sqlDataReader.IsDBNull(4) == false)
                            specification.NationalClassificationCode = sqlDataReader.GetString(4);
                        specification.StartDate = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            specification.EndDate = sqlDataReader.GetDateTime(6);
                        specification.IsPublicallyAvailable = sqlDataReader.GetBoolean(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            specification.Attributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                        specifications.Add(specification);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Specification specification = new Specification();
                    specification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specifications.Add(specification);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specifications.ToArray();
        }

        public Specification Insert(Specification pSpecification)
        {
            Specification specification = new Specification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Specification_Insert]");
                try
                {
                    pSpecification.Detail = base.InsertTranslation(pSpecification.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FormalOrganisationID",pSpecification.Organisation.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@QualificationID",((pSpecification.Qualification != null) ? pSpecification.Qualification.QualificationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pSpecification.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@NationalClassificationCode",((pSpecification.NationalClassificationCode != null) ? pSpecification.NationalClassificationCode : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate",pSpecification.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate",((pSpecification.EndDate.HasValue) ? pSpecification.EndDate : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPublicallyAvailable", pSpecification.IsPublicallyAvailable));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", ((pSpecification.Attributes != null) ? pSpecification.Attributes.ToXMLFragment() : null)));
                    SqlParameter specificationID = sqlCommand.Parameters.Add("@SpecificationID", SqlDbType.Int);
                    specificationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    specification = new Specification((Int32)specificationID.Value);
                    specification.Organisation = new Entities.Core.FormalOrganisation(pSpecification.Organisation.PartyID);
                    if(pSpecification.Qualification != null)
                        specification.Qualification = new Qualification(pSpecification.Qualification.QualificationID);
                    specification.Detail = new Translation(pSpecification.Detail.TranslationID);
                    specification.Detail.Alias = pSpecification.Detail.Alias;
                    specification.Detail.Description = pSpecification.Detail.Description;
                    specification.Detail.Name = pSpecification.Detail.Name;
                    if (pSpecification.NationalClassificationCode != null)
                        specification.NationalClassificationCode = pSpecification.NationalClassificationCode;
                    specification.StartDate = pSpecification.StartDate;
                    if (pSpecification.EndDate.HasValue)
                        specification.EndDate = pSpecification.EndDate;
                    specification.IsPublicallyAvailable = pSpecification.IsPublicallyAvailable;
                    specification.Attributes = pSpecification.Attributes;
                }
                catch (Exception exc)
                {
                    specification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specification;
        }

        public Specification Update(Specification pSpecification)
        {
            Specification specification = new Specification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Specification_Update]");
                try
                {
                    pSpecification.Detail = base.UpdateTranslation(pSpecification.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecification.SpecificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FormalOrganisationID", pSpecification.Organisation.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@QualificationID", ((pSpecification.Qualification != null) ? pSpecification.Qualification.QualificationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@NationalClassificationCode", ((pSpecification.NationalClassificationCode != null) ? pSpecification.NationalClassificationCode : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pSpecification.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", ((pSpecification.EndDate.HasValue) ? pSpecification.EndDate : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPublicallyAvailable", pSpecification.IsPublicallyAvailable));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", ((pSpecification.Attributes != null) ? pSpecification.Attributes.ToXMLFragment() : null)));

                    sqlCommand.ExecuteNonQuery();

                    specification = new Specification(pSpecification.SpecificationID);
                    specification.Organisation = new Entities.Core.FormalOrganisation(pSpecification.Organisation.PartyID);
                    if (pSpecification.Qualification != null)
                        specification.Qualification = new Qualification(pSpecification.Qualification.QualificationID);
                    specification.Detail = new Translation(pSpecification.Detail.TranslationID);
                    specification.Detail.Alias = pSpecification.Detail.Alias;
                    specification.Detail.Description = pSpecification.Detail.Description;
                    specification.Detail.Name = pSpecification.Detail.Name;
                    if (pSpecification.NationalClassificationCode != null)
                        specification.NationalClassificationCode = pSpecification.NationalClassificationCode;
                    specification.StartDate = pSpecification.StartDate;
                    if (pSpecification.EndDate.HasValue)
                        specification.EndDate = pSpecification.EndDate;
                    specification.IsPublicallyAvailable = pSpecification.IsPublicallyAvailable;
                    specification.Attributes = pSpecification.Attributes;
                }
                catch (Exception exc)
                {
                    specification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specification;
        }

        public Specification Delete(Specification pSpecification)
        {
            Specification specification = new Specification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[Specification_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecification.SpecificationID));

                    sqlCommand.ExecuteNonQuery();

                    specification = new Specification(pSpecification.SpecificationID);
                    base.DeleteAllTranslations(pSpecification.Detail);
                }
                catch (Exception exc)
                {
                    specification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specification;
        }

        public BaseBoolean AssignModuleToSpecification(int pSpecificationID, int pModuleID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SpecificationModule_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));

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

        public BaseBoolean RemoveModuleFromSpecification(int pSpecificationID, int pModuleID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SpecificationModule_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));

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
        public BaseBoolean AssignContentToSpecification(int pSpecificationID, int pContentID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SpecificationContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationID));
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

        public BaseBoolean RemoveContentFromSpecification(int pSpecificationID, int pContentID)
        {
            BaseBoolean result = new BaseBoolean();
            result.Value = false;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[SpecificationContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationID));
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

