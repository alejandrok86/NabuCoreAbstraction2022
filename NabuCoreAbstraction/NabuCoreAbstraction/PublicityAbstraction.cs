using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Publicity;

namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class PublicityAbstraction : BaseAbstraction
    {
        public PublicityAbstraction() : base()
        {
        }

        public PublicityAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Advertisement
         *********************************************************************/
        public Advertisement GetAdvertisement(int pAdvertisementID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Get(pAdvertisementID);
            }
            else
                return null;
        }

        public Advertisement GetAdvertisementByRetrievalIdentifier(Guid pUniqueRetrievalID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetByRetrievalIdentifier(pUniqueRetrievalID);
            }
            else
                return null;
        }

        public Advertisement GetAdvertisementByTagID(int pTagID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.GetByTagID(pTagID);
            }
            else
                return null;
        }

        public Advertisement GetAdvertisementByTagPhrase(string pPhrase, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return (Advertisement)dol.GetByTagPhrase(pPhrase, pLanguageID);
            }
            else
                return null;
        }

        public Advertisement[] ListAdvertisement()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return (Advertisement[])dol.List();
            }
            else
                return null;
        }

        public Advertisement[] ListAdvertisementForUnit(int pUnitID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return (Advertisement[])dol.ListForUnit(pUnitID);
            }
            else
                return null;
        }

        public Advertisement[] ListAdvertisementsInCampaign(int pCampaignID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForCampaign(pCampaignID);
            }
            else
                return null;
        }

        public Advertisement[] ListAdvertisementsAtLocation(int pLocationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.ListForLocation(pLocationID);
            }
            else
                return null;
        }

        public Advertisement InsertAdvertisement(Advertisement pAdvertisement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Insert(pAdvertisement);
            }
            else
                return null;
        }

        public Advertisement UpdateAdvertisement(Advertisement pAdvertisement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.Update(pAdvertisement);
            }
            else
                return null;
        }

        public Advertisement DeleteAdvertisementComplete(Advertisement pAdvertisement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                dol.DeleteReferences(pAdvertisement);

                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentDOL contentDOL = new CORE.DOL.MSSQL.Content.ContentDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.Entities.Content.Content content = contentDOL.DeleteComplete(new Octavo.Gate.Nabu.CORE.Entities.Content.Content(pAdvertisement.ContentID));
                return new Advertisement(content.ContentID);
            }
            else
                return null;
        }

        public Advertisement AssignAdvertisementToCampaign(int pAdvertisementID, int pCampaignID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.AssignToCampaign(pAdvertisementID, pCampaignID);
            }
            else
                return null;
        }

        public Advertisement AssignAdvertisementToUnit(int pAdvertisementID, int pUnitID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.AssignToUnit(pAdvertisementID, pUnitID);
            }
            else
                return null;
        }

        public Advertisement AssignAdvertisementToLocation(int pAdvertisementID, int pLocationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.AssignToLocation(pAdvertisementID, pLocationID);
            }
            else
                return null;
        }

        public Advertisement RemoveAdvertisementFromUnit(int pAdvertisementID, int pUnitID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.RemoveFromUnit(pAdvertisementID, pUnitID);
            }
            else
                return null;
        }

        public Advertisement RemoveAdvertisementFromLocation(int pAdvertisementID, int pLocationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.RemoveFromLocation(pAdvertisementID, pLocationID);
            }
            else
                return null;
        }

        public Advertisement RemoveAdvertisementFromCampaign(int pAdvertisementID, int pCampaignID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertisementDOL dol = new CORE.DOL.MSSQL.Publicity.AdvertisementDOL(base.ConnectionString, base.ErrorLogFile);
                return dol.RemoveFromCampaign(pAdvertisementID, pCampaignID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Advertiser
         *********************************************************************/
        public Advertiser GetAdvertiser(int pAdvertiserID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertiserDOL DOL = new CORE.DOL.MSSQL.Publicity.AdvertiserDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAdvertiserID, pLanguageID);
            }
            else
                return null;
        }

        public Advertiser[] ListAdvertisers(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertiserDOL DOL = new CORE.DOL.MSSQL.Publicity.AdvertiserDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Advertiser InsertAdvertiser(Advertiser pAdvertiser)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertiserDOL DOL = new CORE.DOL.MSSQL.Publicity.AdvertiserDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAdvertiser);
            }
            else
                return null;
        }

        public Advertiser UpdateAdvertiser(Advertiser pAdvertiser)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertiserDOL DOL = new CORE.DOL.MSSQL.Publicity.AdvertiserDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAdvertiser);
            }
            else
                return null;
        }

        public Advertiser DeleteAdvertiser(Advertiser pAdvertiser)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.AdvertiserDOL DOL = new CORE.DOL.MSSQL.Publicity.AdvertiserDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAdvertiser);
            }
            else
                return null;
        }
        /**********************************************************************
         * Brand
         *********************************************************************/
        public Brand GetBrand(int pBrandID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.BrandDOL DOL = new CORE.DOL.MSSQL.Publicity.BrandDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pBrandID, pLanguageID);
            }
            else
                return null;
        }

        public Brand GetBrandByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.BrandDOL DOL = new CORE.DOL.MSSQL.Publicity.BrandDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public Brand[] ListBrands(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.BrandDOL DOL = new CORE.DOL.MSSQL.Publicity.BrandDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Brand[] ListBrands(int pOrganisationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.BrandDOL DOL = new CORE.DOL.MSSQL.Publicity.BrandDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pOrganisationID, pLanguageID);
            }
            else
                return null;
        }

        public Brand InsertBrand(Brand pBrand, int pOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.BrandDOL DOL = new CORE.DOL.MSSQL.Publicity.BrandDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pBrand, pOrganisationID);
            }
            else
                return null;
        }

        public Brand UpdateBrand(Brand pBrand)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.BrandDOL DOL = new CORE.DOL.MSSQL.Publicity.BrandDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pBrand);
            }
            else
                return null;
        }

        public Brand DeleteBrand(Brand pBrand)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.BrandDOL DOL = new CORE.DOL.MSSQL.Publicity.BrandDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pBrand);
            }
            else
                return null;
        }
        /**********************************************************************
         * Campaign
         *********************************************************************/
        public Campaign GetCampaign(int pCampaignID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.CampaignDOL DOL = new CORE.DOL.MSSQL.Publicity.CampaignDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pCampaignID, pLanguageID);
            }
            else
                return null;
        }

        public Campaign GetCampaignByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.CampaignDOL DOL = new CORE.DOL.MSSQL.Publicity.CampaignDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public Campaign[] ListCampaigns(int pAdvertiserID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.CampaignDOL DOL = new CORE.DOL.MSSQL.Publicity.CampaignDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAdvertiserID, pLanguageID);
            }
            else
                return null;
        }

        public Campaign InsertCampaign(Campaign pCampaign, int pAdvertiserID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.CampaignDOL DOL = new CORE.DOL.MSSQL.Publicity.CampaignDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCampaign, pAdvertiserID);
            }
            else
                return null;
        }

        public Campaign UpdateCampaign(Campaign pCampaign)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.CampaignDOL DOL = new CORE.DOL.MSSQL.Publicity.CampaignDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pCampaign);
            }
            else
                return null;
        }

        public Campaign DeleteCampaign(Campaign pCampaign)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.CampaignDOL DOL = new CORE.DOL.MSSQL.Publicity.CampaignDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pCampaign);
            }
            else
                return null;
        }
        /**********************************************************************
         * ClickThrough
         *********************************************************************/
        public ClickThrough InsertClickThrough(ClickThrough pClickThrough)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ClickThroughDOL DOL = new CORE.DOL.MSSQL.Publicity.ClickThroughDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pClickThrough);
            }
            else
                return null;
        }
        /**********************************************************************
         * ProductLine
         *********************************************************************/
        public ProductLine GetProductLine(int pProductLineID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProductLineID, pLanguageID);
            }
            else
                return null;
        }

        public ProductLine GetProductLineByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ProductLine GetProductLineForPart(int pPartID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByPart(pPartID, pLanguageID);
            }
            else
                return null;
        }

