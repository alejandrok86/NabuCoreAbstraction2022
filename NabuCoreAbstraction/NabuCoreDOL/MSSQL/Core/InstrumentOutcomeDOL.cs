using Octavo.Gate.Nabu.CORE.Entities.Core;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core
{
    public class InstrumentOutcomeDOL : BaseDOL
    {
        public InstrumentOutcomeDOL() : base ()
        {
        }

        public InstrumentOutcomeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public InstrumentOutcome Get(int? pInstrumentOutcomeID)
        {
            return null;
        }

        public InstrumentOutcome[] List(int pInstrumentID, int pLanguageID)
        {
            List<InstrumentOutcome> instrumentOutcomes = new List<InstrumentOutcome>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[InstrumentOutcome_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pInstrumentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        InstrumentOutcome instrumentOutcome = new InstrumentOutcome(sqlDataReader.GetInt32(0));
                        instrumentOutcome.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        instrumentOutcomes.Add(instrumentOutcome);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    InstrumentOutcome instrumentOutcome = new InstrumentOutcome();
                    instrumentOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrumentOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    instrumentOutcomes.Add(instrumentOutcome);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrumentOutcomes.ToArray();
        }

        public InstrumentOutcome Insert(InstrumentOutcome pInstrumentOutcome)
        {
            return null;
        }

        public InstrumentOutcome Update(InstrumentOutcome pInstrumentOutcome)
        {
            return null;
        }

        public InstrumentOutcome Delete(InstrumentOutcome pInstrumentOutcome)
        {
            return null;
        }
    }
}
