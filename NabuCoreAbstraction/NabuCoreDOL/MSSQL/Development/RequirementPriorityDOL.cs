using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development
{
    public class RequirementPriorityDOL : BaseDOL
    {
        public RequirementPriorityDOL() : base()
        {
        }

        public RequirementPriorityDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority Get(int pRequirementPriorityID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority requirementPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementPriority_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementPriorityID", pRequirementPriorityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        requirementPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority(sqlDataReader.GetInt32(0));
                        requirementPriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    requirementPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority requirementPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementPriority_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        requirementPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority(sqlDataReader.GetInt32(0));
                        requirementPriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    requirementPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority> requirementPrioritys = new List<Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementPriority_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority requirementPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority(sqlDataReader.GetInt32(0));
                        requirementPriority.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        requirementPrioritys.Add(requirementPriority);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority requirementPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority();
                    requirementPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    requirementPrioritys.Add(requirementPriority);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementPrioritys.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority Insert(Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority pRequirementPriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority requirementPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementPriority_Insert]");
                try
                {
                    pRequirementPriority.Detail = base.InsertTranslation(pRequirementPriority.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pRequirementPriority.Detail.TranslationID));
                    SqlParameter requirementPriorityID = sqlCommand.Parameters.Add("@RequirementPriorityID", SqlDbType.Int);
                    requirementPriorityID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    requirementPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority((Int32)requirementPriorityID.Value);
                    requirementPriority.Detail = new Translation(pRequirementPriority.Detail.TranslationID);
                    requirementPriority.Detail.Alias = pRequirementPriority.Detail.Alias;
                    requirementPriority.Detail.Description = pRequirementPriority.Detail.Description;
                    requirementPriority.Detail.Name = pRequirementPriority.Detail.Name;
                }
                catch (Exception exc)
                {
                    requirementPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority Update(Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority pRequirementPriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority requirementPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority();

            pRequirementPriority.Detail = base.UpdateTranslation(pRequirementPriority.Detail);

            requirementPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority(pRequirementPriority.RequirementPriorityID);
            requirementPriority.Detail = new Translation(pRequirementPriority.Detail.TranslationID);
            requirementPriority.Detail.Alias = pRequirementPriority.Detail.Alias;
            requirementPriority.Detail.Description = pRequirementPriority.Detail.Description;
            requirementPriority.Detail.Name = pRequirementPriority.Detail.Name;

            return requirementPriority;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority Delete(Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority pRequirementPriority)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority requirementPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementPriority_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementPriorityID", pRequirementPriority.RequirementPriorityID));

                    sqlCommand.ExecuteNonQuery();

                    requirementPriority = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementPriority(pRequirementPriority.RequirementPriorityID);
                    base.DeleteAllTranslations(pRequirementPriority.Detail);
                }
                catch (Exception exc)
                {
                    requirementPriority.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementPriority.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementPriority;
        }
    }
}

