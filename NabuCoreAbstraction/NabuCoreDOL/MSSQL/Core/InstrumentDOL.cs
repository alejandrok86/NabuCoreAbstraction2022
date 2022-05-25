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
    public class InstrumentDOL : BaseDOL
    {
        public InstrumentDOL() : base()
        {
        }

        public InstrumentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Instrument Get(int pInstrumentID, int pLanguageID)
        {
            Instrument instrument = new Instrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Instrument_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pInstrumentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        instrument = new Instrument(sqlDataReader.GetInt32(0));
                        instrument.Owner = new Party(sqlDataReader.GetInt32(1));
                        instrument.PartCode = sqlDataReader.GetString(2);
                        instrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        instrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        instrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    instrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrument;
        }

        public Instrument[] List(int pOwnedBy, int pLanguageID)
        {
            List<Instrument> instruments = new List<Instrument>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Instrument_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", pOwnedBy));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Instrument instrument = new Instrument(sqlDataReader.GetInt32(0));
                        instrument.Owner = new Party(sqlDataReader.GetInt32(1));
                        instrument.PartCode = sqlDataReader.GetString(2);
                        instrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        instrument.PartType = new Entities.Operations.PartType(sqlDataReader.GetInt32(4));
                        instrument.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        instruments.Add(instrument);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Instrument instrument = new Instrument();
                    instrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    instruments.Add(instrument);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instruments.ToArray();
        }

        public Instrument Insert(Instrument pInstrument)
        {
            Instrument instrument = new Instrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Instrument_Insert]");
                try
                {
                    pInstrument.Detail = base.InsertTranslation(pInstrument.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartCode", pInstrument.PartCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pInstrument.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pInstrument.PartType.PartTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", pInstrument.Owner.PartyID));
                    SqlParameter instrumentID = sqlCommand.Parameters.Add("@InstrumentID", SqlDbType.Int);
                    instrumentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    instrument = new Instrument((Int32)instrumentID.Value);
                    instrument.Owner = new Party(pInstrument.Owner.PartyID);
                    instrument.Detail = new Translation(pInstrument.Detail.TranslationID);
                    instrument.PartCode = pInstrument.PartCode;
                    instrument.PartType = new Entities.Operations.PartType(pInstrument.PartType.PartTypeID);
                }
                catch (Exception exc)
                {
                    instrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrument;
        }

        public Instrument Update(Instrument pInstrument)
        {
            Instrument instrument = new Instrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Instrument_Update]");
                try
                {
                    base.UpdateTranslation(pInstrument.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pInstrument.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", pInstrument.Owner.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartCode", pInstrument.PartCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pInstrument.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pInstrument.PartType.PartTypeID));

                    sqlCommand.ExecuteNonQuery();

                    instrument = new Instrument(pInstrument.PartID);
                    instrument.Owner = new Party(pInstrument.Owner.PartyID);
                    instrument.Detail = new Translation(pInstrument.Detail.TranslationID);
                    instrument.PartCode = pInstrument.PartCode;
                    instrument.PartType = new Entities.Operations.PartType(pInstrument.PartType.PartTypeID);
                }
                catch (Exception exc)
                {
                    instrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrument;
        }

        public Instrument Delete(Instrument pInstrument)
        {
            Instrument instrument = new Instrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Instrument_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pInstrument.PartID));

                    sqlCommand.ExecuteNonQuery();

                    instrument = new Instrument(pInstrument.PartID);
                    base.DeleteAllTranslations(pInstrument.Detail);
                }
                catch (Exception exc)
                {
                    instrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrument;
        }
    }
}

