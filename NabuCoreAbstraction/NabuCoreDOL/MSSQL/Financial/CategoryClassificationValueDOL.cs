using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class CategoryClassificationValueDOL : BaseDOL
    {
        public CategoryClassificationValueDOL() : base()
        {
        }

        public CategoryClassificationValueDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public CategoryClassificationValue Get(int pInstitutionScoreID, int pCategoryClassificationID, int pLanguageID)
        {
            CategoryClassificationValue categoryClassificationValue = new CategoryClassificationValue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoreCategoryClassification_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoreID", pInstitutionScoreID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryClassificationID", pCategoryClassificationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        categoryClassificationValue = new CategoryClassificationValue(sqlDataReader.GetInt32(1));
                        categoryClassificationValue.Detail = base.GetTranslation(sqlDataReader.GetInt32(2),pLanguageID);
                        categoryClassificationValue.Value = sqlDataReader.GetDecimal(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    categoryClassificationValue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    categoryClassificationValue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return categoryClassificationValue;
        }

        public CategoryClassificationValue[] List(int pInstitutionScoreID, int pLanguageID)
        {
            List<CategoryClassificationValue> categoryClassificationValues = new List<CategoryClassificationValue>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoreCategoryClassification_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoreID", pInstitutionScoreID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        CategoryClassificationValue categoryClassificationValue = new CategoryClassificationValue(sqlDataReader.GetInt32(1));
                        categoryClassificationValue.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(2));
                        categoryClassificationValue.Value = sqlDataReader.GetDecimal(3);

                        categoryClassificationValue.Detail.TranslationLanguage = new Entities.Globalisation.Language(pLanguageID);
                        categoryClassificationValue.Detail.Alias = sqlDataReader.GetString(4);
                        categoryClassificationValue.Detail.Name = sqlDataReader.GetString(5);
                        categoryClassificationValue.Detail.Description = sqlDataReader.GetString(6);

                        categoryClassificationValues.Add(categoryClassificationValue);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    CategoryClassificationValue categoryClassificationValue = new CategoryClassificationValue();
                    categoryClassificationValue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    categoryClassificationValue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    categoryClassificationValues.Add(categoryClassificationValue);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return categoryClassificationValues.ToArray();
        }

        public CategoryClassificationValue Insert(CategoryClassificationValue pCategoryClassificationValue, int pInstitutionScoreID)
        {
            CategoryClassificationValue categoryClassificationValue = new CategoryClassificationValue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoreCategoryClassification_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoreID", pInstitutionScoreID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryClassificationID", pCategoryClassificationValue.CategoryClassificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Value", pCategoryClassificationValue.Value));

                    sqlCommand.ExecuteNonQuery();

                    categoryClassificationValue = new CategoryClassificationValue(pCategoryClassificationValue.CategoryClassificationID);
                    categoryClassificationValue.Value = pCategoryClassificationValue.Value;
                }
                catch (Exception exc)
                {
                    categoryClassificationValue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    categoryClassificationValue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return categoryClassificationValue;
        }

        public CategoryClassificationValue Update(CategoryClassificationValue pCategoryClassificationValue, int pInstitutionScoreID)
        {
            CategoryClassificationValue categoryClassificationValue = new CategoryClassificationValue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoreCategoryClassification_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoreID", pInstitutionScoreID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryClassificationID", pCategoryClassificationValue.CategoryClassificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Value", pCategoryClassificationValue.Value));

                    sqlCommand.ExecuteNonQuery();

                    categoryClassificationValue = new CategoryClassificationValue(pCategoryClassificationValue.CategoryClassificationID);
                    categoryClassificationValue.Value = pCategoryClassificationValue.Value;
                }
                catch (Exception exc)
                {
                    categoryClassificationValue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    categoryClassificationValue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return categoryClassificationValue;
        }

        public CategoryClassificationValue Delete(int pInstitutionScoreID)
        {
            CategoryClassificationValue categoryClassificationValue = new CategoryClassificationValue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoreCategoryClassification_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoreID", pInstitutionScoreID));

                    sqlCommand.ExecuteNonQuery();

                    categoryClassificationValue = new CategoryClassificationValue();
                }
                catch (Exception exc)
                {
                    categoryClassificationValue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    categoryClassificationValue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return categoryClassificationValue;
        }
    }
}
