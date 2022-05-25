using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities;
using System;
using System.Reflection;
using System.Data;
using Microsoft.Data.SqlClient;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core
{
    public class InstrumentSectionDOL : BaseDOL
    {
        public InstrumentSectionDOL() : base ()
        {
        }

        public InstrumentSectionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public InstrumentSection Get(int? pInstrumentSectionID, int pLanguageID)
        {
            InstrumentSection instrumentSection = new InstrumentSection();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[InstrumentSection_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentSectionID", pInstrumentSectionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        instrumentSection = new InstrumentSection(sqlDataReader.GetInt32(0));
                        instrumentSection.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    instrumentSection.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrumentSection.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrumentSection;
        }

        public InstrumentSection[] List(int? pInstrumentPartID, int pLanguageID)
        {
            List<InstrumentSection> instrumentSections = new List<InstrumentSection>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[InstrumentSection_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentPartID", pInstrumentPartID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        InstrumentSection instrumentSection = new InstrumentSection(sqlDataReader.GetInt32(0));
                        instrumentSection.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        instrumentSections.Add(instrumentSection);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    InstrumentSection instrumentSection = new InstrumentSection();
                    instrumentSection.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrumentSection.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    instrumentSections.Add(instrumentSection);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrumentSections.ToArray();
        }

        public InstrumentSection Insert(InstrumentSection pInstrumentSection, int? pInstrumentPartID)
        {
            InstrumentSection instrumentSection = new InstrumentSection();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[InstrumentSection_Insert]");
                try
                {
                    pInstrumentSection.Detail = base.InsertTranslation(pInstrumentSection.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentPartID", pInstrumentPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pInstrumentSection.Detail.TranslationID));
                    SqlParameter instrumentSectionID = sqlCommand.Parameters.Add("@InstrumentSectionID", SqlDbType.Int);
                    instrumentSectionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    instrumentSection = new InstrumentSection((Int32)instrumentSectionID.Value);
                    instrumentSection.Detail = new Translation(pInstrumentSection.Detail.TranslationID);
                }
                catch (Exception exc)
                {
                    instrumentSection.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrumentSection.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrumentSection;
        }

        public InstrumentSection Update(InstrumentSection pInstrumentSection)
        {
            base.UpdateTranslation(pInstrumentSection.Detail);
            return pInstrumentSection;
        }

        public InstrumentSection Delete(InstrumentSection pInstrumentSection)
        {
            InstrumentSection instrumentSection = new InstrumentSection();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[InstrumentSection_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentSectionID", pInstrumentSection.InstrumentSectionID));

                    sqlCommand.ExecuteNonQuery();

                    instrumentSection = new InstrumentSection(pInstrumentSection.InstrumentSectionID);
                    base.DeleteAllTranslations(pInstrumentSection.Detail);
                }
                catch (Exception exc)
                {
                    instrumentSection.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    instrumentSection.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return instrumentSection;
        }

        public BaseBoolean AddItemToSection(int pInstrumentSectionID, int pItemID, int pDisplaySequence, int pAttemptNumber)
        {
            BaseBoolean result = new BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[InstrumentItem_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentSectionID", pInstrumentSectionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pDisplaySequence));
                    sqlCommand.Parameters.Add(new SqlParameter("@AttemptNumber", pAttemptNumber));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    result.Value = false;
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public BaseBoolean DeleteAllInSection(int pInstrumentSectionID)
        {
            BaseBoolean result = new BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[InstrumentItem_DeleteInSection]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstrumentSectionID", pInstrumentSectionID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    result.Value = false;
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}
