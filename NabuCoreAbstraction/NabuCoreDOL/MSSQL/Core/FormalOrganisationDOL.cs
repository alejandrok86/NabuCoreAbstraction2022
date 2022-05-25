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
    public class FormalOrganisationDOL : BaseDOL
    {
        public FormalOrganisationDOL() : base()
        {
        }

        public FormalOrganisationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public FormalOrganisation Assign(FormalOrganisation pFormalOrganisation)
        {
            FormalOrganisation formalOrganisation = new FormalOrganisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[FormalOrganisation_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FormalOrganisationID", pFormalOrganisation.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    formalOrganisation = new FormalOrganisation((Int32)pFormalOrganisation.PartyID);
                }
                catch (Exception exc)
                {
                    formalOrganisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    formalOrganisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return formalOrganisation;
        }

        public FormalOrganisation Remove(FormalOrganisation pFormalOrganisation)
        {
            FormalOrganisation formalOrganisation = new FormalOrganisation();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[FormalOrganisation_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FormalOrganisationID", pFormalOrganisation.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    formalOrganisation = new FormalOrganisation(pFormalOrganisation.PartyID);
                }
                catch (Exception exc)
                {
                    formalOrganisation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    formalOrganisation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return formalOrganisation;
        }
    }
}
