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
    public class PaperInstrumentDOL : BaseDOL
    {
        public PaperInstrumentDOL() : base ()
        {
        }

        public PaperInstrumentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PaperInstrument Assign(PaperInstrument pPaperInstrument)
        {
            PaperInstrument paperInstrument = new PaperInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PaperInstrument_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaperInstrumentID", pPaperInstrument.PartID));

                    sqlCommand.ExecuteNonQuery();

                    paperInstrument = new PaperInstrument((Int32)pPaperInstrument.PartID);
                }
                catch (Exception exc)
                {
                    paperInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paperInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paperInstrument;
        }

        public PaperInstrument Remove(PaperInstrument pPaperInstrument)
        {
            PaperInstrument paperInstrument = new PaperInstrument();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Instrument_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaperInstrumentID", pPaperInstrument.PartID));

                    sqlCommand.ExecuteNonQuery();

                    paperInstrument = new PaperInstrument(pPaperInstrument.PartID);
                }
                catch (Exception exc)
                {
                    paperInstrument.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paperInstrument.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paperInstrument;
        }
    }
}
