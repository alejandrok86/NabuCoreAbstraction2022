using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;
using System;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class PeopleAndPlacesAbstraction : BaseAbstraction
    {
        public PeopleAndPlacesAbstraction() : base()
        {
        }

        public PeopleAndPlacesAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Addressable Object Name
         *********************************************************************/
        public AddressableObjectName GetAddressableObjectName(int pAddressableObjectNameID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.AddressableObjectNameDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.AddressableObjectNameDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAddressableObjectNameID, pLanguageID);
            }
            else
                return null;
        }

        public AddressableObjectName InsertAddressableObjectName(AddressableObjectName pAddressableObjectName)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.AddressableObjectNameDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.AddressableObjectNameDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAddressableObjectName);
            }
            else
                return null;
        }

        public AddressableObjectName UpdateAddressableObjectName(AddressableObjectName pAddressableObjectName)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.AddressableObjectNameDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.AddressableObjectNameDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAddressableObjectName);
            }
            else
                return null;
        }

        public AddressableObjectName DeleteAddressableObjectName(AddressableObjectName pAddressableObjectName)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.AddressableObjectNameDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.AddressableObjectNameDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAddressableObjectName);
            }
            else
                return null;
        }
        /**********************************************************************
         * City
         *********************************************************************/
        public City GetCity(int pCityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pCityID, pLanguageID);
            }
            else
                return null;
        }

        public City[] ListCities(int pCountryRegionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pCountryRegionID, pLanguageID);
            }
            else
                return null;
        }

        public City InsertCity(City pCity, int pCountryRegionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCity, pCountryRegionID);
            }
            else
                return null;
        }

        public City UpdateCity(City pCity, int pCountryRegionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pCity, pCountryRegionID);
            }
            else
                return null;
        }

        public City DeleteCity(City pCity)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pCity);
            }
            else
                return null;
        }
        /**********************************************************************
         * Contact Mechanism
         *********************************************************************/
        public ContactMechanism GetContactMechanism(int pContactMechanismID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pContactMechanismID, pLanguageID);
            }
            else
                return null;
        }

        public ContactMechanism[] ListContactMechanisms(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ContactMechanism InsertContactMechanism(ContactMechanism pContactMechanism)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pContactMechanism);
            }
            else
                return null;
        }

        public ContactMechanism UpdateContactMechanism(ContactMechanism pContactMechanism)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pContactMechanism);
            }
            else
                return null;
        }

        public ContactMechanism DeleteContactMechanism(ContactMechanism pContactMechanism)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pContactMechanism);
            }
            else
                return null;
        }
        /**********************************************************************
         * Contact Mechanism Purpose Type
         *********************************************************************/
        public ContactMechanismPurposeType GetContactMechanismPurposeType(int pContactMechanismPurposeTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismPurposeTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismPurposeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pContactMechanismPurposeTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ContactMechanismPurposeType GetContactMechanismPurposeTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismPurposeTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismPurposeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }
        public ContactMechanismPurposeType[] ListContactMechanismPurposeTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismPurposeTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismPurposeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ContactMechanismPurposeType InsertContactMechanismPurposeType(ContactMechanismPurposeType pContactMechanismPurposeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismPurposeTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismPurposeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pContactMechanismPurposeType);
            }
            else
                return null;
        }

        public ContactMechanismPurposeType UpdateContactMechanismPurposeType(ContactMechanismPurposeType pContactMechanismPurposeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismPurposeTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismPurposeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pContactMechanismPurposeType);
            }
            else
                return null;
        }

        public ContactMechanismPurposeType DeleteContactMechanismPurposeType(ContactMechanismPurposeType pContactMechanismPurposeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismPurposeTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismPurposeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pContactMechanismPurposeType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Contact Mechanism Type
         *********************************************************************/
        public ContactMechanismType GetContactMechanismType(int pContactMechanismTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pContactMechanismTypeID, pLanguageID);
            }
            else
                return null;
        }
        
        public ContactMechanismType GetContactMechanismTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ContactMechanismType[] ListContactMechanismTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ContactMechanismType InsertContactMechanismType(ContactMechanismType pContactMechanismType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pContactMechanismType);
            }
            else
                return null;
        }

        public ContactMechanismType UpdateContactMechanismType(ContactMechanismType pContactMechanismType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pContactMechanismType);
            }
            else
                return null;
        }

        public ContactMechanismType DeleteContactMechanismType(ContactMechanismType pContactMechanismType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ContactMechanismTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pContactMechanismType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Country Region
         *********************************************************************/
        public CountryRegion GetCountryRegion(int pCountryRegionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CountryRegionDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CountryRegionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pCountryRegionID, pLanguageID);
            }
            else
                return null;
        }

        public CountryRegion[] ListCountryRegion(int pCountryID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CountryRegionDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CountryRegionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pCountryID, pLanguageID);
            }
            else
                return null;
        }

        public CountryRegion InsertCountryRegion(CountryRegion pCountryRegion, int pCountryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CountryRegionDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CountryRegionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCountryRegion, pCountryID);
            }
            else
                return null;
        }

        public CountryRegion UpdateCountryRegion(CountryRegion pCountryRegion, int pCountryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CountryRegionDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CountryRegionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pCountryRegion, pCountryID);
            }
            else
                return null;
        }

        public CountryRegion DeleteCountryRegion(CountryRegion pCountryRegion)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CountryRegionDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CountryRegionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pCountryRegion);
            }
            else
                return null;
        }
        /**********************************************************************
         * County
         *********************************************************************/
        public County GetCounty(int pCountyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CountyDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CountyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pCountyID, pLanguageID);
            }
            else
                return null;
        }

        public County[] ListCounty(int pCountryRegionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CountyDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CountyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID, pCountryRegionID);
            }
            else
                return null;
        }

        public County InsertCounty(County pCounty, int pCountryRegionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CountyDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CountyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCounty, pCountryRegionID);
            }
            else
                return null;
        }

        public County UpdateCounty(County pCounty, int pCountryRegionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CountyDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CountyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pCounty, pCountryRegionID);
            }
            else
                return null;
        }

        public County DeleteCounty(County pCounty)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.CountyDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.CountyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pCounty);
            }
            else
                return null;
        }
        /**********************************************************************
         * Disability
         *********************************************************************/
        public Disability GetDisability(int pDisabilityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DisabilityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DisabilityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDisabilityID, pLanguageID);
            }
            else
                return null;
        }

        public Disability[] ListDisabilities(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DisabilityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DisabilityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Disability InsertDisability(Disability pDisability)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DisabilityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DisabilityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDisability);
            }
            else
                return null;
        }

        public Disability UpdateDisability(Disability pDisability)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DisabilityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DisabilityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDisability);
            }
            else
                return null;
        }

        public Disability DeleteDisability(Disability pDisability)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DisabilityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DisabilityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDisability);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * DOB Verification Type
         *********************************************************************/
        public DOBVerificationType GetDOBVerificationType(int pDOBVerificationTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DOBVerificationTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DOBVerificationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDOBVerificationTypeID, pLanguageID);
            }
            else
                return null;
        }

        public DOBVerificationType[] ListDOBVerificationTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DOBVerificationTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DOBVerificationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public DOBVerificationType InsertDOBVerificationType(DOBVerificationType pDOBVerificationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DOBVerificationTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DOBVerificationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDOBVerificationType);
            }
            else
                return null;
        }

        public DOBVerificationType UpdateDOBVerificationType(DOBVerificationType pDOBVerificationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DOBVerificationTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DOBVerificationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDOBVerificationType);
            }
            else
                return null;
        }

        public DOBVerificationType DeleteDOBVerificationType(DOBVerificationType pDOBVerificationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DOBVerificationTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DOBVerificationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDOBVerificationType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Dwelling
         *********************************************************************/
        public Dwelling GetDwelling(int pDwellingID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DwellingDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DwellingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDwellingID, pLanguageID);
            }
            else
                return null;
        }

        public Dwelling[] ListDwellings(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DwellingDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DwellingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Dwelling InsertDwelling(Dwelling pDwelling)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DwellingDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DwellingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDwelling);
            }
            else
                return null;
        }

        public Dwelling UpdateDwelling(Dwelling pDwelling)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DwellingDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DwellingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDwelling);
            }
            else
                return null;
        }

        public Dwelling DeleteDwelling(Dwelling pDwelling)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.DwellingDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.DwellingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDwelling);
            }
            else
                return null;
        }
        /**********************************************************************
         * Electronic Address
         *********************************************************************/
        public ElectronicAddress GetElectronicAddress(int pElectronicAddressID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ElectronicAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ElectronicAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pElectronicAddressID, pLanguageID);
            }
            else
                return null;
        }

        public ElectronicAddress GetElectronicAddressByDetail(string pElectronicAddressDetail, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ElectronicAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ElectronicAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAddressDetail(pElectronicAddressDetail, pLanguageID);
            }
            else
                return null;
        }

        public ElectronicAddress InsertElectronicAddress(ElectronicAddress pElectronicAddress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ElectronicAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ElectronicAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pElectronicAddress);
            }
            else
                return null;
        }

        public ElectronicAddress UpdateElectronicAddress(ElectronicAddress pElectronicAddress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ElectronicAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ElectronicAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pElectronicAddress);
            }
            else
                return null;
        }

        public ElectronicAddress DeleteElectronicAddress(ElectronicAddress pElectronicAddress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ElectronicAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ElectronicAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pElectronicAddress);
            }
            else
                return null;
        }
        /**********************************************************************
         * Ethnicity
         *********************************************************************/
        public Ethnicity GetEthnicity(int pEthnicityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pEthnicityID, pLanguageID);
            }
            else
                return null;
        }

        public Ethnicity[] ListEthnicities(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Ethnicity InsertEthnicity(Ethnicity pEthnicity)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pEthnicity);
            }
            else
                return null;
        }

        public Ethnicity UpdateEthnicity(Ethnicity pEthnicity)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pEthnicity);
            }
            else
                return null;
        }

        public Ethnicity DeleteEthnicity(Ethnicity pEthnicity)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pEthnicity);
            }
            else
                return null;
        }
        /**********************************************************************
         * Ethnicity Status
         *********************************************************************/
        public EthnicityStatus GetEthnicityStatus(int pEthnicityStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityStatusDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pEthnicityStatusID, pLanguageID);
            }
            else
                return null;
        }

        public EthnicityStatus[] ListEthnicityStatuses(int pPersonID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityStatusDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPersonID, pLanguageID);
            }
            else
                return null;
        }

        public EthnicityStatus InsertEthnicityStatus(EthnicityStatus pEthnicityStatus, int pPersonID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityStatusDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pEthnicityStatus, pPersonID);
            }
            else
                return null;
        }

        public EthnicityStatus UpdateEthnicityStatus(EthnicityStatus pEthnicityStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityStatusDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pEthnicityStatus);
            }
            else
                return null;
        }

        public EthnicityStatus DeleteEthnicityStatus(EthnicityStatus pEthnicityStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityStatusDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.EthnicityStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pEthnicityStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Gender
         *********************************************************************/
        public Gender GetGender(int pGenderID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GenderDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GenderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pGenderID, pLanguageID);
            }
            else
                return null;
        }

        public Gender GetGenderByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GenderDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GenderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public Gender[] ListGenders(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GenderDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GenderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Gender InsertGender(Gender pGender)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GenderDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GenderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pGender);
            }
            else
                return null;
        }

        public Gender UpdateGender(Gender pGender)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GenderDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GenderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pGender);
            }
            else
                return null;
        }

        public Gender DeleteGender(Gender pGender)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GenderDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GenderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pGender);
            }
            else
                return null;
        }
        /**********************************************************************
         * Geographic Detail
         *********************************************************************/
        public GeographicDetail GetGeographicDetail(int pGeographicDetailID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pGeographicDetailID, pLanguageID);
            }
            else
                return null;
        }

        public GeographicDetail[] ListGeographicDetails(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public GeographicDetail RegisterGeographicDetail(GeoPhysicalLocation pGeoPhysicalLocation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                GeographicDetail registeredLocation = new GeographicDetail();
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL geoDOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL(base.ConnectionString, base.ErrorLogFile);
                GeoPhysicalLocation foundLocation = geoDOL.GetByLatitudeLongitude(pGeoPhysicalLocation.Latitude, pGeoPhysicalLocation.Longitude);
                if (foundLocation.ErrorsDetected == false)
                {
                    if (foundLocation.GeographicDetailID == null)
                    {
                        GeographicDetail newLocation = new GeographicDetail();
                        newLocation.FromDate = DateTime.Now;
                        newLocation.GeographicDetailType = new GeographicDetailType(pGeoPhysicalLocation.GeographicDetailType.GeographicDetailTypeID);
                        // Add a new detail record
                        registeredLocation = DOL.Insert(newLocation);
                        if (registeredLocation.ErrorsDetected == false)
                        {
                            pGeoPhysicalLocation.GeographicDetailID = registeredLocation.GeographicDetailID;
                            // add the geophysical position
                            geoDOL.Insert(pGeoPhysicalLocation);
                        }
                    }
                    else
                    {
                        // we already have this location registered
                        registeredLocation.GeographicDetailID = foundLocation.GeographicDetailID;
                    }
                }
                return registeredLocation;
            }
            else
                return null;
        }

        public GeographicDetail InsertGeographicDetail(GeographicDetail pGeographicDetail)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pGeographicDetail);
            }
            else
                return null;
        }

        public GeographicDetail UpdateGeographicDetail(GeographicDetail pGeographicDetail)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pGeographicDetail);
            }
            else
                return null;
        }

        public GeographicDetail DeleteGeographicDetail(GeographicDetail pGeographicDetail)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pGeographicDetail);
            }
            else
                return null;
        }
        /**********************************************************************
         * Geographic Detail Type
         *********************************************************************/
        public GeographicDetailType GetGeographicDetailType(int pGeographicDetailTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pGeographicDetailTypeID, pLanguageID);
            }
            else
                return null;
        }

        public GeographicDetailType GetGeographicDetailTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public GeographicDetailType[] ListGeographicDetailTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public GeographicDetailType InsertGeographicDetailType(GeographicDetailType pGeographicDetailType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pGeographicDetailType);
            }
            else
                return null;
        }

        public GeographicDetailType UpdateGeographicDetailType(GeographicDetailType pGeographicDetailType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pGeographicDetailType);
            }
            else
                return null;
        }

        public GeographicDetailType DeleteGeographicDetailType(GeographicDetailType pGeographicDetailType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeographicDetailTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pGeographicDetailType);
            }
            else
                return null;
        }
        /**********************************************************************
         * GeoPhysical Location
         *********************************************************************/
        public GeoPhysicalLocation GetGeoPhysicalLocation(int pGeoPhysicalLocationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pGeoPhysicalLocationID, pLanguageID);
            }
            else
                return null;
        }

        public GeoPhysicalLocation InsertGeoPhysicalLocation(GeoPhysicalLocation pGeoPhysicalLocation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pGeoPhysicalLocation);
            }
            else
                return null;
        }

        public GeoPhysicalLocation UpdateGeoPhysicalLocation(GeoPhysicalLocation pGeoPhysicalLocation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pGeoPhysicalLocation);
            }
            else
                return null;
        }

        public GeoPhysicalLocation DeleteGeoPhysicalLocation(GeoPhysicalLocation pGeoPhysicalLocation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pGeoPhysicalLocation);
            }
            else
                return null;
        }
        /**********************************************************************
         * Marital Status
         *********************************************************************/
        public MaritalStatus GetMaritalStatus(int pMaritalStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.MaritalStatusDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.MaritalStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pMaritalStatusID, pLanguageID);
            }
            else
                return null;
        }

        public MaritalStatus[] ListMaritalStatus(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.MaritalStatusDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.MaritalStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public MaritalStatus InsertMaritalStatus(MaritalStatus pMaritalStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.MaritalStatusDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.MaritalStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pMaritalStatus);
            }
            else
                return null;
        }

        public MaritalStatus UpdateMaritalStatus(MaritalStatus pMaritalStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.MaritalStatusDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.MaritalStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pMaritalStatus);
            }
            else
                return null;
        }

        public MaritalStatus DeleteMaritalStatus(MaritalStatus pMaritalStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.MaritalStatusDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.MaritalStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pMaritalStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Person Country
         *********************************************************************/
        public PersonCountry GetPersonCountry(int pPersonCountryID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonCountryDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonCountryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPersonCountryID, pLanguageID);
            }
            else
                return null;
        }

        public PersonCountry[] ListPersonCountries(int pPersonID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonCountryDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonCountryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPersonID, pLanguageID);
            }
            else
                return null;
        }

        public PersonCountry InsertPersonCountry(PersonCountry pPersonCountry, int pPersonID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonCountryDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonCountryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPersonCountry, pPersonID);
            }
            else
                return null;
        }

        public PersonCountry UpdatePersonCountry(PersonCountry pPersonCountry, int pPersonID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonCountryDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonCountryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPersonCountry, pPersonID);
            }
            else
                return null;
        }

        public PersonCountry DeletePersonCountry(PersonCountry pPersonCountry)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonCountryDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonCountryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPersonCountry);
            }
            else
                return null;
        }
        /**********************************************************************
         * Person
         *********************************************************************/
        public Person GetPerson(int pPersonID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPersonID, pLanguageID);
            }
            else
                return null;
        }

        public Person GetPersonBySocialSecurityNumber(string pSocialSecurityNumber, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetBySocialSecurityNumber(pSocialSecurityNumber, pLanguageID);
            }
            else
                return null;
        }

        public Person GetPersonByElectronicAddress(string pElectronicAddressDetail, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByElectronicAddress(pElectronicAddressDetail, pLanguageID);
            }
            else
                return null;
        }

        public Person[] ListPersons(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Person InsertPerson(Person pPerson)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPerson);
            }
            else
                return null;
        }

        public Person UpdatePerson(Person pPerson)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPerson);
            }
            else
                return null;
        }

        public Person DeletePerson(Person pPerson)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPerson);
            }
            else
                return null;
        }
        public BaseBoolean DeletePersonComplete(int pPersonID, int pLanguageID)
        {
            BaseBoolean result = new BaseBoolean(false);
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL personDOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameDOL personNameDOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameDOL(base.ConnectionString, base.ErrorLogFile);

                Person person = personDOL.Get(pPersonID, pLanguageID);
                if (person.ErrorsDetected == false)
                {
                    if (person.PartyID.HasValue)
                    {
                        person.PersonNames = personNameDOL.List(pPersonID, pLanguageID);
                        if (person.PersonNames != null && person.PersonNames.Length > 0)
                        {
                            foreach (PersonName personName in person.PersonNames)
                            {
                                if (personName.ErrorsDetected == false)
                                    personNameDOL.Delete(personName);
                            }
                        }

                        // we can think about the contact mechanisms in a future release

                    }
                    person = personDOL.Delete(person);
                    if (person.ErrorsDetected == false)
                        result.Value = true;
                }
                else
                {
                    result.ErrorsDetected = true;
                    result.ErrorDetails = person.ErrorDetails;
                }
            }
            return result;
        }
        /**********************************************************************
         * Person Language
         *********************************************************************/
        public PersonLanguage GetPersonLanguage(int pPersonLanguageID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonLanguageDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonLanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPersonLanguageID, pLanguageID);
            }
            else
                return null;
        }

        public PersonLanguage[] ListPersonLanguages(int pPersonID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonLanguageDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonLanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPersonID, pLanguageID);
            }
            else
                return null;
        }

        public PersonLanguage InsertPersonLanguage(PersonLanguage pPersonLanguage, int pPersonID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonLanguageDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonLanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPersonLanguage, pPersonID);
            }
            else
                return null;
        }

        public PersonLanguage UpdatePersonLanguage(PersonLanguage pPersonLanguage, int pPersonID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonLanguageDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonLanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPersonLanguage, pPersonID);
            }
            else
                return null;
        }

        public PersonLanguage DeletePersonLanguage(PersonLanguage pPersonLanguage, int pPersonID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonLanguageDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonLanguageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPersonLanguage, pPersonID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Person Name
         *********************************************************************/
        public PersonName GetPersonName(int pPersonNameID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPersonNameID, pLanguageID);
            }
            else
                return null;
        }

        public PersonName[] ListPersonNames(int pPersonID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPersonID, pLanguageID);
            }
            else
                return null;
        }

        public PersonName InsertPersonName(PersonName pPersonName, int pPersonID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPersonName, pPersonID);
            }
            else
                return null;
        }

        public PersonName UpdatePersonName(PersonName pPersonName)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPersonName);
            }
            else
                return null;
        }

        public PersonName DeletePersonName(PersonName pPersonName)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPersonName);
            }
            else
                return null;
        }
        /**********************************************************************
         * Person Name Type
         *********************************************************************/
        public PersonNameType GetPersonNameType(int pPersonNameTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPersonNameTypeID, pLanguageID);
            }
            else
                return null;
        }

        public PersonNameType GetPersonNameTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }
        public PersonNameType[] ListPersonNameTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PersonNameType InsertPersonNameType(PersonNameType pPersonNameType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPersonNameType);
            }
            else
                return null;
        }

        public PersonNameType UpdatePersonNameType(PersonNameType pPersonNameType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPersonNameType);
            }
            else
                return null;
        }

        public PersonNameType DeletePersonNameType(PersonNameType pPersonNameType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PersonNameTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPersonNameType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Postal Address
         *********************************************************************/
        public ComplexPostalAddress GetPostalAddress(int pPostalAddressID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ComplexPostalAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ComplexPostalAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPostalAddressID, pLanguageID);
            }
            else
                return null;
        }

        public ComplexPostalAddress InsertPostalAddress(ComplexPostalAddress pPostalAddress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ComplexPostalAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ComplexPostalAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPostalAddress);
            }
            else
                return null;
        }

        public ComplexPostalAddress UpdatePostalAddress(ComplexPostalAddress pPostalAddress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ComplexPostalAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ComplexPostalAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPostalAddress);
            }
            else
                return null;
        }

        public ComplexPostalAddress DeletePostalAddress(ComplexPostalAddress pPostalAddress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ComplexPostalAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ComplexPostalAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPostalAddress);
            }
            else
                return null;
        }
        /**********************************************************************
         * Postal Code
         *********************************************************************/
        public PostalCode GetPostalCode(int pPostalCodeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PostalCodeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PostalCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPostalCodeID, pLanguageID);
            }
            else
                return null;
        }

        public PostalCode[] ListPostalCodes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PostalCodeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PostalCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PostalCode InsertPostalCode(PostalCode pPostalCode, int pCityID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PostalCodeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PostalCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPostalCode, pCityID);
            }
            else
                return null;
        }

        public PostalCode UpdatePostalCode(PostalCode pPostalCode, int pCityID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PostalCodeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PostalCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPostalCode, pCityID);
            }
            else
                return null;
        }

        public PostalCode DeletePostalCode(PostalCode pPostalCode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.PostalCodeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.PostalCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPostalCode);
            }
            else
                return null;
        }
        /**********************************************************************
         * Religion
         *********************************************************************/
        public Religion GetReligion(int pReligionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ReligionDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ReligionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pReligionID, pLanguageID);
            }
            else
                return null;
        }

        public Religion[] ListReligions(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ReligionDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ReligionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Religion InsertReligion(Religion pReligion)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ReligionDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ReligionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pReligion);
            }
            else
                return null;
        }

        public Religion UpdateReligion(Religion pReligion)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ReligionDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ReligionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pReligion);
            }
            else
                return null;
        }

        public Religion DeleteReligion(Religion pReligion)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.ReligionDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.ReligionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pReligion);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * Telecomms Number
         *********************************************************************/
        public TelecommsNumber GetTelecommsNumber(int pTelecommsNumberID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.TelecommsNumberDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.TelecommsNumberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTelecommsNumberID, pLanguageID);
            }
            else
                return null;
        }

        public TelecommsNumber InsertTelecommsNumber(TelecommsNumber pTelecommsNumber)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.TelecommsNumberDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.TelecommsNumberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTelecommsNumber);
            }
            else
                return null;
        }

        public TelecommsNumber UpdateTelecommsNumber(TelecommsNumber pTelecommsNumber)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.TelecommsNumberDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.TelecommsNumberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTelecommsNumber);
            }
            else
                return null;
        }

        public TelecommsNumber DeleteTelecommsNumber(TelecommsNumber pTelecommsNumber)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.TelecommsNumberDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.TelecommsNumberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTelecommsNumber);
            }
            else
                return null;
        }
        /**********************************************************************
         * Traveller Type
         *********************************************************************/
        public TravellerType GetTravellerType(int pTravellerTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.TravellerTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.TravellerTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTravellerTypeID, pLanguageID);
            }
            else
                return null;
        }

        public TravellerType[] ListTravellerTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.TravellerTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.TravellerTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public TravellerType InsertTravellerType(TravellerType pTravellerType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.TravellerTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.TravellerTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTravellerType);
            }
            else
                return null;
        }

        public TravellerType UpdateTravellerType(TravellerType pTravellerType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.TravellerTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.TravellerTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTravellerType);
            }
            else
                return null;
        }

        public TravellerType DeleteTravellerType(TravellerType pTravellerType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.TravellerTypeDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.TravellerTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTravellerType);
            }
            else
                return null;
        }

        /**********************************************************************
         * Email Addresses
         *********************************************************************/
        public ElectronicAddress[] GetEmailAddressesForParty(int pPartyID)
        {
            List<ElectronicAddress> emailAddresses = new List<ElectronicAddress>();
            emailAddresses.Add(new ElectronicAddress(-1, "kris.knowles@octavogate.com"));
            return emailAddresses.ToArray();
        }

        public ElectronicAddress[] ListEmailAddressesForRelationshipAlias(int pPartyID, string pPartyRelationshipTypeAlias)
        {
            List<ElectronicAddress> emailAddresses = new List<ElectronicAddress>();
            emailAddresses.Add(new ElectronicAddress(-1, "kris.knowles@limathon.com"));
            return emailAddresses.ToArray();
        }

        /**********************************************************************
         * Simple Posta Address
         *********************************************************************/
        public SimplePostalAddress GetSimplePostalAddress(int pPostalAddressID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.SimplePostalAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.SimplePostalAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPostalAddressID, pLanguageID);
            }
            else
                return null;
        }

        public SimplePostalAddress[] ListSimplePostalAddresses(int pPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.SimplePostalAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.SimplePostalAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyID, pLanguageID);
            }
            else
                return null;
        }

        public SimplePostalAddress InsertSimplePostalAddress(SimplePostalAddress pPostalAddress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.SimplePostalAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.SimplePostalAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPostalAddress);
            }
            else
                return null;
        }

        public SimplePostalAddress UpdateSimplePostalAddress(SimplePostalAddress pPostalAddress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.SimplePostalAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.SimplePostalAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPostalAddress);
            }
            else
                return null;
        }

        public SimplePostalAddress DeleteSimplePostalAddress(SimplePostalAddress pPostalAddress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.SimplePostalAddressDOL DOL = new CORE.DOL.MSSQL.PeopleAndPlaces.SimplePostalAddressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPostalAddress);
            }
            else
                return null;
        }
    }
}
