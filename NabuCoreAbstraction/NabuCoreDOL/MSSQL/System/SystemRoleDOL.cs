using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.System;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.System
{
    public class SystemRoleDOL : BaseDOL
    {
        public SystemRoleDOL() : base ()
        {
        }

        public SystemRoleDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public SystemRole Assign(SystemRole pSystemRole)
        {
            SystemRole systemRole = new SystemRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[SystemRole_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SystemRoleID", pSystemRole.PartyRoleTypeID));

                    sqlCommand.ExecuteNonQuery();

                    systemRole = new SystemRole((Int32)pSystemRole.PartyRoleTypeID);
                }
                catch (Exception exc)
                {
                    systemRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    systemRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return systemRole;
        }

        public SystemRole Remove(SystemRole pSystemRole)
        {
            SystemRole systemRole = new SystemRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[SystemRole_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SystemRoleID", pSystemRole.PartyRoleTypeID));

                    sqlCommand.ExecuteNonQuery();

                    systemRole = new SystemRole(pSystemRole.PartyRoleTypeID);
                }
                catch (Exception exc)
                {
                    systemRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    systemRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return systemRole;
        }
    }
}
