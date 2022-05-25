using Octavo.Gate.Nabu.CORE.Entities.Education;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class LearningInstrumentDOL : BaseDOL
    {
        public LearningInstrumentDOL() : base ()
        {
        }

        public LearningInstrumentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public LearningInstrument Get(int? pLearningInstrumentID, int pLanguageID)
        {
            LearningInstrument learningInstrument = new LearningInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningInstrument_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningInstrumentID", pLearningInstrumentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
		                learningInstrument = new LearningInstrument(sqlDataReader.GetInt32(0),sqlDataReader.GetInt32(1));
		                learningInstrument.PartCode = sqlDataReader.GetString(2);
		                learningInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
		                learningInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
		                learningInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
		                learningInstrument.LearningInstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            learningInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if(sqlDataReader.IsDBNull(8)==false)
                            learningInstrument.LearningInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    learningInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrument;
        }

        public LearningInstrument GetByPartCode(string pPartCode, int pLanguageID)
        {
            LearningInstrument learningInstrument = new LearningInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningInstrument_GetByPartCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartCode", pPartCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        learningInstrument = new LearningInstrument(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1));
                        learningInstrument.PartCode = sqlDataReader.GetString(2);
                        learningInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        learningInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        learningInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        learningInstrument.LearningInstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            learningInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            learningInstrument.LearningInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    learningInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrument;
        }

        public LearningInstrument[] List(int pLanguageID)
        {
            List<LearningInstrument> learningInstruments = new List<LearningInstrument>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningInstrument_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LearningInstrument learningInstrument = new LearningInstrument(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1));
                        learningInstrument.PartCode = sqlDataReader.GetString(2);
                        learningInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        learningInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        learningInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        learningInstrument.LearningInstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            learningInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            learningInstrument.LearningInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                        learningInstruments.Add(learningInstrument);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LearningInstrument learningInstrument = new LearningInstrument();
                    learningInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    learningInstruments.Add(learningInstrument);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstruments.ToArray();
        }

        public LearningInstrument[] ListWithinUnit(int UnitID, int pLanguageID)
        {
            List<LearningInstrument> learningInstruments = new List<LearningInstrument>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningInstrument_ListForUnit]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", UnitID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LearningInstrument learningInstrument = new LearningInstrument(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1));
                        learningInstrument.PartCode = sqlDataReader.GetString(2);
                        learningInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        learningInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        learningInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        learningInstrument.LearningInstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            learningInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            learningInstrument.LearningInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                        learningInstruments.Add(learningInstrument);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LearningInstrument learningInstrument = new LearningInstrument();
                    learningInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    learningInstruments.Add(learningInstrument);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstruments.ToArray();
        }

        public LearningInstrument[] ListByOwner(int pOwnerPartyID, int pLanguageID)
        {
            List<LearningInstrument> learningInstruments = new List<LearningInstrument>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningInstrument_ListByOwner]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", pOwnerPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LearningInstrument learningInstrument = new LearningInstrument(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1));
                        learningInstrument.PartCode = sqlDataReader.GetString(2);
                        learningInstrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        learningInstrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        learningInstrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        learningInstrument.LearningInstrumentLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            learningInstrument.VersionNumber = sqlDataReader.GetDouble(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            learningInstrument.LearningInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(sqlDataReader.GetString(8));
                        learningInstruments.Add(learningInstrument);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LearningInstrument learningInstrument = new LearningInstrument();
                    learningInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    learningInstruments.Add(learningInstrument);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstruments.ToArray();
        }

        public LearningInstrument Insert(LearningInstrument pLearningInstrument)
        {
            LearningInstrument learningInstrument = new LearningInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningInstrument_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pLearningInstrument.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLearningInstrument.LearningInstrumentLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@VersionNumber", pLearningInstrument.VersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", ((pLearningInstrument.LearningInstrumentAttributes != null) ? pLearningInstrument.LearningInstrumentAttributes.ToXMLFragment() : null)));
                    SqlParameter learningInstrumentID = sqlCommand.Parameters.Add("@LearningInstrumentID", SqlDbType.Int);
                    learningInstrumentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    learningInstrument = new LearningInstrument((Int32)learningInstrumentID.Value);
                    learningInstrument.PartID = pLearningInstrument.PartID;
                    learningInstrument.LearningInstrumentLanguage = new Entities.Globalisation.Language(pLearningInstrument.LearningInstrumentLanguage.LanguageID);
                    learningInstrument.VersionNumber = pLearningInstrument.VersionNumber;
                    if (pLearningInstrument.LearningInstrumentAttributes != null)
                        learningInstrument.LearningInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(pLearningInstrument.LearningInstrumentAttributes.ToXMLFragment());
                }
                catch (Exception exc)
                {
                    learningInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrument;
        }

        public LearningInstrument Update(LearningInstrument pLearningInstrument)
        {
            LearningInstrument learningInstrument = new LearningInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningInstrument_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningInstrumentID", pLearningInstrument.LearningInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pLearningInstrument.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLearningInstrument.LearningInstrumentLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@VersionNumber", pLearningInstrument.VersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@EntityAttributesXML", ((pLearningInstrument.LearningInstrumentAttributes != null) ? pLearningInstrument.LearningInstrumentAttributes.ToXMLFragment() : null)));

                    sqlCommand.ExecuteNonQuery();

                    learningInstrument = new LearningInstrument(pLearningInstrument.LearningInstrumentID);
                    learningInstrument.PartID = pLearningInstrument.PartID;
                    learningInstrument.LearningInstrumentLanguage = new Entities.Globalisation.Language(pLearningInstrument.LearningInstrumentLanguage.LanguageID);
                    learningInstrument.VersionNumber = pLearningInstrument.VersionNumber;
                    if (pLearningInstrument.LearningInstrumentAttributes != null)
                        learningInstrument.LearningInstrumentAttributes = new Entities.Utility.EntityAttributeCollection(pLearningInstrument.LearningInstrumentAttributes.ToXMLFragment());
                }
                catch (Exception exc)
                {
                    learningInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrument;
        }

        public LearningInstrument Delete(LearningInstrument pLearningInstrument)
        {
            LearningInstrument learningInstrument = new LearningInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningInstrument_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningInstrumentID", pLearningInstrument.LearningInstrumentID));

                    sqlCommand.ExecuteNonQuery();

                    learningInstrument = new LearningInstrument(pLearningInstrument.LearningInstrumentID);
                }
                catch (Exception exc)
                {
                    learningInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrument;
        }
    }
}
