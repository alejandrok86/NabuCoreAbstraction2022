using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class BillLineDOL : BaseDOL
    {
        public BillLineDOL() : base()
        {
        }

        public BillLineDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public BillLine Get(int pBillLineID)
        {
            BillLine billLine = new BillLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillLine_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillLineID", pBillLineID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        billLine = new BillLine(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            billLine.Detail1 = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            billLine.Detail2 = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            billLine.Detail3 = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            billLine.Detail4 = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            billLine.Detail5 = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            billLine.Detail6 = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            billLine.Amount = sqlDataReader.GetDecimal(7);
                        billLine.IsHeaderLine = sqlDataReader.GetBoolean(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    billLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billLine;
        }

        public BillLine[] List(int pBillID)
        {
            List<BillLine> billLines = new List<BillLine>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillLine_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillID", pBillID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        BillLine billLine = new BillLine(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            billLine.Detail1 = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            billLine.Detail2 = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            billLine.Detail3 = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            billLine.Detail4 = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            billLine.Detail5 = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            billLine.Detail6 = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            billLine.Amount = sqlDataReader.GetDecimal(7);
                        billLine.IsHeaderLine = sqlDataReader.GetBoolean(8);

                        billLines.Add(billLine);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    BillLine billLine = new BillLine();
                    billLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    billLines.Add(billLine);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billLines.ToArray();
        }

        public BillLine Insert(BillLine pBillLine, int pBillID)
        {
            BillLine billLine = new BillLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillLine_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillID", pBillID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail1", pBillLine.Detail1));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail2", pBillLine.Detail2));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail3", pBillLine.Detail3));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail4", pBillLine.Detail4));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail5", pBillLine.Detail5));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail6", pBillLine.Detail6));
                    sqlCommand.Parameters.Add(new SqlParameter("@Amount", pBillLine.Amount));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsHeaderLine", pBillLine.IsHeaderLine));
                    SqlParameter billLineID = sqlCommand.Parameters.Add("@BillLineID", SqlDbType.Int);
                    billLineID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    billLine = pBillLine;
                    billLine.BillLineID = (Int32)billLineID.Value;
                }
                catch (Exception exc)
                {
                    billLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billLine;
        }

        public BillLine Update(BillLine pBillLine)
        {
            BillLine billLine = new BillLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillLine_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillLineID", pBillLine.BillLineID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail1", pBillLine.Detail1));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail2", pBillLine.Detail2));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail3", pBillLine.Detail3));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail4", pBillLine.Detail4));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail5", pBillLine.Detail5));
                    sqlCommand.Parameters.Add(new SqlParameter("@Detail6", pBillLine.Detail6));
                    sqlCommand.Parameters.Add(new SqlParameter("@Amount", pBillLine.Amount));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsHeaderLine", pBillLine.IsHeaderLine));

                    sqlCommand.ExecuteNonQuery();

                    billLine = pBillLine;
                }
                catch (Exception exc)
                {
                    billLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace, false);
                    billLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billLine;
        }

        public BillLine Delete(BillLine pBillLine)
        {
            BillLine billLine = new BillLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillLine_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillLineID", pBillLine.BillLineID));

                    sqlCommand.ExecuteNonQuery();

                    billLine = new BillLine(pBillLine.BillLineID);
                }
                catch (Exception exc)
                {
                    billLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billLine;
        }
    }
}
