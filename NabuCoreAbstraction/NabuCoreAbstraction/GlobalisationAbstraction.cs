using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class GlobalisationAbstraction : BaseAbstraction
    {
        public GlobalisationAbstraction() : base()
        {
        }

        public GlobalisationAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Country
         *********************************************************************/
        public Country GetCountry(int pCountryID, int pLanguageID)
        {
            if(base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.CountryDOL countryDOL = new CORE.DOL.MSSQL.Globalisation.CountryDOL(base.ConnectionString, base.ErrorLogFile);
                return countryDOL.Get(pCountryID, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Country GetCountryByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.CountryDOL countryDOL = new CORE.DOL.MSSQL.Globalisation.CountryDOL(base.ConnectionString, base.ErrorLogFile);
                return countryDOL.GetByAlias(pAlias, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Country[] ListCountries(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.CountryDOL countryDOL = new CORE.DOL.MSSQL.Globalisation.CountryDOL(base.ConnectionString, base.ErrorLogFile);
                return countryDOL.List(pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Country InsertCountry(Country pCountry)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.CountryDOL countryDOL = new CORE.DOL.MSSQL.Globalisation.CountryDOL(base.ConnectionString, base.ErrorLogFile);
                return countryDOL.Insert(pCountry);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Country UpdateCountry(Country pCountry)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.CountryDOL countryDOL = new CORE.DOL.MSSQL.Globalisation.CountryDOL(base.ConnectionString, base.ErrorLogFile);
                return countryDOL.Update(pCountry);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Country DeleteCountry(Country pCountry)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.CountryDOL countryDOL = new CORE.DOL.MSSQL.Globalisation.CountryDOL(base.ConnectionString, base.ErrorLogFile);
                return countryDOL.Delete(pCountry);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }
        
        /**********************************************************************
         * Language
         *********************************************************************/
        public Language GetLanguage(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageDOL languageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageDOL.Get(pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Language GetLanguageBySystemName(string pSystemName)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageDOL languageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageDOL.GetBySystemName(pSystemName);
            }
            /*else if (base.DBType == DatabaseType.MSAccess)
            {
                Octavo.Gate.Nabu.DOL.MSAccess.Globalisation.LanguageDOL languageDOL = new DOL.MSAccess.Globalisation.LanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageDOL.GetBySystemName(pSystemName);
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                Octavo.Gate.Nabu.DOL.MySQL.Globalisation.LanguageDOL languageDOL = new DOL.MySQL.Globalisation.LanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageDOL.GetBySystemName(pSystemName);
            }*/
            else
                return null;
        }

        public Language[] ListLanguages()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageDOL languageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageDOL.List();
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }


        public Language InsertLanguage(Language pLanguage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageDOL languageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageDOL.Insert(pLanguage);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Language UpdateLanguage(Language pLanguage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageDOL languageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageDOL.Update(pLanguage);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Language DeleteLanguage(Language pLanguage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageDOL languageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageDOL.Delete(pLanguage);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }
        /**********************************************************************
         * Language Usage
         *********************************************************************/


      

        public LanguageUsage GetLanguageUsage(int pLanguageUsageID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageUsageDOL languageUsageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageUsageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageUsageDOL.Get(pLanguageUsageID, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public LanguageUsage[] ListLanguageUsages(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageUsageDOL languageUsageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageUsageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageUsageDOL.List(pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public LanguageUsage InsertLanguageUsage(LanguageUsage pLanguageUsage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageUsageDOL languageUsageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageUsageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageUsageDOL.Insert(pLanguageUsage);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public LanguageUsage UpdateLanguageUsage(LanguageUsage pLanguageUsage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageUsageDOL languageUsageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageUsageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageUsageDOL.Update(pLanguageUsage);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public LanguageUsage DeleteLanguageUsage(LanguageUsage pLanguageUsage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.LanguageUsageDOL languageUsageDOL = new CORE.DOL.MSSQL.Globalisation.LanguageUsageDOL(base.ConnectionString, base.ErrorLogFile);
                return languageUsageDOL.Delete(pLanguageUsage);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }
        /**********************************************************************
         * Translation
         *********************************************************************/
        public Translation GetTranslation(int pTranslationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL baseDOL = new CORE.DOL.MSSQL.BaseDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.GetTranslation(pTranslationID, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Translation GetRawTranslation(int pTranslationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL baseDOL = new CORE.DOL.MSSQL.BaseDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.GetRawTranslation(pTranslationID, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Translation GetTranslationByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL baseDOL = new CORE.DOL.MSSQL.BaseDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.GetTranslationByAlias(pAlias, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }
        public Translation[] ListTranslations(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL baseDOL = new CORE.DOL.MSSQL.BaseDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.ListTranslations(pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Translation InsertTranslation(Translation pTranslation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL baseDOL = new CORE.DOL.MSSQL.BaseDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.InsertTranslation(pTranslation);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Translation UpdateTranslation(Translation pTranslation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL baseDOL = new CORE.DOL.MSSQL.BaseDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.UpdateTranslation(pTranslation);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Translation DeleteTranslation(Translation pTranslation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL baseDOL = new CORE.DOL.MSSQL.BaseDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.DeleteTranslation(pTranslation);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Translation DeleteAllForTranslation(Translation pTranslation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL baseDOL = new CORE.DOL.MSSQL.BaseDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.DeleteAllTranslations(pTranslation);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Translation AddTranslation(Translation pTranslation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.BaseDOL baseDOL = new CORE.DOL.MSSQL.BaseDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.AddTranslation(pTranslation);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        /**********************************************************************
         * Translated Content
         *********************************************************************/
        public Octavo.Gate.Nabu.CORE.Entities.Content.Content GetTranslatedContent(int pTranslationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.TranslatedContentDOL baseDOL = new CORE.DOL.MSSQL.Globalisation.TranslatedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.Get(pTranslationID, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content GetTranslatedContentByAlias(string pTransationAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.TranslatedContentDOL baseDOL = new CORE.DOL.MSSQL.Globalisation.TranslatedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.GetByAlias(pTransationAlias, pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListTranslatedContent(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.TranslatedContentDOL baseDOL = new CORE.DOL.MSSQL.Globalisation.TranslatedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.List(pLanguageID);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content InsertTranslatedContent(string pAlias, string pTranslatedName, string pTranslatedDescription, int pLanguageID, string pContentName, string pContentDescription, string pXMLFragment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.TranslatedContentDOL baseDOL = new CORE.DOL.MSSQL.Globalisation.TranslatedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.Insert(pAlias, pTranslatedName, pTranslatedDescription, pLanguageID, pContentName, pContentDescription, pXMLFragment);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content AddTranslationToTranslatedContent(int pTranslationID, int pLanguageID, string pContentName, string pContentDescription, string pXMLFragment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation.TranslatedContentDOL baseDOL = new CORE.DOL.MSSQL.Globalisation.TranslatedContentDOL(base.ConnectionString, base.ErrorLogFile);
                return baseDOL.Add(pTranslationID, pLanguageID, pContentName, pContentDescription, pXMLFragment);
            }
            else if (base.DBType == DatabaseType.MSAccess)
            {
                return null;
            }
            else if (base.DBType == DatabaseType.MySQL)
            {
                return null;
            }
            else
                return null;
        }
    }
}
