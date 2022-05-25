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
    public class LiquidityDOL : BaseDOL
    {
        public LiquidityDOL() : base()
        {
        }

        public LiquidityDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Liquidity Get(int pLiquidityID, int pLanguageID)
        {
            Liquidity Liquidity = new Liquidity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Liquidity_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LiquidityID", pLiquidityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        Liquidity = new Liquidity(sqlDataReader.GetInt32(0));
                        Liquidity.Detail = new Translation(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            Liquidity.Days = sqlDataReader.GetInt32(2);
                        Liquidity.Detail.Alias = sqlDataReader.GetString(3);
                        Liquidity.Detail.Name = sqlDataReader.GetString(4);
                        Liquidity.Detail.Description = sqlDataReader.GetString(5);
                        Liquidity.Detail.TranslationLanguage = new Language(pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Liquidity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Liquidity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Liquidity;
        }

        public Liquidity GetByAlias(string pAlias, int pLanguageID)
        {
            Liquidity Liquidity = new Liquidity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Liquidity_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        Liquidity = new Liquidity(sqlDataReader.GetInt32(0));
                        Liquidity.Detail = new Translation(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            Liquidity.Days = sqlDataReader.GetInt32(2);
                        Liquidity.Detail.Alias = sqlDataReader.GetString(3);
                        Liquidity.Detail.Name = sqlDataReader.GetString(4);
                        Liquidity.Detail.Description = sqlDataReader.GetString(5);
                        Liquidity.Detail.TranslationLanguage = new Language(pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Liquidity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Liquidity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Liquidity;
        }

        public Liquidity[] List(int pLanguageID)
        {
            List<Liquidity> Liquiditys = new List<Liquidity>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Liquidity_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Liquidity Liquidity = new Liquidity(sqlDataReader.GetInt32(0));
                        Liquidity.Detail = new Translation(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            Liquidity.Days = sqlDataReader.GetInt32(2);
                        Liquidity.Detail.Alias = sqlDataReader.GetString(3);
                        Liquidity.Detail.Name = sqlDataReader.GetString(4);
                        Liquidity.Detail.Description = sqlDataReader.GetString(5);
                        Liquidity.Detail.TranslationLanguage = new Language(pLanguageID);
                        Liquiditys.Add(Liquidity);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Liquidity Liquidity = new Liquidity();
                    Liquidity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Liquidity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    Liquiditys.Add(Liquidity);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Liquiditys.ToArray();
        }

        public Liquidity Insert(Liquidity pLiquidity)
        {
            Liquidity Liquidity = new Liquidity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Liquidity_Insert]");
                try
                {
                    pLiquidity.Detail = base.InsertTranslation(pLiquidity.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pLiquidity.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Days", ((pLiquidity.Days.HasValue) ? pLiquidity.Days : null)));
                    SqlParameter LiquidityID = sqlCommand.Parameters.Add("@LiquidityID", SqlDbType.Int);
                    LiquidityID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    Liquidity = new Liquidity((Int32)LiquidityID.Value);
                    Liquidity.Detail = new Translation(pLiquidity.Detail.TranslationID);
                    Liquidity.Detail.Alias = pLiquidity.Detail.Alias;
                    Liquidity.Detail.Description = pLiquidity.Detail.Description;
                    Liquidity.Detail.Name = pLiquidity.Detail.Name;
                    Liquidity.Days = pLiquidity.Days;
                }
                catch (Exception exc)
                {
                    Liquidity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Liquidity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Liquidity;
        }

        public Liquidity Update(Liquidity pLiquidity)
        {
            Liquidity Liquidity = new Liquidity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Liquidity_Update]");
                try
                {
                    pLiquidity.Detail = base.UpdateTranslation(pLiquidity.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LiquidityID", pLiquidity.LiquidityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Days", ((pLiquidity.Days.HasValue) ? pLiquidity.Days : null)));

                    sqlCommand.ExecuteNonQuery();

                    Liquidity = new Liquidity(pLiquidity.LiquidityID);
                    Liquidity.Detail = new Translation(pLiquidity.Detail.TranslationID);
                    Liquidity.Detail.Alias = pLiquidity.Detail.Alias;
                    Liquidity.Detail.Description = pLiquidity.Detail.Description;
                    Liquidity.Detail.Name = pLiquidity.Detail.Name;
                    Liquidity.Days = pLiquidity.Days;
                }
                catch (Exception exc)
                {
                    Liquidity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Liquidity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Liquidity;
        }

        public Liquidity Delete(Liquidity pLiquidity)
        {
            Liquidity Liquidity = new Liquidity();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Liquidity_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LiquidityID", pLiquidity.LiquidityID));

                    sqlCommand.ExecuteNonQuery();

                    Liquidity = new Liquidity(pLiquidity.LiquidityID);
                    base.DeleteAllTranslations(pLiquidity.Detail);
                }
                catch (Exception exc)
                {
                    Liquidity.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    Liquidity.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return Liquidity;
        }
    }
}
