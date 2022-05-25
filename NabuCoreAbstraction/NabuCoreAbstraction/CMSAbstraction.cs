using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.CMS;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class CMSAbstraction : BaseAbstraction
    {
        public CMSAbstraction() : base()
        {
        }

        public CMSAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * JavaScript
         *********************************************************************/
        public JavaScript GetJavaScript(int pJavaScriptID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.JavaScriptDOL DOL = new CORE.DOL.MSSQL.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pJavaScriptID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.JavaScriptDOL DOL = new DOL.MSAccess.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pJavaScriptID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public JavaScript[] ListJavaScripts(int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.JavaScriptDOL DOL = new CORE.DOL.MSSQL.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.JavaScriptDOL DOL = new DOL.MSAccess.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.CMS.JavaScriptDOL DOL = new DOL.MySQL.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID);
            }*/
            else
                return null;
        }

        public JavaScript InsertJavaScript(JavaScript pJavaScript)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.JavaScriptDOL DOL = new CORE.DOL.MSSQL.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pJavaScript);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.JavaScriptDOL DOL = new DOL.MSAccess.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pJavaScript);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public JavaScript AssignJavaScriptToPage(JavaScript pJavaScript, int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.JavaScriptDOL DOL = new CORE.DOL.MSSQL.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignToPage(pJavaScript, pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.JavaScriptDOL DOL = new DOL.MSAccess.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignToPage(pJavaScript, pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public JavaScript RemoveJavaScriptFromPage(JavaScript pJavaScript, int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.JavaScriptDOL DOL = new CORE.DOL.MSSQL.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromPage(pJavaScript, pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.JavaScriptDOL DOL = new DOL.MSAccess.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromPage(pJavaScript, pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public JavaScript DeleteJavaScript(JavaScript pJavaScript)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.JavaScriptDOL DOL = new CORE.DOL.MSSQL.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pJavaScript);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.JavaScriptDOL DOL = new DOL.MSAccess.CMS.JavaScriptDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pJavaScript);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        /**********************************************************************
         * MetaTag
         *********************************************************************/
        public MetaTag GetMetaTag(int pMetaTagID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.MetaTagDOL DOL = new CORE.DOL.MSSQL.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pMetaTagID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.MetaTagDOL DOL = new DOL.MSAccess.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pMetaTagID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public MetaTag[] ListMetaTags(int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.MetaTagDOL DOL = new CORE.DOL.MSSQL.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.MetaTagDOL DOL = new DOL.MSAccess.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.CMS.MetaTagDOL DOL = new DOL.MySQL.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID);
            }*/
            else
                return null;
        }

        public MetaTag InsertMetaTag(MetaTag pMetaTag)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.MetaTagDOL DOL = new CORE.DOL.MSSQL.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pMetaTag);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.MetaTagDOL DOL = new DOL.MSAccess.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pMetaTag);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public MetaTag AssignMetaTagToPage(MetaTag pMetaTag, int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.MetaTagDOL DOL = new CORE.DOL.MSSQL.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignToPage(pMetaTag, pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.MetaTagDOL DOL = new DOL.MSAccess.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignToPage(pMetaTag, pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public MetaTag RemoveMetaTagFromPage(MetaTag pMetaTag, int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.MetaTagDOL DOL = new CORE.DOL.MSSQL.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromPage(pMetaTag, pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.MetaTagDOL DOL = new DOL.MSAccess.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromPage(pMetaTag, pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public MetaTag DeleteMetaTag(MetaTag pMetaTag)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.MetaTagDOL DOL = new CORE.DOL.MSSQL.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pMetaTag);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.MetaTagDOL DOL = new DOL.MSAccess.CMS.MetaTagDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pMetaTag);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        /**********************************************************************
         * Page
         *********************************************************************/
        public Page GetPage(int pSiteID, int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageDOL DOL = new CORE.DOL.MSSQL.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSiteID, pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageDOL DOL = new DOL.MSAccess.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSiteID, pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.CMS.PageDOL DOL = new DOL.MySQL.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSiteID, pPageID);
            }*/
            else
                return null;
        }

        public Page GetPageByAlias(int pSiteID, string pAlias)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageDOL DOL = new CORE.DOL.MSSQL.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pSiteID, pAlias);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageDOL DOL = new DOL.MSAccess.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pSiteID, pAlias);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.CMS.PageDOL DOL = new DOL.MySQL.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pSiteID, pAlias);
            }*/
            else
                return null;
        }

        public Page GetLoggedOutHomePage(int pSiteID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageDOL DOL = new CORE.DOL.MSSQL.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetLoggedOutHomePage(pSiteID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageDOL DOL = new DOL.MSAccess.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetLoggedOutHomePage(pSiteID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.CMS.PageDOL DOL = new DOL.MySQL.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetLoggedOutHomePage(pSiteID);
            }*/
            else
                return null;
        }

        public Page GetLoggedInHomePage(int pSiteID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageDOL DOL = new CORE.DOL.MSSQL.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetLoggedInHomePage(pSiteID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageDOL DOL = new DOL.MSAccess.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetLoggedInHomePage(pSiteID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.CMS.PageDOL DOL = new DOL.MySQL.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetLoggedInHomePage(pSiteID);
            }*/
            else
                return null;
        }

        public Page[] ListPages(int pSiteID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageDOL DOL = new CORE.DOL.MSSQL.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pSiteID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageDOL DOL = new DOL.MSAccess.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pSiteID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public Page InsertPage(Page pPage, int pSiteID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageDOL DOL = new CORE.DOL.MSSQL.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPage, pSiteID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageDOL DOL = new DOL.MSAccess.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPage, pSiteID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public Page UpdatePage(Page pPage, int pSiteID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageDOL DOL = new CORE.DOL.MSSQL.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPage, pSiteID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageDOL DOL = new DOL.MSAccess.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPage, pSiteID);
            }*/
            else
                return null;
        }

        public Page DeletePage(Page pPage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageDOL DOL = new CORE.DOL.MSSQL.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPage);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageDOL DOL = new DOL.MSAccess.CMS.PageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPage);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        /**********************************************************************
         * PageContent
         *********************************************************************/
        public BaseInteger PageComponentGetMaxDisplaySequenceOnPage(int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageComponentDOL DOL = new CORE.DOL.MSSQL.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetMaxDisplaySequenceOnPage(pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageComponentDOL DOL = new DOL.MSAccess.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetMaxDisplaySequenceOnPage(pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageComponent GetPageComponent(int pPageComponentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageComponentDOL DOL = new CORE.DOL.MSSQL.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPageComponentID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageComponentDOL DOL = new DOL.MSAccess.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPageComponentID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageComponent[] ListPageComponents(int pPageID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageComponentDOL DOL = new CORE.DOL.MSSQL.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID, pLanguageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageComponentDOL DOL = new DOL.MSAccess.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.CMS.PageComponentDOL DOL = new DOL.MySQL.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID, pLanguageID);
            }*/
            else
                return null;
        }

        public PageComponent InsertPageComponent(PageComponent pPageComponent, int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageComponentDOL DOL = new CORE.DOL.MSSQL.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPageComponent, pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageComponentDOL DOL = new DOL.MSAccess.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPageComponent, pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageComponent UpdatePageComponent(PageComponent pPageComponent, int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageComponentDOL DOL = new CORE.DOL.MSSQL.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPageComponent, pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageComponentDOL DOL = new DOL.MSAccess.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPageComponent, pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageComponent DeletePageComponent(PageComponent pPageComponent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageComponentDOL DOL = new CORE.DOL.MSSQL.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPageComponent);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageComponentDOL DOL = new DOL.MSAccess.CMS.PageComponentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPageComponent);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        /**********************************************************************
         * PageFooter
         *********************************************************************/
        public PageFooter GetPageFooter(int pPageFooterID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageFooterDOL DOL = new CORE.DOL.MSSQL.CMS.PageFooterDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPageFooterID, pLanguageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageFooterDOL DOL = new DOL.MSAccess.CMS.PageFooterDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPageFooterID, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.CMS.PageFooterDOL DOL = new DOL.MySQL.CMS.PageFooterDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPageFooterID, pLanguageID);
            }*/
            else
                return null;
        }

        public PageFooter[] ListPageFooters(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageFooterDOL DOL = new CORE.DOL.MSSQL.CMS.PageFooterDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageFooterDOL DOL = new DOL.MSAccess.CMS.PageFooterDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageFooter InsertPageFooter(PageFooter pPageFooter, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageFooterDOL DOL = new CORE.DOL.MSSQL.CMS.PageFooterDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPageFooter, pLanguageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageFooterDOL DOL = new DOL.MSAccess.CMS.PageFooterDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPageFooter, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageFooter DeletePageFooter(PageFooter pPageFooter, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageFooterDOL DOL = new CORE.DOL.MSSQL.CMS.PageFooterDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPageFooter, pLanguageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageFooterDOL DOL = new DOL.MSAccess.CMS.PageFooterDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPageFooter, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        /**********************************************************************
         * PageHeader
         *********************************************************************/
        public PageHeader GetPageHeader(int pPageHeaderID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageHeaderDOL DOL = new CORE.DOL.MSSQL.CMS.PageHeaderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPageHeaderID, pLanguageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageHeaderDOL DOL = new DOL.MSAccess.CMS.PageHeaderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPageHeaderID, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.CMS.PageHeaderDOL DOL = new DOL.MySQL.CMS.PageHeaderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPageHeaderID, pLanguageID);
            }*/
            else
                return null;
        }

        public PageHeader[] ListPageHeaders(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageHeaderDOL DOL = new CORE.DOL.MSSQL.CMS.PageHeaderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageHeaderDOL DOL = new DOL.MSAccess.CMS.PageHeaderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageHeader InsertPageHeader(PageHeader pPageHeader, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageHeaderDOL DOL = new CORE.DOL.MSSQL.CMS.PageHeaderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPageHeader, pLanguageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageHeaderDOL DOL = new DOL.MSAccess.CMS.PageHeaderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPageHeader, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageHeader DeletePageHeader(PageHeader pPageHeader, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageHeaderDOL DOL = new CORE.DOL.MSSQL.CMS.PageHeaderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPageHeader, pLanguageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.PageHeaderDOL DOL = new DOL.MSAccess.CMS.PageHeaderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPageHeader, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        /**********************************************************************
         * PageView
         *********************************************************************/
        public PageView GetPageView(int pPageViewID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageViewDOL DOL = new CORE.DOL.MSSQL.CMS.PageViewDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPageViewID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageView[] ListPageViews(int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageViewDOL DOL = new CORE.DOL.MSSQL.CMS.PageViewDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageView[] ListPageViews(Entities.Authentication.UserAccountSession pUserAccountSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageViewDOL DOL = new CORE.DOL.MSSQL.CMS.PageViewDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pUserAccountSession);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageView InsertPageView(PageView pPageView)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageViewDOL DOL = new CORE.DOL.MSSQL.CMS.PageViewDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPageView);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageView RegisterPageView(string pSiteName, string pPageAlias, PageView pPageView)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageViewDOL DOL = new CORE.DOL.MSSQL.CMS.PageViewDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Register(pSiteName, pPageAlias, pPageView);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageView UpdatePageView(PageView pPageView)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageViewDOL DOL = new CORE.DOL.MSSQL.CMS.PageViewDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPageView);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public PageView DeletePageView(PageView pPageView)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.PageViewDOL DOL = new CORE.DOL.MSSQL.CMS.PageViewDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPageView);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        /**********************************************************************
         * Site
         *********************************************************************/
        public Site GetSite(int pSiteID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.SiteDOL DOL = new CORE.DOL.MSSQL.CMS.SiteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSiteID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.SiteDOL DOL = new DOL.MSAccess.CMS.SiteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSiteID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.CMS.SiteDOL DOL = new DOL.MySQL.CMS.SiteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSiteID);
            }*/
            else
                return null;
        }

        public Site[] ListSites()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.SiteDOL DOL = new CORE.DOL.MSSQL.CMS.SiteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.SiteDOL DOL = new DOL.MSAccess.CMS.SiteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public Site InsertSite(Site pSite)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.SiteDOL DOL = new CORE.DOL.MSSQL.CMS.SiteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSite);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.SiteDOL DOL = new DOL.MSAccess.CMS.SiteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSite);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public Site UpdateSite(Site pSite)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.SiteDOL DOL = new CORE.DOL.MSSQL.CMS.SiteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSite);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.SiteDOL DOL = new DOL.MSAccess.CMS.SiteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSite);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public Site DeleteSite(Site pSite)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.SiteDOL DOL = new CORE.DOL.MSSQL.CMS.SiteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSite);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.SiteDOL DOL = new DOL.MSAccess.CMS.SiteDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSite);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        /**********************************************************************
         * Stylesheet
         *********************************************************************/
        public Stylesheet GetStylesheet(int pStylesheetID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.StylesheetDOL DOL = new CORE.DOL.MSSQL.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pStylesheetID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.StylesheetDOL DOL = new DOL.MSAccess.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pStylesheetID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public Stylesheet[] ListStylesheets(int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.StylesheetDOL DOL = new CORE.DOL.MSSQL.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.StylesheetDOL DOL = new DOL.MSAccess.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.CMS.StylesheetDOL DOL = new DOL.MySQL.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPageID);
            }*/
            else
                return null;
        }

        public Stylesheet InsertStylesheet(Stylesheet pStylesheet)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.StylesheetDOL DOL = new CORE.DOL.MSSQL.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pStylesheet);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.StylesheetDOL DOL = new DOL.MSAccess.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pStylesheet);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public Stylesheet AssignStylesheetToPage(Stylesheet pStylesheet, int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.StylesheetDOL DOL = new CORE.DOL.MSSQL.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignToPage(pStylesheet,pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.StylesheetDOL DOL = new DOL.MSAccess.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignToPage(pStylesheet, pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public Stylesheet RemoveStylesheetFromPage(Stylesheet pStylesheet, int pPageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.StylesheetDOL DOL = new CORE.DOL.MSSQL.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromPage(pStylesheet, pPageID);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.StylesheetDOL DOL = new DOL.MSAccess.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromPage(pStylesheet, pPageID);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }

        public Stylesheet DeleteStylesheet(Stylesheet pStylesheet)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS.StylesheetDOL DOL = new CORE.DOL.MSSQL.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pStylesheet);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.CMS.StylesheetDOL DOL = new DOL.MSAccess.CMS.StylesheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pStylesheet);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }*/
            else
                return null;
        }
    }
}