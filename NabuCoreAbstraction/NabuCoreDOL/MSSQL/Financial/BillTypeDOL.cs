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
    public class BillTypeDOL : BaseDOL
    {
        public BillTypeDOL() : base()
        {
        }

        public BillTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public BillType Get(int pBillTypeID, int pLanguageID)
        {
            BillType billType = new BillType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillTypeID", pBillTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        billType = new BillType(sqlDataReader.GetInt32(0));
                        billType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    billType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billType;
        }

        public BillType GetByAlias(string pAlias, int pLanguageID)
        {
            BillType billType = new BillType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        billType = new BillType(sqlDataReader.GetInt32(0));
                        billType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    billType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billType;
        }

        public BillType[] List(int pLanguageID)
        {
            List<BillType> billTypes = new List<BillType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        BillType billType = new BillType(sqlDataReader.GetInt32(0));
                        billType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        billTypes.Add(billType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    BillType billType = new BillType();
                    billType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    billTypes.Add(billType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billTypes.ToArray();
        }

        public BillType Insert(BillType pBillType)
        {
            BillType billType = new BillType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillType_Insert]");
                try
                {
                    pBillType.Detail = base.InsertTranslation(pBillType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pBillType.Detail.TranslationID));
                    SqlParameter billTypeID = sqlCommand.Parameters.Add("@BillTypeID", SqlDbType.Int);
                    billTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    billType = new BillType((Int32)billTypeID.Value);
                    billType.Detail = new Translation(pBillType.Detail.TranslationID);
                    billType.Detail.Alias = pBillType.Detail.Alias;
                    billType.Detail.Description = pBillType.Detail.Description;
                    billType.Detail.Name = pBillType.Detail.Name;
                }
                catch (Exception exc)
                {
                    billType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billType;
        }

        public BillType Update(BillType pBillType)
        {
            BillType billType = new BillType();

            pBillType.Detail = base.UpdateTranslation(pBillType.Detail);

            billType = new BillType(pBillType.BillTypeID);
            billType.Detail = new Translation(pBillType.Detail.TranslationID);
            billType.Detail.Alias = pBillType.Detail.Alias;
            billType.Detail.Description = pBillType.Detail.Description;
            billType.Detail.Name = pBillType.Detail.Name;

            return billType;
        }

        public BillType Delete(BillType pBillType)
        {
            BillType billType = new BillType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[BillType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BillTypeID", pBillType.BillTypeID));

                    sqlCommand.ExecuteNonQuery();

                    billType = new BillType(pBillType.BillTypeID);
                    base.DeleteAllTranslations(pBillType.Detail);
                }
                catch (Exception exc)
                {
                    billType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    billType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return billType;
        }
    }
}
