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

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity
{
    public class BrandDOL : BaseDOL
    {
        public BrandDOL() : base ()
        {
        }

        public BrandDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Brand Get(int pBrandID, int pLanguageID)
        {
            Brand brand = new Brand();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Brand_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BrandID", pBrandID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        brand = new Brand(sqlDataReader.GetInt32(0));
                        brand.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    brand.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    brand.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return brand;
        }

        public Brand GetByAlias(string pAlias, int pLanguageID)
        {
            Brand brand = new Brand();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Brand_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        brand = new Brand(sqlDataReader.GetInt32(0));
                        brand.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    brand.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    brand.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return brand;
        }

        public Brand[] List(int pOrganisationID, int pLanguageID)
        {
            List<Brand> brands = new List<Brand>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Brand_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrganisationID", pOrganisationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Brand brand = new Brand(sqlDataReader.GetInt32(0));
                        brand.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        brands.Add(brand);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Brand brand = new Brand();
                    brand.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    brand.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    brands.Add(brand);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return brands.ToArray();
        }

        public Brand[] List(int pLanguageID)
        {
            List<Brand> brands = new List<Brand>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Brand_ListDistinct]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Brand brand = new Brand();
                        brand.Detail = new Translation();
                        brand.Detail.Name = sqlDataReader.GetString(0);
                        brand.BrandID = sqlDataReader.GetInt32(1);
                        brand.Detail.TranslationID = sqlDataReader.GetInt32(2);
                        brand.Detail.Alias = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            brand.Detail.Description = sqlDataReader.GetString(4);
                        brand.Detail.TranslationLanguage = new Language(sqlDataReader.GetInt32(5));
                        brands.Add(brand);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Brand brand = new Brand();
                    brand.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    brand.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    brands.Add(brand);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return brands.ToArray();
        }

        public Brand Insert(Brand pBrand, int pOrganisationID)
        {
            Brand brand = new Brand();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Brand_Insert]");
                try
                {
                    pBrand.Detail = base.InsertTranslation(pBrand.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrganisationID", pOrganisationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pBrand.Detail.TranslationID));
                    SqlParameter brandID = sqlCommand.Parameters.Add("@BrandID", SqlDbType.Int);
                    brandID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    brand = new Brand((Int32)brandID.Value);
                    brand.Detail = new Translation(pBrand.Detail.TranslationID);
                    brand.Detail.Alias = pBrand.Detail.Alias;
                    brand.Detail.Description = pBrand.Detail.Description;
                    brand.Detail.Name = pBrand.Detail.Name;
                }
                catch (Exception exc)
                {
                    brand.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    brand.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return brand;
        }

        public Brand Update(Brand pBrand)
        {
            Brand brand = new Brand();

            brand = new Brand(pBrand.BrandID);
            pBrand.Detail = base.UpdateTranslation(pBrand.Detail);

            return brand;
        }

        public Brand Delete(Brand pBrand)
        {
            Brand brand = new Brand();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[Brand_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BrandID", pBrand.BrandID));

                    sqlCommand.ExecuteNonQuery();

                    brand = new Brand(pBrand.BrandID);
                    base.DeleteAllTranslations(pBrand.Detail);
                }
                catch (Exception exc)
                {
                    brand.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    brand.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return brand;
        }
    }
}
