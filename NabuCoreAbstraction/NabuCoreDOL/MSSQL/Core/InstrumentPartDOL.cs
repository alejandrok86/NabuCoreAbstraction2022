using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core
{
    public class InstrumentPartDOL : BaseDOL
    {
        public InstrumentPartDOL() : base ()
        {
        }

        public InstrumentPartDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public InstrumentPart Get(int? pInstrumentPartID, int pLanguageID)
        {
            InstrumentPart instrumentPart = new InstrumentPart();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[InstrumentPart_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentPartID", pInstrumentPartID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        instrumentPart = new InstrumentPart(sqlDataReader.GetInt32(0));
                        instrumentPart.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    instrumentPart.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrumentPart.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrumentPart;
        }

        public InstrumentPart[] List(int? pInstrumentID, int pLanguageID)
        {
            List<InstrumentPart> instrumentParts = new List<InstrumentPart>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[InstrumentPart_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pInstrumentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        InstrumentPart instrumentPart = new InstrumentPart(sqlDataReader.GetInt32(0));
                        instrumentPart.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        instrumentParts.Add(instrumentPart);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    InstrumentPart instrumentPart = new InstrumentPart();
                    instrumentPart.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrumentPart.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    instrumentParts.Add(instrumentPart);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrumentParts.ToArray();
        }

        public InstrumentPart Insert(InstrumentPart pInstrumentPart, int? pInstrumentID)
        {
            InstrumentPart instrumentPart = new InstrumentPart();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[InstrumentPart_Insert]");
                try
                {
                    pInstrumentPart.Detail = base.InsertTranslation(pInstrumentPart.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentID", pInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pInstrumentPart.Detail.TranslationID));
                    SqlParameter instrumentPartID = sqlCommand.Parameters.Add("@InstrumentPartID", SqlDbType.Int);
                    instrumentPartID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    instrumentPart = new InstrumentPart((Int32)instrumentPartID.Value);
                    instrumentPart.Detail = new Translation(pInstrumentPart.Detail.TranslationID);
                }
                catch (Exception exc)
                {
                    instrumentPart.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrumentPart.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrumentPart;
        }

        public InstrumentPart Update(InstrumentPart pInstrumentPart)
        {
            base.UpdateTranslation(pInstrumentPart.Detail);
            return pInstrumentPart;
        }

        public InstrumentPart Delete(InstrumentPart pInstrumentPart)
        {
            InstrumentPart instrumentPart = new InstrumentPart();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[InstrumentPart_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentPartID", pInstrumentPart.InstrumentPartID));

                    sqlCommand.ExecuteNonQuery();

                    instrumentPart = new InstrumentPart(pInstrumentPart.InstrumentPartID);
                    base.DeleteAllTranslations(pInstrumentPart.Detail);
                }
                catch (Exception exc)
                {
                    instrumentPart.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrumentPart.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrumentPart;
        }
    }
}

