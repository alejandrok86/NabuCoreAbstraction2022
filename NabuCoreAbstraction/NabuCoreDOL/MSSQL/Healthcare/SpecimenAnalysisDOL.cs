using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare
{
    public class SpecimenAnalysisDOL : BaseDOL
    {
        public SpecimenAnalysisDOL() : base ()
        {
        }

        public SpecimenAnalysisDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public SpecimenAnalysis Get(int? pSpecimenAnalysisID)
        {
            SpecimenAnalysis specimenAnalysis = new SpecimenAnalysis();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenAnalysis_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenAnalysisID", pSpecimenAnalysisID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        specimenAnalysis = new SpecimenAnalysis(sqlDataReader.GetInt32(0));
                        specimenAnalysis.AnalysisType = new AnalysisType(sqlDataReader.GetInt32(1));
                        specimenAnalysis.AnalysisInitiatedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            specimenAnalysis.AnalysisStarted = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            specimenAnalysis.AnalysisEnded = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                        specimenAnalysis.AnalysisStatus = new AnalysisStatus(sqlDataReader.GetInt32(5));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    specimenAnalysis.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenAnalysis.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenAnalysis;
        }

        public SpecimenAnalysis[] List(int pSpecimenID)
        {
            List<SpecimenAnalysis> specimenAnalysiss = new List<SpecimenAnalysis>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenAnalysis_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenID", pSpecimenID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        SpecimenAnalysis specimenAnalysis = new SpecimenAnalysis(sqlDataReader.GetInt32(0));
                        specimenAnalysis.AnalysisType = new AnalysisType(sqlDataReader.GetInt32(1));
                        specimenAnalysis.AnalysisInitiatedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            specimenAnalysis.AnalysisStarted = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            specimenAnalysis.AnalysisEnded = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            specimenAnalysis.AnalysisStatus = new AnalysisStatus(sqlDataReader.GetInt32(5));
                        specimenAnalysiss.Add(specimenAnalysis);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    SpecimenAnalysis specimenAnalysis = new SpecimenAnalysis();
                    specimenAnalysis.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenAnalysis.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specimenAnalysiss.Add(specimenAnalysis);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenAnalysiss.ToArray();
        }

        public SpecimenAnalysis Insert(SpecimenAnalysis pSpecimenAnalysis, int pSpecimenID)
        {
            SpecimenAnalysis specimenAnalysis = new SpecimenAnalysis();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenAnalysis_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenID", pSpecimenID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisTypeID", pSpecimenAnalysis.AnalysisType.AnalysisTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisInitiatedBy", pSpecimenAnalysis.AnalysisInitiatedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisStarted", ((pSpecimenAnalysis.AnalysisStarted.HasValue) ? pSpecimenAnalysis.AnalysisStarted : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisEnded", ((pSpecimenAnalysis.AnalysisEnded.HasValue) ? pSpecimenAnalysis.AnalysisEnded : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisStatusID", pSpecimenAnalysis.AnalysisStatus.AnalysisStatusID));
                    SqlParameter specimenAnalysisID = sqlCommand.Parameters.Add("@SpecimenAnalysisID", SqlDbType.Int);
                    specimenAnalysisID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    specimenAnalysis = new SpecimenAnalysis((Int32)specimenAnalysisID.Value);
                    specimenAnalysis.AnalysisType = pSpecimenAnalysis.AnalysisType;
                    specimenAnalysis.AnalysisInitiatedBy = pSpecimenAnalysis.AnalysisInitiatedBy;
                    specimenAnalysis.AnalysisStarted = pSpecimenAnalysis.AnalysisStarted;
                    specimenAnalysis.AnalysisEnded = pSpecimenAnalysis.AnalysisEnded;
                    specimenAnalysis.AnalysisStatus = pSpecimenAnalysis.AnalysisStatus;
                }
                catch (Exception exc)
                {
                    specimenAnalysis.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenAnalysis.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenAnalysis;
        }

        public SpecimenAnalysis Update(SpecimenAnalysis pSpecimenAnalysis)
        {
            SpecimenAnalysis specimenAnalysis = new SpecimenAnalysis();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenAnalysis_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenAnalysisID", pSpecimenAnalysis.SpecimenAnalysisID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisTypeID", pSpecimenAnalysis.AnalysisType.AnalysisTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisInitiatedBy", pSpecimenAnalysis.AnalysisInitiatedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisStarted", ((pSpecimenAnalysis.AnalysisStarted.HasValue) ? pSpecimenAnalysis.AnalysisStarted : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisEnded", ((pSpecimenAnalysis.AnalysisEnded.HasValue) ? pSpecimenAnalysis.AnalysisEnded : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@AnalysisStatusID", pSpecimenAnalysis.AnalysisStatus.AnalysisStatusID));

                    sqlCommand.ExecuteNonQuery();

                    specimenAnalysis = new SpecimenAnalysis(pSpecimenAnalysis.SpecimenAnalysisID);
                    specimenAnalysis.AnalysisType = pSpecimenAnalysis.AnalysisType;
                    specimenAnalysis.AnalysisInitiatedBy = pSpecimenAnalysis.AnalysisInitiatedBy;
                    specimenAnalysis.AnalysisStarted = pSpecimenAnalysis.AnalysisStarted;
                    specimenAnalysis.AnalysisEnded = pSpecimenAnalysis.AnalysisEnded;
                    specimenAnalysis.AnalysisStatus = pSpecimenAnalysis.AnalysisStatus;
                }
                catch (Exception exc)
                {
                    specimenAnalysis.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenAnalysis.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenAnalysis;
        }

        public SpecimenAnalysis Delete(SpecimenAnalysis pSpecimenAnalysis)
        {
            SpecimenAnalysis specimenAnalysis = new SpecimenAnalysis();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenAnalysis_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenAnalysisID", pSpecimenAnalysis.SpecimenAnalysisID));

                    sqlCommand.ExecuteNonQuery();

                    specimenAnalysis = new SpecimenAnalysis(pSpecimenAnalysis.SpecimenAnalysisID);
                }
                catch (Exception exc)
                {
                    specimenAnalysis.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenAnalysis.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenAnalysis;
        }

        public SpecimenAnalysis DeleteBySpecimen(int pSpecimenID)
        {
            SpecimenAnalysis specimenAnalysis = new SpecimenAnalysis();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenAnalysis_DeleteBySpecimen]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenID", pSpecimenID));

                    sqlCommand.ExecuteNonQuery();

                    specimenAnalysis = new SpecimenAnalysis(pSpecimenID);
                }
                catch (Exception exc)
                {
                    specimenAnalysis.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenAnalysis.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenAnalysis;
        }

        public SpecimenAnalysis Assign(int pSpecimenAnalysisID,int pContentID)
        {
            SpecimenAnalysis specimenAnalysis = new SpecimenAnalysis();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenAnalysisOutcome_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenAnalysisID", pSpecimenAnalysisID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    specimenAnalysis = new SpecimenAnalysis(pSpecimenAnalysisID);
                }
                catch (Exception exc)
                {
                    specimenAnalysis.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenAnalysis.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenAnalysis;
        }
        public SpecimenAnalysis Remove(int pSpecimenAnalysisID, int pContentID)
        {
            SpecimenAnalysis specimenAnalysis = new SpecimenAnalysis();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[SpecimenAnalysisOutcome_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenAnalysisID", pSpecimenAnalysisID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    specimenAnalysis = new SpecimenAnalysis(pSpecimenAnalysisID);
                }
                catch (Exception exc)
                {
                    specimenAnalysis.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimenAnalysis.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimenAnalysis;
        }
    }
}
