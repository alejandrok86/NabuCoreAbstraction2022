using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class AccountFeeDOL : BaseDOL
    {
        public AccountFeeDOL() : base()
        {
        }

        public AccountFeeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AccountFee Get(int pAccountFeeID)
        {
            AccountFee accountFee = new AccountFee();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountFee_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountFeeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountFee = new AccountFee();
                        if (sqlDataReader.IsDBNull(1) == false)
                            accountFee.BaseFeePercentage = sqlDataReader.GetDecimal(1);
                        if(sqlDataReader.IsDBNull(2) == false)
                            accountFee.FeeValue = sqlDataReader.GetDecimal(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            accountFee.IntroducerSharePercentageBPS = sqlDataReader.GetDecimal(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            accountFee.IntroducedDiscountPercentage = sqlDataReader.GetDecimal(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            accountFee.SalesDiscountPercentage = sqlDataReader.GetDecimal(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            accountFee.IntroducerSharePercentageOfFeeYear1 = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            accountFee.IntroducerSharePercentageOfFeeYear2 = sqlDataReader.GetDecimal(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            accountFee.CurrencyUpliftPercentage = sqlDataReader.GetDecimal(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountFee.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountFee.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountFee;
        }

        public AccountFee Update(AccountFee pAccountFee, int pAccountID)
        {
            AccountFee accountFee = new AccountFee();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountFee_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BaseFeePercentage", pAccountFee.BaseFeePercentage));
                    sqlCommand.Parameters.Add(new SqlParameter("@FeeValue", pAccountFee.FeeValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@IntroducerSharePercentageBPS", pAccountFee.IntroducerSharePercentageBPS));
                    sqlCommand.Parameters.Add(new SqlParameter("@IntroducedDiscountPercentage", pAccountFee.IntroducedDiscountPercentage));
                    sqlCommand.Parameters.Add(new SqlParameter("@SalesDiscountPercent", pAccountFee.SalesDiscountPercentage));
                    sqlCommand.Parameters.Add(new SqlParameter("@IntroducerSharePercentageOfFeeYear1", pAccountFee.IntroducerSharePercentageOfFeeYear1));
                    sqlCommand.Parameters.Add(new SqlParameter("@IntroducerSharePercentageOfFeeYear2", pAccountFee.IntroducerSharePercentageOfFeeYear2));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyUpliftPercentage", pAccountFee.CurrencyUpliftPercentage));

                    sqlCommand.ExecuteNonQuery();

                    accountFee = new AccountFee();
                    accountFee.BaseFeePercentage = pAccountFee.BaseFeePercentage;
                    accountFee.FeeValue = pAccountFee.FeeValue;
                    accountFee.IntroducerSharePercentageBPS = pAccountFee.IntroducerSharePercentageBPS;
                    accountFee.IntroducedDiscountPercentage = pAccountFee.IntroducedDiscountPercentage;
                    accountFee.SalesDiscountPercentage = pAccountFee.SalesDiscountPercentage;
                    accountFee.IntroducerSharePercentageOfFeeYear1 = pAccountFee.IntroducerSharePercentageOfFeeYear1;
                    accountFee.IntroducerSharePercentageOfFeeYear2 = pAccountFee.IntroducerSharePercentageOfFeeYear2;
                    accountFee.CurrencyUpliftPercentage = pAccountFee.CurrencyUpliftPercentage;
                }
                catch (Exception exc)
                {
                    accountFee.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountFee.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountFee;
        }

        public AccountFee Delete(int pAccountID)
        {
            AccountFee accountFee = new AccountFee();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountFee_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));

                    sqlCommand.ExecuteNonQuery();

                    accountFee = new AccountFee();
                }
                catch (Exception exc)
                {
                    accountFee.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountFee.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountFee;
        }
    }
}
