using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare
{
    public class ClinicalAssessmentInstrumentDOL : BaseDOL
    {
        public ClinicalAssessmentInstrumentDOL() : base ()
        {
        }

        public ClinicalAssessmentInstrumentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ClinicalAssessmentInstrument Get(int? pClinicalAssessmentInstrumentID, int pLanguageID)
        {
            ClinicalAssessmentInstrument clinicalAssessmentInstrument = new ClinicalAssessmentInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalAssessmentInstrument_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentID", pClinicalAssessmentInstrumentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
		                clinicalAssessmentInstrument = new ClinicalAssessmentInstrument(sqlDataReader.GetInt32(0),sqlDataReader.GetInt32(1));
		                clinicalAssessmentInstrument.PartCode = sqlDataReader.GetString(2);
		                clinicalAssessmentInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
		                clinicalAssessmentInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
		                clinicalAssessmentInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
		                clinicalAssessmentInstrument.InstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            clinicalAssessmentInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if(sqlDataReader.IsDBNull(8)==false)
                            clinicalAssessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            clinicalAssessmentInstrument.IsPatientCompleted = sqlDataReader.GetBoolean(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    clinicalAssessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalAssessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalAssessmentInstrument;
        }

        public ClinicalAssessmentInstrument GetByPartCode(string pPartCode, int pLanguageID)
        {
            ClinicalAssessmentInstrument clinicalAssessmentInstrument = new ClinicalAssessmentInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalAssessmentInstrument_GetByPartCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartCode", pPartCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        clinicalAssessmentInstrument = new ClinicalAssessmentInstrument(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1));
                        clinicalAssessmentInstrument.PartCode = sqlDataReader.GetString(2);
                        clinicalAssessmentInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        clinicalAssessmentInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        clinicalAssessmentInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        clinicalAssessmentInstrument.InstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            clinicalAssessmentInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            clinicalAssessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            clinicalAssessmentInstrument.IsPatientCompleted = sqlDataReader.GetBoolean(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    clinicalAssessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalAssessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalAssessmentInstrument;
        }

        public ClinicalAssessmentInstrument[] List(int pLanguageID)
        {
            List<ClinicalAssessmentInstrument> clinicalAssessmentInstruments = new List<ClinicalAssessmentInstrument>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalAssessmentInstrument_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ClinicalAssessmentInstrument clinicalAssessmentInstrument = new ClinicalAssessmentInstrument(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1));
                        clinicalAssessmentInstrument.PartCode = sqlDataReader.GetString(2);
                        clinicalAssessmentInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        clinicalAssessmentInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        clinicalAssessmentInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        clinicalAssessmentInstrument.InstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            clinicalAssessmentInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            clinicalAssessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            clinicalAssessmentInstrument.IsPatientCompleted = sqlDataReader.GetBoolean(9);
                        clinicalAssessmentInstruments.Add(clinicalAssessmentInstrument);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ClinicalAssessmentInstrument clinicalAssessmentInstrument = new ClinicalAssessmentInstrument();

                    clinicalAssessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalAssessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    clinicalAssessmentInstruments.Add(clinicalAssessmentInstrument);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalAssessmentInstruments.ToArray();
        }

        public ClinicalAssessmentInstrument[] ListForClinicalTrial(int pClinicalTrialID, int pLanguageID)
        {
            List<ClinicalAssessmentInstrument> clinicalAssessmentInstruments = new List<ClinicalAssessmentInstrument>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalAssessmentInstrument_ListForClinicalTrail]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ClinicalAssessmentInstrument clinicalAssessmentInstrument = new ClinicalAssessmentInstrument(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1));
                        clinicalAssessmentInstrument.PartCode = sqlDataReader.GetString(2);
                        clinicalAssessmentInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        clinicalAssessmentInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        clinicalAssessmentInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        clinicalAssessmentInstrument.InstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            clinicalAssessmentInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            clinicalAssessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            clinicalAssessmentInstrument.IsPatientCompleted = sqlDataReader.GetBoolean(9);
                        clinicalAssessmentInstruments.Add(clinicalAssessmentInstrument);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ClinicalAssessmentInstrument clinicalAssessmentInstrument = new ClinicalAssessmentInstrument();

                    clinicalAssessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalAssessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    clinicalAssessmentInstruments.Add(clinicalAssessmentInstrument);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalAssessmentInstruments.ToArray();
        }

        public ClinicalAssessmentInstrument[] ListForCondition(int pConditionID, int pLanguageID)
        {
            List<ClinicalAssessmentInstrument> clinicalAssessmentInstruments = new List<ClinicalAssessmentInstrument>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalAssessmentInstrument_ListForCondition]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ConditionID", pConditionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ClinicalAssessmentInstrument clinicalAssessmentInstrument = new ClinicalAssessmentInstrument(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1));
                        clinicalAssessmentInstrument.PartCode = sqlDataReader.GetString(2);
                        clinicalAssessmentInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        clinicalAssessmentInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        clinicalAssessmentInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        clinicalAssessmentInstrument.InstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            clinicalAssessmentInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            clinicalAssessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            clinicalAssessmentInstrument.IsPatientCompleted = sqlDataReader.GetBoolean(9);
                        clinicalAssessmentInstruments.Add(clinicalAssessmentInstrument);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ClinicalAssessmentInstrument clinicalAssessmentInstrument = new ClinicalAssessmentInstrument();

                    clinicalAssessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalAssessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    clinicalAssessmentInstruments.Add(clinicalAssessmentInstrument);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalAssessmentInstruments.ToArray();
        }

        public ClinicalAssessmentInstrument Insert(ClinicalAssessmentInstrument pClinicalAssessmentInstrument)
        {
            ClinicalAssessmentInstrument clinicalAssessmentInstrument = new ClinicalAssessmentInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalAssessmentInstrument_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pClinicalAssessmentInstrument.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pClinicalAssessmentInstrument.InstrumentLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@VersionNumber", pClinicalAssessmentInstrument.VersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", pClinicalAssessmentInstrument.AssessmentInstrumentAttributes.ToXMLFragment()));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPatientCompleted", pClinicalAssessmentInstrument.IsPatientCompleted));
                    SqlParameter clinicalAssessmentInstrumentID = sqlCommand.Parameters.Add("@ClinicalAssessmentInstrumentID", SqlDbType.Int);
                    clinicalAssessmentInstrumentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    clinicalAssessmentInstrument = new ClinicalAssessmentInstrument((Int32)clinicalAssessmentInstrumentID.Value);
                    clinicalAssessmentInstrument.PartCode = pClinicalAssessmentInstrument.PartCode;
                    clinicalAssessmentInstrument.Detail = new Entities.Globalisation.Translation(pClinicalAssessmentInstrument.Detail.TranslationID);
                    clinicalAssessmentInstrument.Detail.Alias = pClinicalAssessmentInstrument.Detail.Alias;
                    clinicalAssessmentInstrument.PartType = new Entities.Operations.PartType(pClinicalAssessmentInstrument.PartType.PartTypeID);
                    clinicalAssessmentInstrument.PartType.Detail = new Entities.Globalisation.Translation(pClinicalAssessmentInstrument.PartType.Detail.TranslationID);
                    clinicalAssessmentInstrument.PartType.Detail.Alias = pClinicalAssessmentInstrument.PartType.Detail.Alias;
                    clinicalAssessmentInstrument.InstrumentLanguage = new Entities.Globalisation.Language(pClinicalAssessmentInstrument.InstrumentLanguage.LanguageID);
                    clinicalAssessmentInstrument.VersionNumber = pClinicalAssessmentInstrument.VersionNumber;
                    clinicalAssessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(pClinicalAssessmentInstrument.AssessmentInstrumentAttributes.ToXMLFragment());
                    clinicalAssessmentInstrument.IsPatientCompleted = pClinicalAssessmentInstrument.IsPatientCompleted;
                }
                catch (Exception exc)
                {
                    clinicalAssessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalAssessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalAssessmentInstrument;
        }

        public ClinicalAssessmentInstrument Update(ClinicalAssessmentInstrument pClinicalAssessmentInstrument)
        {
            ClinicalAssessmentInstrument clinicalAssessmentInstrument = new ClinicalAssessmentInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalAssessmentInstrument_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentID", pClinicalAssessmentInstrument.ClinicalAssessmentInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pClinicalAssessmentInstrument.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pClinicalAssessmentInstrument.InstrumentLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@VersionNumber", pClinicalAssessmentInstrument.VersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", pClinicalAssessmentInstrument.AssessmentInstrumentAttributes.ToXMLFragment()));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPatientCompleted", pClinicalAssessmentInstrument.IsPatientCompleted));

                    sqlCommand.ExecuteNonQuery();

                    clinicalAssessmentInstrument = new ClinicalAssessmentInstrument(pClinicalAssessmentInstrument.ClinicalAssessmentInstrumentID);
                    clinicalAssessmentInstrument.PartCode = pClinicalAssessmentInstrument.PartCode;
                    clinicalAssessmentInstrument.Detail = new Entities.Globalisation.Translation(pClinicalAssessmentInstrument.Detail.TranslationID);
                    clinicalAssessmentInstrument.Detail.Alias = pClinicalAssessmentInstrument.Detail.Alias;
                    clinicalAssessmentInstrument.PartType = new Entities.Operations.PartType(pClinicalAssessmentInstrument.PartType.PartTypeID);
                    clinicalAssessmentInstrument.PartType.Detail = new Entities.Globalisation.Translation(pClinicalAssessmentInstrument.PartType.Detail.TranslationID);
                    clinicalAssessmentInstrument.PartType.Detail.Alias = pClinicalAssessmentInstrument.PartType.Detail.Alias;
                    clinicalAssessmentInstrument.InstrumentLanguage = new Entities.Globalisation.Language(pClinicalAssessmentInstrument.InstrumentLanguage.LanguageID);
                    clinicalAssessmentInstrument.VersionNumber = pClinicalAssessmentInstrument.VersionNumber;
                    clinicalAssessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(pClinicalAssessmentInstrument.AssessmentInstrumentAttributes.ToXMLFragment());
                    clinicalAssessmentInstrument.IsPatientCompleted = pClinicalAssessmentInstrument.IsPatientCompleted;
                }
                catch (Exception exc)
                {
                    clinicalAssessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalAssessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalAssessmentInstrument;
        }

        public ClinicalAssessmentInstrument Delete(ClinicalAssessmentInstrument pClinicalAssessmentInstrument)
        {
            ClinicalAssessmentInstrument clinicalAssessmentInstrument = new ClinicalAssessmentInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalAssessmentInstrument_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentID", pClinicalAssessmentInstrument.ClinicalAssessmentInstrumentID));

                    sqlCommand.ExecuteNonQuery();

                    clinicalAssessmentInstrument = new ClinicalAssessmentInstrument(pClinicalAssessmentInstrument.ClinicalAssessmentInstrumentID);
                }
                catch (Exception exc)
                {
                    clinicalAssessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clinicalAssessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalAssessmentInstrument;
        }

        public BaseBoolean AddToClinicalTrial(int pClinicalAssessmentInstrumentID, int pClinicalTrialID)
        {
            BaseBoolean result = new BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalAssessmentInstrument_AddToClinicalTrial]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentID", pClinicalAssessmentInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));

                    sqlCommand.ExecuteNonQuery();

                    result = new BaseBoolean();
                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
        
        public BaseBoolean RemoveFromClinicalTrial(int pClinicalAssessmentInstrumentID, int pClinicalTrialID)
        {
            BaseBoolean result = new BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalAssessmentInstrument_RemoveFromClinicalTrial]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentID", pClinicalAssessmentInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));

                    sqlCommand.ExecuteNonQuery();

                    result = new BaseBoolean();
                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean AddToCondition(int pClinicalAssessmentInstrumentID, int pConditionID)
        {
            BaseBoolean result = new BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalAssessmentInstrument_AddToCondition]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentID", pClinicalAssessmentInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ConditionID", pConditionID));

                    sqlCommand.ExecuteNonQuery();

                    result = new BaseBoolean();
                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean RemoveFromCondition(int pClinicalAssessmentInstrumentID, int pConditionID)
        {
            BaseBoolean result = new BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[ClinicalAssessmentInstrument_RemoveFromCondition]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentID", pClinicalAssessmentInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ConditionID", pConditionID));

                    sqlCommand.ExecuteNonQuery();

                    result = new BaseBoolean();
                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}
