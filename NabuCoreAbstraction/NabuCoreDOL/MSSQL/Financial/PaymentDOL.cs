using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class PaymentDOL : BaseDOL
    {
        public PaymentDOL() : base()
        {
        }

        public PaymentDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Payment Get(int pPaymentID)
        {
            Payment payment = new Payment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Payment_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentID", pPaymentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        payment = new Payment(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            payment.DateOfPayment = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            payment.Currency = new Currency(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            payment.AmountReceived = sqlDataReader.GetDecimal(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            payment.Type = new PaymentType(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            payment.Status = new PaymentStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            payment.Method = new PaymentMethod(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            payment.RelatedBillID = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            payment.RelatedTransactionID = sqlDataReader.GetInt32(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            payment.Reference = sqlDataReader.GetString(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    payment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    payment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return payment;
        }

        public Payment GetByReference(string pReference)
        {
            Payment payment = new Payment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Payment_GetByReference]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Reference", pReference));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        payment = new Payment(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            payment.DateOfPayment = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            payment.Currency = new Currency(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            payment.AmountReceived = sqlDataReader.GetDecimal(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            payment.Type = new PaymentType(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            payment.Status = new PaymentStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            payment.Method = new PaymentMethod(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            payment.RelatedBillID = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            payment.RelatedTransactionID = sqlDataReader.GetInt32(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            payment.Reference = sqlDataReader.GetString(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    payment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    payment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return payment;
        }

        public Payment GetForTransaction(int pTransactionID)
        {
            Payment payment = new Payment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Payment_GetForTransaction]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionID", pTransactionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        payment = new Payment(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            payment.DateOfPayment = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            payment.Currency = new Currency(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            payment.AmountReceived = sqlDataReader.GetDecimal(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            payment.Type = new PaymentType(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            payment.Status = new PaymentStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            payment.Method = new PaymentMethod(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            payment.RelatedBillID = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            payment.RelatedTransactionID = sqlDataReader.GetInt32(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            payment.Reference = sqlDataReader.GetString(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    payment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    payment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return payment;
        }

        public Payment[] List(int pBillID)
        {
            List<Payment> payments = new List<Payment>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Payment_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillID", pBillID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Payment payment = new Payment(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            payment.DateOfPayment = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            payment.Currency = new Currency(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            payment.AmountReceived = sqlDataReader.GetDecimal(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            payment.Type = new PaymentType(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            payment.Status = new PaymentStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            payment.Method = new PaymentMethod(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            payment.RelatedBillID = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            payment.RelatedTransactionID = sqlDataReader.GetInt32(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            payment.Reference = sqlDataReader.GetString(9);

                        payments.Add(payment);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Payment payment = new Payment();
                    payment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    payment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    payments.Add(payment);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return payments.ToArray();
        }

        public Payment Insert(Payment pPayment, int pBillID)
        {
            Payment payment = new Payment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Payment_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfPayment", pPayment.DateOfPayment));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pPayment.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AmountReceived", pPayment.AmountReceived));
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentTypeID", pPayment.Type.PaymentTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentStatusID", pPayment.Status.PaymentStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodID", ((pPayment.Method != null && pPayment.Method.PaymentMethodID.HasValue) ? pPayment.Method.PaymentMethodID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@BillID", pBillID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionID", pPayment.RelatedTransactionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Reference", pPayment.Reference));
                    SqlParameter paymentID = sqlCommand.Parameters.Add("@PaymentID", SqlDbType.Int);
                    paymentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    payment = pPayment;
                    payment.PaymentID = (Int32)paymentID.Value;
                }
                catch (Exception exc)
                {
                    payment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    payment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return payment;
        }

        public Payment Update(Payment pPayment)
        {
            Payment payment = new Payment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Payment_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentID", pPayment.PaymentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfPayment", pPayment.DateOfPayment));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pPayment.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AmountReceived", pPayment.AmountReceived));
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentTypeID", pPayment.Type.PaymentTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentStatusID", pPayment.Status.PaymentStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodID", ((pPayment.Method != null && pPayment.Method.PaymentMethodID.HasValue) ? pPayment.Method.PaymentMethodID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionID", pPayment.RelatedTransactionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Reference", pPayment.Reference));

                    sqlCommand.ExecuteNonQuery();

                    payment = pPayment;
                }
                catch (Exception exc)
                {
                    payment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace, false);
                    payment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return payment;
        }

        public Payment Delete(Payment pPayment)
        {
            Payment payment = new Payment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Payment_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentID", pPayment.PaymentID));

                    sqlCommand.ExecuteNonQuery();

                    payment = new Payment(pPayment.PaymentID);
                }
                catch (Exception exc)
                {
                    payment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    payment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return payment;
        }
    }
}
