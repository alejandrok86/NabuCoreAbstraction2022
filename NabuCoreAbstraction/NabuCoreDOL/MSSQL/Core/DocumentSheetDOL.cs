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
    public class DocumentSheetDOL : BaseDOL
    {
        public DocumentSheetDOL() : base()
        {
        }

        public DocumentSheetDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public DocumentSheet Get(int pDocumentSheetID)
        {
            DocumentSheet documentSheet = new DocumentSheet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[DocumentSheet_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DocumentSheetID", pDocumentSheetID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        documentSheet = new DocumentSheet(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(1)==false)
                            documentSheet.Content = new Entities.Content.Content(sqlDataReader.GetInt32(1));
                        documentSheet.Sequence = sqlDataReader.GetInt32(2);
                        if(sqlDataReader.IsDBNull(3)==false)
                            documentSheet.sheetDefinition = new SheetDefinition(sqlDataReader.GetInt32(3));
                        if(sqlDataReader.IsDBNull(4)==false)
                            documentSheet.sheetScanException = new Entities.Operations.SheetScanException(sqlDataReader.GetInt32(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    documentSheet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    documentSheet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return documentSheet;
        }

        public DocumentSheet[] List(int pDocumentID)
        {
            List<DocumentSheet> documentSheets = new List<DocumentSheet>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[DocumentSheet_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DocumentID", pDocumentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        DocumentSheet documentSheet = new DocumentSheet(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(1)==false)
                            documentSheet.Content = new Entities.Content.Content(sqlDataReader.GetInt32(1));
                        documentSheet.Sequence = sqlDataReader.GetInt32(2);
                        if(sqlDataReader.IsDBNull(3)==false)
                            documentSheet.sheetDefinition = new SheetDefinition(sqlDataReader.GetInt32(3));
                        if(sqlDataReader.IsDBNull(4)==false)
                            documentSheet.sheetScanException = new Entities.Operations.SheetScanException(sqlDataReader.GetInt32(4));
                        documentSheets.Add(documentSheet);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    DocumentSheet documentSheet = new DocumentSheet();
                    documentSheet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    documentSheet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    documentSheets.Add(documentSheet);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return documentSheets.ToArray();
        }

        public DocumentSheet Insert(DocumentSheet pDocumentSheet, int pDocumentID)
        {
            DocumentSheet documentSheet = new DocumentSheet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[DocumentSheet_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DocumentID", pDocumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", ((pDocumentSheet.Content != null) ? pDocumentSheet.Content.ContentID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Sequence", pDocumentSheet.Sequence));
                    sqlCommand.Parameters.Add(new SqlParameter("@SheetDefinitionID", ((pDocumentSheet.sheetDefinition != null) ? pDocumentSheet.sheetDefinition.SheetDefinitionID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SheetScanExceptionID", ((pDocumentSheet.sheetScanException != null) ? pDocumentSheet.sheetScanException.ScanExceptionID : null)));
                    SqlParameter documentSheetID = sqlCommand.Parameters.Add("@DocumentSheetID", SqlDbType.Int);
                    documentSheetID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    documentSheet = new DocumentSheet((Int32)documentSheetID.Value);
                    if(pDocumentSheet.Content != null)
                        documentSheet.Content = new Entities.Content.Content(pDocumentSheet.Content.ContentID);
                    documentSheet.Sequence = pDocumentSheet.Sequence;
                    if (pDocumentSheet.sheetDefinition != null)
                        documentSheet.sheetDefinition = new SheetDefinition(pDocumentSheet.sheetDefinition.SheetDefinitionID);
                    if (pDocumentSheet.sheetScanException != null)
                        documentSheet.sheetScanException = new Entities.Operations.SheetScanException(pDocumentSheet.sheetScanException.ScanExceptionID);
                }
                catch (Exception exc)
                {
                    documentSheet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    documentSheet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return documentSheet;
        }

        public DocumentSheet Update(DocumentSheet pDocumentSheet, int pDocumentID)
        {
            DocumentSheet documentSheet = new DocumentSheet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[DocumentSheet_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DocumentSheetID", pDocumentSheet.DocumentSheetID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DocumentID", pDocumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", ((pDocumentSheet.Content != null) ? pDocumentSheet.Content.ContentID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Sequence", pDocumentSheet.Sequence));
                    sqlCommand.Parameters.Add(new SqlParameter("@SheetDefinitionID", ((pDocumentSheet.sheetDefinition != null) ? pDocumentSheet.sheetDefinition.SheetDefinitionID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SheetScanExceptionID", ((pDocumentSheet.sheetScanException != null) ? pDocumentSheet.sheetScanException.ScanExceptionID : null)));

                    sqlCommand.ExecuteNonQuery();

                    documentSheet = new DocumentSheet(pDocumentSheet.DocumentSheetID);
                    if(pDocumentSheet.Content != null)
                        documentSheet.Content = new Entities.Content.Content(pDocumentSheet.Content.ContentID);
                    documentSheet.Sequence = pDocumentSheet.Sequence;
                    if (pDocumentSheet.sheetDefinition != null)
                        documentSheet.sheetDefinition = new SheetDefinition(pDocumentSheet.sheetDefinition.SheetDefinitionID);
                    if (pDocumentSheet.sheetScanException != null)
                        documentSheet.sheetScanException = new Entities.Operations.SheetScanException(pDocumentSheet.sheetScanException.ScanExceptionID);
                }
                catch (Exception exc)
                {
                    documentSheet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    documentSheet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return documentSheet;
        }

        public DocumentSheet Delete(DocumentSheet pDocumentSheet)
        {
            DocumentSheet documentSheet = new DocumentSheet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[DocumentSheet_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DocumentSheetID", pDocumentSheet.DocumentSheetID));

                    sqlCommand.ExecuteNonQuery();

                    documentSheet = new DocumentSheet(pDocumentSheet.DocumentSheetID);
                }
                catch (Exception exc)
                {
                    documentSheet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    documentSheet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return documentSheet;
        }
    }
}

