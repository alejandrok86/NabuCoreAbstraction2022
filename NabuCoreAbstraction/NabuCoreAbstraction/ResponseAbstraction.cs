using Octavo.Gate.Nabu.CORE.Entities.Response;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class ResponseAbstraction : BaseAbstraction
    {
        public ResponseAbstraction() : base()
        {
        }

        public ResponseAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Assessment Instrument Response
         *********************************************************************/
        public AssessmentInstrumentResponse GetAssessmentInstrumentResponse(int pAssessmentInstrumentResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAssessmentInstrumentResponseID);
            }
            else
                return null;
        }

        public AssessmentInstrumentResponse[] ListAssessmentInstrumentResponses()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public AssessmentInstrumentResponse[] ListAssessmentInstrumentResponsesByAssessmentEvent(int pAssessmentEventID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByAssessmentEvent(pAssessmentEventID);
            }
            else
                return null;
        }

        public AssessmentInstrumentResponse[] ListAssessmentInstrumentResponsesByLearner(int pLearnerID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByLearner(pLearnerID);
            }
            else
                return null;
        }

        public AssessmentInstrumentResponse[] ListAssessmentInstrumentResponsesByRespondent(int pRespondentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByRespondent(pRespondentID);
            }
            else
                return null;
        }

        public AssessmentInstrumentResponse InsertAssessmentInstrumentResponse(AssessmentInstrumentResponse pAssessmentInstrumentResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAssessmentInstrumentResponse);
            }
            else
                return null;
        }

        public AssessmentInstrumentResponse UpdateAssessmentInstrumentResponse(AssessmentInstrumentResponse pAssessmentInstrumentResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAssessmentInstrumentResponse);
            }
            else
                return null;
        }

        public AssessmentInstrumentResponse DeleteAssessmentInstrumentResponse(AssessmentInstrumentResponse pAssessmentInstrumentResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.AssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAssessmentInstrumentResponse);
            }
            else
                return null;
        }

        /**********************************************************************
         * Clinical Assessment Instrument Response
         *********************************************************************/
        public ClinicalAssessmentInstrumentResponse GetClinicalAssessmentInstrumentResponse(int pClinicalAssessmentInstrumentResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pClinicalAssessmentInstrumentResponseID);
            }
            else
                return null;
        }

        public ClinicalAssessmentInstrumentResponse[] ListClinicalAssessmentInstrumentResponses()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public ClinicalAssessmentInstrumentResponse[] ListClinicalAssessmentInstrumentResponsesByPatientNonTrial(int pPatientID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPatientNonTrial(pPatientID, pLanguageID);
            }
            else
                return null;
        }

        public ClinicalAssessmentInstrumentResponse[] ListClinicalAssessmentInstrumentResponsesByPatientInTrial(int pPatientID, int pClinicalTrialID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPatientInTrial(pPatientID, pClinicalTrialID);
            }
            else
                return null;
        }

        public ClinicalAssessmentInstrumentResponse InsertClinicalAssessmentInstrumentResponse(ClinicalAssessmentInstrumentResponse pClinicalAssessmentInstrumentResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pClinicalAssessmentInstrumentResponse);
            }
            else
                return null;
        }

        public ClinicalAssessmentInstrumentResponse UpdateClinicalAssessmentInstrumentResponse(ClinicalAssessmentInstrumentResponse pClinicalAssessmentInstrumentResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pClinicalAssessmentInstrumentResponse);
            }
            else
                return null;
        }

        public ClinicalAssessmentInstrumentResponse DeleteClinicalAssessmentInstrumentResponse(ClinicalAssessmentInstrumentResponse pClinicalAssessmentInstrumentResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.ClinicalAssessmentInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pClinicalAssessmentInstrumentResponse);
            }
            else
                return null;
        }

        /**********************************************************************
         * Item Body Response
         *********************************************************************/
        public ItemBodyResponse GetItemBodyResponse(int pItemBodyResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemBodyResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemBodyResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pItemBodyResponseID);
            }
            else
                return null;
        }

        public ItemBodyResponse[] ListItemBodyResponses(int pItemResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemBodyResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemBodyResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pItemResponseID);
            }
            else
                return null;
        }

        public ItemBodyResponse InsertItemBodyResponse(ItemBodyResponse pItemBodyResponse, int pItemResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemBodyResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemBodyResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pItemBodyResponse, pItemResponseID);
            }
            else
                return null;
        }

        public ItemBodyResponse UpdateItemBodyResponse(ItemBodyResponse pItemBodyResponse, int pItemResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemBodyResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemBodyResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pItemBodyResponse, pItemResponseID);
            }
            else
                return null;
        }

        public ItemBodyResponse DeleteItemBodyResponse(ItemBodyResponse pItemBodyResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemBodyResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemBodyResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pItemBodyResponse);
            }
            else
                return null;
        }
        /**********************************************************************
         * Item Response
         *********************************************************************/
        public ItemResponse GetItemResponse(int pItemResponseID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pItemResponseID, pLanguageID);
            }
            else
                return null;
        }

        public ItemResponse[] ListItemResponses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ItemResponse[] ListItemResponsesByResponse(int pResponseID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByResponse(pResponseID, pLanguageID);
            }
            else
                return null;
        }

        public ItemResponse[] ListItemResponsesByResponseIncludingOutcomes(int pResponseID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseDOL itemResponseDOL = new CORE.DOL.MSSQL.Response.ItemResponseDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseOutcomeDOL itemResponseOutcomeDOL = new CORE.DOL.MSSQL.Response.ItemResponseOutcomeDOL(base.ConnectionString, base.ErrorLogFile);

                ItemResponse[] itemResponses = itemResponseDOL.ListByResponse(pResponseID, pLanguageID);
                for (int idx = 0; idx < itemResponses.Length; idx++)
                    itemResponses[idx].ItemResponseOutcomes = itemResponseOutcomeDOL.List((int)itemResponses[idx].ItemResponseID, pLanguageID);
                return itemResponses;
            }
            else
                return null;
        }

        public ItemResponse[] ListItemResponsesByItemAndResponse(int pItemID, int pResponseID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemBodyDOL bodyDOL = new CORE.DOL.MSSQL.Item.ItemBodyDOL(base.ConnectionString, base.ErrorLogFile);
                ItemResponse[] itemResponses = DOL.ListByItemAndResponse(pItemID, pResponseID, pLanguageID);
                if (itemResponses.Length > 0)
                {
                    if (itemResponses[0].ErrorsDetected == false)
                    {
                        foreach (ItemResponse itemResponse in itemResponses)
                        {
                            itemResponse.ItemBodyResponses = ListItemBodyResponses((int)itemResponse.ItemResponseID);
                            if (itemResponse.ItemBodyResponses[0].ErrorsDetected == false)
                            {

                                foreach (ItemBodyResponse itemBodyResponse in itemResponse.ItemBodyResponses)
                                {
                                    itemBodyResponse.ItemBody = bodyDOL.Get((int)itemBodyResponse.ItemBody.ContentID);
                                }
                            }
                        }
                    }
                }
                return itemResponses;
            }
            else
                return null;
        }

        public ItemResponse[] ListItemResponsesByItemAndRespondent(int pItemID, int pRespondentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item.ItemBodyDOL bodyDOL = new CORE.DOL.MSSQL.Item.ItemBodyDOL(base.ConnectionString, base.ErrorLogFile);
                ItemResponse[] itemResponses = DOL.ListByItemAndRespondent(pItemID, pRespondentID, pLanguageID);
                if (itemResponses.Length > 0)
                {
                    if (itemResponses[0].ErrorsDetected == false)
                    {
                        foreach (ItemResponse itemResponse in itemResponses)
                        {
                            itemResponse.ItemBodyResponses = ListItemBodyResponses((int)itemResponse.ItemResponseID);
                            if (itemResponse.ItemBodyResponses[0].ErrorsDetected == false)
                            {

                                foreach (ItemBodyResponse itemBodyResponse in itemResponse.ItemBodyResponses)
                                {
                                    itemBodyResponse.ItemBody = bodyDOL.Get((int)itemBodyResponse.ItemBody.ContentID);
                                }
                            }
                        }
                    }
                }
                return itemResponses;
            }
            else
                return null;
        }

        public BaseInteger CountItemResponses(int pResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Count(pResponseID);
            }
            else
                return null;
        }

        public ItemResponse InsertItemResponse(ItemResponse pItemResponse, int pResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pItemResponse, pResponseID);
            }
            else
                return null;
        }

        public ItemResponse UpdateItemResponse(ItemResponse pItemResponse, int pResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pItemResponse, pResponseID);
            }
            else
                return null;
        }

        public ItemResponse DeleteItemResponse(ItemResponse pItemResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pItemResponse);
            }
            else
                return null;
        }
        /**********************************************************************
         * Item Response Outcome
         *********************************************************************/
        public ItemResponseOutcome GetItemResponseOutcome(int pItemResponseOutcomeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseOutcomeDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pItemResponseOutcomeID, pLanguageID);
            }
            else
                return null;
        }

        public ItemResponseOutcome[] ListItemResponseOutcomes(int pItemResponseID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseOutcomeDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pItemResponseID, pLanguageID);
            }
            else
                return null;
        }

        public ItemResponseOutcome InsertItemResponseOutcome(ItemResponseOutcome pItemResponseOutcome, int pItemResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseOutcomeDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pItemResponseOutcome, pItemResponseID);
            }
            else
                return null;
        }

        public ItemResponseOutcome UpdateItemResponseOutcome(ItemResponseOutcome pItemResponseOutcome, int pItemResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseOutcomeDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pItemResponseOutcome, pItemResponseID);
            }
            else
                return null;
        }

        public ItemResponseOutcome DeleteItemResponseOutcome(ItemResponseOutcome pItemResponseOutcome)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseOutcomeDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pItemResponseOutcome);
            }
            else
                return null;
        }
        /**********************************************************************
         * Item Response Type
         *********************************************************************/
        public ItemResponseType GetItemResponseType(int pItemResponseTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseTypeDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pItemResponseTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ItemResponseType GetItemResponseTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseTypeDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ItemResponseType[] ListItemResponseTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseTypeDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ItemResponseType InsertItemResponseType(ItemResponseType pItemResponseType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseTypeDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pItemResponseType);
            }
            else
                return null;
        }

        public ItemResponseType UpdateItemResponseType(ItemResponseType pItemResponseType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseTypeDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pItemResponseType);
            }
            else
                return null;
        }

        public ItemResponseType DeleteItemResponseType(ItemResponseType pItemResponseType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ItemResponseTypeDOL DOL = new CORE.DOL.MSSQL.Response.ItemResponseTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pItemResponseType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Learning Instrument Response
         *********************************************************************/
        public LearningInstrumentResponse GetLearningInstrumentResponse(int pLearningInstrumentResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLearningInstrumentResponseID);
            }
            else
                return null;
        }

        public LearningInstrumentResponse[] ListLearningInstrumentResponses()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public LearningInstrumentResponse[] ListLearningInstrumentResponsesByLearningEvent(int pLearningEventID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByLearningEvent(pLearningEventID);
            }
            else
                return null;
        }

        public LearningInstrumentResponse[] ListLearningInstrumentResponsesByLearner(int pLearnerID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByLearner(pLearnerID);
            }
            else
                return null;
        }

        public LearningInstrumentResponse[] ListLearningInstrumentResponsesByRespondent(int pRespondentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByRespondent(pRespondentID);
            }
            else
                return null;
        }

        public LearningInstrumentResponse InsertLearningInstrumentResponse(LearningInstrumentResponse pLearningInstrumentResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pLearningInstrumentResponse);
            }
            else
                return null;
        }

        public LearningInstrumentResponse UpdateLearningInstrumentResponse(LearningInstrumentResponse pLearningInstrumentResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pLearningInstrumentResponse);
            }
            else
                return null;
        }

        public LearningInstrumentResponse DeleteLearningInstrumentResponse(LearningInstrumentResponse pLearningInstrumentResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL DOL = new CORE.DOL.MSSQL.Response.LearningInstrumentResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pLearningInstrumentResponse);
            }
            else
                return null;
        }
        /**********************************************************************
         * Respondent
         *********************************************************************/
        public Respondent AssignRespondent(int pRespondentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.RespondentDOL DOL = new CORE.DOL.MSSQL.Response.RespondentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pRespondentID);
            }
            else
                return null;
        }

        public Respondent RemoveRespondent(int pRespondentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.RespondentDOL DOL = new CORE.DOL.MSSQL.Response.RespondentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pRespondentID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Response
         *********************************************************************/
        public Response GetResponse(int pResponseID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseDOL DOL = new CORE.DOL.MSSQL.Response.ResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pResponseID, pLanguageID);
            }
            else
                return null;
        }

        public Response[] ListResponses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseDOL DOL = new CORE.DOL.MSSQL.Response.ResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Response InsertResponse(Response pResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseDOL DOL = new CORE.DOL.MSSQL.Response.ResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pResponse);
            }
            else
                return null;
        }

        public Response UpdateResponse(Response pResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseDOL DOL = new CORE.DOL.MSSQL.Response.ResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pResponse);
            }
            else
                return null;
        }

        public Response DeleteResponse(Response pResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseDOL DOL = new CORE.DOL.MSSQL.Response.ResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pResponse);
            }
            else
                return null;
        }

        public Response DeleteCompleteResponse(Response pResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseDOL DOL = new CORE.DOL.MSSQL.Response.ResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.DeleteComplete(pResponse);
            }
            else
                return null;
        }

        public BaseType ResponseContentAssign(int pResponseID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseDOL DOL = new CORE.DOL.MSSQL.Response.ResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pResponseID, pContentID);
            }
            else
                return null;
        }

        public BaseType ResponseContentRemove(int pResponseID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseDOL DOL = new CORE.DOL.MSSQL.Response.ResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pResponseID, pContentID);
            }
            else
                return null;
        }

        /**********************************************************************
         * ResponseAudit
         *********************************************************************/
        public ResponseAudit[] ListResponseAudit(int pResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseAuditDOL DOL = new CORE.DOL.MSSQL.Response.ResponseAuditDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pResponseID);
            }
            else
                return null;
        }

        public ResponseAudit InsertResponseAudit(ResponseAudit pResponseAudit)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseAuditDOL DOL = new CORE.DOL.MSSQL.Response.ResponseAuditDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pResponseAudit);
            }
            else
                return null;
        }

        /**********************************************************************
         * Response Outcome
         *********************************************************************/
        public ResponseOutcome GetResponseOutcome(int pResponseOutcomeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseOutcomeDOL DOL = new CORE.DOL.MSSQL.Response.ResponseOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pResponseOutcomeID);
            }
            else
                return null;
        }

        public ResponseOutcome[] ListResponseOutcomes(int pResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseOutcomeDOL DOL = new CORE.DOL.MSSQL.Response.ResponseOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pResponseID);
            }
            else
                return null;
        }

        public ResponseOutcome InsertResponseOutcome(ResponseOutcome pResponseOutcome, int pResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseOutcomeDOL DOL = new CORE.DOL.MSSQL.Response.ResponseOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pResponseOutcome, pResponseID);
            }
            else
                return null;
        }

        public ResponseOutcome UpdateResponseOutcome(ResponseOutcome pResponseOutcome, int pResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseOutcomeDOL DOL = new CORE.DOL.MSSQL.Response.ResponseOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pResponseOutcome, pResponseID);
            }
            else
                return null;
        }

        public ResponseOutcome DeleteResponseOutcome(ResponseOutcome pResponseOutcome)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseOutcomeDOL DOL = new CORE.DOL.MSSQL.Response.ResponseOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pResponseOutcome);
            }
            else
                return null;
        }
        /**********************************************************************
         * Response Type
         *********************************************************************/
        public ResponseType GetResponseType(int pResponseTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseTypeDOL DOL = new CORE.DOL.MSSQL.Response.ResponseTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pResponseTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ResponseType GetResponseTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseTypeDOL DOL = new CORE.DOL.MSSQL.Response.ResponseTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ResponseType[] ListResponseTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseTypeDOL DOL = new CORE.DOL.MSSQL.Response.ResponseTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ResponseType InsertResponseType(ResponseType pResponseType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseTypeDOL DOL = new CORE.DOL.MSSQL.Response.ResponseTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pResponseType);
            }
            else
                return null;
        }

        public ResponseType UpdateResponseType(ResponseType pResponseType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseTypeDOL DOL = new CORE.DOL.MSSQL.Response.ResponseTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pResponseType);
            }
            else
                return null;
        }

        public ResponseType DeleteResponseType(ResponseType pResponseType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseTypeDOL DOL = new CORE.DOL.MSSQL.Response.ResponseTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pResponseType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Response Progress
         *********************************************************************/
        public BaseDecimal GetLearnerSubscriptionProgress(LearnerSubscriptionProgress pLearnerSubscriptionProgress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseProgressDOL DOL = new CORE.DOL.MSSQL.Response.ResponseProgressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLearnerSubscriptionProgress);
            }
            else
                return null;
        }
        public BaseDecimal GetModuleProgress(ModuleProgress pModuleProgress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseProgressDOL DOL = new CORE.DOL.MSSQL.Response.ResponseProgressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pModuleProgress);
            }
            else
                return null;
        }
        public BaseDecimal GetUnitProgress(UnitProgress pUnitProgress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseProgressDOL DOL = new CORE.DOL.MSSQL.Response.ResponseProgressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUnitProgress);
            }
            else
                return null;
        }
        public BaseDecimal GetUnitComponentProgress(UnitComponentProgress pUnitComponentProgress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseProgressDOL DOL = new CORE.DOL.MSSQL.Response.ResponseProgressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUnitComponentProgress);
            }
            else
                return null;
        }
        public BaseBoolean UpdateLearnerSubscriptionProgress(LearnerSubscriptionProgress pLearnerSubscriptionProgress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseProgressDOL DOL = new CORE.DOL.MSSQL.Response.ResponseProgressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pLearnerSubscriptionProgress);
            }
            else
                return null;
        }
        public BaseBoolean UpdateModuleProgress(ModuleProgress pModuleProgress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseProgressDOL DOL = new CORE.DOL.MSSQL.Response.ResponseProgressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pModuleProgress);
            }
            else
                return null;
        }
        public BaseBoolean UpdateUnitProgress(UnitProgress pUnitProgress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseProgressDOL DOL = new CORE.DOL.MSSQL.Response.ResponseProgressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pUnitProgress);
            }
            else
                return null;
        }
        public BaseBoolean UpdateUnitComponentProgress(UnitComponentProgress pUnitComponentProgress)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response.ResponseProgressDOL DOL = new CORE.DOL.MSSQL.Response.ResponseProgressDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pUnitComponentProgress);
            }
            else
                return null;
        }
    }
}
