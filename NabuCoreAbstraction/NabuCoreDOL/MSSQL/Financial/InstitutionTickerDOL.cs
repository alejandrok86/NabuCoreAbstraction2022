using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class InstitutionTickerDOL : BaseDOL
    {
        public InstitutionTickerDOL() : base()
        {
        }

        public InstitutionTickerDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public InstitutionTicker Get(int pInstitutionID, int pAssessingOrganisationID)
        {
            InstitutionTicker institutionTicker = new InstitutionTicker();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionTicker_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessingOrganisationID", pAssessingOrganisationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        institutionTicker = new InstitutionTicker();
                        institutionTicker.assessingOrganisation = new AssessingOrganisation(sqlDataReader.GetInt32(0));
                        institutionTicker.Code = sqlDataReader.GetString(1);
                    } 

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    institutionTicker.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionTicker.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionTicker;
        }

        public InstitutionTicker[] List(int pInstitutionID)
        {
            List<InstitutionTicker> institutionTickers = new List<InstitutionTicker>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionTicker_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        InstitutionTicker institutionTicker = new InstitutionTicker();
                        institutionTicker.assessingOrganisation = new AssessingOrganisation(sqlDataReader.GetInt32(0));
                        institutionTicker.Code = sqlDataReader.GetString(1);

                        institutionTickers.Add(institutionTicker);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    InstitutionTicker institutionTicker = new InstitutionTicker();
                    institutionTicker.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionTicker.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    institutionTickers.Add(institutionTicker);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionTickers.ToArray();
        }

        public InstitutionTicker Insert(InstitutionTicker pInstitutionTicker, int pInstitutionID)
        {
            InstitutionTicker institutionTicker = new InstitutionTicker();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionTicker_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessingOrganisationID", pInstitutionTicker.assessingOrganisation.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", pInstitutionTicker.Code));

                    sqlCommand.ExecuteNonQuery();

                    institutionTicker = new InstitutionTicker();
                    institutionTicker.assessingOrganisation = pInstitutionTicker.assessingOrganisation;
                    institutionTicker.Code = pInstitutionTicker.Code;
                }
                catch (Exception exc)
                {
                    institutionTicker.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionTicker.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionTicker;
        }

        public InstitutionTicker Update(InstitutionTicker pInstitutionTicker, int pInstitutionID)
        {
            InstitutionTicker institutionTicker = new InstitutionTicker();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionTicker_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessingOrganisationID", pInstitutionTicker.assessingOrganisation.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", pInstitutionTicker.Code));

                    sqlCommand.ExecuteNonQuery();

                    institutionTicker = new InstitutionTicker();
                    institutionTicker.assessingOrganisation = pInstitutionTicker.assessingOrganisation;
                    institutionTicker.Code = pInstitutionTicker.Code;
                }
                catch (Exception exc)
                {
                    institutionTicker.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionTicker.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionTicker;
        }

        public InstitutionTicker Delete(InstitutionTicker pInstitutionTicker, int pInstitutionID)
        {
            InstitutionTicker institutionTicker = new InstitutionTicker();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionTicker_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessingOrganisationID", pInstitutionTicker.assessingOrganisation.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    institutionTicker = new InstitutionTicker();
                }
                catch (Exception exc)
                {
                    institutionTicker.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionTicker.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionTicker;
        }

    }
}
