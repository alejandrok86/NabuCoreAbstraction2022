using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.System
{
    public class ScreenDOL : BaseDOL
    {
        public ScreenDOL() : base()
        {
        }

        public ScreenDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Screen Get(int pScreenID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Screen screen = new Octavo.Gate.Nabu.CORE.Entities.System.Screen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Screen_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenID", pScreenID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        screen = new Octavo.Gate.Nabu.CORE.Entities.System.Screen(sqlDataReader.GetInt32(0));
                        screen.Name = sqlDataReader.GetString(1);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    screen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    screen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return screen;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Screen GetByName(int pModuleID, string pScreenName)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Screen screen = new Octavo.Gate.Nabu.CORE.Entities.System.Screen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Screen_GetByName]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenName", pScreenName));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        screen = new Octavo.Gate.Nabu.CORE.Entities.System.Screen(sqlDataReader.GetInt32(0));
                        screen.Name = sqlDataReader.GetString(1);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    screen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    screen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return screen;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Screen[] List(int pModuleID, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.System.Screen> screens = new List<Octavo.Gate.Nabu.CORE.Entities.System.Screen>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Screen_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.System.Screen screen = new Octavo.Gate.Nabu.CORE.Entities.System.Screen(sqlDataReader.GetInt32(0));
                        screen.Name = sqlDataReader.GetString(1);
                        screens.Add(screen);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.System.Screen screen = new Octavo.Gate.Nabu.CORE.Entities.System.Screen();
                    screen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    screen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    screens.Add(screen);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return screens.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Screen Insert(Octavo.Gate.Nabu.CORE.Entities.System.Screen pScreen, int pModuleID)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Screen screen = new Octavo.Gate.Nabu.CORE.Entities.System.Screen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Screen_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenName", pScreen.Name));
                    SqlParameter screenID = sqlCommand.Parameters.Add("@ScreenID", SqlDbType.Int);
                    screenID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    screen = new Octavo.Gate.Nabu.CORE.Entities.System.Screen((Int32)screenID.Value);
                    screen.Name = pScreen.Name;
                }
                catch (Exception exc)
                {
                    screen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    screen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return screen;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Screen Update(Octavo.Gate.Nabu.CORE.Entities.System.Screen pScreen, int pModuleID)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Screen screen = new Octavo.Gate.Nabu.CORE.Entities.System.Screen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Screen_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenID", pScreen.ScreenID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ModuleID", pModuleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenName", pScreen.Name));

                    sqlCommand.ExecuteNonQuery();

                    screen = new Octavo.Gate.Nabu.CORE.Entities.System.Screen(pScreen.ScreenID);
                    screen.Name = pScreen.Name;
                }
                catch (Exception exc)
                {
                    screen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    screen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return screen;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Screen Delete(Octavo.Gate.Nabu.CORE.Entities.System.Screen pScreen)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Screen screen = new Octavo.Gate.Nabu.CORE.Entities.System.Screen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Screen_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ScreenID", pScreen.ScreenID));

                    sqlCommand.ExecuteNonQuery();

                    screen = new Octavo.Gate.Nabu.CORE.Entities.System.Screen(pScreen.ScreenID);
                }
                catch (Exception exc)
                {
                    screen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    screen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return screen;
        }
    }
}


