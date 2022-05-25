using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class ShareholderDOL : BaseDOL
    {
        public ShareholderDOL() : base()
        {
        }

        public ShareholderDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Shareholder Get(int pInstitutionID, int pShareholderID)
        {
            Shareholder shareholder = new Shareholder();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Shareholder_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareholderID", pShareholderID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        shareholder = new Shareholder(sqlDataReader.GetInt32(0));
                        shareholder.PercentageShareholding = sqlDataReader.GetDecimal(1);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    shareholder.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareholder.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareholder;
        }

        public Shareholder[] List(int pInstitutionID)
        {
            List<Shareholder> shareholders = new List<Shareholder>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Shareholder_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Shareholder shareholder = new Shareholder(sqlDataReader.GetInt32(0));
                        shareholder.PercentageShareholding = sqlDataReader.GetDecimal(1);
                        shareholders.Add(shareholder);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Shareholder shareholder = new Shareholder();
                    shareholder.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareholder.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    shareholders.Add(shareholder);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareholders.ToArray();
        }

        public Shareholder Insert(Shareholder pShareholder, int pInstitutionID)
        {
            Shareholder shareholder = new Shareholder();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Shareholder_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareholderID", pShareholder.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PercentageShareholding", pShareholder.PercentageShareholding));

                    sqlCommand.ExecuteNonQuery();

                    shareholder = new Shareholder(pShareholder.PartyID);
                    shareholder.PercentageShareholding = pShareholder.PercentageShareholding;
                }
                catch (Exception exc)
                {
                    shareholder.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareholder.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareholder;
        }

        public Shareholder Update(Shareholder pShareholder, int pInstitutionID)
        {
            Shareholder shareholder = new Shareholder();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Shareholder_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareholderID", pShareholder.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PercentageShareholding", pShareholder.PercentageShareholding));

                    sqlCommand.ExecuteNonQuery();

                    shareholder = new Shareholder(pShareholder.PartyID);
                    shareholder.PercentageShareholding = pShareholder.PercentageShareholding;
                }
                catch (Exception exc)
                {
                    shareholder.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareholder.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareholder;
        }

        public Shareholder Delete(Shareholder pShareholder, int pInstitutionID)
        {
            Shareholder shareholder = new Shareholder();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Shareholder_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ShareholderID", pShareholder.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    shareholder = new Shareholder(pShareholder.PartyID);
                }
                catch (Exception exc)
                {
                    shareholder.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    shareholder.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return shareholder;
        }
    }
}
