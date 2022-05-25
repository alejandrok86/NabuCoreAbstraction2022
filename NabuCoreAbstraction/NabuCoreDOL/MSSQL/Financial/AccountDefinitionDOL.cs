using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;


namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class AccountDefinitionDOL : BaseDOL
    {
        public AccountDefinitionDOL() : base()
        {
        }

        public AccountDefinitionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AccountDefinition Get(int pAccountDefinitionID, int pLanguageID)
        {
            AccountDefinition accountDefinition = new AccountDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountDefinition_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountDefinitionID", pAccountDefinitionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountDefinition = new AccountDefinition(sqlDataReader.GetInt32(0));
                        accountDefinition.PartCode = sqlDataReader.GetString(1);
                        accountDefinition.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        accountDefinition.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(3));
                        accountDefinition.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        accountDefinition.Branch = new Entities.Operations.Facility(sqlDataReader.GetInt32(5));
                        accountDefinition.Branch.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        accountDefinition.Currency = new Currency(sqlDataReader.GetInt32(7));
                        accountDefinition.Currency.CurrencyCode = sqlDataReader.GetString(8);
                        accountDefinition.Domicile = new Entities.Globalisation.Country(sqlDataReader.GetInt32(9));
                        accountDefinition.Domicile.Detail = base.GetTranslation(sqlDataReader.GetInt32(10),pLanguageID);
                        if(sqlDataReader.IsDBNull(11)==false)
    		                accountDefinition.LiquidityTenor = sqlDataReader.GetString(11);
                        if(sqlDataReader.IsDBNull(12)==false)
    		                accountDefinition.RateOneMinimum = sqlDataReader.GetDecimal(12);
                        if(sqlDataReader.IsDBNull(13)==false)
		                    accountDefinition.RateOneMaximum = sqlDataReader.GetDecimal(13);
                        if(sqlDataReader.IsDBNull(14)==false)
		                    accountDefinition.RateOne = sqlDataReader.GetDecimal(14);
                        if(sqlDataReader.IsDBNull(15)==false)
		                    accountDefinition.RateTwoMinimum = sqlDataReader.GetDecimal(15);
                        if(sqlDataReader.IsDBNull(16)==false)
		                    accountDefinition.RateTwoMaximum = sqlDataReader.GetDecimal(16);
                        if(sqlDataReader.IsDBNull(17)==false)
		                    accountDefinition.RateTwo = sqlDataReader.GetDecimal(17);
                        if(sqlDataReader.IsDBNull(18)==false)
		                    accountDefinition.RateThreeMinimum = sqlDataReader.GetDecimal(18);
                        if(sqlDataReader.IsDBNull(19)==false)
		                    accountDefinition.RateThreeMaximum = sqlDataReader.GetDecimal(19);
                        if(sqlDataReader.IsDBNull(20)==false)
		                    accountDefinition.RateThree = sqlDataReader.GetDecimal(20);
                        if(sqlDataReader.IsDBNull(21)==false)
		                    accountDefinition.RateFourMinimum = sqlDataReader.GetDecimal(21);
                        if(sqlDataReader.IsDBNull(22)==false)
		                    accountDefinition.RateFourMaximum = sqlDataReader.GetDecimal(22);
                        if(sqlDataReader.IsDBNull(23)==false)
                            accountDefinition.RateFour = sqlDataReader.GetDecimal(23);
                        if (sqlDataReader.IsDBNull(24) == false)
                            accountDefinition.Footnote = sqlDataReader.GetString(24);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountDefinition;
        }

        public AccountDefinition[] List(int pInstitutionID, int pLanguageID)
        {
            List<AccountDefinition> accountDefinitions = new List<AccountDefinition>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountDefinition_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountDefinition accountDefinition = new AccountDefinition(sqlDataReader.GetInt32(0));
                        accountDefinition.PartCode = sqlDataReader.GetString(1);
                        accountDefinition.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        accountDefinition.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(3));
                        accountDefinition.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        accountDefinition.Branch = new Entities.Operations.Facility(sqlDataReader.GetInt32(5));
                        accountDefinition.Branch.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        accountDefinition.Currency = new Currency(sqlDataReader.GetInt32(7));
                        accountDefinition.Currency.CurrencyCode = sqlDataReader.GetString(8);
                        accountDefinition.Domicile = new Entities.Globalisation.Country(sqlDataReader.GetInt32(9));
                        accountDefinition.Domicile.Detail = base.GetTranslation(sqlDataReader.GetInt32(10),pLanguageID);
                        if (sqlDataReader.IsDBNull(11) == false)
                            accountDefinition.LiquidityTenor = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            accountDefinition.RateOneMinimum = sqlDataReader.GetDecimal(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            accountDefinition.RateOneMaximum = sqlDataReader.GetDecimal(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            accountDefinition.RateOne = sqlDataReader.GetDecimal(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            accountDefinition.RateTwoMinimum = sqlDataReader.GetDecimal(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            accountDefinition.RateTwoMaximum = sqlDataReader.GetDecimal(16);
                        if (sqlDataReader.IsDBNull(17) == false)
                            accountDefinition.RateTwo = sqlDataReader.GetDecimal(17);
                        if (sqlDataReader.IsDBNull(18) == false)
                            accountDefinition.RateThreeMinimum = sqlDataReader.GetDecimal(18);
                        if (sqlDataReader.IsDBNull(19) == false)
                            accountDefinition.RateThreeMaximum = sqlDataReader.GetDecimal(19);
                        if (sqlDataReader.IsDBNull(20) == false)
                            accountDefinition.RateThree = sqlDataReader.GetDecimal(20);
                        if (sqlDataReader.IsDBNull(21) == false)
                            accountDefinition.RateFourMinimum = sqlDataReader.GetDecimal(21);
                        if (sqlDataReader.IsDBNull(22) == false)
                            accountDefinition.RateFourMaximum = sqlDataReader.GetDecimal(22);
                        if (sqlDataReader.IsDBNull(23) == false)
                            accountDefinition.RateFour = sqlDataReader.GetDecimal(23);
                        if (sqlDataReader.IsDBNull(24) == false)
                            accountDefinition.Footnote = sqlDataReader.GetString(24);

                        accountDefinitions.Add(accountDefinition);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountDefinition accountDefinition = new AccountDefinition();
                    accountDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountDefinitions.Add(accountDefinition);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountDefinitions.ToArray();
        }

        public AccountDefinition[] ListUpdatedAfter(int pInstitutionID, DateTime pUpdatedAfter, int pLanguageID)
        {
            List<AccountDefinition> accountDefinitions = new List<AccountDefinition>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountDefinition_ListUpdatedAfter]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UpdatedDate", pUpdatedAfter));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountDefinition accountDefinition = new AccountDefinition(sqlDataReader.GetInt32(0));
                        accountDefinition.PartCode = sqlDataReader.GetString(1);
                        accountDefinition.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        accountDefinition.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(3));
                        accountDefinition.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        accountDefinition.Branch = new Entities.Operations.Facility(sqlDataReader.GetInt32(5));
                        accountDefinition.Branch.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        accountDefinition.Currency = new Currency(sqlDataReader.GetInt32(7));
                        accountDefinition.Currency.CurrencyCode = sqlDataReader.GetString(8);
                        accountDefinition.Domicile = new Entities.Globalisation.Country(sqlDataReader.GetInt32(9));
                        accountDefinition.Domicile.Detail = base.GetTranslation(sqlDataReader.GetInt32(10), pLanguageID);
                        if (sqlDataReader.IsDBNull(11) == false)
                            accountDefinition.LiquidityTenor = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            accountDefinition.RateOneMinimum = sqlDataReader.GetDecimal(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            accountDefinition.RateOneMaximum = sqlDataReader.GetDecimal(13);
                        if (sqlDataReader.IsDBNull(14) == false)
                            accountDefinition.RateOne = sqlDataReader.GetDecimal(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            accountDefinition.RateTwoMinimum = sqlDataReader.GetDecimal(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            accountDefinition.RateTwoMaximum = sqlDataReader.GetDecimal(16);
                        if (sqlDataReader.IsDBNull(17) == false)
                            accountDefinition.RateTwo = sqlDataReader.GetDecimal(17);
                        if (sqlDataReader.IsDBNull(18) == false)
                            accountDefinition.RateThreeMinimum = sqlDataReader.GetDecimal(18);
                        if (sqlDataReader.IsDBNull(19) == false)
                            accountDefinition.RateThreeMaximum = sqlDataReader.GetDecimal(19);
                        if (sqlDataReader.IsDBNull(20) == false)
                            accountDefinition.RateThree = sqlDataReader.GetDecimal(20);
                        if (sqlDataReader.IsDBNull(21) == false)
                            accountDefinition.RateFourMinimum = sqlDataReader.GetDecimal(21);
                        if (sqlDataReader.IsDBNull(22) == false)
                            accountDefinition.RateFourMaximum = sqlDataReader.GetDecimal(22);
                        if (sqlDataReader.IsDBNull(23) == false)
                            accountDefinition.RateFour = sqlDataReader.GetDecimal(23);
                        if (sqlDataReader.IsDBNull(24) == false)
                            accountDefinition.Footnote = sqlDataReader.GetString(24);

                        accountDefinitions.Add(accountDefinition);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountDefinition accountDefinition = new AccountDefinition();
                    accountDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountDefinitions.Add(accountDefinition);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountDefinitions.ToArray();
        }

        public AccountDefinition Insert(AccountDefinition pAccountDefinition, int pInstitutionID)
        {
            AccountDefinition accountDefinition = new AccountDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountDefinition_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountDefinitionID", pAccountDefinition.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FacilityID", pAccountDefinition.Branch.FacilityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pAccountDefinition.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pAccountDefinition.Domicile.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LiquidityTenor", pAccountDefinition.LiquidityTenor));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateOneMinimum", pAccountDefinition.RateOneMinimum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateOneMaximum", pAccountDefinition.RateOneMaximum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateOne", pAccountDefinition.RateOne));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateTwoMinimum", pAccountDefinition.RateTwoMinimum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateTwoMaximum", pAccountDefinition.RateTwoMaximum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateTwo", pAccountDefinition.RateTwo));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateThreeMinimum", pAccountDefinition.RateThreeMinimum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateThreeMaximum", pAccountDefinition.RateThreeMaximum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateThree", pAccountDefinition.RateThree));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateFourMinimum", pAccountDefinition.RateFourMinimum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateFourMaximum", pAccountDefinition.RateFourMaximum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateFour", pAccountDefinition.RateFour));
                    sqlCommand.Parameters.Add(new SqlParameter("@Footnote", ((pAccountDefinition.Footnote.Trim().Length > 0) ? pAccountDefinition.Footnote : null)));

                    sqlCommand.ExecuteNonQuery();

                    accountDefinition = new AccountDefinition(pAccountDefinition.PartID);
                    accountDefinition.Branch = pAccountDefinition.Branch;
                    accountDefinition.Currency = pAccountDefinition.Currency;
                    accountDefinition.Detail = pAccountDefinition.Detail;
                    accountDefinition.Domicile = pAccountDefinition.Domicile;
                    accountDefinition.PartCode = pAccountDefinition.PartCode;
                    accountDefinition.PartType = pAccountDefinition.PartType;
                    accountDefinition.LiquidityTenor = pAccountDefinition.LiquidityTenor;
                    accountDefinition.RateOneMinimum = pAccountDefinition.RateOneMinimum;
                    accountDefinition.RateOneMaximum = pAccountDefinition.RateOneMaximum;
                    accountDefinition.RateOne = pAccountDefinition.RateOne;
                    accountDefinition.RateTwoMinimum = pAccountDefinition.RateTwoMinimum;
                    accountDefinition.RateTwoMaximum = pAccountDefinition.RateTwoMaximum;
                    accountDefinition.RateTwo = pAccountDefinition.RateTwo;
                    accountDefinition.RateThreeMinimum = pAccountDefinition.RateThreeMinimum;
                    accountDefinition.RateThreeMaximum = pAccountDefinition.RateThreeMaximum;
                    accountDefinition.RateThree = pAccountDefinition.RateThree;
                    accountDefinition.RateFourMinimum = pAccountDefinition.RateFourMinimum;
                    accountDefinition.RateFourMaximum = pAccountDefinition.RateFourMaximum;
                    accountDefinition.RateFour = pAccountDefinition.RateFour;
                    accountDefinition.Footnote = pAccountDefinition.Footnote;
                }
                catch (Exception exc)
                {
                    accountDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountDefinition;
        }

        public AccountDefinition Update(AccountDefinition pAccountDefinition, int pInstitutionID)
        {
            AccountDefinition accountDefinition = new AccountDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountDefinition_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountDefinitionID", pAccountDefinition.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FacilityID", pAccountDefinition.Branch.FacilityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pAccountDefinition.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pAccountDefinition.Domicile.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LiquidityTenor", pAccountDefinition.LiquidityTenor));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateOneMinimum", pAccountDefinition.RateOneMinimum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateOneMaximum", pAccountDefinition.RateOneMaximum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateOne", pAccountDefinition.RateOne));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateTwoMinimum", pAccountDefinition.RateTwoMinimum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateTwoMaximum", pAccountDefinition.RateTwoMaximum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateTwo", pAccountDefinition.RateTwo));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateThreeMinimum", pAccountDefinition.RateThreeMinimum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateThreeMaximum", pAccountDefinition.RateThreeMaximum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateThree", pAccountDefinition.RateThree));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateFourMinimum", pAccountDefinition.RateFourMinimum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateFourMaximum", pAccountDefinition.RateFourMaximum));
                    sqlCommand.Parameters.Add(new SqlParameter("@RateFour", pAccountDefinition.RateFour));
                    sqlCommand.Parameters.Add(new SqlParameter("@Footnote", ((pAccountDefinition.Footnote.Trim().Length > 0) ? pAccountDefinition.Footnote : null)));

                    sqlCommand.ExecuteNonQuery();

                    accountDefinition = new AccountDefinition(pAccountDefinition.PartID);
                    accountDefinition.Branch = pAccountDefinition.Branch;
                    accountDefinition.Currency = pAccountDefinition.Currency;
                    accountDefinition.Detail = pAccountDefinition.Detail;
                    accountDefinition.Domicile = pAccountDefinition.Domicile;
                    accountDefinition.PartCode = pAccountDefinition.PartCode;
                    accountDefinition.PartType = pAccountDefinition.PartType;
                    accountDefinition.LiquidityTenor = pAccountDefinition.LiquidityTenor;
                    accountDefinition.RateOneMinimum = pAccountDefinition.RateOneMinimum;
                    accountDefinition.RateOneMaximum = pAccountDefinition.RateOneMaximum;
                    accountDefinition.RateOne = pAccountDefinition.RateOne;
                    accountDefinition.RateTwoMinimum = pAccountDefinition.RateTwoMinimum;
                    accountDefinition.RateTwoMaximum = pAccountDefinition.RateTwoMaximum;
                    accountDefinition.RateTwo = pAccountDefinition.RateTwo;
                    accountDefinition.RateThreeMinimum = pAccountDefinition.RateThreeMinimum;
                    accountDefinition.RateThreeMaximum = pAccountDefinition.RateThreeMaximum;
                    accountDefinition.RateThree = pAccountDefinition.RateThree;
                    accountDefinition.RateFourMinimum = pAccountDefinition.RateFourMinimum;
                    accountDefinition.RateFourMaximum = pAccountDefinition.RateFourMaximum;
                    accountDefinition.RateFour = pAccountDefinition.RateFour;
                    accountDefinition.Footnote = pAccountDefinition.Footnote;
                }
                catch (Exception exc)
                {
                    accountDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountDefinition;
        }

        public AccountDefinition Delete(AccountDefinition pAccountDefinition)
        {
            AccountDefinition accountDefinition = new AccountDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountDefinition_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountDefinitionID", pAccountDefinition.PartID));

                    sqlCommand.ExecuteNonQuery();

                    accountDefinition = new AccountDefinition(pAccountDefinition.PartID);
                }
                catch (Exception exc)
                {
                    accountDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountDefinition;
        }
    }
}
