using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Planning;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning
{
    public class NoteDOL : BaseDOL
    {
        public NoteDOL() : base ()
        {
        }

        public NoteDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Note AssignTo(int pNoteID, Entities.Project.Action pAction)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToAction]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionID", pAction.ActionID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.Project.Assumption pAssumption)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToAssumption]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionID", pAssumption.AssumptionID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.Project.Issue pIssue)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToIssue]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueID", pIssue.IssueID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.Project.Risk pRisk)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToRisk]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskID", pRisk.RiskID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.Planning.Project pProject)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToProject]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProject.ProjectID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.Planning.Programme pProgramme)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToProgramme]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgramme.ProgrammeID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.Planning.Task pTask)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToTask]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskID", pTask.TaskID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.ServiceManagement.Incident pIncident)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToIncident]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncident.IncidentID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.ServiceManagement.Problem pProblem)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToProblem]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemID", pProblem.ProblemID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.ServiceManagement.Change pChange)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToChange]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeID", pChange.ChangeID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.Development.Defect pDefect)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToDefect]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectID", pDefect.DefectID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.Development.Iteration pIteration)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToIteration]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIteration.IterationID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.Development.Requirement pRequirement)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToRequirement]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementID", pRequirement.RequirementID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
        public Note AssignTo(int pNoteID, Entities.Financial.AccountTransaction pTransaction)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_AssignToAccountTransaction]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionID", pTransaction.AccountTransactionID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }

        public Note Get(int? pNoteID)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNoteID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }

        public Note[] ListFor(Entities.Project.Action pAction)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForAction]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionID", pAction.ActionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.Project.Assumption pAssumption)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForAssumption]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssumptionID", pAssumption.AssumptionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.Project.Issue pIssue)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForIssue]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueID", pIssue.IssueID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.Project.Risk pRisk)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForRisk]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RiskID", pRisk.RiskID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.Planning.Project pProject)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForProject]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProject.ProjectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.Planning.Programme pProgramme)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForProgramme]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgramme.ProgrammeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.Planning.Task pTask)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForTask]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TaskID", pTask.TaskID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.ServiceManagement.Incident pIncident)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForIncident]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncident.IncidentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.ServiceManagement.Problem pProblem)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForProblem]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemID", pProblem.ProblemID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.ServiceManagement.Change pChange)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForChange]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeID", pChange.ChangeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.Development.Defect pDefect)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForDefect]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectID", pDefect.DefectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.Development.Iteration pIteration)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForIteration]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIteration.IterationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.Development.Requirement pRequirement)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForRequirement]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementID", pRequirement.RequirementID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }
        public Note[] ListFor(Entities.Financial.AccountTransaction pTransaction)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_ListForAccountTransaction]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionID", pTransaction.AccountTransactionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Note note = new Note(sqlDataReader.GetInt32(0));
                        note.NoteText = sqlDataReader.GetString(1);
                        note.NoteTakenBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        note.NoteDateTime = sqlDataReader.GetDateTime(3);
                        notes.Add(note);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Note note = new Note();
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notes.Add(note);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notes.ToArray();
        }

        public Note Insert(Note pNote)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteText", pNote.NoteText));
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteTakenByPersonID", pNote.NoteTakenBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteDateTime", pNote.NoteDateTime));
                    SqlParameter noteID = sqlCommand.Parameters.Add("@NoteID", SqlDbType.Int);
                    noteID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    note = new Note((Int32)noteID.Value);
                    note.NoteText = pNote.NoteText;
                    note.NoteTakenBy = pNote.NoteTakenBy;
                    note.NoteDateTime = pNote.NoteDateTime;
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }

        public Note Update(Note pNote)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNote.NoteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteText", pNote.NoteText));
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteTakenByPersonID", pNote.NoteTakenBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteDateTime", pNote.NoteDateTime));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNote.NoteID);
                    note.NoteText = pNote.NoteText;
                    note.NoteTakenBy = pNote.NoteTakenBy;
                    note.NoteDateTime = pNote.NoteDateTime;
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }

        public Note Delete(Note pNote)
        {
            Note note = new Note();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Note_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NoteID", pNote.NoteID));

                    sqlCommand.ExecuteNonQuery();

                    note = new Note(pNote.NoteID);
                }
                catch (Exception exc)
                {
                    note.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    note.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return note;
        }
    }
}
