using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
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
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Instrument_Get]");
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
                        instrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        instrument.TickerCode = sqlDataReader.GetString(2);
                        instrument.Currency = new Currency(sqlDataReader.GetInt32(3));
                        instrument.Price = sqlDataReader.GetDecimal(4);
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

        public Instrument[] List(int pInstitutionID, int pLanguageID)
        {
            List<Instrument> instruments = new List<Instrument>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Instrument_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Instrument instrument = new Instrument(sqlDataReader.GetInt32(0));
                        instrument.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        instrument.TickerCode = sqlDataReader.GetString(2);
                        instrument.Currency = new Currency(sqlDataReader.GetInt32(3));
                        instrument.Price = sqlDataReader.GetDecimal(4);
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

        public Instrument Insert(Instrument pInstrument, int pInstitutionID)
        {
            Instrument instrument = new Instrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Instrument_Insert]");
                try
                {
                    pInstrument.Detail = base.InsertTranslation(pInstrument.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pInstrument.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TickerCode", pInstrument.TickerCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pInstrument.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Price", pInstrument.Price));
                    SqlParameter instrumentID = sqlCommand.Parameters.Add("@InstrumentID", SqlDbType.Int);
                    instrumentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    instrument = new Instrument((Int32)instrumentID.Value);
                    instrument.Detail = pInstrument.Detail;
                    instrument.TickerCode = pInstrument.TickerCode;
                    instrument.Currency = pInstrument.Currency;
                    instrument.Price = pInstrument.Price;
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
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Instrument_Update]");
                try
                {
                    pInstrument.Detail = base.UpdateTranslation(pInstrument.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pInstrument.InstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pInstrument.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TickerCode", pInstrument.TickerCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@CurrencyID", pInstrument.Currency.CurrencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Price", pInstrument.Price));

                    sqlCommand.ExecuteNonQuery();

                    instrument = new Instrument(pInstrument.InstrumentID);
                    instrument.Detail = pInstrument.Detail;
                    instrument.TickerCode = pInstrument.TickerCode;
                    instrument.Currency = pInstrument.Currency;
                    instrument.Price = pInstrument.Price;
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
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Instrument_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pInstrument.InstrumentID));

                    sqlCommand.ExecuteNonQuery();

                    instrument = new Instrument(pInstrument.InstrumentID);
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
