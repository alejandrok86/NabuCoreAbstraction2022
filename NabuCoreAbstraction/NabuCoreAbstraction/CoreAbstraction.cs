using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities;
using System;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class CoreAbstraction : BaseAbstraction
    {
        public CoreAbstraction() : base()
        {
        }

        public CoreAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Document
         *********************************************************************/
        public Document GetDocument(int pDocumentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentDOL DOL = new CORE.DOL.MSSQL.Core.DocumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDocumentID, pLanguageID);
            }
            else
                return null;
        }

        public Document[] ListDocuments(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentDOL DOL = new CORE.DOL.MSSQL.Core.DocumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Document InsertDocument(Document pDocument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentDOL DOL = new CORE.DOL.MSSQL.Core.DocumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDocument);
            }
            else
                return null;
        }

        public Document UpdateDocument(Document pDocument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentDOL DOL = new CORE.DOL.MSSQL.Core.DocumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDocument);
            }
            else
                return null;
        }

        public Document DeleteDocument(Document pDocument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentDOL DOL = new CORE.DOL.MSSQL.Core.DocumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDocument);
            }
            else
                return null;
        }

        /**********************************************************************
         * Document Sheet
         *********************************************************************/
        public DocumentSheet GetDocumentSheet(int pDocumentSheetID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentSheetDOL DOL = new CORE.DOL.MSSQL.Core.DocumentSheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDocumentSheetID);
            }
            else
                return null;
        }

        public DocumentSheet[] ListDocumentSheets(int pDocumentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentSheetDOL DOL = new CORE.DOL.MSSQL.Core.DocumentSheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pDocumentID);
            }
            else
                return null;
        }

        public DocumentSheet InsertDocumentSheet(DocumentSheet pDocumentSheet, int pDocumentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentSheetDOL DOL = new CORE.DOL.MSSQL.Core.DocumentSheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDocumentSheet, pDocumentID);
            }
            else
                return null;
        }

        public DocumentSheet UpdateDocumentSheet(DocumentSheet pDocumentSheet, int pDocumentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentSheetDOL DOL = new CORE.DOL.MSSQL.Core.DocumentSheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDocumentSheet, pDocumentID);
            }
            else
                return null;
        }

        public DocumentSheet DeleteDocumentSheet(DocumentSheet pDocumentSheet)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentSheetDOL DOL = new CORE.DOL.MSSQL.Core.DocumentSheetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDocumentSheet);
            }
            else
                return null;
        }

        /**********************************************************************
         * Document Type
         *********************************************************************/
        public DocumentType GetDocumentType(int pDocumentTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentTypeDOL DOL = new CORE.DOL.MSSQL.Core.DocumentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDocumentTypeID, pLanguageID);
            }
            else
                return null;
        }

        public DocumentType[] ListDocumentTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentTypeDOL DOL = new CORE.DOL.MSSQL.Core.DocumentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public DocumentType InsertDocumentType(DocumentType pDocumentType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentTypeDOL DOL = new CORE.DOL.MSSQL.Core.DocumentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDocumentType);
            }
            else
                return null;
        }

        public DocumentType UpdateDocumentType(DocumentType pDocumentType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentTypeDOL DOL = new CORE.DOL.MSSQL.Core.DocumentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDocumentType);
            }
            else
                return null;
        }

        public DocumentType DeleteDocumentType(DocumentType pDocumentType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.DocumentTypeDOL DOL = new CORE.DOL.MSSQL.Core.DocumentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDocumentType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Event
         *********************************************************************/
        public Event GetEvent(int pEventID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.EventDOL DOL = new CORE.DOL.MSSQL.Core.EventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pEventID);
            }
            else
                return null;
        }

        public Event[] ListEvents()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.EventDOL DOL = new CORE.DOL.MSSQL.Core.EventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public Event InsertEvent(Event pEvent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.EventDOL DOL = new CORE.DOL.MSSQL.Core.EventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pEvent);
            }
            else
                return null;
        }

        public Event UpdateEvent(Event pEvent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.EventDOL DOL = new CORE.DOL.MSSQL.Core.EventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pEvent);
            }
            else
                return null;
        }

        public Event DeleteEvent(Event pEvent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.EventDOL DOL = new CORE.DOL.MSSQL.Core.EventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pEvent);
            }
            else
                return null;
        }
        /**********************************************************************
         * Formal Organisation
         *********************************************************************/
        public FormalOrganisation AssignFormalOrganisation(FormalOrganisation pFormalOrganisation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.FormalOrganisationDOL DOL = new CORE.DOL.MSSQL.Core.FormalOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pFormalOrganisation);
            }
            else
                return null;
        }

        public FormalOrganisation RemoveFormalOrganisation(FormalOrganisation pFormalOrganisation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.FormalOrganisationDOL DOL = new CORE.DOL.MSSQL.Core.FormalOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pFormalOrganisation);
            }
            else
                return null;
        }
        /**********************************************************************
         * Informal Organisation
         *********************************************************************/
        public InformalOrganisation AssignInformalOrganisation(InformalOrganisation pInformalOrganisation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InformalOrganisationDOL DOL = new CORE.DOL.MSSQL.Core.InformalOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pInformalOrganisation);
            }
            else
                return null;
        }

        public InformalOrganisation RemoveInformalOrganisation(InformalOrganisation pInformalOrganisation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InformalOrganisationDOL DOL = new CORE.DOL.MSSQL.Core.InformalOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pInformalOrganisation);
            }
            else
                return null;
        }
        /**********************************************************************
         * Instrument
         *********************************************************************/
        public Instrument GetInstrument(int pInstrumentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstrumentID,pLanguageID);
            }
            else
                return null;
        }

        public Instrument[] ListInstruments(int pOwnedBy,int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pOwnedBy,pLanguageID);
            }
            else
                return null;
        }

        public Instrument InsertInstrument(Instrument pInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pInstrument);
            }
            else
                return null;
        }

        public Instrument UpdateInstrument(Instrument pInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pInstrument);
            }
            else
                return null;
        }

        public Instrument DeleteInstrument(Instrument pInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pInstrument);
            }
            else
                return null;
        }
        /**********************************************************************
         * Instrument Part
         *********************************************************************/
        public InstrumentPart GetInstrumentPart(int pInstrumentPartID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentPartDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentPartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstrumentPartID, pLanguageID);
            }
            else
                return null;
        }

        public InstrumentPart[] ListInstrumentParts(int pInstrumentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentPartDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentPartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pInstrumentID, pLanguageID);
            }
            else
                return null;
        }

        public InstrumentPart InsertInstrumentPart(InstrumentPart pInstrumentPart, int pInstrumentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentPartDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentPartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pInstrumentPart, pInstrumentID);
            }
            else
                return null;
        }

        public InstrumentPart UpdateInstrumentPart(InstrumentPart pInstrumentPart)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentPartDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentPartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pInstrumentPart);
            }
            else
                return null;
        }

        public InstrumentPart DeleteInstrumentPart(InstrumentPart pInstrumentPart)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentPartDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentPartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pInstrumentPart);
            }
            else
                return null;
        }
        /**********************************************************************
         * Instrument Section
         *********************************************************************/
        public InstrumentSection GetInstrumentSection(int pInstrumentSectionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentSectionDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentSectionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pInstrumentSectionID, pLanguageID);
            }
            else
                return null;
        }

        public InstrumentSection[] ListInstrumentSections(int pInstrumentPartID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentSectionDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentSectionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pInstrumentPartID, pLanguageID);
            }
            else
                return null;
        }

        public InstrumentSection InsertInstrumentSection(InstrumentSection pInstrumentSection, int pInstrumentPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentSectionDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentSectionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pInstrumentSection, pInstrumentPartID);
            }
            else
                return null;
        }

        public InstrumentSection UpdateInstrumentSection(InstrumentSection pInstrumentSection)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentSectionDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentSectionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pInstrumentSection);
            }
            else
                return null;
        }

        public InstrumentSection DeleteInstrumentSection(InstrumentSection pInstrumentSection)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentSectionDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentSectionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pInstrumentSection);
            }
            else
                return null;
        }
        /**********************************************************************
         * Instrument Items
         *********************************************************************/
        public BaseBoolean InsertInstrumentItem(int pInstrumentSectionID, int pItemID, int pDisplaySequence, int pAttemptNumber)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentSectionDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentSectionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AddItemToSection(pInstrumentSectionID, pItemID, pDisplaySequence, pAttemptNumber);
            }
            else
                return null;
        }

        public BaseBoolean DeleteItemsInInstrumentSection(int pInstrumentSectionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.InstrumentSectionDOL DOL = new CORE.DOL.MSSQL.Core.InstrumentSectionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.DeleteAllInSection(pInstrumentSectionID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Organisation
         *********************************************************************/
        public Organisation GetOrganisation(int pOrganisationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.OrganisationDOL DOL = new CORE.DOL.MSSQL.Core.OrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pOrganisationID, pLanguageID);
            }
            else
                return null;
        }

        public Organisation[] ListOrganisations(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.OrganisationDOL DOL = new CORE.DOL.MSSQL.Core.OrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Organisation[] ListOrganisationsByPartyTypeAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.OrganisationDOL DOL = new CORE.DOL.MSSQL.Core.OrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPartyTypeAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public Organisation InsertOrganisation(Organisation pOrganisation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.OrganisationDOL DOL = new CORE.DOL.MSSQL.Core.OrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pOrganisation);
            }
            else
                return null;
        }

        public Organisation UpdateOrganisation(Organisation pOrganisation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.OrganisationDOL DOL = new CORE.DOL.MSSQL.Core.OrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pOrganisation);
            }
            else
                return null;
        }

        public Organisation DeleteOrganisation(Organisation pOrganisation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.OrganisationDOL DOL = new CORE.DOL.MSSQL.Core.OrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pOrganisation);
            }
            else
                return null;
        }
        /**********************************************************************
         * Paper Instrument
         *********************************************************************/
        public PaperInstrument AssignPaperInstrument(PaperInstrument pPaperInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PaperInstrumentDOL DOL = new CORE.DOL.MSSQL.Core.PaperInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pPaperInstrument);
            }
            else
                return null;
        }

        public PaperInstrument RemovePaperInstrument(PaperInstrument pPaperInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PaperInstrumentDOL DOL = new CORE.DOL.MSSQL.Core.PaperInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pPaperInstrument);
            }
            else
                return null;
        }

        /**********************************************************************
         * Party Attribute
         *********************************************************************/
        public PartyAttribute GetPartyAttribute(int pPartyAttributeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyAttributeID, pLanguageID);
            }
            else
                return null;
        }

        public PartyAttribute[] ListPartyAttributes(int pPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyID, pLanguageID);
            }
            else
                return null;
        }

        public PartyAttribute[] ListPartyAttributesInGroup(int pPartyID, int pPartyAttributeGroupID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListInGroup(pPartyID, pPartyAttributeGroupID, pLanguageID);
            }
            else
                return null;
        }

        public PartyAttribute InsertPartyAttribute(PartyAttribute pPartyAttribute, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyAttribute, pPartyID);
            }
            else
                return null;
        }

        public PartyAttribute UpdatePartyAttribute(PartyAttribute pPartyAttribute)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyAttribute);
            }
            else
                return null;
        }

        public PartyAttribute DeletePartyAttribute(PartyAttribute pPartyAttribute)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyAttribute);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * Party Attribute Data Type
         *********************************************************************/
        public PartyAttributeDataType GetPartyAttributeDataType(int pPartyAttributeDataTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyAttributeDataTypeID, pLanguageID);
            }
            else
                return null;
        }

        public PartyAttributeDataType[] ListPartyAttributeDataTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PartyAttributeDataType InsertPartyAttributeDataType(PartyAttributeDataType pPartyAttributeDataType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyAttributeDataType);
            }
            else
                return null;
        }

        public PartyAttributeDataType UpdatePartyAttributeDataType(PartyAttributeDataType pPartyAttributeDataType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyAttributeDataType);
            }
            else
                return null;
        }

        public PartyAttributeDataType DeletePartyAttributeDataType(PartyAttributeDataType pPartyAttributeDataType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyAttributeDataType);
            }
            else
                return null;
        }

        /**********************************************************************
         * Party Attribute Group
         *********************************************************************/
        public PartyAttributeGroup GetPartyAttributeGroup(int pPartyAttributeGroupID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyAttributeGroupID, pLanguageID);
            }
            else
                return null;
        }

        public PartyAttributeGroup GetPartyAttributeGroupByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PartyAttributeGroup[] ListPartyAttributeGroups(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PartyAttributeGroup InsertPartyAttributeGroup(PartyAttributeGroup pPartyAttributeGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyAttributeGroup);
            }
            else
                return null;
        }

        public PartyAttributeGroup UpdatePartyAttributeGroup(PartyAttributeGroup pPartyAttributeGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyAttributeGroup);
            }
            else
                return null;
        }

        public PartyAttributeGroup DeletePartyAttributeGroup(PartyAttributeGroup pPartyAttributeGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyAttributeGroup);
            }
            else
                return null;
        }

        /**********************************************************************
         * Party Attribute Type
         *********************************************************************/
        public PartyAttributeType GetPartyAttributeType(int pPartyAttributeTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyAttributeTypeID, pLanguageID);
            }
            else
                return null;
        }

        public PartyAttributeType GetPartyAttributeTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PartyAttributeType[] ListPartyAttributeTypes(int pPartyTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyTypeID, pLanguageID);
            }
            else
                return null;
        }

        public PartyAttributeType[] ListPartyAttributeTypesInGroup(int pPartyTypeID, int pPartyAttributeGroupID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListInGroup(pPartyTypeID, pPartyAttributeGroupID ,pLanguageID);
            }
            else
                return null;
        }

        public PartyAttributeType InsertPartyAttributeType(PartyAttributeType pPartyAttributeType, int pPartyTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyAttributeType, pPartyTypeID);
            }
            else
                return null;
        }

        public PartyAttributeType UpdatePartyAttributeType(PartyAttributeType pPartyAttributeType, int pPartyTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyAttributeType, pPartyTypeID);
            }
            else
                return null;
        }

        public PartyAttributeType DeletePartyAttributeType(PartyAttributeType pPartyAttributeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyAttributeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyAttributeType);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * Party Contact Mechanism
         *********************************************************************/
        public PartyContactMechanism GetPartyContactMechanism(int pPartyContactMechanismID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyContactMechanismDOL DOL = new CORE.DOL.MSSQL.Core.PartyContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyContactMechanismID);
            }
            else
                return null;
        }

        public PartyContactMechanism[] ListPartyContactMechanisms(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyContactMechanismDOL DOL = new CORE.DOL.MSSQL.Core.PartyContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyID);
            }
            else
                return null;
        }

        public PartyContactMechanism[] ListPartyContactMechanismsLikeContactMechanismType(int pPartyID, string pLikeContactMechanismTypeAlias)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyContactMechanismDOL DOL = new CORE.DOL.MSSQL.Core.PartyContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListWhereContactMechanismTypeIsLike(pPartyID, pLikeContactMechanismTypeAlias);
            }
            else
                return null;
        }

        public PartyContactMechanism InsertPartyContactMechanism(PartyContactMechanism pPartyContactMechanism, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyContactMechanismDOL DOL = new CORE.DOL.MSSQL.Core.PartyContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyContactMechanism, pPartyID);
            }
            else
                return null;
        }

        public PartyContactMechanism UpdatePartyContactMechanism(PartyContactMechanism pPartyContactMechanism, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyContactMechanismDOL DOL = new CORE.DOL.MSSQL.Core.PartyContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyContactMechanism, pPartyID);
            }
            else
                return null;
        }

        public PartyContactMechanism DeletePartyContactMechanism(PartyContactMechanism pPartyContactMechanism)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyContactMechanismDOL DOL = new CORE.DOL.MSSQL.Core.PartyContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyContactMechanism);
            }
            else
                return null;
        }

        public PartyContactMechanism AssignPartyContactMechanismPurposeType(int pPartyContactMechanismID, int pContactMechanismPurposeTypeID, DateTime pFromDate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyContactMechanismDOL DOL = new CORE.DOL.MSSQL.Core.PartyContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignPurposeType(pPartyContactMechanismID,pContactMechanismPurposeTypeID,pFromDate);
            }
            else
                return null;
        }
        
        public PartyContactMechanism RemovePartyContactMechanismPurposeType(int pPartyContactMechanismID, int pContactMechanismPurposeTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyContactMechanismDOL DOL = new CORE.DOL.MSSQL.Core.PartyContactMechanismDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemovePurposeType(pPartyContactMechanismID, pContactMechanismPurposeTypeID);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * Party
         *********************************************************************/
        public Party GetParty(int pPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyDOL DOL = new CORE.DOL.MSSQL.Core.PartyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyID, pLanguageID);
            }
            else
                return null;
        }

        public Party[] ListParties(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyDOL DOL = new CORE.DOL.MSSQL.Core.PartyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Party[] ListParties(int pPartyTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyDOL DOL = new CORE.DOL.MSSQL.Core.PartyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyTypeID, pLanguageID);
            }
            else
                return null;
        }

        public Party InsertParty(Party pParty)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyDOL DOL = new CORE.DOL.MSSQL.Core.PartyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pParty);
            }
            else
                return null;
        }

        public Party UpdateParty(Party pParty)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyDOL DOL = new CORE.DOL.MSSQL.Core.PartyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pParty);
            }
            else
                return null;
        }

        public Party DeleteParty(Party pParty)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyDOL DOL = new CORE.DOL.MSSQL.Core.PartyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pParty);
            }
            else
                return null;
        }
        
        public Party AssignContentToParty(int pPartyID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyDOL DOL = new CORE.DOL.MSSQL.Core.PartyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignContent(pPartyID, pContentID);
            }
            else
                return null;
        }

        public Party RemoveContentFromParty(int pPartyID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyDOL DOL = new CORE.DOL.MSSQL.Core.PartyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveContent(pPartyID, pContentID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Party Group
         *********************************************************************/
        public PartyGroup GetPartyGroup(int pPartyGroupID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyGroupID, pLanguageID);
            }
            else
                return null;
        }

        public PartyGroup[] ListPartyGroups(int pPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyID, pLanguageID);
            }
            else
                return null;
        }

        public PartyGroup InsertPartyGroup(PartyGroup pPartyGroup, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyGroup, pPartyID);
            }
            else
                return null;
        }

        public PartyGroup UpdatePartyGroup(PartyGroup pPartyGroup, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyGroup, pPartyID);
            }
            else
                return null;
        }

        public PartyGroup DeletePartyGroup(PartyGroup pPartyGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyGroup);
            }
            else
                return null;
        }

        public BaseBoolean AssignMemberToPartyGroup(int pPartyGroupID, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignMember(pPartyGroupID, pPartyID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveMemberFromPartyGroup(int pPartyGroupID, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveMember(pPartyGroupID, pPartyID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Party Group Type
         *********************************************************************/
        public PartyGroupType GetPartyGroupType(int pPartyGroupTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyGroupTypeID, pLanguageID);
            }
            else
                return null;
        }

        public PartyGroupType GetPartyGroupType(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PartyGroupType[] ListPartyGroupTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PartyGroupType InsertPartyGroupType(PartyGroupType pPartyGroupType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyGroupType);
            }
            else
                return null;
        }

        public PartyGroupType UpdatePartyGroupType(PartyGroupType pPartyGroupType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyGroupType);
            }
            else
                return null;
        }

        public PartyGroupType DeletePartyGroupType(PartyGroupType pPartyGroupType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyGroupTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyGroupTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyGroupType);
            }
            else
                return null;
        }

        /**********************************************************************
         * Party Relationship
         *********************************************************************/
        public PartyRelationship GetPartyRelationship(int pPartyRelationshipID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyRelationshipID, pLanguageID);
            }
            else
                return null;
        }

        public PartyRelationship GetPartyRelationshipByParties(int pFromPartyID, int pToPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByParties(pFromPartyID, pToPartyID, pLanguageID);
            }
            else
                return null;
        }

        public PartyRelationship[] ListPartyRelationshipsTo(int pToPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListTo(pToPartyID, pLanguageID);
            }
            else
                return null;
        }

        public PartyRelationship[] ListPartyRelationshipsFrom(int pFromPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFrom(pFromPartyID, pLanguageID);
            }
            else
                return null;
        }

        public PartyRelationship InsertPartyRelationship(PartyRelationship pPartyRelationship)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyRelationship);
            }
            else
                return null;
        }

        public PartyRelationship UpdatePartyRelationship(PartyRelationship pPartyRelationship)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyRelationship);
            }
            else
                return null;
        }

        public PartyRelationship DeletePartyRelationship(PartyRelationship pPartyRelationship)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyRelationship);
            }
            else
                return null;
        }
        /**********************************************************************
         * Party Relationship Type
         *********************************************************************/
        public PartyRelationshipType GetPartyRelationshipType(int pPartyRelationshipTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyRelationshipTypeID, pLanguageID);
            }
            else
                return null;
        }

        public PartyRelationshipType GetPartyRelationshipTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PartyRelationshipType[] ListPartyRelationshipTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PartyRelationshipType InsertPartyRelationshipType(PartyRelationshipType pPartyRelationshipType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyRelationshipType);
            }
            else
                return null;
        }

        public PartyRelationshipType UpdatePartyRelationshipType(PartyRelationshipType pPartyRelationshipType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyRelationshipType);
            }
            else
                return null;
        }

        public PartyRelationshipType DeletePartyRelationshipType(PartyRelationshipType pPartyRelationshipType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRelationshipTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRelationshipTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyRelationshipType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Party Role
         *********************************************************************/
        public PartyRole GetPartyRole(int pPartyRoleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyRoleID, pLanguageID);
            }
            else
                return null;
        }

        public PartyRole GetPartyRoleByAlias(int pPartyID, string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pPartyID, pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PartyRole[] ListPartyRoles(int pPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyID, pLanguageID);
            }
            else
                return null;
        }

        public PartyRole InsertPartyRole(PartyRole pPartyRole, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyRole, pPartyID);
            }
            else
                return null;
        }

        public PartyRole UpdatePartyRole(PartyRole pPartyRole, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyRole, pPartyID);
            }
            else
                return null;
        }

        public PartyRole DeletePartyRole(PartyRole pPartyRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyRole);
            }
            else
                return null;
        }
        /**********************************************************************
         * Party Role Type
         *********************************************************************/
        public PartyRoleType GetPartyRoleType(int pPartyRoleTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyRoleTypeID, pLanguageID);
            }
            else
                return null;
        }

        public PartyRoleType GetPartyRoleTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PartyRoleType[] ListPartyRoleTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PartyRoleType[] ListPartyRoleTypes(Entities.Education.EducationProvider pEducationProvider, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pEducationProvider, pLanguageID);
            }
            else
                return null;
        }

        public PartyRoleType InsertPartyRoleType(PartyRoleType pPartyRoleType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyRoleType);
            }
            else
                return null;
        }

        public PartyRoleType UpdatePartyRoleType(PartyRoleType pPartyRoleType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyRoleType);
            }
            else
                return null;
        }

        public PartyRoleType DeletePartyRoleType(PartyRoleType pPartyRoleType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyRoleTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyRoleTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyRoleType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Party Type
         *********************************************************************/
        public PartyType GetPartyType(int pPartyTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyTypeID, pLanguageID);
            }
            else
                return null;
        }

        public PartyType GetPartyTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PartyType[] ListPartyTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PartyType InsertPartyType(PartyType pPartyType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyType);
            }
            else
                return null;
        }

        public PartyType UpdatePartyType(PartyType pPartyType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyType);
            }
            else
                return null;
        }

        public PartyType DeletePartyType(PartyType pPartyType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.PartyTypeDOL DOL = new CORE.DOL.MSSQL.Core.PartyTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Sharing
         *********************************************************************/
        public Sharing GetShare(int pShareID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.SharingDOL DOL = new CORE.DOL.MSSQL.Core.SharingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pShareID);
            }
            else
                return null;
        }

        public Sharing GetShareByRetreivalToken(string pRetreivalToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.SharingDOL DOL = new CORE.DOL.MSSQL.Core.SharingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByRetrievalToken(pRetreivalToken);
            }
            else
                return null;
        }
        public Sharing[] ListShares(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.SharingDOL DOL = new CORE.DOL.MSSQL.Core.SharingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyID);
            }
            else
                return null;
        }

        public Sharing InsertShare(Sharing pShare)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.SharingDOL DOL = new CORE.DOL.MSSQL.Core.SharingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pShare);
            }
            else
                return null;
        }

        public Sharing UpdateShare(Sharing pShare)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.SharingDOL DOL = new CORE.DOL.MSSQL.Core.SharingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pShare);
            }
            else
                return null;
        }

        public Sharing DeleteShare(Sharing pShare)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.SharingDOL DOL = new CORE.DOL.MSSQL.Core.SharingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pShare);
            }
            else
                return null;
        }

        /**********************************************************************
         * Sheet Definition
         *********************************************************************/
        public SheetDefinition GetSheetDefinition(int pSheetDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.SheetDefinitionDOL DOL = new CORE.DOL.MSSQL.Core.SheetDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSheetDefinitionID);
            }
            else
                return null;
        }

        public SheetDefinition[] ListSheetDefinitions(int pPaperInstrumentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.SheetDefinitionDOL DOL = new CORE.DOL.MSSQL.Core.SheetDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPaperInstrumentID);
            }
            else
                return null;
        }

        public SheetDefinition InsertSheetDefinition(SheetDefinition pSheetDefinition, int pPaperInstrumentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.SheetDefinitionDOL DOL = new CORE.DOL.MSSQL.Core.SheetDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSheetDefinition, pPaperInstrumentID);
            }
            else
                return null;
        }

        public SheetDefinition UpdateSheetDefinition(SheetDefinition pSheetDefinition, int pPaperInstrumentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.SheetDefinitionDOL DOL = new CORE.DOL.MSSQL.Core.SheetDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSheetDefinition, pPaperInstrumentID);
            }
            else
                return null;
        }

        public SheetDefinition DeleteSheetDefinition(SheetDefinition pSheetDefinition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.SheetDefinitionDOL DOL = new CORE.DOL.MSSQL.Core.SheetDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSheetDefinition);
            }
            else
                return null;
        }
    }
}
