using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class BillDOL : BaseDOL
    {
        public BillDOL() : base()
        {
        }

        public BillDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Bill Get(int pBillID)
        {
            Bill bill = new Bill();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Bill_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillID", pBillID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        bill = new Bill(sqlDataReader.GetInt32(0));
                        bill.Client = new Client(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            bill.Account = new Account(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            bill.DateOfIssue = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            bill.DateOfExpiration = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            bill.Currency = new Currency(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            bill.Total = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            bill.Reference = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            bill.Barcode = sqlDataReader.GetString(8);
                        bill.Status = new BillStatus(sqlDataReader.GetInt32(9));
                        bill.Type = new BillType(sqlDataReader.GetInt32(10));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    bill.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    bill.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return bill;
        }

        public Bill GetByBarcode(string pBarcode)
        {
            Bill bill = new Bill();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Bill_GetByBarcode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Barcode", pBarcode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        bill = new Bill(sqlDataReader.GetInt32(0));
                        bill.Client = new Client(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            bill.Account = new Account(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            bill.DateOfIssue = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            bill.DateOfExpiration = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            bill.Currency = new Currency(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            bill.Total = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            bill.Reference = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            bill.Barcode = sqlDataReader.GetString(8);
                        bill.Status = new BillStatus(sqlDataReader.GetInt32(9));
                        bill.Type = new BillType(sqlDataReader.GetInt32(10));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    bill.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    bill.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return bill;
        }

        public Bill GetByReference(string pReference)
        {
            Bill bill = new Bill();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Bill_GetByReference]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Reference", pReference));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        bill = new Bill(sqlDataReader.GetInt32(0));
                        bill.Client = new Client(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            bill.Account = new Account(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            bill.DateOfIssue = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            bill.DateOfExpiration = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            bill.Currency = new Currency(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            bill.Total = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            bill.Reference = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            bill.Barcode = sqlDataReader.GetString(8);
                        bill.Status = new BillStatus(sqlDataReader.GetInt32(9));
                        bill.Type = new BillType(sqlDataReader.GetInt32(10));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    bill.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    bill.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return bill;
        }

        public Bill[] List(int pClientID)
        {
            List<Bill> bills = new List<Bill>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Bill_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClientID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Bill bill = new Bill(sqlDataReader.GetInt32(0));
                        bill.Client = new Client(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            bill.Account = new Account(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            bill.DateOfIssue = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            bill.DateOfExpiration = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            bill.Currency = new Currency(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            bill.Total = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            bill.Reference = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            bill.Barcode = sqlDataReader.GetString(8);
                        bill.Status = new BillStatus(sqlDataReader.GetInt32(9));
                        bill.Type = new BillType(sqlDataReader.GetInt32(10));

                        bills.Add(bill);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Bill bill = new Bill();
                    bill.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    bill.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    bills.Add(bill);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return bills.ToArray();
        }

        public Bill[] ListByStatus(int pClientID, int pBillStatusID)
        {
            List<Bill> bills = new List<Bill>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Bill_ListByStatus]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClientID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BillStatusID", pBillStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Bill bill = new Bill(sqlDataReader.GetInt32(0));
                        bill.Client = new Client(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            bill.Account = new Account(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            bill.DateOfIssue = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            bill.DateOfExpiration = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            bill.Currency = new Currency(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            bill.Total = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            bill.Reference = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            bill.Barcode = sqlDataReader.GetString(8);
                        bill.Status = new BillStatus(sqlDataReader.GetInt32(9));
                        bill.Type = new BillType(sqlDataReader.GetInt32(10));

                        bills.Add(bill);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Bill bill = new Bill();
                    bill.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    bill.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    bills.Add(bill);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return bills.ToArray();
        }

        public Bill Insert(Bill pBill)
        {
            Bill bill = new Bill();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Bill_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pBill.Client.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", ((pBill.Account != null && pBill.Account.AccountID.HasValue) ? pBill.Account.AccountID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfIssue", pBill.DateOfIssue));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfExpiration", pBill.DateOfExpiration));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pBill.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Total", pBill.Total));
                    sqlCommand.Parameters.Add(new SqlParameter("@Reference", pBill.Reference));
                    sqlCommand.Parameters.Add(new SqlParameter("@Barcode", pBill.Barcode));
                    sqlCommand.Parameters.Add(new SqlParameter("@BillStatusID", pBill.Status.BillStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BillTypeID", pBill.Type.BillTypeID));
                    SqlParameter billID = sqlCommand.Parameters.Add("@BillID", SqlDbType.Int);
                    billID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    bill = pBill;
                    bill.BillID = (Int32)billID.Value;
                }
                catch (Exception exc)
                {
                    bill.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    bill.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return bill;
        }

        public Bill Update(Bill pBill)
        {
            Bill bill = new Bill();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Bill_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillID", pBill.BillID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pBill.Client.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", ((pBill.Account != null && pBill.Account.AccountID.HasValue) ? pBill.Account.AccountID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfIssue", pBill.DateOfIssue));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfExpiration", pBill.DateOfExpiration));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pBill.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Total", pBill.Total));
                    sqlCommand.Parameters.Add(new SqlParameter("@Reference", pBill.Reference));
                    sqlCommand.Parameters.Add(new SqlParameter("@Barcode", pBill.Barcode));
                    sqlCommand.Parameters.Add(new SqlParameter("@BillStatusID", pBill.Status.BillStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BillTypeID", pBill.Type.BillTypeID));

                    sqlCommand.ExecuteNonQuery();

                    bill = pBill;
                }
                catch (Exception exc)
                {
                    bill.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace, false);
                    bill.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return bill;
        }

        public Bill Delete(Bill pBill)
        {
            Bill bill = new Bill();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Bill_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillID", pBill.BillID));

                    sqlCommand.ExecuteNonQuery();

                    bill = new Bill(pBill.BillID);
                }
                catch (Exception exc)
                {
                    bill.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    bill.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return bill;
        }
    }
}
