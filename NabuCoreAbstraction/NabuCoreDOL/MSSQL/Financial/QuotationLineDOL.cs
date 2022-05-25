using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class QuotationLineDOL : BaseDOL
    {
        public QuotationLineDOL() : base()
        {
        }

        public QuotationLineDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public QuotationLine Get(int pQuotationLineID)
        {
            QuotationLine quotationLine = new QuotationLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationLine_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationLineID", pQuotationLineID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        quotationLine = new QuotationLine(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            quotationLine.Detail1 = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            quotationLine.Detail2 = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            quotationLine.Detail3 = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            quotationLine.Detail4 = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            quotationLine.Detail5 = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            quotationLine.Detail6 = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            quotationLine.Amount = sqlDataReader.GetDecimal(7);
                        quotationLine.IsHeaderLine = sqlDataReader.GetBoolean(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    quotationLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationLine;
        }

        public QuotationLine[] List(int pQuotationID)
        {
            List<QuotationLine> quotationLines = new List<QuotationLine>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationLine_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationID", pQuotationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        QuotationLine quotationLine = new QuotationLine(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            quotationLine.Detail1 = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            quotationLine.Detail2 = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            quotationLine.Detail3 = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            quotationLine.Detail4 = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            quotationLine.Detail5 = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            quotationLine.Detail6 = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            quotationLine.Amount = sqlDataReader.GetDecimal(7);
                        quotationLine.IsHeaderLine = sqlDataReader.GetBoolean(8);

                        quotationLines.Add(quotationLine);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    QuotationLine quotationLine = new QuotationLine();
                    quotationLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    quotationLines.Add(quotationLine);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationLines.ToArray();
        }

        public QuotationLine Insert(QuotationLine pQuotationLine, int pQuotationID)
        {
            QuotationLine quotationLine = new QuotationLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationLine_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationID", pQuotationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail1", pQuotationLine.Detail1));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail2", pQuotationLine.Detail2));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail3", pQuotationLine.Detail3));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail4", pQuotationLine.Detail4));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail5", pQuotationLine.Detail5));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail6", pQuotationLine.Detail6));
                    sqlCommand.Parameters.Add(new SqlParameter("@Amount", pQuotationLine.Amount));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsHeaderLine", pQuotationLine.IsHeaderLine));
                    SqlParameter quotationLineID = sqlCommand.Parameters.Add("@QuotationLineID", SqlDbType.Int);
                    quotationLineID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    quotationLine = pQuotationLine;
                    quotationLine.QuotationLineID = (Int32)quotationLineID.Value;
                }
                catch (Exception exc)
                {
                    quotationLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationLine;
        }

        public QuotationLine Update(QuotationLine pQuotationLine)
        {
            QuotationLine quotationLine = new QuotationLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationLine_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationLineID", pQuotationLine.QuotationLineID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail1", pQuotationLine.Detail1));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail2", pQuotationLine.Detail2));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail3", pQuotationLine.Detail3));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail4", pQuotationLine.Detail4));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail5", pQuotationLine.Detail5));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail6", pQuotationLine.Detail6));
                    sqlCommand.Parameters.Add(new SqlParameter("@Amount", pQuotationLine.Amount));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsHeaderLine", pQuotationLine.IsHeaderLine));

                    sqlCommand.ExecuteNonQuery();

                    quotationLine = pQuotationLine;
                }
                catch (Exception exc)
                {
                    quotationLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace, false);
                    quotationLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationLine;
        }

        public QuotationLine Delete(QuotationLine pQuotationLine)
        {
            QuotationLine quotationLine = new QuotationLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[QuotationLine_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@QuotationLineID", pQuotationLine.QuotationLineID));

                    sqlCommand.ExecuteNonQuery();

                    quotationLine = new QuotationLine(pQuotationLine.QuotationLineID);
                }
                catch (Exception exc)
                {
                    quotationLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    quotationLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return quotationLine;
        }
    }
}
