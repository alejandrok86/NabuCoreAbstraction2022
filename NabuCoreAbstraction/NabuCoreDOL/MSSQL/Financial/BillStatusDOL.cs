using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class BillStatusDOL : BaseDOL
    {
        public BillStatusDOL() : base()
        {
        }

        public BillStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public BillStatus Get(int pBillStatusID, int pLanguageID)
        {
            BillStatus billStatus = new BillStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillStatusID", pBillStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        billStatus = new BillStatus(sqlDataReader.GetInt32(0));
                        billStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    billStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billStatus;
        }

        public BillStatus GetByAlias(string pAlias, int pLanguageID)
        {
            BillStatus billStatus = new BillStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        billStatus = new BillStatus(sqlDataReader.GetInt32(0));
                        billStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    billStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billStatus;
        }

        public BillStatus[] List(int pLanguageID)
        {
            List<BillStatus> billStatuss = new List<BillStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        BillStatus billStatus = new BillStatus(sqlDataReader.GetInt32(0));
                        billStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        billStatuss.Add(billStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    BillStatus billStatus = new BillStatus();
                    billStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    billStatuss.Add(billStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billStatuss.ToArray();
        }

        public BillStatus Insert(BillStatus pBillStatus)
        {
            BillStatus billStatus = new BillStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillStatus_Insert]");
                try
                {
                    pBillStatus.Detail = base.InsertTranslation(pBillStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pBillStatus.Detail.TranslationID));
                    SqlParameter billStatusID = sqlCommand.Parameters.Add("@BillStatusID", SqlDbType.Int);
                    billStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    billStatus = new BillStatus((Int32)billStatusID.Value);
                    billStatus.Detail = new Translation(pBillStatus.Detail.TranslationID);
                    billStatus.Detail.Alias = pBillStatus.Detail.Alias;
                    billStatus.Detail.Description = pBillStatus.Detail.Description;
                    billStatus.Detail.Name = pBillStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    billStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billStatus;
        }

        public BillStatus Update(BillStatus pBillStatus)
        {
            BillStatus billStatus = new BillStatus();

            pBillStatus.Detail = base.UpdateTranslation(pBillStatus.Detail);

            billStatus = new BillStatus(pBillStatus.BillStatusID);
            billStatus.Detail = new Translation(pBillStatus.Detail.TranslationID);
            billStatus.Detail.Alias = pBillStatus.Detail.Alias;
            billStatus.Detail.Description = pBillStatus.Detail.Description;
            billStatus.Detail.Name = pBillStatus.Detail.Name;

            return billStatus;
        }

        public BillStatus Delete(BillStatus pBillStatus)
        {
            BillStatus billStatus = new BillStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillStatusID", pBillStatus.BillStatusID));

                    sqlCommand.ExecuteNonQuery();

                    billStatus = new BillStatus(pBillStatus.BillStatusID);
                    base.DeleteAllTranslations(pBillStatus.Detail);
                }
                catch (Exception exc)
                {
                    billStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billStatus;
        }
    }
}
