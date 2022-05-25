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
    public class InformalOrganisationDOL : BaseDOL
    {
        public InformalOrganisationDOL()
            : base()
        {
        }

        public InformalOrganisationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public InformalOrganisation Assign(InformalOrganisation pInformalOrganisation)
        {
            InformalOrganisation informalOrganisation = new InformalOrganisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[InformalOrganisation_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InformalOrganisationID", pInformalOrganisation.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    informalOrganisation = new InformalOrganisation((Int32)pInformalOrganisation.PartyID);
                }
                catch (Exception exc)
                {
                    informalOrganisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    informalOrganisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return informalOrganisation;
        }

        public InformalOrganisation Remove(InformalOrganisation pInformalOrganisation)
        {
            InformalOrganisation informalOrganisation = new InformalOrganisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[Instrument_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InformalOrganisationID", pInformalOrganisation.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    informalOrganisation = new InformalOrganisation(pInformalOrganisation.PartyID);
                }
                catch (Exception exc)
                {
                    informalOrganisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    informalOrganisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return informalOrganisation;
        }
    }
}
