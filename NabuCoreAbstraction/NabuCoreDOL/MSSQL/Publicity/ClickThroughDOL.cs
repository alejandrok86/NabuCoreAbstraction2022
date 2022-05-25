using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octavo.Gate.Nabu.CORE.Entities.Publicity;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Data;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Publicity
{
    public class ClickThroughDOL : BaseDOL
    {
        public ClickThroughDOL() : base ()
        {
        }

        public ClickThroughDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ClickThrough Insert(ClickThrough pClickThrough)
        {
            ClickThrough clickThrough = new ClickThrough();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPublicity].[ClickThrough_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AdvertisementID", pClickThrough.AdvertisementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClickedThroughOn", pClickThrough.ClickedThroughOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@RemoteUser", pClickThrough.RemoteUser));
                    sqlCommand.Parameters.Add(new SqlParameter("@RemoteHost", pClickThrough.RemoteHost));
                    sqlCommand.Parameters.Add(new SqlParameter("@Type", pClickThrough.Type));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pClickThrough.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@Version", pClickThrough.Version));
                    sqlCommand.Parameters.Add(new SqlParameter("@MajorVersion", pClickThrough.MajorVersion));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinorVersion", pClickThrough.MinorVersion));
                    sqlCommand.Parameters.Add(new SqlParameter("@Platform", pClickThrough.Platform));
                    sqlCommand.Parameters.Add(new SqlParameter("@SupportsCookies", pClickThrough.SupportsCookies));
                    sqlCommand.Parameters.Add(new SqlParameter("@SupportsJavaScript", pClickThrough.SupportsJavaScript));
                    sqlCommand.Parameters.Add(new SqlParameter("@SupportsActiveXControls", pClickThrough.SupportsActiveXControls));
                    SqlParameter clickThroughID = sqlCommand.Parameters.Add("@ClickThroughID", SqlDbType.Int);
                    clickThroughID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    clickThrough = new ClickThrough((Int32)clickThroughID.Value);
                    clickThrough.AdvertisementID = pClickThrough.AdvertisementID;
                    clickThrough.ClickedThroughOn = pClickThrough.ClickedThroughOn;
                    clickThrough.RemoteUser = pClickThrough.RemoteUser;
                    clickThrough.RemoteHost = pClickThrough.RemoteHost;
                    clickThrough.Type = pClickThrough.Type;
                    clickThrough.Name = pClickThrough.Name;
                    clickThrough.Version = pClickThrough.Version;
                    clickThrough.MajorVersion = pClickThrough.MajorVersion;
                    clickThrough.MinorVersion = pClickThrough.MinorVersion;
                    clickThrough.Platform = pClickThrough.Platform;
                    clickThrough.SupportsCookies = pClickThrough.SupportsCookies;
                    clickThrough.SupportsJavaScript = pClickThrough.SupportsJavaScript;
                    clickThrough.SupportsActiveXControls = pClickThrough.SupportsActiveXControls;
                }
                catch (Exception exc)
                {
                    clickThrough.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clickThrough.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clickThrough;
        }
    }
}
