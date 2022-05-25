using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core
{
    public class EventDOL : BaseDOL
    {
        public EventDOL() : base()
        {
        }

        public EventDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Event Get(int pEventID)
        {
            Event evt = new Event();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Event_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EventID", pEventID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        evt = new Event(sqlDataReader.GetInt32(0));
                        evt.StartDate = sqlDataReader.GetDateTime(1);
                        evt.EndDate = sqlDataReader.GetDateTime(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    evt.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evt.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evt;
        }

        public Event[] List()
        {
            List<Event> evts = new List<Event>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Event_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Event evt = new Event(sqlDataReader.GetInt32(0));
                        evt.StartDate = sqlDataReader.GetDateTime(1);
                        evt.EndDate = sqlDataReader.GetDateTime(1);
                        evts.Add(evt);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Event evt = new Event();
                    evt.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evt.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    evts.Add(evt);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evts.ToArray();
        }

        public Event Insert(Event pEvent)
        {
            Event evt = new Event();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Event_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pEvent.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", pEvent.EndDate));
                    SqlParameter evtID = sqlCommand.Parameters.Add("@EventID", SqlDbType.Int);
                    evtID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    evt = new Event((Int32)evtID.Value);
                    evt.StartDate = pEvent.StartDate;
                    evt.EndDate = pEvent.EndDate;
                }
                catch (Exception exc)
                {
                    evt.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evt.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evt;
        }

        public Event Update(Event pEvent)
        {
            Event evt = new Event();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Event_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EventID", pEvent.EventID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pEvent.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", pEvent.EndDate));

                    sqlCommand.ExecuteNonQuery();

                    evt = new Event(pEvent.EventID);
                    evt.StartDate = pEvent.StartDate;
                    evt.EndDate = pEvent.EndDate;
                }
                catch (Exception exc)
                {
                    evt.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evt.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evt;
        }

        public Event Delete(Event pEvent)
        {
            Event evt = new Event();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Event_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EventID", pEvent.EventID));

                    sqlCommand.ExecuteNonQuery();

                    evt = new Event(pEvent.EventID);
                }
                catch (Exception exc)
                {
                    evt.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    evt.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return evt;
        }
    }
}

