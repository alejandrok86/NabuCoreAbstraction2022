using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Item;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item
{
    public class ScaleDOL : BaseDOL
    {
        public ScaleDOL() : base ()
        {
        }

        public ScaleDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Scale Get(int pScaleID, int pLanguageID)
        {
            Scale scale = new Scale();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Scale_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ScaleID", pScaleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        scale = new Scale(sqlDataReader.GetInt32(0));
                        scale.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    scale.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scale.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scale;
        }

        public Scale GetByAlias(string pAlias, int pLanguageID)
        {
            Scale scale = new Scale();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Scale_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        scale = new Scale(sqlDataReader.GetInt32(0));
                        scale.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    scale.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scale.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scale;
        }

        public Scale[] List(int pLanguageID)
        {
            List<Scale> scales = new List<Scale>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Scale_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Scale scale = new Scale(sqlDataReader.GetInt32(0));
                        scale.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        scales.Add(scale);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Scale scale = new Scale();
                    scale.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scale.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    scales.Add(scale);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scales.ToArray();
        }

        public Scale Insert(Scale pScale)
        {
            Scale scale = new Scale();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Scale_Insert]");
                try
                {
                    pScale.Detail = base.InsertTranslation(pScale.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pScale.Detail.TranslationID));
                    SqlParameter scaleID = sqlCommand.Parameters.Add("@ScaleID", SqlDbType.Int);
                    scaleID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    scale = new Scale((Int32)scaleID.Value);
                    scale.Detail = new Translation(pScale.Detail.TranslationID);
                    scale.Detail.Alias = pScale.Detail.Alias;
                    scale.Detail.Description = pScale.Detail.Description;
                    scale.Detail.Name = pScale.Detail.Name;
                }
                catch (Exception exc)
                {
                    scale.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scale.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scale;
        }

        public Scale Update(Scale pScale)
        {
            Scale scale = new Scale();

            pScale.Detail = base.UpdateTranslation(pScale.Detail);

            scale = new Scale(pScale.ScaleID);
            scale.Detail = new Translation(pScale.Detail.TranslationID);
            scale.Detail.Alias = pScale.Detail.Alias;
            scale.Detail.Description = pScale.Detail.Description;
            scale.Detail.Name = pScale.Detail.Name;

            return scale;
        }

        public Scale Delete(Scale pScale)
        {
            Scale scale = new Scale();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[Scale_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ScaleID", pScale.ScaleID));

                    sqlCommand.ExecuteNonQuery();

                    scale = new Scale(pScale.ScaleID);
                    base.DeleteAllTranslations(pScale.Detail);
                }
                catch (Exception exc)
                {
                    scale.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scale.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scale;
        }
    }
}
