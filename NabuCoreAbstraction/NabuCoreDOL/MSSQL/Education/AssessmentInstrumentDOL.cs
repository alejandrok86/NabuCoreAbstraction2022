using Octavo.Gate.Nabu.CORE.Entities.Education;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class AssessmentInstrumentDOL : BaseDOL
    {
        public AssessmentInstrumentDOL() : base ()
        {
        }

        public AssessmentInstrumentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AssessmentInstrument Get(int? pAssessmentInstrumentID, int pLanguageID)
        {
            AssessmentInstrument assessmentInstrument = new AssessmentInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentInstrument_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentInstrumentID", pAssessmentInstrumentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
		                assessmentInstrument = new AssessmentInstrument(sqlDataReader.GetInt32(0),sqlDataReader.GetInt32(1));
		                assessmentInstrument.PartCode = sqlDataReader.GetString(2);
		                assessmentInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
		                assessmentInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
		                assessmentInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
		                assessmentInstrument.AssessmentInstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrument.MandatedStartDateTime = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            assessmentInstrument.MandatedEndDateTime = sqlDataReader.GetDateTime(9);
                        if(sqlDataReader.IsDBNull(10)==false)
                            assessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            assessmentInstrument.MaximumAttempts = sqlDataReader.GetInt32(11);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrument;
        }

        public AssessmentInstrument GetByPartCode(string pPartCode, int pLanguageID)
        {
            AssessmentInstrument assessmentInstrument = new AssessmentInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentInstrument_GetByPartCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartCode", pPartCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        assessmentInstrument = new AssessmentInstrument(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1));
                        assessmentInstrument.PartCode = sqlDataReader.GetString(2);
                        assessmentInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        assessmentInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        assessmentInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        assessmentInstrument.AssessmentInstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrument.MandatedStartDateTime = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            assessmentInstrument.MandatedEndDateTime = sqlDataReader.GetDateTime(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            assessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(10));
                        if(sqlDataReader.IsDBNull(11) == false)
                            assessmentInstrument.MaximumAttempts = sqlDataReader.GetInt32(11);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrument;
        }

        public AssessmentInstrument[] List(int pLanguageID)
        {
            List<AssessmentInstrument> assessmentInstruments = new List<AssessmentInstrument>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentInstrument_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AssessmentInstrument assessmentInstrument = new AssessmentInstrument(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1));
                        assessmentInstrument.PartCode = sqlDataReader.GetString(2);
                        assessmentInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        assessmentInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        assessmentInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        assessmentInstrument.AssessmentInstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrument.MandatedStartDateTime = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            assessmentInstrument.MandatedEndDateTime = sqlDataReader.GetDateTime(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            assessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(10));
                        assessmentInstruments.Add(assessmentInstrument);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssessmentInstrument assessmentInstrument = new AssessmentInstrument();
                    assessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assessmentInstruments.Add(assessmentInstrument);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstruments.ToArray();
        }

        public AssessmentInstrument[] ListWithinUnit(int pUnitID, int pLanguageID)
        {
            List<AssessmentInstrument> assessmentInstruments = new List<AssessmentInstrument>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentInstrument_ListForUnit]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AssessmentInstrument assessmentInstrument = new AssessmentInstrument(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1));
                        assessmentInstrument.PartCode = sqlDataReader.GetString(2);
                        assessmentInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        assessmentInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        assessmentInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        assessmentInstrument.AssessmentInstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrument.MandatedStartDateTime = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            assessmentInstrument.MandatedEndDateTime = sqlDataReader.GetDateTime(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            assessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(10));
                        assessmentInstruments.Add(assessmentInstrument);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssessmentInstrument assessmentInstrument = new AssessmentInstrument();
                    assessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assessmentInstruments.Add(assessmentInstrument);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstruments.ToArray();
        }

        public AssessmentInstrument[] ListByOwner(int pOwnerPartyID, int pLanguageID)
        {
            List<AssessmentInstrument> assessmentInstruments = new List<AssessmentInstrument>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentInstrument_ListByOwner]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", pOwnerPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AssessmentInstrument assessmentInstrument = new AssessmentInstrument(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1));
                        assessmentInstrument.PartCode = sqlDataReader.GetString(2);
                        assessmentInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        assessmentInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        assessmentInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        assessmentInstrument.AssessmentInstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrument.MandatedStartDateTime = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            assessmentInstrument.MandatedEndDateTime = sqlDataReader.GetDateTime(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            assessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(10));
                        assessmentInstruments.Add(assessmentInstrument);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssessmentInstrument assessmentInstrument = new AssessmentInstrument();
                    assessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assessmentInstruments.Add(assessmentInstrument);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstruments.ToArray();
        }

        public AssessmentInstrument Insert(AssessmentInstrument pAssessmentInstrument)
        {
            AssessmentInstrument assessmentInstrument = new AssessmentInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentInstrument_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pAssessmentInstrument.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pAssessmentInstrument.AssessmentInstrumentLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@VersionNumber", pAssessmentInstrument.VersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@MandatedStartDateTime", ((pAssessmentInstrument.MandatedStartDateTime.HasValue) ? pAssessmentInstrument.MandatedStartDateTime : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@MandatedEndDateTime", ((pAssessmentInstrument.MandatedEndDateTime.HasValue) ? pAssessmentInstrument.MandatedEndDateTime : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", ((pAssessmentInstrument.AssessmentInstrumentAttributes != null) ? pAssessmentInstrument.AssessmentInstrumentAttributes.ToXMLFragment() : null)));
                    SqlParameter assessmentInstrumentID = sqlCommand.Parameters.Add("@AssessmentInstrumentID", SqlDbType.Int);
                    assessmentInstrumentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    assessmentInstrument = new AssessmentInstrument((Int32)assessmentInstrumentID.Value);
                    assessmentInstrument.PartID = pAssessmentInstrument.PartID;
                    assessmentInstrument.AssessmentInstrumentLanguage = new Entities.Globalisation.Language(pAssessmentInstrument.AssessmentInstrumentLanguage.LanguageID);
                    assessmentInstrument.VersionNumber = pAssessmentInstrument.VersionNumber;
                    assessmentInstrument.MandatedStartDateTime = pAssessmentInstrument.MandatedStartDateTime;
                    assessmentInstrument.MandatedEndDateTime = pAssessmentInstrument.MandatedEndDateTime;
                    if (pAssessmentInstrument.AssessmentInstrumentAttributes != null)
                        assessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(pAssessmentInstrument.AssessmentInstrumentAttributes.ToXMLFragment());
                }
                catch (Exception exc)
                {
                    assessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrument;
        }

        public AssessmentInstrument Update(AssessmentInstrument pAssessmentInstrument)
        {
            AssessmentInstrument assessmentInstrument = new AssessmentInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentInstrument_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentInstrumentID", pAssessmentInstrument.AssessmentInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pAssessmentInstrument.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pAssessmentInstrument.AssessmentInstrumentLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@VersionNumber", pAssessmentInstrument.VersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@MandatedStartDateTime", ((pAssessmentInstrument.MandatedStartDateTime.HasValue) ? pAssessmentInstrument.MandatedStartDateTime : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@MandatedEndDateTime", ((pAssessmentInstrument.MandatedEndDateTime.HasValue) ? pAssessmentInstrument.MandatedEndDateTime : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", ((pAssessmentInstrument.AssessmentInstrumentAttributes != null) ? pAssessmentInstrument.AssessmentInstrumentAttributes.ToXMLFragment() : null)));

                    sqlCommand.ExecuteNonQuery();

                    assessmentInstrument = new AssessmentInstrument(pAssessmentInstrument.AssessmentInstrumentID);
                    assessmentInstrument.PartID = pAssessmentInstrument.PartID;
                    assessmentInstrument.AssessmentInstrumentLanguage = new Entities.Globalisation.Language(pAssessmentInstrument.AssessmentInstrumentLanguage.LanguageID);
                    assessmentInstrument.VersionNumber = pAssessmentInstrument.VersionNumber;
                    assessmentInstrument.MandatedStartDateTime = pAssessmentInstrument.MandatedStartDateTime;
                    assessmentInstrument.MandatedEndDateTime = pAssessmentInstrument.MandatedEndDateTime;
                    if (pAssessmentInstrument.AssessmentInstrumentAttributes != null)
                        assessmentInstrument.AssessmentInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(pAssessmentInstrument.AssessmentInstrumentAttributes.ToXMLFragment());
                }
                catch (Exception exc)
                {
                    assessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrument;
        }

        public AssessmentInstrument Delete(AssessmentInstrument pAssessmentInstrument)
        {
            AssessmentInstrument assessmentInstrument = new AssessmentInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentInstrument_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentInstrumentID", pAssessmentInstrument.AssessmentInstrumentID));

                    sqlCommand.ExecuteNonQuery();

                    assessmentInstrument = new AssessmentInstrument(pAssessmentInstrument.AssessmentInstrumentID);
                }
                catch (Exception exc)
                {
                    assessmentInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrument;
        }
    }
}
