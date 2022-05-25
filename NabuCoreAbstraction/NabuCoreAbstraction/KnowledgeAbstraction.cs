using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Content;
using Octavo.Gate.Nabu.CORE.Entities.Knowledge;

namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class KnowledgeAbstraction : BaseAbstraction
    {
        public KnowledgeAbstraction() : base()
        {
        }

        public KnowledgeAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Article
         *********************************************************************/
        public Article[] ListArticles(int pCategoryID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Knowledge.CategoryDOL DOL = new CORE.DOL.MSSQL.Knowledge.CategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListArticles(pCategoryID, pLanguageID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Category
         *********************************************************************/
        public Category GetCategory(int pCategoryID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Knowledge.CategoryDOL DOL = new CORE.DOL.MSSQL.Knowledge.CategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pCategoryID, pLanguageID);
            }
            else
                return null;
        }

        public Category GetCategoryByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Knowledge.CategoryDOL DOL = new CORE.DOL.MSSQL.Knowledge.CategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public Category[] ListCategories(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Knowledge.CategoryDOL DOL = new CORE.DOL.MSSQL.Knowledge.CategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListAll(pLanguageID);
            }
            else
                return null;
        }

        public Category[] ListCategories(int? pParentCategoryID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Knowledge.CategoryDOL DOL = new CORE.DOL.MSSQL.Knowledge.CategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pParentCategoryID, pLanguageID);
            }
            else
                return null;
        }

        public Category InsertCategory(Category pCategory, int? pParentCategoryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Knowledge.CategoryDOL DOL = new CORE.DOL.MSSQL.Knowledge.CategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCategory, pParentCategoryID);
            }
            else
                return null;
        }

        public Category UpdateCategory(Category pCategory, int? pParentCategoryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Knowledge.CategoryDOL DOL = new CORE.DOL.MSSQL.Knowledge.CategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pCategory, pParentCategoryID);
            }
            else
                return null;
        }

        public Category DeleteCategory(Category pCategory)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Knowledge.CategoryDOL DOL = new CORE.DOL.MSSQL.Knowledge.CategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pCategory);
            }
            else
                return null;
        }

        public BaseBoolean AssignArticleToCategory(Category pCategory, Article pArticle)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Knowledge.CategoryDOL DOL = new CORE.DOL.MSSQL.Knowledge.CategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pCategory, pArticle);
            }
            else
                return null;
        }

        public BaseBoolean RemoveArticleFromCategory(Category pCategory, Article pArticle)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Knowledge.CategoryDOL DOL = new CORE.DOL.MSSQL.Knowledge.CategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pCategory, pArticle);
            }
            else
                return null;
        }
    }
}
