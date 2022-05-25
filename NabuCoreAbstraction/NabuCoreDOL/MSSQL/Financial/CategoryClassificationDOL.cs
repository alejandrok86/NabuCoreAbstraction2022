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
    public class CategoryClassificationDOL : BaseDOL
    {
        public CategoryClassificationDOL() : base()
        {
        }

        public CategoryClassificationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public CategoryClassification Get(int pCategoryClassificationID, int pLanguageID)
        {
            CategoryClassification categoryClassification = new CategoryClassification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[CategoryClassification_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryClassificationID", pCategoryClassificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        categoryClassification = new CategoryClassification(sqlDataReader.GetInt32(0));
                        categoryClassification.Detail = new Translation(sqlDataReader.GetInt32(1));
                        categoryClassification.Detail.Alias = sqlDataReader.GetString(2);
                        categoryClassification.Detail.Name = sqlDataReader.GetString(3);
                        categoryClassification.Detail.Description = sqlDataReader.GetString(4);
                        categoryClassification.Detail.TranslationLanguage = new Language(pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    categoryClassification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    categoryClassification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return categoryClassification;
        }

        public CategoryClassification GetByAlias(string pAlias, int pLanguageID)
        {
            CategoryClassification categoryClassification = new CategoryClassification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[CategoryClassification_GetByAlias]");
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
                        categoryClassification = new CategoryClassification(sqlDataReader.GetInt32(0));
                        categoryClassification.Detail = new Translation(sqlDataReader.GetInt32(1));
                        categoryClassification.Detail.Alias = sqlDataReader.GetString(2);
                        categoryClassification.Detail.Name = sqlDataReader.GetString(3);
                        categoryClassification.Detail.Description = sqlDataReader.GetString(4);
                        categoryClassification.Detail.TranslationLanguage = new Language(pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    categoryClassification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    categoryClassification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return categoryClassification;
        }
       
        public CategoryClassification[] List(int pLanguageID)
        {
            List<CategoryClassification> categoryClassifications = new List<CategoryClassification>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[CategoryClassification_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        CategoryClassification categoryClassification = new CategoryClassification(sqlDataReader.GetInt32(0));
                        categoryClassification.Detail = new Translation(sqlDataReader.GetInt32(1));
                        categoryClassification.Detail.Alias = sqlDataReader.GetString(2);
                        categoryClassification.Detail.Name = sqlDataReader.GetString(3);
                        categoryClassification.Detail.Description = sqlDataReader.GetString(4);
                        categoryClassification.Detail.TranslationLanguage = new Language(pLanguageID);
                        categoryClassifications.Add(categoryClassification);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    CategoryClassification categoryClassification = new CategoryClassification();
                    categoryClassification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    categoryClassification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    categoryClassifications.Add(categoryClassification);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return categoryClassifications.ToArray();
        }

        public CategoryClassification Insert(CategoryClassification pCategoryClassification)
        {
            CategoryClassification categoryClassification = new CategoryClassification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[CategoryClassification_Insert]");
                try
                {
                    pCategoryClassification.Detail = base.InsertTranslation(pCategoryClassification.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pCategoryClassification.Detail.TranslationID));
                    SqlParameter categoryClassificationID = sqlCommand.Parameters.Add("@CategoryClassificationID", SqlDbType.Int);
                    categoryClassificationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    categoryClassification = new CategoryClassification((Int32)categoryClassificationID.Value);
                    categoryClassification.Detail = new Translation(pCategoryClassification.Detail.TranslationID);
                    categoryClassification.Detail.Alias = pCategoryClassification.Detail.Alias;
                    categoryClassification.Detail.Description = pCategoryClassification.Detail.Description;
                    categoryClassification.Detail.Name = pCategoryClassification.Detail.Name;
                }
                catch (Exception exc)
                {
                    categoryClassification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    categoryClassification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return categoryClassification;
        }

        public CategoryClassification Update(CategoryClassification pCategoryClassification)
        {
            CategoryClassification categoryClassification = new CategoryClassification();

            pCategoryClassification.Detail = base.UpdateTranslation(pCategoryClassification.Detail);

            categoryClassification = new CategoryClassification(pCategoryClassification.CategoryClassificationID);
            categoryClassification.Detail = new Translation(pCategoryClassification.Detail.TranslationID);
            categoryClassification.Detail.Alias = pCategoryClassification.Detail.Alias;
            categoryClassification.Detail.Description = pCategoryClassification.Detail.Description;
            categoryClassification.Detail.Name = pCategoryClassification.Detail.Name;

            return categoryClassification;
        }

        public CategoryClassification Delete(CategoryClassification pCategoryClassification)
        {
            CategoryClassification categoryClassification = new CategoryClassification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[CategoryClassification_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryClassificationID", pCategoryClassification.CategoryClassificationID));

                    sqlCommand.ExecuteNonQuery();

                    categoryClassification = new CategoryClassification(pCategoryClassification.CategoryClassificationID);
                    base.DeleteAllTranslations(pCategoryClassification.Detail);
                }
                catch (Exception exc)
                {
                    categoryClassification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    categoryClassification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return categoryClassification;
        }
    }
}
