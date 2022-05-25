using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development
{
    public class RequirementTypeDOL : BaseDOL
    {
        public RequirementTypeDOL() : base()
        {
        }

        public RequirementTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType Get(int pRequirementTypeID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType requirementType = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementTypeID", pRequirementTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        requirementType = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType(sqlDataReader.GetInt32(0));
                        requirementType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    requirementType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType requirementType = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        requirementType = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType(sqlDataReader.GetInt32(0));
                        requirementType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    requirementType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType> requirementTypes = new List<Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType requirementType = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType(sqlDataReader.GetInt32(0));
                        requirementType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        requirementTypes.Add(requirementType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType requirementType = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType();
                    requirementType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    requirementTypes.Add(requirementType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementTypes.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType Insert(Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType pRequirementType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType requirementType = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementType_Insert]");
                try
                {
                    pRequirementType.Detail = base.InsertTranslation(pRequirementType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pRequirementType.Detail.TranslationID));
                    SqlParameter requirementTypeID = sqlCommand.Parameters.Add("@RequirementTypeID", SqlDbType.Int);
                    requirementTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    requirementType = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType((Int32)requirementTypeID.Value);
                    requirementType.Detail = new Translation(pRequirementType.Detail.TranslationID);
                    requirementType.Detail.Alias = pRequirementType.Detail.Alias;
                    requirementType.Detail.Description = pRequirementType.Detail.Description;
                    requirementType.Detail.Name = pRequirementType.Detail.Name;
                }
                catch (Exception exc)
                {
                    requirementType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType Update(Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType pRequirementType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType requirementType = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType();

            pRequirementType.Detail = base.UpdateTranslation(pRequirementType.Detail);

            requirementType = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType(pRequirementType.RequirementTypeID);
            requirementType.Detail = new Translation(pRequirementType.Detail.TranslationID);
            requirementType.Detail.Alias = pRequirementType.Detail.Alias;
            requirementType.Detail.Description = pRequirementType.Detail.Description;
            requirementType.Detail.Name = pRequirementType.Detail.Name;

            return requirementType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType Delete(Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType pRequirementType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType requirementType = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementTypeID", pRequirementType.RequirementTypeID));

                    sqlCommand.ExecuteNonQuery();

                    requirementType = new Octavo.Gate.Nabu.CORE.Entities.Development.RequirementType(pRequirementType.RequirementTypeID);
                    base.DeleteAllTranslations(pRequirementType.Detail);
                }
                catch (Exception exc)
                {
                    requirementType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirementType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirementType;
        }
    }
}

