using Octavo.Gate.Nabu.CORE.Entities.Content;
using Octavo.Gate.Nabu.CORE.Entities;
using System;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class ContentAbstraction : BaseAbstraction
    {
        public ContentAbstraction() : base()
        {
        }

        public ContentAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Article
         *********************************************************************/
        public Article GetArticle(int pArticleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ArticleDOL dol = new CORE.DOL.MSSQL.Content.ArticleDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Get(pArticleID, pLanguageID);
            }
            else
                return null;
        }

        public Article[] ListArticles(int pAuthoredByPartyID,int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ArticleDOL dol = new CORE.DOL.MSSQL.Content.ArticleDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.List(pAuthoredByPartyID,pLanguageID);
            }
            else
                return null;
        }

        public Article InsertArticle(Article pArticle)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ArticleDOL dol = new CORE.DOL.MSSQL.Content.ArticleDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Insert(pArticle);
            }
            else
                return null;
        }

        public Article UpdateArticle(Article pArticle, int? pOptionalParentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ArticleDOL dol = new CORE.DOL.MSSQL.Content.ArticleDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pArticle, pOptionalParentID);
            }
            else
                return null;
        }

        public Article DeleteArticle(Article pArticle)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ArticleDOL dol = new CORE.DOL.MSSQL.Content.ArticleDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Delete(pArticle);
            }
            else
                return null;
        }

        /**********************************************************************
         * Content Body Type
         *********************************************************************/
        public ContentBodyType GetContentBodyType(int pContentBodyTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentBodyTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentBodyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Get(pContentBodyTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ContentBodyType GetContentBodyTypeByAlias(string pContentBodyTypeAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentBodyTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentBodyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetByAlias(pContentBodyTypeAlias, pLanguageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.Content.ContentBodyTypeDOL dol = new DOL.MSAccess.Content.ContentBodyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetByAlias(pContentBodyTypeAlias, pLanguageID);
            }*/
            else
                return null;
        }

        public ContentBodyType[] ListContentBodyTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentBodyTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentBodyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.List(pLanguageID);
            }
            else
                return null;
        }

        public ContentBodyType InsertContentBodyType(ContentBodyType pContentBodyType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentBodyTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentBodyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Insert(pContentBodyType);
            }
            else
                return null;
        }

        public ContentBodyType UpdateContentBodyType(ContentBodyType pContentBodyType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentBodyTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentBodyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pContentBodyType);
            }
            else
                return null;
        }

        public ContentBodyType DeleteContentBodyType(ContentBodyType pContentBodyType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentBodyTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentBodyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Delete(pContentBodyType);
            }
            else
                return null;
        }

        /**********************************************************************
         * Content 
         *********************************************************************/
        public Content GetContent(int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Get(pContentID);
            }
            else
                return null;
        }

        public Content GetContentByRetrievalIdentifier(Guid pUniqueRetrievalID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetByRetrievalIdentifier(pUniqueRetrievalID);
            }
            else
                return null;
        }

        public Content GetContentByTagID(int pTagID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetByTagID(pTagID);
            }
            else
                return null;
        }

        public Content GetContentByTagPhrase(string pPhrase, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetByTagPhrase(pPhrase, pLanguageID);
            }
            else
                return null;
        }

        public Content[] ListContent()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.List();
            }
            else
                return null;
        }

        public Content[] ListContentForUnit(int pUnitID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForUnit(pUnitID);
            }
            else
                return null;
        }

        public Content[] ListContentForModule(int pModuleID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForModule(pModuleID);
            }
            else
                return null;
        }

        public Content[] ListContentForSpecification(int pSpecificationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForSpecification(pSpecificationID);
            }
            else
                return null;
        }

        public Content[] ListChildContent(int pParentContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListChildren(pParentContentID);
            }
            else
                return null;
        }

        public Content[] ListContentForParty(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForParty(pPartyID);
            }
            else
                return null;
        }

        public Content[] ListContentForPartyAndType(int pPartyID, string pContentTypeAlias, int pLanguage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForPartyAndContentTypeAlias(pPartyID, pContentTypeAlias, pLanguage);
            }
            else
                return null;
        }

        public Content[] ListContentForProgrammeAndType(int pProgrammeID, string pContentTypeAlias, int pLanguage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForProgrammeAndContentTypeAlias(pProgrammeID, pContentTypeAlias, pLanguage);
            }
            else
                return null;
        }

        public Content[] ListContentForProjectAndType(int pProjectID, string pContentTypeAlias, int pLanguage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForProjectAndContentTypeAlias(pProjectID, pContentTypeAlias, pLanguage);
            }
            else
                return null;
        }

        public Content[] ListContentForPart(int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForPart(pPartID);
            }
            else
                return null;
        }

        public Content[] ListContentForPartAndType(int pPartID, string pContentTypeAlias, int pLanguage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForPartAndContentTypeAlias(pPartID, pContentTypeAlias, pLanguage);
            }
            else
                return null;
        }

        public Content[] ListContentForDefect(int pDefectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForDefect(pDefectID);
            }
            else
                return null;
        }

        public Content[] ListContentForIteration(int pIterationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForIteration(pIterationID);
            }
            else
                return null;
        }

        public Content[] ListContentForRequirement(int pRequirementID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForRequirement(pRequirementID);
            }
            else
                return null;
        }

        public Content[] ListContentForIncident(int pIncidentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForIncident(pIncidentID);
            }
            else
                return null;
        }

        public Content[] ListContentForProblem(int pProblemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForProblem(pProblemID);
            }
            else
                return null;
        }

        public Content[] ListContentForChange(int pChangeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForChange(pChangeID);
            }
            else
                return null;
        }

        public Content InsertContent(Content pContent, int? pParentContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Insert(pContent, pParentContentID);
            }
            /*if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.Content.ContentDOL dol = new DOL.MSAccess.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Insert(pContent, pParentContentID);
            }*/
            else
                return null;
        }

        public Content UpdateContent(Content pContent, int? pParentContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pContent, pParentContentID);
            }
            else
                return null;
        }

        public Content UpdateContent(Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pContent);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.Content.ContentDOL dol = new DOL.MSAccess.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pContent);
            }*/
            else
                return null;
        }

        public Content DeleteContent(Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Delete(pContent);
            }
            else
                return null;
        }

        public Content DeleteContentComplete(Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL dol = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.DeleteComplete(pContent);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * Content Type
         *********************************************************************/
        public ContentType GetContentType(int pContentTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Get(pContentTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ContentType GetContentTypeByAlias(string pContentTypeAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetByAlias(pContentTypeAlias, pLanguageID);
            }
            else
                return null;
        }

        public ContentType[] ListContentTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.List(pLanguageID);
            }
            else
                return null;
        }

        public ContentType[] ListContentTypesForContent(int pContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForContent(pContentID,pLanguageID);
            }
            else
                return null;
        }

        public ContentType[] ListContentTypesForPartType(int pPartTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForPartType(pPartTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ContentType InsertContentType(ContentType pContentType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Insert(pContentType);
            }
            else
                return null;
        }

        public ContentType UpdateContentType(ContentType pContentType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pContentType);
            }
            else
                return null;
        }

        public ContentType DeleteContentType(ContentType pContentType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Delete(pContentType);
            }
            else
                return null;
        }

        public ContentType AssignContentType(int pContentID, int pContentTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.AssignContentType(pContentID, pContentTypeID);
            }
            else
                return null;
        }

        public ContentType DeAssignContentType(int pContentID, int pContentTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL dol = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.DeAssignContentType(pContentID, pContentTypeID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Content Version
         *********************************************************************/
        public ContentVersion GetCurrentVersion(int pContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentVersionDOL dol = new CORE.DOL.MSSQL.Content.ContentVersionDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Get(pContentID, pLanguageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.Content.ContentVersionDOL dol = new DOL.MSAccess.Content.ContentVersionDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Get(pContentID, pLanguageID);
            }*/
            else
                return null;
        }

        /**********************************************************************
         * Managed Content 
         *********************************************************************/
        public ManagedContent GetManagedContent(int pManagedContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ManagedContentDOL dol = new CORE.DOL.MSSQL.Content.ManagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Get(pManagedContentID, pLanguageID);
            }
            else
                return null;
        }

        public ManagedContent GetLatestManagedContent(int pContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ManagedContentDOL dol = new CORE.DOL.MSSQL.Content.ManagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetLatest(pContentID, pLanguageID);
            }
            else
                return null;
        }

        public BaseLong GetSpaceUsed(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ManagedContentDOL dol = new CORE.DOL.MSSQL.Content.ManagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetSpaceUsed(pPartyID);
            }
            else
                return null;
        }

        public ManagedContent[] ListManagedContent(int pContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ManagedContentDOL dol = new CORE.DOL.MSSQL.Content.ManagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.List(pContentID, pLanguageID);
            }
            else
                return null;
        }

        public ManagedContent InsertManagedContent(ManagedContent pManagedContent, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ManagedContentDOL dol = new CORE.DOL.MSSQL.Content.ManagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Insert(pManagedContent, pContentID);
            }
            else
                return null;
        }

        public ManagedContent UpdateManagedContent(ManagedContent pManagedContent, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ManagedContentDOL dol = new CORE.DOL.MSSQL.Content.ManagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pManagedContent,pContentID);
            }
            else
                return null;
        }

        public ManagedContent DeleteManagedContent(ManagedContent pManagedContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ManagedContentDOL dol = new CORE.DOL.MSSQL.Content.ManagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Delete(pManagedContent);
            }
            else
                return null;
        }

        /**********************************************************************
         * Structured Content 
         *********************************************************************/
        public StructuredContent GetStructuredContent(int pStructuredContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL dol = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Get(pStructuredContentID,pLanguageID);
            }
            else
                return null;
        }

        public StructuredContent GetLatestStructuredContent(int pContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL dol = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetLatest(pContentID, pLanguageID);
            }
            else
                return null;
        }

        public StructuredContent[] ListStructuredContent(int pContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL dol = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.List(pContentID, pLanguageID);
            }
            else
                return null;
        }

        public StructuredContent InsertStructuredContent(StructuredContent pStructuredContent, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL dol = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Insert(pStructuredContent, pContentID);
            }
            else
                return null;
        }

        public StructuredContent UpdateStructuredContent(StructuredContent pStructuredContent, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL dol = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pStructuredContent, pContentID);
            }
            else
                return null;
        }

        public StructuredContent DeleteStructuredContent(StructuredContent pStructuredContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.StructuredContentDOL dol = new CORE.DOL.MSSQL.Content.StructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Delete(pStructuredContent);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * Tag
         *********************************************************************/
        public Tag GetTag(int pTagID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.TagDOL dol = new CORE.DOL.MSSQL.Content.TagDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Get(pTagID);
            }
            else
                return null;
        }

        public Tag[] GetTagCloud(int pLanguageID, int pLimitEntries)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.TagDOL dol = new CORE.DOL.MSSQL.Content.TagDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetTagCloud(pLanguageID, pLimitEntries);
            }
            else
                return null;
        }

        public Tag[] ListTagsForContent(int pContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.TagDOL dol = new CORE.DOL.MSSQL.Content.TagDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.List(pContentID, pLanguageID);
            }
            else
                return null;
        }

        public Tag[] ListTags(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.TagDOL dol = new CORE.DOL.MSSQL.Content.TagDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.List(pLanguageID);
            }
            else
                return null;
        }

        public Tag InsertTag(Tag pTag)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.TagDOL dol = new CORE.DOL.MSSQL.Content.TagDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Insert(pTag);
            }
            else
                return null;
        }

        public Tag InsertContentTag(int pContentID, Tag pTag)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.TagDOL dol = new CORE.DOL.MSSQL.Content.TagDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ContentTagInsert(pContentID, pTag);
            }
            else
                return null;
        }

        public Tag UpdateTag(Tag pTag)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.TagDOL dol = new CORE.DOL.MSSQL.Content.TagDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pTag);
            }
            else
                return null;
        }

        public Tag DeleteTag(Tag pTag)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.TagDOL dol = new CORE.DOL.MSSQL.Content.TagDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Delete(pTag);
            }
            else
                return null;
        }

        public Tag DeleteContentTag(int pContentID, Tag pTag)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.TagDOL dol = new CORE.DOL.MSSQL.Content.TagDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ContentTagDelete(pContentID, pTag);
            }
            else
                return null;
        }

        /**********************************************************************
         * Unmanaged Content
         *********************************************************************/
        public UnmanagedContent GetUnmanagedContent(int pUnmanagedContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.UnmanagedContentDOL dol = new CORE.DOL.MSSQL.Content.UnmanagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Get(pUnmanagedContentID, pLanguageID);
            }
            else
                return null;
        }

        public UnmanagedContent GetLatestUnmanagedContent(int pContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.UnmanagedContentDOL dol = new CORE.DOL.MSSQL.Content.UnmanagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetLatest(pContentID, pLanguageID);
            }
            else
                return null;
        }

        public UnmanagedContent[] ListUnmanagedContent(int pContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.UnmanagedContentDOL dol = new CORE.DOL.MSSQL.Content.UnmanagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.List(pContentID, pLanguageID);
            }
            else
                return null;
        }

        public UnmanagedContent InsertUnmanagedContent(UnmanagedContent pUnmanagedContent, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.UnmanagedContentDOL dol = new CORE.DOL.MSSQL.Content.UnmanagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Insert(pUnmanagedContent, pContentID);
            }
            else
                return null;
        }

        public UnmanagedContent UpdateUnmanagedContent(UnmanagedContent pUnmanagedContent, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.UnmanagedContentDOL dol = new CORE.DOL.MSSQL.Content.UnmanagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pUnmanagedContent, pContentID);
            }
            else
                return null;
        }

        public UnmanagedContent DeleteUnmanagedContent(UnmanagedContent pUnmanagedContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.UnmanagedContentDOL dol = new CORE.DOL.MSSQL.Content.UnmanagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Delete(pUnmanagedContent);
            }
            else
                return null;
        }
        /**********************************************************************
         * Unstructured Content
         *********************************************************************/
        public UnstructuredContent GetUnstructuredContent(int pUnstructuredContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.UnstructuredContentDOL dol = new CORE.DOL.MSSQL.Content.UnstructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Get(pUnstructuredContentID, pLanguageID);
            }
            else
                return null;
        }

        public UnstructuredContent GetLatestUnstructuredContent(int pContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.UnstructuredContentDOL dol = new CORE.DOL.MSSQL.Content.UnstructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetLatest(pContentID, pLanguageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.Content.UnstructuredContentDOL dol = new DOL.MSAccess.Content.UnstructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetLatest(pContentID, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.Content.UnstructuredContentDOL dol = new DOL.MySQL.Content.UnstructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetLatest(pContentID, pLanguageID);
            }*/
            else
                return null;
        }

        public UnstructuredContent[] ListUnstructuredContent(int pContentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.UnstructuredContentDOL dol = new CORE.DOL.MSSQL.Content.UnstructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.List(pContentID, pLanguageID);
            }
            else
                return null;
        }

        public UnstructuredContent InsertUnstructuredContent(UnstructuredContent pUnstructuredContent, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.UnstructuredContentDOL dol = new CORE.DOL.MSSQL.Content.UnstructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Insert(pUnstructuredContent, pContentID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.Content.UnstructuredContentDOL dol = new DOL.MSAccess.Content.UnstructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Insert(pUnstructuredContent, pContentID);
            }*/
            else
                return null;
        }

        public UnstructuredContent UpdateUnstructuredContent(UnstructuredContent pUnstructuredContent, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.UnstructuredContentDOL dol = new CORE.DOL.MSSQL.Content.UnstructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pUnstructuredContent, pContentID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.Content.UnstructuredContentDOL dol = new DOL.MSAccess.Content.UnstructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pUnstructuredContent, pContentID);
            }*/
            else
                return null;
        }

        public UnstructuredContent DeleteUnstructuredContent(UnstructuredContent pUnstructuredContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.UnstructuredContentDOL dol = new CORE.DOL.MSSQL.Content.UnstructuredContentDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Delete(pUnstructuredContent);
            }
            else
                return null;
        }
    }
}
