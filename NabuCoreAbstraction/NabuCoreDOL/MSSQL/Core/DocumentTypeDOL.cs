using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core
{
    public class DocumentTypeDOL : BaseDOL
    {
        public DocumentTypeDOL() : base()
        {
        }

        public DocumentTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public DocumentType Get(int pDocumentTypeID, int pLanguageID)
        {
            DocumentType documentType = new DocumentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[DocumentType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DocumentTypeID", pDocumentTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        documentType = new DocumentType(sqlDataReader.GetInt32(0));
                        documentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    documentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    documentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return documentType;
        }

        public DocumentType[] List(int pLanguageID)
        {
            List<DocumentType> documentTypes = new List<DocumentType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[DocumentType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        DocumentType documentType = new DocumentType(sqlDataReader.GetInt32(0));
                        documentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        documentTypes.Add(documentType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    DocumentType documentType = new DocumentType();
                    documentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    documentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    documentTypes.Add(documentType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return documentTypes.ToArray();
        }

        public DocumentType Insert(DocumentType pDocumentType)
        {
            DocumentType documentType = new DocumentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[DocumentType_Insert]");
                try
                {
                    pDocumentType.Detail = base.InsertTranslation(pDocumentType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pDocumentType.Detail.TranslationID));
                    SqlParameter documentTypeID = sqlCommand.Parameters.Add("@DocumentTypeID", SqlDbType.Int);
                    documentTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    documentType = new DocumentType((Int32)documentTypeID.Value);
                    documentType.Detail = new Translation(pDocumentType.Detail.TranslationID);
                    documentType.Detail.Alias = pDocumentType.Detail.Alias;
                    documentType.Detail.Description = pDocumentType.Detail.Description;
                    documentType.Detail.Name = pDocumentType.Detail.Name;
                }
                catch (Exception exc)
                {
                    documentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    documentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return documentType;
        }

        public DocumentType Update(DocumentType pDocumentType)
        {
            DocumentType documentType = new DocumentType();

            pDocumentType.Detail = base.UpdateTranslation(pDocumentType.Detail);

            documentType = new DocumentType(pDocumentType.DocumentTypeID);
            documentType.Detail = new Translation(pDocumentType.Detail.TranslationID);
            documentType.Detail.Alias = pDocumentType.Detail.Alias;
            documentType.Detail.Description = pDocumentType.Detail.Description;
            documentType.Detail.Name = pDocumentType.Detail.Name;

            return documentType;
        }

        public DocumentType Delete(DocumentType pDocumentType)
        {
            DocumentType documentType = new DocumentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[DocumentType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DocumentTypeID", pDocumentType.DocumentTypeID));

                    sqlCommand.ExecuteNonQuery();

                    documentType = new DocumentType(pDocumentType.DocumentTypeID);
                    base.DeleteAllTranslations(pDocumentType.Detail);
                }
                catch (Exception exc)
                {
                    documentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    documentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return documentType;
        }
    }
}
