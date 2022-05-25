using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class AssumptionDOL : BaseDOL
    {
        public AssumptionDOL() : base()
        {
        }

        public AssumptionDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Project.Assumption Get(int? pAssumptionID)
        {
            Entities.Project.Assumption assumption = new Entities.Project.Assumption();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Assumption_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionID", pAssumptionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        assumption = new Entities.Project.Assumption(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assumption.Author = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assumption.DateRaised = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            assumption.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            assumption.DateAssigned = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            assumption.AssumptionStatus = new Entities.Project.AssumptionStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            assumption.DateStatusChanged = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            assumption.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            assumption.Description = sqlDataReader.GetString(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assumption.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumption.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumption;
        }

        public Entities.Project.Assumption[] List(int pAssumptionLogID)
        {
            List<Entities.Project.Assumption> assumptions = new List<Entities.Project.Assumption>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Assumption_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionLogID", pAssumptionLogID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Project.Assumption assumption = new Entities.Project.Assumption(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assumption.Author = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assumption.DateRaised = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            assumption.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            assumption.DateAssigned = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            assumption.AssumptionStatus = new Entities.Project.AssumptionStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            assumption.DateStatusChanged = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            assumption.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            assumption.Description = sqlDataReader.GetString(8);
                        assumptions.Add(assumption);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Project.Assumption assumption = new Entities.Project.Assumption();
                    assumption.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumption.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assumptions.Add(assumption);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumptions.ToArray();
        }

        public Entities.Project.Assumption[] ListByOwner(int pAssumptionLogID, int pOwnerPartyID)
        {
            List<Entities.Project.Assumption> assumptions = new List<Entities.Project.Assumption>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Assumption_ListByOwnerPartyIDForAssumptionLogID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionLogID", pAssumptionLogID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", pOwnerPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Project.Assumption assumption = new Entities.Project.Assumption(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assumption.Author = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assumption.DateRaised = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            assumption.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            assumption.DateAssigned = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            assumption.AssumptionStatus = new Entities.Project.AssumptionStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            assumption.DateStatusChanged = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            assumption.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            assumption.Description = sqlDataReader.GetString(8);
                        assumptions.Add(assumption);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Project.Assumption assumption = new Entities.Project.Assumption();
                    assumption.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumption.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assumptions.Add(assumption);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumptions.ToArray();
        }

        public Entities.Project.Assumption[] ListByOwner(int pOwnerPartyID)
        {
            List<Entities.Project.Assumption> assumptions = new List<Entities.Project.Assumption>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Assumption_ListByOwnerPartyID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", pOwnerPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Project.Assumption assumption = new Entities.Project.Assumption(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assumption.Author = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assumption.DateRaised = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            assumption.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            assumption.DateAssigned = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            assumption.AssumptionStatus = new Entities.Project.AssumptionStatus(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            assumption.DateStatusChanged = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            assumption.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            assumption.Description = sqlDataReader.GetString(8);
                        assumptions.Add(assumption);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Project.Assumption assumption = new Entities.Project.Assumption();
                    assumption.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumption.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assumptions.Add(assumption);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumptions.ToArray();
        }

        public Entities.Project.Assumption Insert(Entities.Project.Assumption pAssumption, int pAssumptionLogID)
        {
            Entities.Project.Assumption assumption = new Entities.Project.Assumption();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Assumption_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionLogID", pAssumptionLogID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthorPartyID", ((pAssumption.Author != null && pAssumption.Author.PartyID.HasValue) ? pAssumption.Author.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateRaised", pAssumption.DateRaised));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", ((pAssumption.Owner != null && pAssumption.Owner.PartyID.HasValue) ? pAssumption.Owner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pAssumption.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionStatusID", ((pAssumption.AssumptionStatus != null && pAssumption.AssumptionStatus.AssumptionStatusID.HasValue) ? pAssumption.AssumptionStatus.AssumptionStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateStatusChanged", pAssumption.DateStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", ((pAssumption.StatusChangedBy != null && pAssumption.StatusChangedBy.PartyID.HasValue) ? pAssumption.StatusChangedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pAssumption.Description));
                    SqlParameter assumptionID = sqlCommand.Parameters.Add("@AssumptionID", SqlDbType.Int);
                    assumptionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    assumption = new Entities.Project.Assumption((Int32)assumptionID.Value);
                    assumption.Author = pAssumption.Author;
                    assumption.DateRaised = pAssumption.DateRaised;
                    assumption.Owner = pAssumption.Owner;
                    assumption.DateAssigned = pAssumption.DateAssigned;
                    assumption.AssumptionStatus = pAssumption.AssumptionStatus;
                    assumption.DateStatusChanged = pAssumption.DateStatusChanged;
                    assumption.StatusChangedBy = pAssumption.StatusChangedBy;
                    assumption.Description = pAssumption.Description;
                }
                catch (Exception exc)
                {
                    assumption.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumption.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumption;
        }

        public Entities.Project.Assumption Update(Entities.Project.Assumption pAssumption, int pAssumptionLogID)
        {
            Entities.Project.Assumption assumption = new Entities.Project.Assumption();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Assumption_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionID", pAssumption.AssumptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionLogID", pAssumptionLogID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthorPartyID", ((pAssumption.Author != null && pAssumption.Author.PartyID.HasValue) ? pAssumption.Author.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateRaised", pAssumption.DateRaised));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", ((pAssumption.Owner != null && pAssumption.Owner.PartyID.HasValue) ? pAssumption.Owner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pAssumption.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionStatusID", ((pAssumption.AssumptionStatus != null && pAssumption.AssumptionStatus.AssumptionStatusID.HasValue) ? pAssumption.AssumptionStatus.AssumptionStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateStatusChanged", pAssumption.DateStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", ((pAssumption.StatusChangedBy != null && pAssumption.StatusChangedBy.PartyID.HasValue) ? pAssumption.StatusChangedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pAssumption.Description));

                    sqlCommand.ExecuteNonQuery();

                    assumption = new Entities.Project.Assumption(pAssumption.AssumptionID);
                    assumption.Author = pAssumption.Author;
                    assumption.DateRaised = pAssumption.DateRaised;
                    assumption.Owner = pAssumption.Owner;
                    assumption.DateAssigned = pAssumption.DateAssigned;
                    assumption.AssumptionStatus = pAssumption.AssumptionStatus;
                    assumption.DateStatusChanged = pAssumption.DateStatusChanged;
                    assumption.StatusChangedBy = pAssumption.StatusChangedBy;
                    assumption.Description = pAssumption.Description;
                }
                catch (Exception exc)
                {
                    assumption.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumption.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumption;
        }

        public Entities.Project.Assumption Update(Entities.Project.Assumption pAssumption)
        {
            Entities.Project.Assumption assumption = new Entities.Project.Assumption();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Assumption_UpdateWithoutLog]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionID", pAssumption.AssumptionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthorPartyID", ((pAssumption.Author != null && pAssumption.Author.PartyID.HasValue) ? pAssumption.Author.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateRaised", pAssumption.DateRaised));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", ((pAssumption.Owner != null && pAssumption.Owner.PartyID.HasValue) ? pAssumption.Owner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pAssumption.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionStatusID", ((pAssumption.AssumptionStatus != null && pAssumption.AssumptionStatus.AssumptionStatusID.HasValue) ? pAssumption.AssumptionStatus.AssumptionStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateStatusChanged", pAssumption.DateStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", ((pAssumption.StatusChangedBy != null && pAssumption.StatusChangedBy.PartyID.HasValue) ? pAssumption.StatusChangedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pAssumption.Description));

                    sqlCommand.ExecuteNonQuery();

                    assumption = new Entities.Project.Assumption(pAssumption.AssumptionID);
                    assumption.Author = pAssumption.Author;
                    assumption.DateRaised = pAssumption.DateRaised;
                    assumption.Owner = pAssumption.Owner;
                    assumption.DateAssigned = pAssumption.DateAssigned;
                    assumption.AssumptionStatus = pAssumption.AssumptionStatus;
                    assumption.DateStatusChanged = pAssumption.DateStatusChanged;
                    assumption.StatusChangedBy = pAssumption.StatusChangedBy;
                    assumption.Description = pAssumption.Description;
                }
                catch (Exception exc)
                {
                    assumption.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumption.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumption;
        }

        public Entities.Project.Assumption Delete(Entities.Project.Assumption pAssumption)
        {
            Entities.Project.Assumption assumption = new Entities.Project.Assumption();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Assumption_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionID", pAssumption.AssumptionID));

                    sqlCommand.ExecuteNonQuery();

                    assumption = new Entities.Project.Assumption(pAssumption.AssumptionID);
                }
                catch (Exception exc)
                {
                    assumption.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assumption.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assumption;
        }
    }
}
