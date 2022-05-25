using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Item;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Content;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item
{
    public class ItemDOL : BaseDOL
    {
        public ItemDOL() : base ()
        {
        }

        public ItemDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item Get(int pItemID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Item_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item(sqlDataReader.GetInt32(0));
                        item.Identifier = sqlDataReader.GetString(1);
                        item.Title = sqlDataReader.GetString(2);
                        item.Label = sqlDataReader.GetString(3);
                        item.IsAdaptive = sqlDataReader.GetBoolean(4);
                        item.IsScoringItem = sqlDataReader.GetBoolean(5);
                        item.IsTimeDependent = sqlDataReader.GetBoolean(6);
                        item.AuthoringToolName = sqlDataReader.GetString(7);
                        item.AuthoringToolVersion = sqlDataReader.GetString(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    item.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    item.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return item;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item GetByIdentifier(string pIdentifier)
        {
            Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Item_GetByIdentifier]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Identifier", pIdentifier));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item(sqlDataReader.GetInt32(0));
                        item.Identifier = sqlDataReader.GetString(1);
                        item.Title = sqlDataReader.GetString(2);
                        item.Label = sqlDataReader.GetString(3);
                        item.IsAdaptive = sqlDataReader.GetBoolean(4);
                        item.IsScoringItem = sqlDataReader.GetBoolean(5);
                        item.IsTimeDependent = sqlDataReader.GetBoolean(6);
                        item.AuthoringToolName = sqlDataReader.GetString(7);
                        item.AuthoringToolVersion = sqlDataReader.GetString(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    item.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    item.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return item;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item GetByLanguageAndView(int pItemID, int pLanguageID, string pViewAlias)
        {
            Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Item_GetByLanguageAndView]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ViewAlias", pViewAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item(sqlDataReader.GetInt32(0));
                        item.Identifier = sqlDataReader.GetString(1);
                        item.Title = sqlDataReader.GetString(2);
                        item.Label = sqlDataReader.GetString(3);
                        item.IsAdaptive = sqlDataReader.GetBoolean(4);
                        item.IsScoringItem = sqlDataReader.GetBoolean(5);
                        item.IsTimeDependent = sqlDataReader.GetBoolean(6);
                        item.AuthoringToolName = sqlDataReader.GetString(7);
                        item.AuthoringToolVersion = sqlDataReader.GetString(8);

                        List<ItemBody> itemBodies = new List<ItemBody>();
                        ItemBody itemBody = new ItemBody(sqlDataReader.GetInt32(9));
                        itemBody.BodyLanguage = new Language(sqlDataReader.GetInt32(10));
                        itemBody.BodyScale = new Scale(sqlDataReader.GetInt32(14));
                        itemBody.BodyStyle = new Stylesheet(sqlDataReader.GetInt32(13));
                        itemBody.BodyView = new View(sqlDataReader.GetInt32(11));
                        itemBody.BodyView.Detail = new Translation();
                        itemBody.BodyView.Detail.Alias = sqlDataReader.GetString(12);
                        itemBody.ContentID = sqlDataReader.GetInt32(15);
                        itemBody.Name = sqlDataReader.GetString(16);
                        itemBody.Description = sqlDataReader.GetString(17);

                        List<ContentVersion> contentVersions = new List<ContentVersion>();
                        StructuredContent structuredContent = new StructuredContent(sqlDataReader.GetInt32(18));
                        structuredContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(21));
                        structuredContent.IsCurrentVersion = sqlDataReader.GetBoolean(22);
                        structuredContent.IsPublished = sqlDataReader.GetBoolean(23);
                        structuredContent.MajorVersionNumber = sqlDataReader.GetInt32(19);
                        structuredContent.MinorVersionNumber = sqlDataReader.GetInt32(20);
                        structuredContent.XMLFragment = sqlDataReader.GetString(24);
                        contentVersions.Add(structuredContent);
                        itemBody.ContentVersions = contentVersions.ToArray();

                        if (sqlDataReader.IsDBNull(25) == false)
                            itemBody.outputDeclaration = new OutputDeclaration(sqlDataReader.GetInt32(25));
                        if (sqlDataReader.IsDBNull(26) == false)
                            itemBody.responseDeclaration = new ResponseDeclaration(sqlDataReader.GetInt32(26));
                        if (sqlDataReader.IsDBNull(27) == false)
                            itemBody.responseProcessing = new ResponseProcessing(sqlDataReader.GetInt32(27));
                        if (sqlDataReader.IsDBNull(28) == false)
                            itemBody.feedbackDeclaration = new FeedbackDeclaration(sqlDataReader.GetInt32(28));

                        itemBodies.Add(itemBody);
                        item.ItemBodies = itemBodies.ToArray();
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    item.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    item.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return item;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item GetAlternateItemForInstrumentPartCode(string pInstrumentPartCode, int pDisplaySequence, int pAttemptNumber)
        {
            Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Item_GetAlternateItemForInstrumentPartCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentPartCode", pInstrumentPartCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pDisplaySequence));
                    sqlCommand.Parameters.Add(new SqlParameter("@AttemptNumber", pAttemptNumber));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item(sqlDataReader.GetInt32(0));
                        item.Identifier = sqlDataReader.GetString(1);
                        item.Title = sqlDataReader.GetString(2);
                        item.Label = sqlDataReader.GetString(3);
                        item.IsAdaptive = sqlDataReader.GetBoolean(4);
                        item.IsScoringItem = sqlDataReader.GetBoolean(5);
                        item.IsTimeDependent = sqlDataReader.GetBoolean(6);
                        item.AuthoringToolName = sqlDataReader.GetString(7);
                        item.AuthoringToolVersion = sqlDataReader.GetString(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    item.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    item.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return item;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item[] List(int pOwnerOrganisationID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Item.Item> items = new List<Octavo.Gate.Nabu.CORE.Entities.Item.Item>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Item_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerOrganisationID", pOwnerOrganisationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item(sqlDataReader.GetInt32(0));
                        item.Identifier = sqlDataReader.GetString(1);
                        item.Title = sqlDataReader.GetString(2);
                        item.Label = sqlDataReader.GetString(3);
                        item.IsAdaptive = sqlDataReader.GetBoolean(4);
                        item.IsScoringItem = sqlDataReader.GetBoolean(5);
                        item.IsTimeDependent = sqlDataReader.GetBoolean(6);
                        item.AuthoringToolName = sqlDataReader.GetString(7);
                        item.AuthoringToolVersion = sqlDataReader.GetString(8);
                        items.Add(item);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item();
                    item.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    item.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    items.Add(item);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return items.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item[] ListForInstrumentPartCode(string pInstrumentPartCode)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Item.Item> items = new List<Octavo.Gate.Nabu.CORE.Entities.Item.Item>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Item_ListForInstrumentPartCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentPartCode", pInstrumentPartCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item(sqlDataReader.GetInt32(0));
                        item.Identifier = sqlDataReader.GetString(1);
                        item.Title = sqlDataReader.GetString(2);
                        item.Label = sqlDataReader.GetString(3);
                        item.IsAdaptive = sqlDataReader.GetBoolean(4);
                        item.IsScoringItem = sqlDataReader.GetBoolean(5);
                        item.IsTimeDependent = sqlDataReader.GetBoolean(6);
                        item.AuthoringToolName = sqlDataReader.GetString(7);
                        item.AuthoringToolVersion = sqlDataReader.GetString(8);
                        items.Add(item);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item();
                    item.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    item.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    items.Add(item);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return items.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item[] ListForInstrumentSection(int pInstrumentSectionID, int pAttemptNumber)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Item.Item> items = new List<Octavo.Gate.Nabu.CORE.Entities.Item.Item>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Item_ListForInstrumentSection]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentSectionID", pInstrumentSectionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AttemptNumber", pAttemptNumber));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item(sqlDataReader.GetInt32(0));
                        item.Identifier = sqlDataReader.GetString(1);
                        item.Title = sqlDataReader.GetString(2);
                        item.Label = sqlDataReader.GetString(3);
                        item.IsAdaptive = sqlDataReader.GetBoolean(4);
                        item.IsScoringItem = sqlDataReader.GetBoolean(5);
                        item.IsTimeDependent = sqlDataReader.GetBoolean(6);
                        item.AuthoringToolName = sqlDataReader.GetString(7);
                        item.AuthoringToolVersion = sqlDataReader.GetString(8);
                        items.Add(item);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item();
                    item.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    item.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    items.Add(item);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return items.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item Insert(Octavo.Gate.Nabu.CORE.Entities.Item.Item pItem)
        {
            Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Item_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Identifier",pItem.Identifier));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pItem.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Label", pItem.Label));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsAdaptive", pItem.IsAdaptive));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsScoringItem", pItem.IsScoringItem));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsTimeDependent", pItem.IsTimeDependent));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthoringToolName", pItem.AuthoringToolName));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthoringToolVersion", pItem.AuthoringToolVersion));
                    SqlParameter itemID = sqlCommand.Parameters.Add("@ItemID", SqlDbType.Int);
                    itemID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item((Int32)itemID.Value);
                    item.Identifier = pItem.Identifier;
                    item.Title = pItem.Title;
                    item.Label = pItem.Label;
                    item.IsAdaptive = pItem.IsAdaptive;
                    item.IsScoringItem = pItem.IsScoringItem;
                    item.IsTimeDependent = pItem.IsTimeDependent;
                    item.AuthoringToolName = pItem.AuthoringToolName;
                    item.AuthoringToolVersion = pItem.AuthoringToolVersion;
                }
                catch (Exception exc)
                {
                    item.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    item.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return item;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item Update(Octavo.Gate.Nabu.CORE.Entities.Item.Item pItem)
        {
            Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Item_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID",pItem.ItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Identifier",pItem.Identifier));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pItem.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Label", pItem.Label));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsAdaptive", pItem.IsAdaptive));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsScoringItem", pItem.IsScoringItem));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsTimeDependent", pItem.IsTimeDependent));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthoringToolName", pItem.AuthoringToolName));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthoringToolVersion", pItem.AuthoringToolVersion));

                    sqlCommand.ExecuteNonQuery();

                    item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item(pItem.ItemID);
                    item.Identifier = pItem.Identifier;
                    item.Title = pItem.Title;
                    item.Label = pItem.Label;
                    item.IsAdaptive = pItem.IsAdaptive;
                    item.IsScoringItem = pItem.IsScoringItem;
                    item.IsTimeDependent = pItem.IsTimeDependent;
                    item.AuthoringToolName = pItem.AuthoringToolName;
                    item.AuthoringToolVersion = pItem.AuthoringToolVersion;
                }
                catch (Exception exc)
                {
                    item.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    item.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return item;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item Delete(Octavo.Gate.Nabu.CORE.Entities.Item.Item pItem)
        {
            Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Item_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItem.ItemID));

                    sqlCommand.ExecuteNonQuery();

                    item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item(pItem.ItemID);
                }
                catch (Exception exc)
                {
                    item.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    item.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return item;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item Remove(int pItemID, int pOrganisationID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemOwner_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OrganisationID", pOrganisationID));

                    sqlCommand.ExecuteNonQuery();

                    item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item(pItemID);
                }
                catch (Exception exc)
                {
                    item.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    item.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return item;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item Assign(int pItemID, int pOrganisationID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Item.Item item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemOwner_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OrganisationID", pOrganisationID));

                    sqlCommand.ExecuteNonQuery();

                    item = new Octavo.Gate.Nabu.CORE.Entities.Item.Item(pItemID);
                }
                catch (Exception exc)
                {
                    item.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    item.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return item;
        }
    }
}