public ProductLine[] ListProductLines(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ProductLine[] ListProductLinesByBrand(int pBrandID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByBrand(pBrandID, pLanguageID);
            }
            else
                return null;
        }

        public ProductLine[] ListProductLinesByOrganisation(int pOrganisationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByOrganisation(pOrganisationID, pLanguageID);
            }
            else
                return null;
        }

        public ProductLine InsertProductLine(ProductLine pProductLine, int? pBrandID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProductLine, pBrandID);
            }
            else
                return null;
        }

        public ProductLine InsertProductLineForOrganisation(ProductLine pProductLine, int pOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.InsertForOrganisation(pProductLine, pOrganisationID);
            }
            else
                return null;
        }

        public ProductLine UpdateProductLine(ProductLine pProductLine, int? pBrandID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProductLine, pBrandID);
            }
            else
                return null;
        }

        public ProductLine UpdateProductLineForOrganisation(ProductLine pProductLine, int pOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.UpdateForOrganisation(pProductLine, pOrganisationID);
            }
            else
                return null;
        }

        public ProductLine DeleteProductLine(ProductLine pProductLine)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProductLine);
            }
            else
                return null;
        }

        public ProductLine AssignPartToProductLine(int pProductLineID, int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pProductLineID, pPartID);
            }
            else
                return null;
        }

        public ProductLine RemovePartFromProductLine(int pProductLineID, int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pProductLineID, pPartID);
            }
            else
                return null;
        }
        public BaseBoolean RemovePartFromAllProductLines(int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity.ProductLineDOL DOL = new CORE.DOL.MSSQL.Publicity.ProductLineDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pPartID);
            }
            else
                return null;
        }
    }
}
