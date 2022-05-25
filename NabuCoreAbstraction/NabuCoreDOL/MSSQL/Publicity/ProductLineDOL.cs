using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octavo.Gate.Nabu.CORE.Entities.Publicity;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity
{
    public class ProductLineDOL : BaseDOL
    {
        public ProductLineDOL() : base()
        {
        }

        public ProductLineDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ProductLine Get(int pProductLineID, int pLanguageID)
        {
            ProductLine productLine = new ProductLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProductLineID", pProductLineID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        productLine = new ProductLine(sqlDataReader.GetInt32(0));
                        productLine.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLine;
        }

        public ProductLine GetByAlias(string pAlias, int pLanguageID)
        {
            ProductLine productLine = new ProductLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        productLine = new ProductLine(sqlDataReader.GetInt32(0));
                        productLine.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLine;
        }

        public ProductLine GetByPart(int pPartID, int pLanguageID)
        {
            ProductLine productLine = new ProductLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_GetForPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        productLine = new ProductLine(sqlDataReader.GetInt32(0));
                        productLine.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLine;
        }

        public ProductLine[] List(int pLanguageID)
        {
            List<ProductLine> productLines = new List<ProductLine>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_ListDistinct]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProductLine productLine = new ProductLine();
                        productLine.Detail = new Translation();
                        productLine.Detail.Name = sqlDataReader.GetString(0);
                        productLine.ProductLineID = sqlDataReader.GetInt32(1);
                        productLine.Detail.TranslationID = sqlDataReader.GetInt32(2);
                        productLine.Detail.Alias = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            productLine.Detail.Description = sqlDataReader.GetString(4);
                        productLine.Detail.TranslationLanguage = new Language(sqlDataReader.GetInt32(5));
                        productLines.Add(productLine);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ProductLine productLine = new ProductLine();
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    productLines.Add(productLine);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLines.ToArray();
        }

        public ProductLine[] ListByBrand(int pBrandID, int pLanguageID)
        {
            List<ProductLine> productLines = new List<ProductLine>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_ListByBrand]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BrandID", pBrandID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProductLine productLine = new ProductLine(sqlDataReader.GetInt32(0));
                        productLine.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        productLines.Add(productLine);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ProductLine productLine = new ProductLine();
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    productLines.Add(productLine);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLines.ToArray();
        }

        public ProductLine[] ListByOrganisation(int pOrganisationID, int pLanguageID)
        {
            List<ProductLine> productLines = new List<ProductLine>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_ListByOrganisation]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrganisationID", pOrganisationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProductLine productLine = new ProductLine(sqlDataReader.GetInt32(0));
                        productLine.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        productLines.Add(productLine);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ProductLine productLine = new ProductLine();
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    productLines.Add(productLine);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLines.ToArray();
        }

        public ProductLine Insert(ProductLine pProductLine, int? pBrandID)
        {
            ProductLine productLine = new ProductLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_Insert]");
                try
                {
                    pProductLine.Detail = base.InsertTranslation(pProductLine.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@BrandID", ((pBrandID.HasValue) ? pBrandID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pProductLine.Detail.TranslationID));
                    SqlParameter productLineID = sqlCommand.Parameters.Add("@ProductLineID", SqlDbType.Int);
                    productLineID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    productLine = new ProductLine((Int32)productLineID.Value);
                    productLine.Detail = new Translation(pProductLine.Detail.TranslationID);
                    productLine.Detail.Alias = pProductLine.Detail.Alias;
                    productLine.Detail.Description = pProductLine.Detail.Description;
                    productLine.Detail.Name = pProductLine.Detail.Name;
                }
                catch (Exception exc)
                {
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLine;
        }

        public ProductLine InsertForOrganisation(ProductLine pProductLine, int pOrganisationID)
        {
            ProductLine productLine = new ProductLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_InsertForOrganisation]");
                try
                {
                    pProductLine.Detail = base.InsertTranslation(pProductLine.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@OrganisationID", pOrganisationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pProductLine.Detail.TranslationID));
                    SqlParameter productLineID = sqlCommand.Parameters.Add("@ProductLineID", SqlDbType.Int);
                    productLineID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    productLine = new ProductLine((Int32)productLineID.Value);
                    productLine.Detail = new Translation(pProductLine.Detail.TranslationID);
                    productLine.Detail.Alias = pProductLine.Detail.Alias;
                    productLine.Detail.Description = pProductLine.Detail.Description;
                    productLine.Detail.Name = pProductLine.Detail.Name;
                }
                catch (Exception exc)
                {
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLine;
        }

        public ProductLine Update(ProductLine pProductLine, int? pBrandID)
        {
            ProductLine productLine = new ProductLine();
            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_Update]");
                try
                {
                    productLine.Detail = base.UpdateTranslation(productLine.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProductLineID", pProductLine.ProductLineID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BrandID", ((pBrandID.HasValue) ? pBrandID : null)));

                    sqlCommand.ExecuteNonQuery();

                    productLine = new ProductLine(pProductLine.ProductLineID);
                    pProductLine.Detail = base.UpdateTranslation(pProductLine.Detail);
                }
                catch (Exception exc)
                {
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLine;
        }

        public ProductLine UpdateForOrganisation(ProductLine pProductLine, int pOrganisationID)
        {
            ProductLine productLine = new ProductLine();
            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_UpdateForOrganisation]");
                try
                {
                    productLine.Detail = base.UpdateTranslation(productLine.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProductLineID", pProductLine.ProductLineID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OrganisationID", pOrganisationID));

                    sqlCommand.ExecuteNonQuery();

                    productLine = new ProductLine(pProductLine.ProductLineID);
                    pProductLine.Detail = base.UpdateTranslation(pProductLine.Detail);
                }
                catch (Exception exc)
                {
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLine;
        }

        public ProductLine Delete(ProductLine pProductLine)
        {
            ProductLine productLine = new ProductLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProductLineID", pProductLine.ProductLineID));

                    sqlCommand.ExecuteNonQuery();

                    productLine = new ProductLine(pProductLine.ProductLineID);
                    base.DeleteAllTranslations(pProductLine.Detail);
                }
                catch (Exception exc)
                {
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLine;
        }

        public ProductLine Assign(int pProductLineID, int pPartID)
        {
            ProductLine productLine = new ProductLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProductLineID", pProductLineID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));

                    sqlCommand.ExecuteNonQuery();

                    productLine = new ProductLine(pProductLineID);
                }
                catch (Exception exc)
                {
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLine;
        }

        public ProductLine Remove(int pProductLineID, int pPartID)
        {
            ProductLine productLine = new ProductLine();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProductLineID", pProductLineID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));

                    sqlCommand.ExecuteNonQuery();

                    productLine = new ProductLine(pProductLineID);
                }
                catch (Exception exc)
                {
                    productLine.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    productLine.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return productLine;
        }
        public BaseBoolean Remove(int pPartID)
        {
            BaseBoolean result = new BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ProductLine_RemoveAllForPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}
