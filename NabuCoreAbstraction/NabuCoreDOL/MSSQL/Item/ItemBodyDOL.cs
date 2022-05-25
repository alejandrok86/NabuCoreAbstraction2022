using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Item;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item
{
    public class ItemBodyDOL : BaseDOL
    {
        public ItemBodyDOL() : base ()
        {
        }

        public ItemBodyDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ItemBody Get(int pItemBodyID)
        {
            ItemBody itemBody = new ItemBody();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemBody_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemBodyID", pItemBodyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        itemBody = new ItemBody(sqlDataReader.GetInt32(0));
                        itemBody.BodyLanguage = new Language(sqlDataReader.GetInt32(2));
                        itemBody.BodyView = new View(sqlDataReader.GetInt32(3));
                        itemBody.BodyStyle = new Stylesheet(sqlDataReader.GetInt32(4));
                        itemBody.BodyScale = new Scale(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            itemBody.responseDeclaration = new ResponseDeclaration(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            itemBody.outputDeclaration = new OutputDeclaration(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            itemBody.responseProcessing = new ResponseProcessing(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            itemBody.feedbackDeclaration = new FeedbackDeclaration(sqlDataReader.GetInt32(9));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    itemBody.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemBody.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemBody;
        }

        public ItemBody GetByLanguageAndView(int pItemID, int pLanguageID, string pViewAlias)
        {
            ItemBody itemBody = new ItemBody();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemBody_GetForItemByLanguageAndView]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ViewAlias", pViewAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        itemBody = new ItemBody(sqlDataReader.GetInt32(0));
                        itemBody.BodyLanguage = new Language(sqlDataReader.GetInt32(2));
                        itemBody.BodyView = new View(sqlDataReader.GetInt32(3));
                        itemBody.BodyStyle = new Stylesheet(sqlDataReader.GetInt32(4));
                        itemBody.BodyScale = new Scale(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            itemBody.responseDeclaration = new ResponseDeclaration(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            itemBody.outputDeclaration = new OutputDeclaration(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            itemBody.responseProcessing = new ResponseProcessing(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            itemBody.feedbackDeclaration = new FeedbackDeclaration(sqlDataReader.GetInt32(9));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    itemBody.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemBody.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemBody;
        }

        public ItemBody[] List(int pItemID)
        {
            List<ItemBody> itemBodys = new List<ItemBody>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemBody_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ItemBody itemBody = new ItemBody(sqlDataReader.GetInt32(0));
                        itemBody.BodyLanguage = new Language(sqlDataReader.GetInt32(2));
                        itemBody.BodyView = new View(sqlDataReader.GetInt32(3));
                        itemBody.BodyStyle = new Stylesheet(sqlDataReader.GetInt32(4));
                        itemBody.BodyScale = new Scale(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            itemBody.responseDeclaration = new ResponseDeclaration(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            itemBody.outputDeclaration = new OutputDeclaration(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            itemBody.responseProcessing = new ResponseProcessing(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            itemBody.feedbackDeclaration = new FeedbackDeclaration(sqlDataReader.GetInt32(9));
                        itemBodys.Add(itemBody);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ItemBody itemBody = new ItemBody();
                    itemBody.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemBody.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    itemBodys.Add(itemBody);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemBodys.ToArray();
        }

        public ItemBody[] ListByLanguage(int pItemID, int pLanguageID)
        {
            List<ItemBody> itemBodys = new List<ItemBody>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemBody_ListByLanguage]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ItemBody itemBody = new ItemBody(sqlDataReader.GetInt32(0));
                        itemBody.BodyLanguage = new Language(sqlDataReader.GetInt32(2));
                        itemBody.BodyView = new View(sqlDataReader.GetInt32(3));
                        itemBody.BodyStyle = new Stylesheet(sqlDataReader.GetInt32(4));
                        itemBody.BodyScale = new Scale(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            itemBody.responseDeclaration = new ResponseDeclaration(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            itemBody.outputDeclaration = new OutputDeclaration(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            itemBody.responseProcessing = new ResponseProcessing(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            itemBody.feedbackDeclaration = new FeedbackDeclaration(sqlDataReader.GetInt32(9));
                        itemBodys.Add(itemBody);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ItemBody itemBody = new ItemBody();
                    itemBody.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemBody.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    itemBodys.Add(itemBody);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemBodys.ToArray();
        }

        public ItemBody Insert(ItemBody pItemBody, int pItemID)
        {
            ItemBody itemBody = new ItemBody();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemBody_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemBodyID", pItemBody.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pItemBody.BodyLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StylesheetID", pItemBody.BodyStyle.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ViewID", pItemBody.BodyView.ViewID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScaleID", pItemBody.BodyScale.ScaleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseDeclarationID", ((pItemBody.responseDeclaration != null) ? pItemBody.responseDeclaration.ResponseDeclarationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@OutputDeclarationID", ((pItemBody.outputDeclaration != null) ? pItemBody.outputDeclaration.OutputDeclarationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseProcessingID", ((pItemBody.responseProcessing != null) ? pItemBody.responseProcessing.ResponseProcessingID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedbackDeclarationID", ((pItemBody.feedbackDeclaration != null) ? pItemBody.feedbackDeclaration.FeedbackDeclarationID : null)));

                    sqlCommand.ExecuteNonQuery();

                    itemBody = new ItemBody(pItemBody.ContentID);
                    itemBody.BodyLanguage = new Language(pItemBody.BodyLanguage.LanguageID);
                    itemBody.BodyStyle = new Stylesheet(pItemBody.BodyStyle.ContentID);
                    itemBody.BodyView = new View(pItemBody.BodyView.ViewID);
                    itemBody.BodyScale = new Scale(pItemBody.BodyScale.ScaleID);
                    if (pItemBody.responseDeclaration != null)
                        itemBody.responseDeclaration = new ResponseDeclaration(pItemBody.responseDeclaration.ResponseDeclarationID);
                    if (pItemBody.outputDeclaration != null)
                        itemBody.outputDeclaration = new OutputDeclaration(pItemBody.outputDeclaration.OutputDeclarationID);
                    if (pItemBody.responseProcessing != null)
                        itemBody.responseProcessing = new ResponseProcessing(pItemBody.responseProcessing.ResponseProcessingID);
                    if (pItemBody.feedbackDeclaration != null)
                        itemBody.feedbackDeclaration = new FeedbackDeclaration(pItemBody.feedbackDeclaration.FeedbackDeclarationID);
                }
                catch (Exception exc)
                {
                    itemBody.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemBody.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemBody;
        }

        public ItemBody Update(ItemBody pItemBody, int pItemID)
        {
            ItemBody itemBody = new ItemBody();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemBody_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemBodyID", pItemBody.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pItemBody.BodyLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StylesheetID", pItemBody.BodyStyle.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ViewID", pItemBody.BodyView.ViewID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScaleID", pItemBody.BodyScale.ScaleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseDeclarationID", ((pItemBody.responseDeclaration != null) ? pItemBody.responseDeclaration.ResponseDeclarationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@OutputDeclarationID", ((pItemBody.outputDeclaration != null) ? pItemBody.outputDeclaration.OutputDeclarationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseProcessingID", ((pItemBody.responseProcessing != null) ? pItemBody.responseProcessing.ResponseProcessingID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedbackDeclarationID", ((pItemBody.feedbackDeclaration != null) ? pItemBody.feedbackDeclaration.FeedbackDeclarationID : null)));

                    sqlCommand.ExecuteNonQuery();

                    itemBody = new ItemBody(pItemBody.ContentID);
                    itemBody.BodyLanguage = new Language(pItemBody.BodyLanguage.LanguageID);
                    itemBody.BodyStyle = new Stylesheet(pItemBody.BodyStyle.ContentID);
                    itemBody.BodyView = new View(pItemBody.BodyView.ViewID);
                    itemBody.BodyScale = new Scale(pItemBody.BodyScale.ScaleID);
                    if (pItemBody.responseDeclaration != null)
                        itemBody.responseDeclaration = new ResponseDeclaration(pItemBody.responseDeclaration.ResponseDeclarationID);
                    if (pItemBody.outputDeclaration != null)
                        itemBody.outputDeclaration = new OutputDeclaration(pItemBody.outputDeclaration.OutputDeclarationID);
                    if (pItemBody.responseProcessing != null)
                        itemBody.responseProcessing = new ResponseProcessing(pItemBody.responseProcessing.ResponseProcessingID);
                    if (pItemBody.feedbackDeclaration != null)
                        itemBody.feedbackDeclaration = new FeedbackDeclaration(pItemBody.feedbackDeclaration.FeedbackDeclarationID);
                }
                catch (Exception exc)
                {
                    itemBody.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemBody.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemBody;
        }

        public ItemBody Delete(ItemBody pItemBody)
        {
            ItemBody itemBody = new ItemBody();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemBody_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemBodyID", pItemBody.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    itemBody = new ItemBody(pItemBody.ContentID);
                }
                catch (Exception exc)
                {
                    itemBody.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemBody.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemBody;
        }
    }
}
