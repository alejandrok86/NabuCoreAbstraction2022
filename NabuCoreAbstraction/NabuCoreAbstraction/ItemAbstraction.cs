using Octavo.Gate.Nabu.CORE.Entities.Item;
using Octavo.Gate.Nabu.CORE.Entities;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class ItemAbstraction : BaseAbstraction
    {
        public ItemAbstraction() : base()
        {
        }

        public ItemAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Item Body
         *********************************************************************/
        public ItemBody GetItemBody(int pItemBodyID)
        {
            ItemBody itemBody = null;
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemBodyDOL itemBodyDOL = new CORE.DOL.MSSQL.Item.ItemBodyDOL(base.ConnectionString, base.ErrorLogFile);
                itemBody = itemBodyDOL.Get(pItemBodyID);
                if (itemBody.ErrorsDetected == false)
                {
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL contentDOL = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content tmpContent = contentDOL.Get((int)itemBody.ContentID);
                    if (tmpContent.ErrorsDetected == false)
                    {
                        itemBody.Description = tmpContent.Description;
                        itemBody.Name = tmpContent.Name;
                        itemBody.UseVersionControls = tmpContent.UseVersionControls;

                        Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL structuredContentDOL = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                        Octavo.Gate.Nabu.CORE.Entities.Content.StructuredContent[] structuredContents = structuredContentDOL.List((int)itemBody.ContentID, (int)itemBody.BodyLanguage.LanguageID);
                        if (structuredContents[0].ErrorsDetected == false)
                        {
                            Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentBodyTypeDOL contentBodyTypeDOL = new CORE.DOL.MSSQL.Content.ContentBodyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                            List<Entities.Content.ContentVersion> contentVersions = new List<Entities.Content.ContentVersion>();
                            foreach (Octavo.Gate.Nabu.CORE.Entities.Content.StructuredContent structuredContent in structuredContents)
                            {
                                structuredContent.BodyType = contentBodyTypeDOL.Get((int)structuredContent.BodyType.ContentBodyTypeID, (int)itemBody.BodyLanguage.LanguageID);
                                contentVersions.Add(structuredContent);
                            }
                            itemBody.ContentVersions = contentVersions.ToArray();
                        }
                        
                        Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL contentTypeDOL = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                        itemBody.ContentClassifications = contentTypeDOL.ListForContent((int)itemBody.ContentID, (int)itemBody.BodyLanguage.LanguageID);

                        itemBody.BodyView = GetView((int)itemBody.BodyView.ViewID, (int)itemBody.BodyLanguage.LanguageID);
                        
                        itemBody.BodyStyle = GetStylesheet((int)itemBody.BodyStyle.ContentID);

                        Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageDOL languageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageDOL(base.ConnectionString, base.ErrorLogFile);
                        itemBody.BodyLanguage = languageDOL.Get((int)itemBody.BodyLanguage.LanguageID);

                        itemBody.BodyScale = GetScale((int)itemBody.BodyScale.ScaleID,(int)itemBody.BodyLanguage.LanguageID);
                    }
                }
            }
            return itemBody;
        }

        public ItemBody GetItemBodyByLanguageAndView(int pItemID, int pLanguageID, string pViewAlias)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemBodyDOL itemBodyDOL = new CORE.DOL.MSSQL.Item.ItemBodyDOL(base.ConnectionString, base.ErrorLogFile);
                return itemBodyDOL.GetByLanguageAndView(pItemID, pLanguageID, pViewAlias);
            }
            return null;
        }

        public ItemBody[] ListItemBodiesByLanguage(int pItemID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemBodyDOL itemBodyDOL = new CORE.DOL.MSSQL.Item.ItemBodyDOL(base.ConnectionString, base.ErrorLogFile);
                ItemBody[] tmpBodies = itemBodyDOL.ListByLanguage(pItemID, pLanguageID);
                List<ItemBody> listBodies = new List<ItemBody>();
                foreach (ItemBody tmpBody in tmpBodies)
                {
                    listBodies.Add(GetItemBody((int)tmpBody.ContentID));
                }
                return listBodies.ToArray();
            }
            else
                return null;
        }

        public ItemBody[] ListItemBodies(int pItemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemBodyDOL itemBodyDOL = new CORE.DOL.MSSQL.Item.ItemBodyDOL(base.ConnectionString, base.ErrorLogFile);
                ItemBody[] tmpBodies = itemBodyDOL.List(pItemID);
                List<ItemBody> listBodies = new List<ItemBody>();
                foreach (ItemBody tmpBody in tmpBodies)
                {
                    listBodies.Add(GetItemBody((int)tmpBody.ContentID));
                }
                return listBodies.ToArray();
            }
            else
                return null;
        }
       
        public ItemBody InsertItemBody(ItemBody pItemBody, int pItemID)
        {
            ItemBody itemBody = null;
            if (base.DBType == DatabaseType.MSSQL)
            {
                // Create the content
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL contentDOL = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                Entities.Content.Content tmpContent = contentDOL.Insert(pItemBody, null);
                if (tmpContent.ErrorsDetected == false)
                {
                    itemBody = new ItemBody(tmpContent.ContentID);
                    itemBody.Name = tmpContent.Name;
                    itemBody.Description = tmpContent.Description;
                    itemBody.UseVersionControls = tmpContent.UseVersionControls;
                    itemBody.BodyLanguage = new Entities.Globalisation.Language(pItemBody.BodyLanguage.LanguageID);
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

                    // assign the content type(s)
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL contentTypeDOL = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                    foreach (Entities.Content.ContentType contentType in pItemBody.ContentClassifications)
                    {
                        contentTypeDOL.AssignContentType((int)itemBody.ContentID, (int)contentType.ContentTypeID);
                    }

                    // create the content version/structured content
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL structuredContentDOL = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                    foreach(Entities.Content.ContentVersion contentVersion in pItemBody.ContentVersions)
                    {
                        if (contentVersion.GetType() == typeof(Entities.Content.StructuredContent))
                        {
                            Entities.Content.StructuredContent tmpStructuredContent = contentVersion as Entities.Content.StructuredContent;
                            structuredContentDOL.Insert(tmpStructuredContent, (int)itemBody.ContentID);
                        }
                    }
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemBodyDOL itemBodyDOL = new CORE.DOL.MSSQL.Item.ItemBodyDOL(base.ConnectionString, base.ErrorLogFile);
                    itemBody = itemBodyDOL.Insert(itemBody, pItemID);
                }
            }
            return itemBody;
        }

        public ItemBody UpdateItemBody(ItemBody pItemBody, int pItemID)
        {
            ItemBody itemBody = null;
            if (base.DBType == DatabaseType.MSSQL)
            {
                // Create the content
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL contentDOL = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                Entities.Content.Content tmpContent = contentDOL.Update(pItemBody, null);
                if (tmpContent.ErrorsDetected == false)
                {
                    itemBody = new ItemBody(tmpContent.ContentID);
                    itemBody.Name = tmpContent.Name;
                    itemBody.Description = tmpContent.Description;
                    itemBody.UseVersionControls = tmpContent.UseVersionControls;
                    itemBody.BodyLanguage = new Entities.Globalisation.Language((int)pItemBody.BodyLanguage.LanguageID);
                    itemBody.BodyScale = new Scale(pItemBody.BodyScale.ScaleID);
                    itemBody.BodyStyle = new Stylesheet(pItemBody.BodyStyle.ContentID);
                    itemBody.BodyView = new View(pItemBody.BodyView.ViewID);
                    if (pItemBody.responseDeclaration != null)
                        itemBody.responseDeclaration = new ResponseDeclaration(pItemBody.responseDeclaration.ResponseDeclarationID);
                    if (pItemBody.outputDeclaration != null)
                        itemBody.outputDeclaration = new OutputDeclaration(pItemBody.outputDeclaration.OutputDeclarationID);
                    if (pItemBody.responseProcessing != null)
                        itemBody.responseProcessing = new ResponseProcessing(pItemBody.responseProcessing.ResponseProcessingID);
                    if (pItemBody.feedbackDeclaration != null)
                        itemBody.feedbackDeclaration = new FeedbackDeclaration(pItemBody.feedbackDeclaration.FeedbackDeclarationID);

                    // create the content version/structured content
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL structuredContentDOL = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                    foreach (Entities.Content.ContentVersion contentVersion in pItemBody.ContentVersions)
                    {
                        if (contentVersion.GetType() == typeof(Entities.Content.StructuredContent))
                        {
                            Entities.Content.StructuredContent tmpStructuredContent = contentVersion as Entities.Content.StructuredContent;
                            structuredContentDOL.Update(tmpStructuredContent, (int)itemBody.ContentID);
                        }
                    }
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemBodyDOL itemBodyDOL = new CORE.DOL.MSSQL.Item.ItemBodyDOL(base.ConnectionString, base.ErrorLogFile);
                    itemBody = itemBodyDOL.Update(itemBody, pItemID);
                }
            }
            return itemBody;
        }

        public ItemBody DeleteItemBody(ItemBody pItemBody)
        {
            ItemBody itemBody = null;
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemBodyDOL itemBodyDOL = new CORE.DOL.MSSQL.Item.ItemBodyDOL(base.ConnectionString, base.ErrorLogFile);
                itemBody = itemBodyDOL.Delete(pItemBody);  // delete the item body

                // delete the structured content/versions
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL structuredContentDOL = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                foreach (Entities.Content.ContentVersion contentVersion in pItemBody.ContentVersions)
                {
                    if (contentVersion.GetType() == typeof(Entities.Content.StructuredContent))
                    {
                        Entities.Content.StructuredContent tmpStructuredContent = contentVersion as Entities.Content.StructuredContent;
                        structuredContentDOL.Delete(tmpStructuredContent);
                    }
                }

                // remove the content classifications/types
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL contentTypeDOL = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                foreach (Entities.Content.ContentType contentType in pItemBody.ContentClassifications)
                {
                    contentTypeDOL.DeAssignContentType((int)pItemBody.ContentID, (int)contentType.ContentTypeID);
                }

                // delete the underlying content
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL contentDOL = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                contentDOL.Delete(pItemBody);
            }
            return itemBody;
        }

        /**********************************************************************
         * Item
         *********************************************************************/
        public Octavo.Gate.Nabu.CORE.Entities.Item.Item GetItem(int pItemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemDOL itemDOL = new CORE.DOL.MSSQL.Item.ItemDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.Get(pItemID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item GetItemByIdentifier(string pIdentifier)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemDOL itemDOL = new CORE.DOL.MSSQL.Item.ItemDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.GetByIdentifier(pIdentifier);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item GetItemByLanguageAndView(int pItemID, int pLanguageID, string pViewAlias)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemDOL itemDOL = new CORE.DOL.MSSQL.Item.ItemDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.GetByLanguageAndView(pItemID, pLanguageID, pViewAlias);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item[] ListItems(int pOwnerOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemDOL itemDOL = new CORE.DOL.MSSQL.Item.ItemDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.List(pOwnerOrganisationID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item[] ListItemsForInstrumentPartCode(string pInstrumentPartCode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemDOL itemDOL = new CORE.DOL.MSSQL.Item.ItemDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.ListForInstrumentPartCode(pInstrumentPartCode);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item[] ListItemsForInstrumentSection(int pInstrumentSectionID, int pAttemptNumber)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemDOL itemDOL = new CORE.DOL.MSSQL.Item.ItemDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.ListForInstrumentSection(pInstrumentSectionID, pAttemptNumber);
            }
            else
                return null;
        }
        public Octavo.Gate.Nabu.CORE.Entities.Item.Item GetAlternateItemForInstrumentPartCode(string pInstrumentPartCode, int pDisplaySequence, int pAttemptNumber)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemDOL itemDOL = new CORE.DOL.MSSQL.Item.ItemDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.GetAlternateItemForInstrumentPartCode(pInstrumentPartCode, pDisplaySequence, pAttemptNumber);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item InsertItem(Octavo.Gate.Nabu.CORE.Entities.Item.Item pItem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemDOL itemDOL = new CORE.DOL.MSSQL.Item.ItemDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.Insert(pItem);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item UpdateItem(Octavo.Gate.Nabu.CORE.Entities.Item.Item pItem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemDOL itemDOL = new CORE.DOL.MSSQL.Item.ItemDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.Update(pItem);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item DeleteItem(Octavo.Gate.Nabu.CORE.Entities.Item.Item pItem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemDOL itemDOL = new CORE.DOL.MSSQL.Item.ItemDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.Delete(pItem);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item AssignItemOwner(int pItemID, int pOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemDOL itemDOL = new CORE.DOL.MSSQL.Item.ItemDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.Assign(pItemID, pOrganisationID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Item.Item RemoveItemOwner(int pItemID, int pOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemDOL itemDOL = new CORE.DOL.MSSQL.Item.ItemDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.Remove(pItemID, pOrganisationID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Outcome
         *********************************************************************/
        public ItemOutcome GetItemOutcome(int pItemOutcomeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemOutcomeDOL itemOutcomeDOL = new CORE.DOL.MSSQL.Item.ItemOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return itemOutcomeDOL.Get(pItemOutcomeID, pLanguageID);
            }
            else
                return null;
        }

        public ItemOutcome[] ListItemOutcomes(int pItemID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemOutcomeDOL itemOutcomeDOL = new CORE.DOL.MSSQL.Item.ItemOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return itemOutcomeDOL.List(pItemID, pLanguageID);
            }
            else
                return null;
        }

        public ItemOutcome InsertItemOutcome(ItemOutcome pItemOutcome, int pItemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemOutcomeDOL itemOutcomeDOL = new CORE.DOL.MSSQL.Item.ItemOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return itemOutcomeDOL.Insert(pItemOutcome, pItemID);
            }
            else
                return null;
        }

        public ItemOutcome UpdateItemOutcome(ItemOutcome pItemOutcome)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemOutcomeDOL itemOutcomeDOL = new CORE.DOL.MSSQL.Item.ItemOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return itemOutcomeDOL.Update(pItemOutcome);
            }
            else
                return null;
        }

        public ItemOutcome DeleteItemOutcome(ItemOutcome pItemOutcome)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemOutcomeDOL itemOutcomeDOL = new CORE.DOL.MSSQL.Item.ItemOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return itemOutcomeDOL.Delete(pItemOutcome);
            }
            else
                return null;
        }

        public ItemOutcome AssignItemOutcomeCompetency(int pItemOutcomeID, int pCompetencyStatementID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemOutcomeDOL itemOutcomeDOL = new CORE.DOL.MSSQL.Item.ItemOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return itemOutcomeDOL.Assign(pItemOutcomeID, pCompetencyStatementID);
            }
            else
                return null;
        }

        public ItemOutcome RemoveItemOutcomeCompetency(int pItemOutcomeID, int pCompetencyStatementID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemOutcomeDOL itemOutcomeDOL = new CORE.DOL.MSSQL.Item.ItemOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return itemOutcomeDOL.Remove(pItemOutcomeID, pCompetencyStatementID);
            }
            else
                return null;
        }
        /**********************************************************************
         * FeedbackDeclaration
         *********************************************************************/
        public FeedbackDeclaration GetFeedbackDeclaration(int pFeedbackDeclarationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.FeedbackDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.FeedbackDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pFeedbackDeclarationID);
            }
            else
                return null;
        }

        public FeedbackDeclaration[] ListFeedbackDeclarations()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.FeedbackDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.FeedbackDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public FeedbackDeclaration InsertFeedbackDeclaration(FeedbackDeclaration pFeedbackDeclaration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.FeedbackDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.FeedbackDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pFeedbackDeclaration);
            }
            else
                return null;
        }

        public FeedbackDeclaration UpdateFeedbackDeclaration(FeedbackDeclaration pFeedbackDeclaration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.FeedbackDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.FeedbackDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pFeedbackDeclaration);
            }
            else
                return null;
        }

        public FeedbackDeclaration DeleteFeedbackDeclaration(FeedbackDeclaration pFeedbackDeclaration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.FeedbackDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.FeedbackDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pFeedbackDeclaration);
            }
            else
                return null;
        }
        /**********************************************************************
         * OutputDeclaration
         *********************************************************************/
        public OutputDeclaration GetOutputDeclaration(int pOutputDeclarationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.OutputDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.OutputDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pOutputDeclarationID, pLanguageID);
            }
            else
                return null;
        }

        public OutputDeclaration GetOutputDeclarationByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.OutputDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.OutputDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public OutputDeclaration[] ListOutputDeclarations(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.OutputDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.OutputDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public OutputDeclaration InsertOutputDeclaration(OutputDeclaration pOutputDeclaration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.OutputDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.OutputDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pOutputDeclaration);
            }
            else
                return null;
        }

        public OutputDeclaration UpdateOutputDeclaration(OutputDeclaration pOutputDeclaration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.OutputDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.OutputDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pOutputDeclaration);
            }
            else
                return null;
        }

        public OutputDeclaration DeleteOutputDeclaration(OutputDeclaration pOutputDeclaration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.OutputDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.OutputDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pOutputDeclaration);
            }
            else
                return null;
        }
        /**********************************************************************
         * ResponseDeclaration
         *********************************************************************/
        public ResponseDeclaration GetResponseDeclaration(int pResponseDeclarationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ResponseDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.ResponseDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pResponseDeclarationID, pLanguageID);
            }
            else
                return null;
        }

        public ResponseDeclaration[] ListResponseDeclarations(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ResponseDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.ResponseDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ResponseDeclaration InsertResponseDeclaration(ResponseDeclaration pResponseDeclaration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ResponseDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.ResponseDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pResponseDeclaration);
            }
            else
                return null;
        }

        public ResponseDeclaration UpdateResponseDeclaration(ResponseDeclaration pResponseDeclaration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ResponseDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.ResponseDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pResponseDeclaration);
            }
            else
                return null;
        }

        public ResponseDeclaration DeleteResponseDeclaration(ResponseDeclaration pResponseDeclaration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ResponseDeclarationDOL DOL = new CORE.DOL.MSSQL.Item.ResponseDeclarationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pResponseDeclaration);
            }
            else
                return null;
        }
        /**********************************************************************
         * ResponseProcessing
         *********************************************************************/
        public ResponseProcessing GetResponseProcessing(int pResponseProcessingID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ResponseProcessingDOL DOL = new CORE.DOL.MSSQL.Item.ResponseProcessingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pResponseProcessingID, pLanguageID);
            }
            else
                return null;
        }

        public ResponseProcessing GetResponseProcessingByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ResponseProcessingDOL DOL = new CORE.DOL.MSSQL.Item.ResponseProcessingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ResponseProcessing[] ListResponseProcessings(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ResponseProcessingDOL DOL = new CORE.DOL.MSSQL.Item.ResponseProcessingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ResponseProcessing InsertResponseProcessing(ResponseProcessing pResponseProcessing)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ResponseProcessingDOL DOL = new CORE.DOL.MSSQL.Item.ResponseProcessingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pResponseProcessing);
            }
            else
                return null;
        }

        public ResponseProcessing UpdateResponseProcessing(ResponseProcessing pResponseProcessing)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ResponseProcessingDOL DOL = new CORE.DOL.MSSQL.Item.ResponseProcessingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pResponseProcessing);
            }
            else
                return null;
        }

        public ResponseProcessing DeleteResponseProcessing(ResponseProcessing pResponseProcessing)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ResponseProcessingDOL DOL = new CORE.DOL.MSSQL.Item.ResponseProcessingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pResponseProcessing);
            }
            else
                return null;
        }
        /**********************************************************************
         * Scale
         *********************************************************************/
        public Scale GetScale(int pScaleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ScaleDOL viewDOL = new CORE.DOL.MSSQL.Item.ScaleDOL(base.ConnectionString, base.ErrorLogFile);
                return viewDOL.Get(pScaleID, pLanguageID);
            }
            else
                return null;
        }

        public Scale GetScaleByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ScaleDOL viewDOL = new CORE.DOL.MSSQL.Item.ScaleDOL(base.ConnectionString, base.ErrorLogFile);
                return viewDOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }
       
        public Scale[] ListScales(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ScaleDOL viewDOL = new CORE.DOL.MSSQL.Item.ScaleDOL(base.ConnectionString, base.ErrorLogFile);
                return viewDOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Scale InsertScale(Scale pScale)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ScaleDOL viewDOL = new CORE.DOL.MSSQL.Item.ScaleDOL(base.ConnectionString, base.ErrorLogFile);
                return viewDOL.Insert(pScale);
            }
            else
                return null;
        }

        public Scale UpdateScale(Scale pScale)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ScaleDOL viewDOL = new CORE.DOL.MSSQL.Item.ScaleDOL(base.ConnectionString, base.ErrorLogFile);
                return viewDOL.Update(pScale);
            }
            else
                return null;
        }

        public Scale DeleteScale(Scale pScale)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ScaleDOL viewDOL = new CORE.DOL.MSSQL.Item.ScaleDOL(base.ConnectionString, base.ErrorLogFile);
                return viewDOL.Delete(pScale);
            }
            else
                return null;
        }

        /**********************************************************************
         * Stylesheet
         *********************************************************************/
        public Stylesheet GetStylesheet(int pStylesheetID)
        {
            Stylesheet stylesheet = null;
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.StylesheetDOL stylesheetDOL = new CORE.DOL.MSSQL.Item.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                stylesheet = stylesheetDOL.Get(pStylesheetID);
                if (stylesheet.ErrorsDetected == false)
                {
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL contentDOL = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content tmpContent = contentDOL.Get((int)stylesheet.ContentID);
                    if (tmpContent.ErrorsDetected == false)
                    {
                        stylesheet.Description = tmpContent.Description;
                        stylesheet.Name = tmpContent.Name;
                        stylesheet.UseVersionControls = tmpContent.UseVersionControls;

                        Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL structuredContentDOL = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                        Octavo.Gate.Nabu.CORE.Entities.Content.StructuredContent[] structuredContents = structuredContentDOL.List((int)stylesheet.ContentID, 1);  // Assume Stylesheets are always in english
                        if (structuredContents[0].ErrorsDetected == false)
                        {
                            Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentBodyTypeDOL contentBodyTypeDOL = new CORE.DOL.MSSQL.Content.ContentBodyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                            List<Entities.Content.ContentVersion> contentVersions = new List<Entities.Content.ContentVersion>();
                            foreach (Octavo.Gate.Nabu.CORE.Entities.Content.StructuredContent structuredContent in structuredContents)
                            {
                                structuredContent.BodyType = contentBodyTypeDOL.Get((int)structuredContent.BodyType.ContentBodyTypeID, 1); // Assume Stylesheets are always in english
                                contentVersions.Add(structuredContent);
                            }
                            stylesheet.ContentVersions = contentVersions.ToArray();
                        }

                        Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL contentTypeDOL = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                        stylesheet.ContentClassifications = contentTypeDOL.ListForContent((int)stylesheet.ContentID, 1); // Assume Stylesheets are always in english
                    }
                }
            }
            return stylesheet;
        }

        public Stylesheet GetStylesheetByName(string pStylesheetName)
        {
            Stylesheet stylesheet = null;
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.StylesheetDOL stylesheetDOL = new CORE.DOL.MSSQL.Item.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                stylesheet = stylesheetDOL.GetByName(pStylesheetName);
                if (stylesheet.ErrorsDetected == false)
                {
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL contentDOL = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content tmpContent = contentDOL.Get((int)stylesheet.ContentID);
                    if (tmpContent.ErrorsDetected == false)
                    {
                        stylesheet.Description = tmpContent.Description;
                        stylesheet.Name = tmpContent.Name;
                        stylesheet.UseVersionControls = tmpContent.UseVersionControls;

                        Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL structuredContentDOL = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                        Octavo.Gate.Nabu.CORE.Entities.Content.StructuredContent[] structuredContents = structuredContentDOL.List((int)stylesheet.ContentID, 1);  // Assume Stylesheets are always in english
                        if (structuredContents[0].ErrorsDetected == false)
                        {
                            Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentBodyTypeDOL contentBodyTypeDOL = new CORE.DOL.MSSQL.Content.ContentBodyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                            List<Entities.Content.ContentVersion> contentVersions = new List<Entities.Content.ContentVersion>();
                            foreach (Octavo.Gate.Nabu.CORE.Entities.Content.StructuredContent structuredContent in structuredContents)
                            {
                                structuredContent.BodyType = contentBodyTypeDOL.Get((int)structuredContent.BodyType.ContentBodyTypeID, 1); // Assume Stylesheets are always in english
                                contentVersions.Add(structuredContent);
                            }
                            stylesheet.ContentVersions = contentVersions.ToArray();
                        }

                        Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL contentTypeDOL = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                        stylesheet.ContentClassifications = contentTypeDOL.ListForContent((int)stylesheet.ContentID, 1); // Assume Stylesheets are always in english
                    }
                }
            }
            return stylesheet;
        }

        public Stylesheet[] ListStylesheets(int pOwnerOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.StylesheetDOL stylesheetDOL = new CORE.DOL.MSSQL.Item.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                Stylesheet[] tmpStylesheets = stylesheetDOL.List(pOwnerOrganisationID);
                List<Stylesheet> listStylesheet = new List<Stylesheet>();
                foreach (Stylesheet stylesheet in tmpStylesheets)
                {
                    listStylesheet.Add(GetStylesheet((int)stylesheet.ContentID));
                }
                return listStylesheet.ToArray();
            }
            else
                return null;
        }

        public Stylesheet InsertStylesheet(Stylesheet pStylesheet)
        {
            Stylesheet stylesheet = null;
            if (base.DBType == DatabaseType.MSSQL)
            {
                // Create the content
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL contentDOL = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                Entities.Content.Content tmpContent = contentDOL.Insert(pStylesheet, null);
                if (tmpContent.ErrorsDetected == false)
                {
                    stylesheet = new Stylesheet(tmpContent.ContentID);
                    stylesheet.Name = tmpContent.Name;
                    stylesheet.Description = tmpContent.Description;
                    stylesheet.UseVersionControls = tmpContent.UseVersionControls;

                    // assign the content type(s)
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL contentTypeDOL = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                    foreach (Entities.Content.ContentType contentType in pStylesheet.ContentClassifications)
                    {
                        contentTypeDOL.AssignContentType((int)stylesheet.ContentID, (int)contentType.ContentTypeID);
                    }

                    // create the content version/structured content
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL structuredContentDOL = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                    foreach (Entities.Content.ContentVersion contentVersion in pStylesheet.ContentVersions)
                    {
                        if (contentVersion.GetType() == typeof(Entities.Content.StructuredContent))
                        {
                            Entities.Content.StructuredContent tmpStructuredContent = contentVersion as Entities.Content.StructuredContent;
                            structuredContentDOL.Insert(tmpStructuredContent, (int)stylesheet.ContentID);
                        }
                    }
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.StylesheetDOL stylesheetDOL = new CORE.DOL.MSSQL.Item.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                    stylesheet = stylesheetDOL.Insert(stylesheet);
                }
            }
            return stylesheet;
        }

        public Stylesheet UpdateStylesheet(Stylesheet pStylesheet)
        {
            Stylesheet stylesheet = null;
            if (base.DBType == DatabaseType.MSSQL)
            {
                // Create the content
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL contentDOL = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                Entities.Content.Content tmpContent = contentDOL.Update(pStylesheet, null);
                if (tmpContent.ErrorsDetected == false)
                {
                    stylesheet = new Stylesheet(tmpContent.ContentID);
                    stylesheet.Name = tmpContent.Name;
                    stylesheet.Description = tmpContent.Description;
                    stylesheet.UseVersionControls = tmpContent.UseVersionControls;

                    // create the content version/structured content
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL structuredContentDOL = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                    foreach (Entities.Content.ContentVersion contentVersion in pStylesheet.ContentVersions)
                    {
                        if (contentVersion.GetType() == typeof(Entities.Content.StructuredContent))
                        {
                            Entities.Content.StructuredContent tmpStructuredContent = contentVersion as Entities.Content.StructuredContent;
                            structuredContentDOL.Update(tmpStructuredContent, (int)stylesheet.ContentID);
                        }
                    }
                }
            }
            return stylesheet;
        }

        public Stylesheet DeleteStylesheet(Stylesheet pStylesheet)
        {
            Stylesheet stylesheet = null;
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.StylesheetDOL stylesheetDOL = new CORE.DOL.MSSQL.Item.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                stylesheet = stylesheetDOL.Delete(pStylesheet);  // delete the item body

                // delete the structured content/versions
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL structuredContentDOL = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                foreach (Entities.Content.ContentVersion contentVersion in pStylesheet.ContentVersions)
                {
                    if (contentVersion.GetType() == typeof(Entities.Content.StructuredContent))
                    {
                        Entities.Content.StructuredContent tmpStructuredContent = contentVersion as Entities.Content.StructuredContent;
                        structuredContentDOL.Delete(tmpStructuredContent);
                    }
                }

                // remove the content classifications/types
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL contentTypeDOL = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                foreach (Entities.Content.ContentType contentType in pStylesheet.ContentClassifications)
                {
                    contentTypeDOL.DeAssignContentType((int)pStylesheet.ContentID, (int)contentType.ContentTypeID);
                }

                // delete the underlying content
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL contentDOL = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                contentDOL.Delete(pStylesheet);
            }
            return stylesheet;
        }

        public Stylesheet AssignStylesheetOwner(int pStylesheetID, int pOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.StylesheetDOL itemDOL = new CORE.DOL.MSSQL.Item.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.Assign(pStylesheetID, pOrganisationID);
            }
            else
                return null;
        }

        public Stylesheet RemoveStylesheetOwner(int pStylesheetID, int pOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.StylesheetDOL itemDOL = new CORE.DOL.MSSQL.Item.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return itemDOL.Remove(pStylesheetID, pOrganisationID);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * View
         *********************************************************************/
        public View GetView(int pViewID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ViewDOL viewDOL = new CORE.DOL.MSSQL.Item.ViewDOL(base.ConnectionString, base.ErrorLogFile);
                return viewDOL.Get(pViewID, pLanguageID);
            }
            else
                return null;
        }

        public View GetViewByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ViewDOL viewDOL = new CORE.DOL.MSSQL.Item.ViewDOL(base.ConnectionString, base.ErrorLogFile);
                return viewDOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public View[] ListViews(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ViewDOL viewDOL = new CORE.DOL.MSSQL.Item.ViewDOL(base.ConnectionString, base.ErrorLogFile);
                return viewDOL.List(pLanguageID);
            }
            else
                return null;
        }

        public View InsertView(View pView)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ViewDOL viewDOL = new CORE.DOL.MSSQL.Item.ViewDOL(base.ConnectionString, base.ErrorLogFile);
                return viewDOL.Insert(pView);
            }
            else
                return null;
        }

        public View UpdateView(View pView)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ViewDOL viewDOL = new CORE.DOL.MSSQL.Item.ViewDOL(base.ConnectionString, base.ErrorLogFile);
                return viewDOL.Update(pView);
            }
            else
                return null;
        }

        public View DeleteView(View pView)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ViewDOL viewDOL = new CORE.DOL.MSSQL.Item.ViewDOL(base.ConnectionString, base.ErrorLogFile);
                return viewDOL.Delete(pView);
            }
            else
                return null;
        }
    }
}
