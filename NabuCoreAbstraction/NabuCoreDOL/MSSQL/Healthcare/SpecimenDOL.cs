using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare
{
    public class SpecimenDOL : BaseDOL
    {
        public SpecimenDOL() : base ()
        {
        }

        public SpecimenDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Specimen Get(int? pSpecimenID)
        {
            Specimen specimen = new Specimen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Specimen_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenID", pSpecimenID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        specimen = new Specimen(sqlDataReader.GetInt32(0));
                        specimen.CollectedAt = sqlDataReader.GetDateTime(1);
                        specimen.CollectedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            specimen.CollectedFromLocation = new Entities.Operations.Location(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            specimen.CollectedFromLatitude = sqlDataReader.GetDecimal(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            specimen.CollectedFromLongitude = sqlDataReader.GetDecimal(5);
                        specimen.SpecimenType = new SpecimenType(sqlDataReader.GetInt32(6));
                        specimen.SpecimenStatus = new SpecimenStatus(sqlDataReader.GetInt32(7));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    specimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimen;
        }

        public PhysicalSpecimen GetPhysicalSpecimen(string pTrackingCode)
        {
            PhysicalSpecimen physicalSpecimen = new PhysicalSpecimen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PhysicalSpecimen_GetByTrackingCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", pTrackingCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        physicalSpecimen = new PhysicalSpecimen(sqlDataReader.GetInt32(0));
                        physicalSpecimen.CollectedAt = sqlDataReader.GetDateTime(1);
                        physicalSpecimen.CollectedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            physicalSpecimen.CollectedFromLocation = new Entities.Operations.Location(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            physicalSpecimen.CollectedFromLatitude = sqlDataReader.GetDecimal(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            physicalSpecimen.CollectedFromLongitude = sqlDataReader.GetDecimal(5);
                        physicalSpecimen.SpecimenType = new SpecimenType(sqlDataReader.GetInt32(6));
                        physicalSpecimen.SpecimenStatus = new SpecimenStatus(sqlDataReader.GetInt32(7));
                        physicalSpecimen.StockItem = new Entities.Operations.StockItem(sqlDataReader.GetInt32(8));
                        physicalSpecimen.TrackingCode = new Entities.Operations.TrackingCode(sqlDataReader.GetInt32(9));
                        physicalSpecimen.TrackingCode.Code = sqlDataReader.GetString(10);
                        physicalSpecimen.TrackingCode.TrackingCodeType = new Entities.Operations.TrackingCodeType(sqlDataReader.GetInt32(11));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    physicalSpecimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    physicalSpecimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return physicalSpecimen;
        }

        public Specimen[] List()
        {
            List<Specimen> specimens = new List<Specimen>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Specimen_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Specimen specimen = new Specimen(sqlDataReader.GetInt32(0));
                        specimen.CollectedAt = sqlDataReader.GetDateTime(1);
                        specimen.CollectedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            specimen.CollectedFromLocation = new Entities.Operations.Location(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            specimen.CollectedFromLatitude = sqlDataReader.GetDecimal(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            specimen.CollectedFromLongitude = sqlDataReader.GetDecimal(5);
                        specimen.SpecimenType = new SpecimenType(sqlDataReader.GetInt32(6));
                        specimen.SpecimenStatus = new SpecimenStatus(sqlDataReader.GetInt32(7));
                        specimens.Add(specimen);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Specimen specimen = new Specimen();
                    specimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specimens.Add(specimen);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimens.ToArray();
        }
        public Specimen[] ListByPart(int pPartID)
        {
            List<Specimen> specimens = new List<Specimen>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Specimen_ListByPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Specimen specimen = new Specimen(sqlDataReader.GetInt32(0));
                        specimen.CollectedAt = sqlDataReader.GetDateTime(1);
                        specimen.CollectedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            specimen.CollectedFromLocation = new Entities.Operations.Location(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            specimen.CollectedFromLatitude = sqlDataReader.GetDecimal(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            specimen.CollectedFromLongitude = sqlDataReader.GetDecimal(5);
                        specimen.SpecimenType = new SpecimenType(sqlDataReader.GetInt32(6));
                        specimen.SpecimenStatus = new SpecimenStatus(sqlDataReader.GetInt32(7));
                        specimens.Add(specimen);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Specimen specimen = new Specimen();
                    specimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specimens.Add(specimen);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimens.ToArray();
        }
        public Specimen[] ListByParty(int pPartyID)
        {
            List<Specimen> specimens = new List<Specimen>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Specimen_ListByParty]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Specimen specimen = new Specimen(sqlDataReader.GetInt32(0));
                        specimen.CollectedAt = sqlDataReader.GetDateTime(1);
                        specimen.CollectedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            specimen.CollectedFromLocation = new Entities.Operations.Location(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            specimen.CollectedFromLatitude = sqlDataReader.GetDecimal(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            specimen.CollectedFromLongitude = sqlDataReader.GetDecimal(5);
                        specimen.SpecimenType = new SpecimenType(sqlDataReader.GetInt32(6));
                        specimen.SpecimenStatus = new SpecimenStatus(sqlDataReader.GetInt32(7));
                        specimens.Add(specimen);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Specimen specimen = new Specimen();
                    specimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    specimens.Add(specimen);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimens.ToArray();
        }

        public DigitalSpecimen[] ListDigitalSpecimenByPart(int pPartID)
        {
            List<DigitalSpecimen> digitalSpecimens = new List<DigitalSpecimen>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[DigitalSpecimen_ListByPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        DigitalSpecimen digitalSpecimen = new DigitalSpecimen(sqlDataReader.GetInt32(0));
                        digitalSpecimen.CollectedAt = sqlDataReader.GetDateTime(1);
                        digitalSpecimen.CollectedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            digitalSpecimen.CollectedFromLocation = new Entities.Operations.Location(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            digitalSpecimen.CollectedFromLatitude = sqlDataReader.GetDecimal(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            digitalSpecimen.CollectedFromLongitude = sqlDataReader.GetDecimal(5);
                        digitalSpecimen.SpecimenType = new SpecimenType(sqlDataReader.GetInt32(6));
                        digitalSpecimen.SpecimenStatus = new SpecimenStatus(sqlDataReader.GetInt32(7));
                        digitalSpecimen.Content = new Entities.Content.Content(sqlDataReader.GetInt32(8));
                        digitalSpecimens.Add(digitalSpecimen);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    DigitalSpecimen digitalSpecimen = new DigitalSpecimen();
                    digitalSpecimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    digitalSpecimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    digitalSpecimens.Add(digitalSpecimen);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return digitalSpecimens.ToArray();
        }
        public DigitalSpecimen[] ListDigitalSpecimenByParty(int pPartyID)
        {
            List<DigitalSpecimen> digitalSpecimens = new List<DigitalSpecimen>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[DigitalSpecimen_ListByParty]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        DigitalSpecimen digitalSpecimen = new DigitalSpecimen(sqlDataReader.GetInt32(0));
                        digitalSpecimen.CollectedAt = sqlDataReader.GetDateTime(1);
                        digitalSpecimen.CollectedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            digitalSpecimen.CollectedFromLocation = new Entities.Operations.Location(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            digitalSpecimen.CollectedFromLatitude = sqlDataReader.GetDecimal(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            digitalSpecimen.CollectedFromLongitude = sqlDataReader.GetDecimal(5);
                        digitalSpecimen.SpecimenType = new SpecimenType(sqlDataReader.GetInt32(6));
                        digitalSpecimen.SpecimenStatus = new SpecimenStatus(sqlDataReader.GetInt32(7));
                        digitalSpecimen.Content = new Entities.Content.Content(sqlDataReader.GetInt32(8));
                        digitalSpecimens.Add(digitalSpecimen);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    DigitalSpecimen digitalSpecimen = new DigitalSpecimen();
                    digitalSpecimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    digitalSpecimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    digitalSpecimens.Add(digitalSpecimen);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return digitalSpecimens.ToArray();
        }
        public PhysicalSpecimen[] ListPhysicalSpecimenByPart(int pPartID)
        {
            List<PhysicalSpecimen> physicalSpecimens = new List<PhysicalSpecimen>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PhysicalSpecimen_ListByPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PhysicalSpecimen physicalSpecimen = new PhysicalSpecimen(sqlDataReader.GetInt32(0));
                        physicalSpecimen.CollectedAt = sqlDataReader.GetDateTime(1);
                        physicalSpecimen.CollectedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            physicalSpecimen.CollectedFromLocation = new Entities.Operations.Location(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            physicalSpecimen.CollectedFromLatitude = sqlDataReader.GetDecimal(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            physicalSpecimen.CollectedFromLongitude = sqlDataReader.GetDecimal(5);
                        physicalSpecimen.SpecimenType = new SpecimenType(sqlDataReader.GetInt32(6));
                        physicalSpecimen.SpecimenStatus = new SpecimenStatus(sqlDataReader.GetInt32(7));
                        physicalSpecimen.StockItem = new Entities.Operations.StockItem(sqlDataReader.GetInt32(8));
                        physicalSpecimen.TrackingCode = new Entities.Operations.TrackingCode(sqlDataReader.GetInt32(9));
                        physicalSpecimens.Add(physicalSpecimen);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PhysicalSpecimen physicalSpecimen = new PhysicalSpecimen();
                    physicalSpecimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    physicalSpecimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    physicalSpecimens.Add(physicalSpecimen);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return physicalSpecimens.ToArray();
        }
        public PhysicalSpecimen[] ListPhysicalSpecimenByParty(int pPartyID)
        {
            List<PhysicalSpecimen> physicalSpecimens = new List<PhysicalSpecimen>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PhysicalSpecimen_ListByParty]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PhysicalSpecimen physicalSpecimen = new PhysicalSpecimen(sqlDataReader.GetInt32(0));
                        physicalSpecimen.CollectedAt = sqlDataReader.GetDateTime(1);
                        physicalSpecimen.CollectedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            physicalSpecimen.CollectedFromLocation = new Entities.Operations.Location(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            physicalSpecimen.CollectedFromLatitude = sqlDataReader.GetDecimal(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            physicalSpecimen.CollectedFromLongitude = sqlDataReader.GetDecimal(5);
                        physicalSpecimen.SpecimenType = new SpecimenType(sqlDataReader.GetInt32(6));
                        physicalSpecimen.SpecimenStatus = new SpecimenStatus(sqlDataReader.GetInt32(7));
                        physicalSpecimen.StockItem = new Entities.Operations.StockItem(sqlDataReader.GetInt32(8));
                        physicalSpecimen.TrackingCode = new Entities.Operations.TrackingCode(sqlDataReader.GetInt32(9));
                        physicalSpecimens.Add(physicalSpecimen);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PhysicalSpecimen physicalSpecimen = new PhysicalSpecimen();
                    physicalSpecimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    physicalSpecimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    physicalSpecimens.Add(physicalSpecimen);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return physicalSpecimens.ToArray();
        }

        public Specimen Insert(Specimen pSpecimen)
        {
            Specimen specimen = new Specimen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Specimen_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CollectedAt", pSpecimen.CollectedAt));
                    sqlCommand.Parameters.Add(new SqlParameter("@CollectedBy", pSpecimen.CollectedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CollectedFromLocationID", ((pSpecimen.CollectedFromLocation != null && pSpecimen.CollectedFromLocation.LocationID != null) ? pSpecimen.CollectedFromLocation.LocationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@CollectedFromLatitude", ((pSpecimen.CollectedFromLatitude.HasValue) ? pSpecimen.CollectedFromLatitude : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@CollectedFromLongitude", ((pSpecimen.CollectedFromLongitude.HasValue) ? pSpecimen.CollectedFromLatitude : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenTypeID", pSpecimen.SpecimenType.SpecimenTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenStatusID", pSpecimen.SpecimenStatus.SpecimenStatusID));
                    SqlParameter specimenID = sqlCommand.Parameters.Add("@SpecimenID", SqlDbType.Int);
                    specimenID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    specimen = new Specimen((Int32)specimenID.Value);
                    specimen.CollectedAt = pSpecimen.CollectedAt;
                    specimen.CollectedBy = pSpecimen.CollectedBy;
                    specimen.CollectedFromLocation = pSpecimen.CollectedFromLocation;
                    specimen.CollectedFromLatitude = pSpecimen.CollectedFromLatitude;
                    specimen.CollectedFromLongitude = pSpecimen.CollectedFromLongitude;
                    specimen.SpecimenType = pSpecimen.SpecimenType;
                    specimen.SpecimenStatus = pSpecimen.SpecimenStatus;
                }
                catch (Exception exc)
                {
                    specimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimen;
        }

        public Specimen Update(Specimen pSpecimen)
        {
            Specimen specimen = new Specimen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Specimen_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenID", pSpecimen.SpecimenID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CollectedAt", pSpecimen.CollectedAt));
                    sqlCommand.Parameters.Add(new SqlParameter("@CollectedBy", pSpecimen.CollectedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CollectedFromLocationID", ((pSpecimen.CollectedFromLocation != null && pSpecimen.CollectedFromLocation.LocationID != null) ? pSpecimen.CollectedFromLocation.LocationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@CollectedFromLatitude", ((pSpecimen.CollectedFromLatitude.HasValue) ? pSpecimen.CollectedFromLatitude : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@CollectedFromLongitude", ((pSpecimen.CollectedFromLongitude.HasValue) ? pSpecimen.CollectedFromLatitude : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenTypeID", pSpecimen.SpecimenType.SpecimenTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenStatusID", pSpecimen.SpecimenStatus.SpecimenStatusID));

                    sqlCommand.ExecuteNonQuery();

                    specimen = new Specimen(pSpecimen.SpecimenID);
                    specimen.CollectedAt = pSpecimen.CollectedAt;
                    specimen.CollectedBy = pSpecimen.CollectedBy;
                    specimen.CollectedFromLocation = pSpecimen.CollectedFromLocation;
                    specimen.CollectedFromLatitude = pSpecimen.CollectedFromLatitude;
                    specimen.CollectedFromLongitude = pSpecimen.CollectedFromLongitude;
                    specimen.SpecimenType = pSpecimen.SpecimenType;
                    specimen.SpecimenStatus = pSpecimen.SpecimenStatus;
                }
                catch (Exception exc)
                {
                    specimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimen;
        }

        public Specimen Delete(Specimen pSpecimen)
        {
            Specimen specimen = new Specimen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[Specimen_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenID", pSpecimen.SpecimenID));

                    sqlCommand.ExecuteNonQuery();

                    specimen = new Specimen(pSpecimen.SpecimenID);
                }
                catch (Exception exc)
                {
                    specimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    specimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return specimen;
        }

        public DigitalSpecimen AssignContent(int pSpecimenID, int pContentID)
        {
            DigitalSpecimen digitalSpecimen = new DigitalSpecimen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[DigitalSpecimen_AssignContent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenID", pSpecimenID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    digitalSpecimen = new DigitalSpecimen(pSpecimenID);
                }
                catch (Exception exc)
                {
                    digitalSpecimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    digitalSpecimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return digitalSpecimen;
        }

        public PhysicalSpecimen Assign(int pSpecimenID, int pStockItemID, int pTrackingCodeID)
        {
            PhysicalSpecimen physicalSpecimen = new PhysicalSpecimen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PhysicalSpecimen_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenID", pSpecimenID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StockItemID", pStockItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TrackingCodeID", pTrackingCodeID));

                    sqlCommand.ExecuteNonQuery();

                    physicalSpecimen = new PhysicalSpecimen(pSpecimenID);
                }
                catch (Exception exc)
                {
                    physicalSpecimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    physicalSpecimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return physicalSpecimen;
        }

        public DigitalSpecimen DeleteDigitalSpecimen(int pSpecimenID)
        {
            DigitalSpecimen digitalSpecimen = new DigitalSpecimen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[DigitalSpecimen_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenID", pSpecimenID));

                    sqlCommand.ExecuteNonQuery();

                    digitalSpecimen = new DigitalSpecimen(pSpecimenID);
                }
                catch (Exception exc)
                {
                    digitalSpecimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    digitalSpecimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return digitalSpecimen;
        }
        public PhysicalSpecimen DeletePhysicalSpecimen(int pSpecimenID)
        {
            PhysicalSpecimen physicalSpecimen = new PhysicalSpecimen();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[PhysicalSpecimen_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecimenID", pSpecimenID));

                    sqlCommand.ExecuteNonQuery();

                    physicalSpecimen = new PhysicalSpecimen(pSpecimenID);   
                }
                catch (Exception exc)
                {
                    physicalSpecimen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    physicalSpecimen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return physicalSpecimen;
        }
    }
}
