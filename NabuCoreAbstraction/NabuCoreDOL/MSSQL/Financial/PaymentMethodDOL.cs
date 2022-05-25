using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class PaymentMethodDOL : BaseDOL
    {
        public PaymentMethodDOL() : base()
        {
        }

        public PaymentMethodDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public PaymentMethod Get(int pPaymentMethodID)
        {
            PaymentMethod paymentMethod = new PaymentMethod();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethod_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodID", pPaymentMethodID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        paymentMethod = new PaymentMethod(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            paymentMethod.Type = new PaymentMethodType(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            paymentMethod.Status = new PaymentMethodStatus(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            paymentMethod.Detail = sqlDataReader.GetString(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    paymentMethod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethod;
        }

        public PaymentMethod[] List(int pClientID)
        {
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethod_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClientID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PaymentMethod paymentMethod = new PaymentMethod(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            paymentMethod.Type = new PaymentMethodType(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            paymentMethod.Status = new PaymentMethodStatus(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            paymentMethod.Detail = sqlDataReader.GetString(3);

                        paymentMethods.Add(paymentMethod);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PaymentMethod paymentMethod = new PaymentMethod();
                    paymentMethod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    paymentMethods.Add(paymentMethod);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethods.ToArray();
        }

        public PaymentMethod Insert(PaymentMethod pPaymentMethod, int pClientID)
        {
            PaymentMethod paymentMethod = new PaymentMethod();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethod_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClientID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodStatusID", pPaymentMethod.Status.PaymentMethodStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodTypeID", pPaymentMethod.Type.PaymentMethodTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail", pPaymentMethod.Type.Detail));
                    SqlParameter paymentMethodID = sqlCommand.Parameters.Add("@PaymentMethodID", SqlDbType.Int);
                    paymentMethodID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    paymentMethod = pPaymentMethod;
                    paymentMethod.PaymentMethodID = (Int32)paymentMethodID.Value;
                }
                catch (Exception exc)
                {
                    paymentMethod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethod;
        }

        public PaymentMethod Update(PaymentMethod pPaymentMethod)
        {
            PaymentMethod paymentMethod = new PaymentMethod();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethod_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodID", pPaymentMethod.PaymentMethodID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodStatusID", pPaymentMethod.Status.PaymentMethodStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodTypeID", pPaymentMethod.Type.PaymentMethodTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail", pPaymentMethod.Type.Detail));

                    sqlCommand.ExecuteNonQuery();

                    paymentMethod = pPaymentMethod;
                }
                catch (Exception exc)
                {
                    paymentMethod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace, false);
                    paymentMethod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethod;
        }

        public PaymentMethod Delete(PaymentMethod pPaymentMethod)
        {
            PaymentMethod paymentMethod = new PaymentMethod();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethod_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodID", pPaymentMethod.PaymentMethodID));

                    sqlCommand.ExecuteNonQuery();

                    paymentMethod = new PaymentMethod(pPaymentMethod.PaymentMethodID);
                }
                catch (Exception exc)
                {
                    paymentMethod.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethod.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethod;
        }
    }
}
