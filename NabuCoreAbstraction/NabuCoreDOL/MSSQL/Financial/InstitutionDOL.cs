using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class InstitutionDOL : BaseDOL
    {
        public InstitutionDOL() : base()
        {
        }

        public InstitutionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Institution Get(int pInstitutionID, int pLanguageID)
        {
            Institution institution = new Institution();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Institution_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        institution = new Institution(sqlDataReader.GetInt32(0));
                        institution.InstitutionType = new InstitutionType(sqlDataReader.GetInt32(1));
                        institution.InstitutionType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(2));
                        institution.Name = sqlDataReader.GetString(3);
                        institution.InstitutionStatus = new InstitutionStatus(sqlDataReader.GetInt32(4));
                        institution.InstitutionStatus.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(5));
                        institution.DefaultCurrency = new Currency(sqlDataReader.GetInt32(6));
                        institution.Country = new Entities.Globalisation.Country(sqlDataReader.GetInt32(7));
                        institution.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            institution.ShortName = sqlDataReader.GetString(9);

                        institution.InstitutionType.Detail.TranslationLanguage = new Entities.Globalisation.Language(pLanguageID);
                        institution.InstitutionType.Detail.Alias = sqlDataReader.GetString(10);
                        institution.InstitutionType.Detail.Name = sqlDataReader.GetString(11);
                        institution.InstitutionType.Detail.Description = sqlDataReader.GetString(12);

                        institution.InstitutionStatus.Detail.TranslationLanguage = new Entities.Globalisation.Language(pLanguageID);
                        institution.InstitutionStatus.Detail.Alias = sqlDataReader.GetString(13);
                        institution.InstitutionStatus.Detail.Name = sqlDataReader.GetString(14);
                        institution.InstitutionStatus.Detail.Description = sqlDataReader.GetString(15);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    institution.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institution.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institution;
        }

        public Institution GetForShortName(string pBankShortName, int pLanguageID)
        {
            Institution institution = new Institution();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Institution_GetForShortName]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BankShortName", pBankShortName));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        institution = new Institution(sqlDataReader.GetInt32(0));
                        institution.InstitutionType = new InstitutionType(sqlDataReader.GetInt32(1));
                        institution.InstitutionType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(2));
                        institution.Name = sqlDataReader.GetString(3);
                        institution.InstitutionStatus = new InstitutionStatus(sqlDataReader.GetInt32(4));
                        institution.InstitutionStatus.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(5));
                        institution.DefaultCurrency = new Currency(sqlDataReader.GetInt32(6));
                        institution.Country = new Entities.Globalisation.Country(sqlDataReader.GetInt32(7));
                        institution.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            institution.ShortName = sqlDataReader.GetString(9);

                        institution.InstitutionType.Detail.TranslationLanguage = new Entities.Globalisation.Language(pLanguageID);
                        institution.InstitutionType.Detail.Alias = sqlDataReader.GetString(10);
                        institution.InstitutionType.Detail.Name = sqlDataReader.GetString(11);
                        institution.InstitutionType.Detail.Description = sqlDataReader.GetString(12);

                        institution.InstitutionStatus.Detail.TranslationLanguage = new Entities.Globalisation.Language(pLanguageID);
                        institution.InstitutionStatus.Detail.Alias = sqlDataReader.GetString(13);
                        institution.InstitutionStatus.Detail.Name = sqlDataReader.GetString(14);
                        institution.InstitutionStatus.Detail.Description = sqlDataReader.GetString(15);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    institution.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institution.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institution;
        }

        public Institution GetForShortNameAndClientType(string pBankShortName, string pClientTypeName, int pLanguageID)
        {
            Institution institution = new Institution();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Institution_GetForShortNameAndClientType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BankShortName", pBankShortName));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientTypeName", pClientTypeName));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        institution = new Institution(sqlDataReader.GetInt32(0));
                        institution.InstitutionType = new InstitutionType(sqlDataReader.GetInt32(1));
                        institution.InstitutionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        institution.Name = sqlDataReader.GetString(3);
                        institution.InstitutionStatus = new InstitutionStatus(sqlDataReader.GetInt32(4));
                        institution.InstitutionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        institution.DefaultCurrency = new Currency(sqlDataReader.GetInt32(6));
                        institution.Country = new Entities.Globalisation.Country(sqlDataReader.GetInt32(7));
                        institution.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            institution.ShortName = sqlDataReader.GetString(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    institution.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institution.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institution;
        }

        public Institution GetForPart(int pPartID)
        {
            Institution institution = new Institution();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Institution_GetForPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        institution = new Institution(sqlDataReader.GetInt32(0));
                        institution.InstitutionType = new InstitutionType(sqlDataReader.GetInt32(1));
                        institution.Name = sqlDataReader.GetString(2);
                        institution.InstitutionStatus = new InstitutionStatus(sqlDataReader.GetInt32(3));
                        institution.DefaultCurrency = new Currency(sqlDataReader.GetInt32(4));
                        institution.Country = new Entities.Globalisation.Country(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            institution.ShortName = sqlDataReader.GetString(6);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    institution.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institution.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institution;
        }

        public Institution[] List(int pLanguageID)
        {
            List<Institution> institutions = new List<Institution>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Institution_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Institution institution = new Institution(sqlDataReader.GetInt32(0));
                        institution.InstitutionType = new InstitutionType(sqlDataReader.GetInt32(1));
                        institution.InstitutionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        institution.Name = sqlDataReader.GetString(3);
                        institution.InstitutionStatus = new InstitutionStatus(sqlDataReader.GetInt32(4));
                        institution.InstitutionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        institution.DefaultCurrency = new Currency(sqlDataReader.GetInt32(6));
                        institution.Country = new Entities.Globalisation.Country(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            institution.ShortName = sqlDataReader.GetString(8);

                        institutions.Add(institution);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Institution institution = new Institution();
                    institution.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institution.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    institutions.Add(institution);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutions.ToArray();
        }

        public Institution[] ListForClientCategory(string pClientCategoryName, int pLanguageID, bool pAcceptsDeposits, bool pIsOffshore)
        {
            List<Institution> institutions = new List<Institution>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Institution_ListForClientCategory]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientCategoryName", pClientCategoryName));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcceptsDeposits", pAcceptsDeposits));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsOffshore", pIsOffshore));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Institution institution = new Institution(sqlDataReader.GetInt32(0));
                        institution.InstitutionType = new InstitutionType(sqlDataReader.GetInt32(1));
                        institution.InstitutionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        institution.Name = sqlDataReader.GetString(3);
                        institution.InstitutionStatus = new InstitutionStatus(sqlDataReader.GetInt32(4));
                        institution.InstitutionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        institution.DefaultCurrency = new Currency(sqlDataReader.GetInt32(6));
                        institution.Country = new Entities.Globalisation.Country(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            institution.ShortName = sqlDataReader.GetString(8);

                        institutions.Add(institution);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Institution institution = new Institution();
                    institution.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institution.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    institutions.Add(institution);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutions.ToArray();
        }

        public Institution[] ListWhereAccountFeatureUpdatedAfter(DateTime pUpdatedAfter, int pPartFeatureTypeID, int pLanguageID)
        {
            List<Institution> institutions = new List<Institution>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Institution_ListWhereAccountFeatureUpdatedAfter]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UpdatedDate", pUpdatedAfter));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureTypeID", pPartFeatureTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Institution institution = new Institution(sqlDataReader.GetInt32(0));
                        institution.InstitutionType = new InstitutionType(sqlDataReader.GetInt32(1));
                        institution.InstitutionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        institution.Name = sqlDataReader.GetString(3);
                        institution.InstitutionStatus = new InstitutionStatus(sqlDataReader.GetInt32(4));
                        institution.InstitutionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        institution.DefaultCurrency = new Currency(sqlDataReader.GetInt32(6));
                        institution.Country = new Entities.Globalisation.Country(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            institution.ShortName = sqlDataReader.GetString(8);

                        institutions.Add(institution);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Institution institution = new Institution();
                    institution.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institution.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    institutions.Add(institution);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutions.ToArray();
        }

        public Institution[] ListWhereAccountDefinitionUpdatedAfter(DateTime pUpdatedAfter, int pLanguageID)
        {
            List<Institution> institutions = new List<Institution>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Institution_ListWhereAccountDefinitionUpdatedAfter]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UpdatedDate", pUpdatedAfter));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Institution institution = new Institution(sqlDataReader.GetInt32(0));
                        institution.InstitutionType = new InstitutionType(sqlDataReader.GetInt32(1));
                        institution.InstitutionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        institution.Name = sqlDataReader.GetString(3);
                        institution.InstitutionStatus = new InstitutionStatus(sqlDataReader.GetInt32(4));
                        institution.InstitutionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        institution.DefaultCurrency = new Currency(sqlDataReader.GetInt32(6));
                        institution.Country = new Entities.Globalisation.Country(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            institution.ShortName = sqlDataReader.GetString(8);

                        institutions.Add(institution);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Institution institution = new Institution();
                    institution.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institution.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    institutions.Add(institution);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutions.ToArray();
        }

        public Institution Insert(Institution pInstitution)
        {
            Institution institution = new Institution();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Institution_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitution.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionTypeID", pInstitution.InstitutionType.InstitutionTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionStatusID", pInstitution.InstitutionStatus.InstitutionStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefaultCurrencyID", pInstitution.DefaultCurrency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pInstitution.Country.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShortName", pInstitution.ShortName));

                    sqlCommand.ExecuteNonQuery();

                    institution = new Institution(pInstitution.PartyID);
                    institution.InstitutionType = new InstitutionType(pInstitution.InstitutionType.InstitutionTypeID);
                    institution.InstitutionStatus = new InstitutionStatus(pInstitution.InstitutionStatus.InstitutionStatusID);
                    institution.DefaultCurrency = new Currency(pInstitution.DefaultCurrency.CurrencyID);
                    institution.Country = new Entities.Globalisation.Country(pInstitution.Country.CountryID);
                    institution.ShortName = pInstitution.ShortName;
                }
                catch (Exception exc)
                {
                    institution.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institution.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institution;
        }

        public Institution Update(Institution pInstitution)
        {
            Institution institution = new Institution();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Institution_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitution.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionTypeID", pInstitution.InstitutionType.InstitutionTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionStatusID", pInstitution.InstitutionStatus.InstitutionStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefaultCurrencyID", pInstitution.DefaultCurrency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pInstitution.Country.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShortName", pInstitution.ShortName));

                    sqlCommand.ExecuteNonQuery();

                    institution = new Institution(pInstitution.PartyID);
                    institution.InstitutionType = new InstitutionType(pInstitution.InstitutionType.InstitutionTypeID);
                    institution.InstitutionStatus = new InstitutionStatus(pInstitution.InstitutionStatus.InstitutionStatusID);
                    institution.DefaultCurrency = new Currency(pInstitution.DefaultCurrency.CurrencyID);
                    institution.Country = new Entities.Globalisation.Country(pInstitution.Country.CountryID);
                    institution.ShortName = pInstitution.ShortName;
                }
                catch (Exception exc)
                {
                    institution.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institution.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institution;
        }

        public Institution Delete(Institution pInstitution)
        {
            Institution institution = new Institution();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Institution_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitution.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    institution = new Institution(pInstitution.PartyID);
                }
                catch (Exception exc)
                {
                    institution.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institution.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institution;
        }
    }
}
