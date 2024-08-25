using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESL.Core.Migrations
{
    /// <inheritdoc />
    public partial class sqliteUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_CreatedBy",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_ModifiedBy",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_NotifiedPerson",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_OperatorID",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_ReleasedBy_EmployeeEmployeeNo",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_ReleasedTo_EmployeeEmployeeNo",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_ReportedBy_EmployeeEmployeeNo",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_ReportedTo_EmployeeEmployeeNo",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_UpdatedBy_EmployeeEmployeeNo",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_Facilities_FacilNo",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_Facilities_NotifiedFacilityFacilNo",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_LogTypes_LogTypeNo",
                table: "ESL_SOC");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_FlowChanges",
                table: "ESL_FlowChanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_EquipmentInvolved",
                table: "ESL_EquipmentInvolved");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_Details",
                table: "ESL_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_ScanDocs",
                table: "ESL_ScanDocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_LogTypes",
                table: "ESL_LogTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_Facilities",
                table: "ESL_Facilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_Employees",
                table: "ESL_Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_Constants",
                table: "ESL_Constants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_ClearanceZones",
                table: "ESL_ClearanceZones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_ClearanceTypes",
                table: "ESL_ClearanceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_ClearanceIssues",
                table: "ESL_ClearanceIssues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_AllEvents",
                table: "ESL_AllEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_PlantShifts",
                table: "ESL_PlantShifts");

            migrationBuilder.DropColumn(
                name: "IssedBy",
                table: "ESL_ClearanceIssues");

            migrationBuilder.DropColumn(
                name: "IssedDate",
                table: "ESL_ClearanceIssues");

            migrationBuilder.DropColumn(
                name: "IssedTime",
                table: "ESL_ClearanceIssues");

            migrationBuilder.DropColumn(
                name: "IssedTo",
                table: "ESL_ClearanceIssues");

            migrationBuilder.EnsureSchema(
                name: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_FlowChanges",
                newName: "ESL_FLOWCHANGES");

            migrationBuilder.RenameTable(
                name: "ESL_EquipmentInvolved",
                newName: "ESL_EQUIPMENTINVOLVED");

            migrationBuilder.RenameTable(
                name: "ESL_Details",
                newName: "ESL_DETAILS");

            migrationBuilder.RenameTable(
                name: "ESL_WorkToBePerformed",
                newName: "ESL_WorkToBePerformed",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_WorkOrders",
                newName: "ESL_WorkOrders",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_SOC",
                newName: "ESL_SOC",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_ScanDocs",
                newName: "ESL_SCANDOCS",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_RelatedTo",
                newName: "ESL_RelatedTo",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_LogTypes",
                newName: "ESL_LOGTYPES",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_Facilities",
                newName: "ESL_FACILITIES",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_Employees",
                newName: "ESL_EMPLOYEES",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_Constants",
                newName: "ESL_CONSTANTS",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_ClearanceZones",
                newName: "ESL_CLEARANCEZONES",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_ClearanceTypes",
                newName: "ESL_CLEARANCETYPES",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_ClearanceIssues",
                newName: "ESL_CLEARANCEISSUES",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_AllEvents",
                newName: "ESL_ALLEVENTS",
                newSchema: "ESL");

            migrationBuilder.RenameTable(
                name: "ESL_PlantShifts",
                newName: "ESL_PLANTSHITS");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "ESL_Units",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "ESL_Subjects",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "ESL_Meters",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "ESL_General",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "Yr",
                table: "ESL_FLOWCHANGES",
                newName: "YR");

            migrationBuilder.RenameColumn(
                name: "WorkOrders",
                table: "ESL_FLOWCHANGES",
                newName: "WORKORDERS");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ESL_FLOWCHANGES",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "ESL_FLOWCHANGES",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "ShiftNo",
                table: "ESL_FLOWCHANGES",
                newName: "SHIFTNO");

            migrationBuilder.RenameColumn(
                name: "SeqNo",
                table: "ESL_FLOWCHANGES",
                newName: "SEQNO");

            migrationBuilder.RenameColumn(
                name: "RequestedTo",
                table: "ESL_FLOWCHANGES",
                newName: "REQUESTEDTO");

            migrationBuilder.RenameColumn(
                name: "RequestedTime",
                table: "ESL_FLOWCHANGES",
                newName: "REQUESTEDTIME");

            migrationBuilder.RenameColumn(
                name: "RequestedDate",
                table: "ESL_FLOWCHANGES",
                newName: "REQUESTEDDATE");

            migrationBuilder.RenameColumn(
                name: "RequestedBy",
                table: "ESL_FLOWCHANGES",
                newName: "REQUESTEDBY");

            migrationBuilder.RenameColumn(
                name: "RelatedTo",
                table: "ESL_FLOWCHANGES",
                newName: "RELATEDTO");

            migrationBuilder.RenameColumn(
                name: "OperatorType",
                table: "ESL_FLOWCHANGES",
                newName: "OPERATORTYPE");

            migrationBuilder.RenameColumn(
                name: "OperatorID",
                table: "ESL_FLOWCHANGES",
                newName: "OPERATORID");

            migrationBuilder.RenameColumn(
                name: "OldValue",
                table: "ESL_FLOWCHANGES",
                newName: "OLDVALUE");

            migrationBuilder.RenameColumn(
                name: "OldUnit",
                table: "ESL_FLOWCHANGES",
                newName: "OLDUNIT");

            migrationBuilder.RenameColumn(
                name: "OffTime",
                table: "ESL_FLOWCHANGES",
                newName: "OFFTIME");

            migrationBuilder.RenameColumn(
                name: "NotifiedPerson",
                table: "ESL_FLOWCHANGES",
                newName: "NOTIFIEDPERSON");

            migrationBuilder.RenameColumn(
                name: "NotifiedFacil",
                table: "ESL_FLOWCHANGES",
                newName: "NOTIFIEDFACIL");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "ESL_FLOWCHANGES",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "NewValue",
                table: "ESL_FLOWCHANGES",
                newName: "NEWVALUE");

            migrationBuilder.RenameColumn(
                name: "ModifyFlag",
                table: "ESL_FLOWCHANGES",
                newName: "MODIFYFLAG");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "ESL_FLOWCHANGES",
                newName: "MODIFIEDDATE");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ESL_FLOWCHANGES",
                newName: "MODIFIEDBY");

            migrationBuilder.RenameColumn(
                name: "MeterID",
                table: "ESL_FLOWCHANGES",
                newName: "METERID");

            migrationBuilder.RenameColumn(
                name: "EventTime",
                table: "ESL_FLOWCHANGES",
                newName: "EVENTTIME");

            migrationBuilder.RenameColumn(
                name: "EventDate",
                table: "ESL_FLOWCHANGES",
                newName: "EVENTDATE");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "ESL_FLOWCHANGES",
                newName: "CREATEDDATE");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ESL_FLOWCHANGES",
                newName: "CREATEDBY");

            migrationBuilder.RenameColumn(
                name: "ChangeByUnit",
                table: "ESL_FLOWCHANGES",
                newName: "CHANGEBYUNIT");

            migrationBuilder.RenameColumn(
                name: "ChangeBy",
                table: "ESL_FLOWCHANGES",
                newName: "CHANGEBY");

            migrationBuilder.RenameColumn(
                name: "Accepted",
                table: "ESL_FLOWCHANGES",
                newName: "ACCEPTED");

            migrationBuilder.RenameColumn(
                name: "EventID_RevNo",
                table: "ESL_FLOWCHANGES",
                newName: "EVENTID_REVNO");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "ESL_FLOWCHANGES",
                newName: "EVENTID");

            migrationBuilder.RenameColumn(
                name: "LogTypeNo",
                table: "ESL_FLOWCHANGES",
                newName: "LOGTYPENO");

            migrationBuilder.RenameColumn(
                name: "FacilNo",
                table: "ESL_FLOWCHANGES",
                newName: "FACILNO");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "ESL_FLOWCHANGES",
                newName: "NEWUNIT");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ESL_EQUIPMENTINVOLVED",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "ESL_EQUIPMENTINVOLVED",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "ESL_EQUIPMENTINVOLVED",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "FacilType",
                table: "ESL_EQUIPMENTINVOLVED",
                newName: "FACILTYPE");

            migrationBuilder.RenameColumn(
                name: "EquipName",
                table: "ESL_EQUIPMENTINVOLVED",
                newName: "EQUIPNAME");

            migrationBuilder.RenameColumn(
                name: "Disable",
                table: "ESL_EQUIPMENTINVOLVED",
                newName: "DISABLE");

            migrationBuilder.RenameColumn(
                name: "EquipNo",
                table: "ESL_EQUIPMENTINVOLVED",
                newName: "EQUIPNO");

            migrationBuilder.RenameColumn(
                name: "FacilNo",
                table: "ESL_EQUIPMENTINVOLVED",
                newName: "FACILNO");

            migrationBuilder.RenameColumn(
                name: "Yr",
                table: "ESL_EOS",
                newName: "YR");

            migrationBuilder.RenameColumn(
                name: "WorkOrders",
                table: "ESL_EOS",
                newName: "WORKORDERS");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ESL_EOS",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "ESL_EOS",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "TagsRemoved",
                table: "ESL_EOS",
                newName: "TAGSREMOVED");

            migrationBuilder.RenameColumn(
                name: "TagsInstalled",
                table: "ESL_EOS",
                newName: "TAGSINSTALLED");

            migrationBuilder.RenameColumn(
                name: "ShiftNo",
                table: "ESL_EOS",
                newName: "SHIFTNO");

            migrationBuilder.RenameColumn(
                name: "SeqNo",
                table: "ESL_EOS",
                newName: "SEQNO");

            migrationBuilder.RenameColumn(
                name: "ReportedTo",
                table: "ESL_EOS",
                newName: "REPORTEDTO");

            migrationBuilder.RenameColumn(
                name: "ReportedTime",
                table: "ESL_EOS",
                newName: "REPORTEDTIME");

            migrationBuilder.RenameColumn(
                name: "ReportedDate",
                table: "ESL_EOS",
                newName: "REPORTEDDATE");

            migrationBuilder.RenameColumn(
                name: "ReportedBy",
                table: "ESL_EOS",
                newName: "REPORTEDBY");

            migrationBuilder.RenameColumn(
                name: "ReleasedTime",
                table: "ESL_EOS",
                newName: "RELEASEDTIME");

            migrationBuilder.RenameColumn(
                name: "ReleasedDate",
                table: "ESL_EOS",
                newName: "RELEASEDDATE");

            migrationBuilder.RenameColumn(
                name: "ReleasedBy",
                table: "ESL_EOS",
                newName: "RELEASEDBY");

            migrationBuilder.RenameColumn(
                name: "ReleaseType",
                table: "ESL_EOS",
                newName: "RELEASETYPE");

            migrationBuilder.RenameColumn(
                name: "RelatedTo",
                table: "ESL_EOS",
                newName: "RELATEDTO");

            migrationBuilder.RenameColumn(
                name: "OperatorType",
                table: "ESL_EOS",
                newName: "OPERATORTYPE");

            migrationBuilder.RenameColumn(
                name: "OperatorID",
                table: "ESL_EOS",
                newName: "OPERATORID");

            migrationBuilder.RenameColumn(
                name: "NotifiedPerson",
                table: "ESL_EOS",
                newName: "NOTIFIEDPERSON");

            migrationBuilder.RenameColumn(
                name: "NotifiedFacil",
                table: "ESL_EOS",
                newName: "NOTIFIEDFACIL");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "ESL_EOS",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "ModifyFlag",
                table: "ESL_EOS",
                newName: "MODIFYFLAG");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "ESL_EOS",
                newName: "MODIFIEDDATE");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ESL_EOS",
                newName: "MODIFIEDBY");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "ESL_EOS",
                newName: "LOCATION");

            migrationBuilder.RenameColumn(
                name: "EquipmentInvolved",
                table: "ESL_EOS",
                newName: "EQUIPMENTINVOLVED");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "ESL_EOS",
                newName: "CREATEDDATE");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ESL_EOS",
                newName: "CREATEDBY");

            migrationBuilder.RenameColumn(
                name: "EventID_RevNo",
                table: "ESL_EOS",
                newName: "EVENTID_REVNO");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "ESL_EOS",
                newName: "EVENTID");

            migrationBuilder.RenameColumn(
                name: "LogTypeNo",
                table: "ESL_EOS",
                newName: "LOGTYPENO");

            migrationBuilder.RenameColumn(
                name: "FacilNo",
                table: "ESL_EOS",
                newName: "FACILNO");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ESL_DETAILS",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "ESL_DETAILS",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "SortNo",
                table: "ESL_DETAILS",
                newName: "SORTNO");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "ESL_DETAILS",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "FacilType",
                table: "ESL_DETAILS",
                newName: "FACILTYPE");

            migrationBuilder.RenameColumn(
                name: "DetailsName",
                table: "ESL_DETAILS",
                newName: "DETAILSNAME");

            migrationBuilder.RenameColumn(
                name: "DetailsNo",
                table: "ESL_DETAILS",
                newName: "DETAILSNO");

            migrationBuilder.RenameColumn(
                name: "FacilNo",
                table: "ESL_DETAILS",
                newName: "FACILNO");

            migrationBuilder.RenameColumn(
                name: "Disabled?",
                table: "ESL_DETAILS",
                newName: "DISABLE");

            migrationBuilder.RenameColumn(
                name: "WorkDescription",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                newName: "WORKDESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "SortNo",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                newName: "SORTNO");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "Disable",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                newName: "DISABLE");

            migrationBuilder.RenameColumn(
                name: "WorkNo",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                newName: "WORKNO");

            migrationBuilder.RenameColumn(
                name: "FacilType",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                newName: "FACILTYPE");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "ESL",
                table: "ESL_WorkOrders",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_WorkOrders",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_WorkOrders",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "WO_No",
                schema: "ESL",
                table: "ESL_WorkOrders",
                newName: "WO_NO");

            migrationBuilder.RenameColumn(
                name: "EventID",
                schema: "ESL",
                table: "ESL_WorkOrders",
                newName: "EVENTID");

            migrationBuilder.RenameColumn(
                name: "LogTypeNo",
                schema: "ESL",
                table: "ESL_WorkOrders",
                newName: "LOGTYPENO");

            migrationBuilder.RenameColumn(
                name: "FacilNo",
                schema: "ESL",
                table: "ESL_WorkOrders",
                newName: "FACILNO");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_SOC",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "TagsInstalled",
                schema: "ESL",
                table: "ESL_SOC",
                newName: "TagsRemoved");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "ScanFileName",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                newName: "SCANFILENAME");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "ScanNo",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                newName: "SCANNO");

            migrationBuilder.RenameColumn(
                name: "EventID",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                newName: "EVENTID");

            migrationBuilder.RenameColumn(
                name: "LogTypeNo",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                newName: "LOGTYPENO");

            migrationBuilder.RenameColumn(
                name: "FacilNo",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                newName: "FACILNO");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "ESL",
                table: "ESL_RelatedTo",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_RelatedTo",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_RelatedTo",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "RelatedTo_Subject",
                schema: "ESL",
                table: "ESL_RelatedTo",
                newName: "RelatedTo_SUBJECT");

            migrationBuilder.RenameColumn(
                name: "EventID",
                schema: "ESL",
                table: "ESL_RelatedTo",
                newName: "EVENTID");

            migrationBuilder.RenameColumn(
                name: "LogTypeNo",
                schema: "ESL",
                table: "ESL_RelatedTo",
                newName: "LOGTYPENO");

            migrationBuilder.RenameColumn(
                name: "FacilNo",
                schema: "ESL",
                table: "ESL_RelatedTo",
                newName: "FACILNO");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "ESL",
                table: "ESL_LOGTYPES",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_LOGTYPES",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_LOGTYPES",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "LogTypeNo",
                schema: "ESL",
                table: "ESL_LOGTYPES",
                newName: "LOGTYPENO");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "ESL",
                table: "ESL_FACILITIES",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_FACILITIES",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "SortNo",
                schema: "ESL",
                table: "ESL_FACILITIES",
                newName: "SORTNO");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_FACILITIES",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "FacilType",
                schema: "ESL",
                table: "ESL_FACILITIES",
                newName: "FACILTYPE");

            migrationBuilder.RenameColumn(
                name: "FacilName",
                schema: "ESL",
                table: "ESL_FACILITIES",
                newName: "FACILNAME");

            migrationBuilder.RenameColumn(
                name: "FacilFullName",
                schema: "ESL",
                table: "ESL_FACILITIES",
                newName: "FACILFULLNAME");

            migrationBuilder.RenameColumn(
                name: "FacilAbbr",
                schema: "ESL",
                table: "ESL_FACILITIES",
                newName: "FACILABBR");

            migrationBuilder.RenameColumn(
                name: "Disable",
                schema: "ESL",
                table: "ESL_FACILITIES",
                newName: "DISABLE");

            migrationBuilder.RenameColumn(
                name: "FacilNo",
                schema: "ESL",
                table: "ESL_FACILITIES",
                newName: "FACILNO");

            migrationBuilder.RenameColumn(
                name: "VisibleTo",
                schema: "ESL",
                table: "ESL_FACILITIES",
                newName: "VISABLETO");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                newName: "LASTNAME");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                newName: "JOBTITLE");

            migrationBuilder.RenameColumn(
                name: "GroupName",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                newName: "GROUPNAME");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                newName: "FIRSTNAME");

            migrationBuilder.RenameColumn(
                name: "FacilNo",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                newName: "FACILNO");

            migrationBuilder.RenameColumn(
                name: "Disable",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                newName: "DISABLE");

            migrationBuilder.RenameColumn(
                name: "Company",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                newName: "COMPANY");

            migrationBuilder.RenameColumn(
                name: "EmployeeNo",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                newName: "EMPLOYEENO");

            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                newName: "VALUE");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                newName: "ENDDATE");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                newName: "STARTDATE");

            migrationBuilder.RenameColumn(
                name: "ConstantName",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                newName: "CONSTANTNAME");

            migrationBuilder.RenameColumn(
                name: "FacilNo",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                newName: "FACILNO");

            migrationBuilder.RenameColumn(
                name: "ZoneDescription",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                newName: "ZONEDESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "SortNo",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                newName: "SORTNO");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "Disable",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                newName: "DISABLE");

            migrationBuilder.RenameColumn(
                name: "ZoneNo",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                newName: "ZONENO");

            migrationBuilder.RenameColumn(
                name: "FacilType",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                newName: "FACILTYPE");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "SortNo",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                newName: "SORTNO");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "ClearanceTypeName",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                newName: "CLEARANCETYPENAME");

            migrationBuilder.RenameColumn(
                name: "ClearanceTypeAbbr",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                newName: "CLEARANCETYPEABBR");

            migrationBuilder.RenameColumn(
                name: "ClearanceTypeNo",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                newName: "CLEARANCETYPENO");

            migrationBuilder.RenameColumn(
                name: "Yr",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "YR");

            migrationBuilder.RenameColumn(
                name: "WorkToBePerformed",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "WORKTOBEPERFORMED");

            migrationBuilder.RenameColumn(
                name: "WorkOrders",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "WORKORDERS");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "TagsRemoved",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "TAGSREMOVED");

            migrationBuilder.RenameColumn(
                name: "ShiftNo",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "SHIFTNO");

            migrationBuilder.RenameColumn(
                name: "SeqNo",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "SEQNO");

            migrationBuilder.RenameColumn(
                name: "ReleasedTo",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "RELEASEDTO");

            migrationBuilder.RenameColumn(
                name: "ReleasedTime",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "RELEASEDTIME");

            migrationBuilder.RenameColumn(
                name: "ReleasedDate",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "RELEASEDDATE");

            migrationBuilder.RenameColumn(
                name: "ReleasedBy",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "RELEASEDBY");

            migrationBuilder.RenameColumn(
                name: "ReleaseType",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "RELEASETYPE");

            migrationBuilder.RenameColumn(
                name: "RelatedTo",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "RELATEDTO");

            migrationBuilder.RenameColumn(
                name: "OperatorType",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "OPERATORTYPE");

            migrationBuilder.RenameColumn(
                name: "OperatorID",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "OPERATORID");

            migrationBuilder.RenameColumn(
                name: "NotifiedPerson",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "NOTIFIEDPERSON");

            migrationBuilder.RenameColumn(
                name: "NotifiedFacil",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "NOTIFIEDFACIL");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "ModifyFlag",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "MODIFYFLAG");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "MODIFIEDDATE");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "MODIFIEDBY");

            migrationBuilder.RenameColumn(
                name: "Location",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "LOCATION");

            migrationBuilder.RenameColumn(
                name: "FacilAbbr",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "FACILABBR");

            migrationBuilder.RenameColumn(
                name: "EquipmentInvolved",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "EQUIPMENTINVOLVED");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "CREATEDDATE");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "CREATEDBY");

            migrationBuilder.RenameColumn(
                name: "ClearanceZone",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "CLEARANCEZONE");

            migrationBuilder.RenameColumn(
                name: "ClearanceType",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "CLEARANCETYPE");

            migrationBuilder.RenameColumn(
                name: "ClearanceID",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "CLEARANCEID");

            migrationBuilder.RenameColumn(
                name: "EventID_RevNo",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "EVENTID_REVNO");

            migrationBuilder.RenameColumn(
                name: "EventID",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "EVENTID");

            migrationBuilder.RenameColumn(
                name: "LogTypeNo",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "LOGTYPENO");

            migrationBuilder.RenameColumn(
                name: "FacilNo",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                newName: "FACILNO");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "UPDATEDBY");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "UPDATEDATE");

            migrationBuilder.RenameColumn(
                name: "Subject",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "SUBJECT");

            migrationBuilder.RenameColumn(
                name: "Notes",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "NOTES");

            migrationBuilder.RenameColumn(
                name: "ModifyFlag",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "MODIFYFLAG");

            migrationBuilder.RenameColumn(
                name: "EventTime",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "EVENTTIME");

            migrationBuilder.RenameColumn(
                name: "EventDate",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "EVENTDATE");

            migrationBuilder.RenameColumn(
                name: "Details",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "DETAILS");

            migrationBuilder.RenameColumn(
                name: "ClearanceID",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "CLEARANCEID");

            migrationBuilder.RenameColumn(
                name: "EventID_RevNo",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "EVENTID_REVNO");

            migrationBuilder.RenameColumn(
                name: "EventID",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "EVENTID");

            migrationBuilder.RenameColumn(
                name: "LogTypeNo",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "LOGTYPENO");

            migrationBuilder.RenameColumn(
                name: "FacilNo",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "FACILNO");

            migrationBuilder.RenameColumn(
                name: "OperatorType",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                newName: "OPERATORYTYPE");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                table: "ESL_Units",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_Subjects",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "ESL_Subjects",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                table: "ESL_Subjects",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_ScanLobs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "ESL_ScanLobs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ScanLobType",
                table: "ESL_ScanLobs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ScanLob",
                table: "ESL_ScanLobs",
                type: "BLOB",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_Meters",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "ESL_Meters",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                table: "ESL_Meters",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeterType",
                table: "ESL_Meters",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                table: "ESL_General",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "YR",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "WORKORDERS",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                table: "ESL_FLOWCHANGES",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "SHIFTNO",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SEQNO",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "REQUESTEDTO",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "REQUESTEDTIME",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "REQUESTEDDATE",
                table: "ESL_FLOWCHANGES",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "REQUESTEDBY",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RELATEDTO",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OPERATORTYPE",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OPERATORID",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "OLDVALUE",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OLDUNIT",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "OFFTIME",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NOTIFIEDPERSON",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTIFIEDFACIL",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NEWVALUE",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MODIFYFLAG",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIEDDATE",
                table: "ESL_FLOWCHANGES",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MODIFIEDBY",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "METERID",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EVENTTIME",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EVENTDATE",
                table: "ESL_FLOWCHANGES",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDDATE",
                table: "ESL_FLOWCHANGES",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CREATEDBY",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CHANGEBYUNIT",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CHANGEBY",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ACCEPTED",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EVENTID_REVNO",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "EVENTID",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "LOGTYPENO",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FACILNO",
                table: "ESL_FLOWCHANGES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "NEWUNIT",
                table: "ESL_FLOWCHANGES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                table: "ESL_EQUIPMENTINVOLVED",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                table: "ESL_EQUIPMENTINVOLVED",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                table: "ESL_EQUIPMENTINVOLVED",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FACILTYPE",
                table: "ESL_EQUIPMENTINVOLVED",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EQUIPNAME",
                table: "ESL_EQUIPMENTINVOLVED",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "DISABLE",
                table: "ESL_EQUIPMENTINVOLVED",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EQUIPNO",
                table: "ESL_EQUIPMENTINVOLVED",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FACILNO",
                table: "ESL_EQUIPMENTINVOLVED",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "YR",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "WORKORDERS",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                table: "ESL_EOS",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "TAGSREMOVED",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TAGSINSTALLED",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SHIFTNO",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SEQNO",
                table: "ESL_EOS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "REPORTEDTO",
                table: "ESL_EOS",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "REPORTEDTIME",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "REPORTEDDATE",
                table: "ESL_EOS",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "REPORTEDBY",
                table: "ESL_EOS",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RELEASEDTIME",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RELEASEDDATE",
                table: "ESL_EOS",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RELEASEDBY",
                table: "ESL_EOS",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RELEASETYPE",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RELATEDTO",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OPERATORTYPE",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OPERATORID",
                table: "ESL_EOS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "NOTIFIEDPERSON",
                table: "ESL_EOS",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTIFIEDFACIL",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MODIFYFLAG",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIEDDATE",
                table: "ESL_EOS",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MODIFIEDBY",
                table: "ESL_EOS",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LOCATION",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EQUIPMENTINVOLVED",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDDATE",
                table: "ESL_EOS",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CREATEDBY",
                table: "ESL_EOS",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EVENTID_REVNO",
                table: "ESL_EOS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "EVENTID",
                table: "ESL_EOS",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "LOGTYPENO",
                table: "ESL_EOS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FACILNO",
                table: "ESL_EOS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                table: "ESL_DETAILS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                table: "ESL_DETAILS",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SORTNO",
                table: "ESL_DETAILS",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                table: "ESL_DETAILS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FACILTYPE",
                table: "ESL_DETAILS",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "DETAILSNAME",
                table: "ESL_DETAILS",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "DETAILSNO",
                table: "ESL_DETAILS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FACILNO",
                table: "ESL_DETAILS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "DISABLE",
                table: "ESL_DETAILS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SUBJNO",
                table: "ESL_DETAILS",
                type: "NUMBER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WORKDESCRIPTION",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "SORTNO",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DISABLE",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WORKNO",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "FACILTYPE",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                schema: "ESL",
                table: "ESL_WorkOrders",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                schema: "ESL",
                table: "ESL_WorkOrders",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_WorkOrders",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WO_NO",
                schema: "ESL",
                table: "ESL_WorkOrders",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EVENTID",
                schema: "ESL",
                table: "ESL_WorkOrders",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "LOGTYPENO",
                schema: "ESL",
                table: "ESL_WorkOrders",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FACILNO",
                schema: "ESL",
                table: "ESL_WorkOrders",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ReportedTo_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ReportedTime",
                schema: "ESL",
                table: "ESL_SOC",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ReportedBy_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ReleasedTo_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ReleasedBy_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "OperatorID",
                schema: "ESL",
                table: "ESL_SOC",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "NotifiedPerson",
                schema: "ESL",
                table: "ESL_SOC",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NotifiedFacilityFacilNo",
                schema: "ESL",
                table: "ESL_SOC",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_SOC",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                schema: "ESL",
                table: "ESL_SOC",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                schema: "ESL",
                table: "ESL_SOC",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LogTypeNo",
                schema: "ESL",
                table: "ESL_SOC",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                schema: "ESL",
                table: "ESL_SOC",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "SCANFILENAME",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SCANNO",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "EVENTID",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "LOGTYPENO",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FACILNO",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                schema: "ESL",
                table: "ESL_RelatedTo",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                schema: "ESL",
                table: "ESL_RelatedTo",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_RelatedTo",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RelatedTo_SUBJECT",
                schema: "ESL",
                table: "ESL_RelatedTo",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EVENTID",
                schema: "ESL",
                table: "ESL_RelatedTo",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "LOGTYPENO",
                schema: "ESL",
                table: "ESL_RelatedTo",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FACILNO",
                schema: "ESL",
                table: "ESL_RelatedTo",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                schema: "ESL",
                table: "ESL_LOGTYPES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                schema: "ESL",
                table: "ESL_LOGTYPES",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_LOGTYPES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogTypeName",
                schema: "ESL",
                table: "ESL_LOGTYPES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "LOGTYPENO",
                schema: "ESL",
                table: "ESL_LOGTYPES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                schema: "ESL",
                table: "ESL_FACILITIES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                schema: "ESL",
                table: "ESL_FACILITIES",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "SORTNO",
                schema: "ESL",
                table: "ESL_FACILITIES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_FACILITIES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FACILTYPE",
                schema: "ESL",
                table: "ESL_FACILITIES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FACILNAME",
                schema: "ESL",
                table: "ESL_FACILITIES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FACILFULLNAME",
                schema: "ESL",
                table: "ESL_FACILITIES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FACILABBR",
                schema: "ESL",
                table: "ESL_FACILITIES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "DISABLE",
                schema: "ESL",
                table: "ESL_FACILITIES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FACILNO",
                schema: "ESL",
                table: "ESL_FACILITIES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "VISABLETO",
                schema: "ESL",
                table: "ESL_FACILITIES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LASTNAME",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "JOBTITLE",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GROUPNAME",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FIRSTNAME",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "FACILNO",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DISABLE",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "COMPANY",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "EMPLOYEENO",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "VALUE",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ENDDATE",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "STARTDATE",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CONSTANTNAME",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "FACILNO",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ZONEDESCRIPTION",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "SORTNO",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DISABLE",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ZONENO",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "FACILTYPE",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "FACILNO",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                type: "NUMBER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "SORTNO",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLEARANCETYPENAME",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CLEARANCETYPEABBR",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CLEARANCETYPENO",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "YR",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "WORKTOBEPERFORMED",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WORKORDERS",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "TAGSREMOVED",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SHIFTNO",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SEQNO",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "RELEASEDTO",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RELEASEDTIME",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RELEASEDDATE",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RELEASEDBY",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RELEASETYPE",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RELATEDTO",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OPERATORTYPE",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OPERATORID",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "NOTIFIEDPERSON",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTIFIEDFACIL",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MODIFYFLAG",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIEDDATE",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MODIFIEDBY",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LOCATION",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FACILABBR",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EQUIPMENTINVOLVED",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATEDDATE",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CREATEDBY",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CLEARANCEZONE",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CLEARANCETYPE",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CLEARANCEID",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EVENTID_REVNO",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "EVENTID",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "LOGTYPENO",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FACILNO",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ISSUEDBY",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ISSUEDDATE",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ISSUEDTIME",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "VARCHAR2",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ISSUEDTO",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                type: "NUMBER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UPDATEDBY",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATEDATE",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "SUBJECT",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NOTES",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MODIFYFLAG",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EVENTTIME",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EVENTDATE",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DETAILS",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CLEARANCEID",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EVENTID_REVNO",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "EVENTID",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "VARCHAR2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "LOGTYPENO",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FACILNO",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "NUMBER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "OPERATORYTYPE",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                type: "VARCHAR2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_PLANTSHITS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "ESL_PLANTSHITS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_FLOWCHANGES",
                table: "ESL_FLOWCHANGES",
                columns: new[] { "FACILNO", "LOGTYPENO", "EVENTID", "EVENTID_REVNO" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_EQUIPMENTINVOLVED",
                table: "ESL_EQUIPMENTINVOLVED",
                columns: new[] { "FACILNO", "EQUIPNO" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_DETAILS",
                table: "ESL_DETAILS",
                columns: new[] { "FACILNO", "DETAILSNO" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_SCANDOCS",
                schema: "ESL",
                table: "ESL_SCANDOCS",
                columns: new[] { "FACILNO", "LOGTYPENO", "EVENTID", "SCANNO" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_LOGTYPES",
                schema: "ESL",
                table: "ESL_LOGTYPES",
                column: "LOGTYPENO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_FACILITIES",
                schema: "ESL",
                table: "ESL_FACILITIES",
                column: "FACILNO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_EMPLOYEES",
                schema: "ESL",
                table: "ESL_EMPLOYEES",
                column: "EMPLOYEENO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_CONSTANTS",
                schema: "ESL",
                table: "ESL_CONSTANTS",
                columns: new[] { "FACILNO", "CONSTANTNAME", "STARTDATE" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_CLEARANCEZONES",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES",
                columns: new[] { "FACILTYPE", "ZONENO" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_CLEARANCETYPES",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES",
                column: "CLEARANCETYPENO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_CLEARANCEISSUES",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES",
                columns: new[] { "FACILNO", "LOGTYPENO", "EVENTID", "EVENTID_REVNO" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_ALLEVENTS",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                columns: new[] { "FACILNO", "LOGTYPENO", "EVENTID", "EVENTID_REVNO" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_PLANTSHITS",
                table: "ESL_PLANTSHITS",
                columns: new[] { "FacilNo", "ShiftNo" });

            migrationBuilder.CreateTable(
                name: "ViewAllEventsByFacility",
                columns: table => new
                {
                    FACILNO = table.Column<int>(type: "NUMBER", nullable: false),
                    FacilName = table.Column<string>(type: "VARCHAR2", nullable: false),
                    FacilAbbr = table.Column<string>(type: "VARCHAR2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewAllEventsByLogType",
                columns: table => new
                {
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewAlleventsSearches",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EventTime = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    ClearanceID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewAllFlowChanges",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EventTime = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    FacilName = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    ScanDocsNo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewAllSOC",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EventTime = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    FacilName = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    ScanDocsNo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewClearanceAll",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EventTime = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    ClearanceID = table.Column<string>(type: "TEXT", nullable: true),
                    ScanDocsNo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewCurrentAllEvents",
                columns: table => new
                {
                    FACILNO = table.Column<int>(type: "NUMBER", nullable: false),
                    FACILNAME = table.Column<string>(type: "VARCHAR2", nullable: false),
                    FACILABBR = table.Column<string>(type: "VARCHAR2", nullable: false),
                    LOGTYPENO = table.Column<int>(type: "NUMBER", nullable: false),
                    LOGTYPENAME = table.Column<string>(type: "VARCHAR2", nullable: false),
                    EVENTID = table.Column<string>(type: "VARCHAR2", nullable: false),
                    EVENTID_REVNO = table.Column<int>(type: "NUMBER", nullable: false),
                    EVENTDATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    EVENTTIME = table.Column<string>(type: "VARCHAR2", nullable: true),
                    SUBJECT = table.Column<string>(type: "VARCHAR2", nullable: true),
                    DETAILS = table.Column<string>(type: "VARCHAR2", nullable: true),
                    MODIFYFLAG = table.Column<string>(type: "VARCHAR2", nullable: true),
                    NOTES = table.Column<string>(type: "VARCHAR2", nullable: true),
                    OPERATORTYPE = table.Column<string>(type: "VARCHAR2", nullable: true),
                    UPDATEBY = table.Column<string>(type: "VARCHAR2", nullable: true),
                    UPDATEDATE = table.Column<string>(type: "VARCHAR2", nullable: true),
                    CLEARANCEID = table.Column<string>(type: "VARCHAR2", nullable: true),
                    SCANDOCSNO = table.Column<int>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewCurrentClearanceIssues",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    FacilName = table.Column<string>(type: "TEXT", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IssedTo = table.Column<int>(type: "INTEGER", nullable: false),
                    IssedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    IssedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IssedTime = table.Column<string>(type: "TEXT", nullable: false),
                    ModifyFlag = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Yr = table.Column<string>(type: "TEXT", nullable: false),
                    FacilAbbr = table.Column<string>(type: "TEXT", nullable: false),
                    SeqNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ClearanceType = table.Column<string>(type: "TEXT", nullable: false),
                    ClearanceZone = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    WorkToBePerformed = table.Column<string>(type: "TEXT", nullable: true),
                    EquipmentInvolved = table.Column<string>(type: "TEXT", nullable: true),
                    WorkOrders = table.Column<string>(type: "TEXT", nullable: true),
                    RelatedTo = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    NotifiedFacil = table.Column<string>(type: "TEXT", nullable: true),
                    NotifiedPerson = table.Column<int>(type: "INTEGER", nullable: true),
                    ShiftNo = table.Column<int>(type: "INTEGER", nullable: true),
                    ReleasedTo = table.Column<int>(type: "INTEGER", nullable: true),
                    ReleasedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    ReleasedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReleasedTime = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseType = table.Column<string>(type: "TEXT", nullable: true),
                    TagsRemoved = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClearanceID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewCurrentEOS",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    FacilName = table.Column<string>(type: "TEXT", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Reportedby = table.Column<int>(type: "INTEGER", nullable: true),
                    ReportedTo = table.Column<int>(type: "INTEGER", nullable: true),
                    ReportedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReportedTime = table.Column<string>(type: "TEXT", nullable: true),
                    EquipmentInvolved = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    ReleasedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    ReleasedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReleasedTime = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseType = table.Column<string>(type: "TEXT", nullable: true),
                    TagsInstalled = table.Column<string>(type: "TEXT", nullable: true),
                    TagsRemoved = table.Column<string>(type: "TEXT", nullable: true),
                    ModifyFlag = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    NotifiedFacil = table.Column<string>(type: "TEXT", nullable: true),
                    NotifiedPerson = table.Column<int>(type: "INTEGER", nullable: true),
                    ShiftNo = table.Column<int>(type: "INTEGER", nullable: true),
                    Yr = table.Column<string>(type: "TEXT", nullable: false),
                    SeqNo = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WorkOrders = table.Column<string>(type: "TEXT", nullable: true),
                    RelatedTo = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewCurrentSOC",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    FacilName = table.Column<string>(type: "TEXT", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Reportedby = table.Column<int>(type: "INTEGER", nullable: true),
                    ReportedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReportedTime = table.Column<string>(type: "TEXT", nullable: true),
                    ReportedTo = table.Column<int>(type: "INTEGER", nullable: true),
                    ReleasedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    ReleasedTo = table.Column<int>(type: "INTEGER", nullable: true),
                    ReleasedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReleasedTime = table.Column<string>(type: "TEXT", nullable: true),
                    Yr = table.Column<string>(type: "TEXT", nullable: false),
                    FacilAbbr = table.Column<string>(type: "TEXT", nullable: false),
                    SeqNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Limitations = table.Column<string>(type: "TEXT", nullable: false),
                    EquipmentInvolved = table.Column<string>(type: "TEXT", nullable: true),
                    ModifyFlag = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    NotifiedFacil = table.Column<string>(type: "TEXT", nullable: true),
                    NotifiedPerson = table.Column<int>(type: "INTEGER", nullable: true),
                    ShiftNo = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WorkOrders = table.Column<string>(type: "TEXT", nullable: true),
                    RelatedTo = table.Column<string>(type: "TEXT", nullable: true),
                    TagsRemoved = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseType = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewEOSAll",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EventTime = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    FacilName = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    ScanDocsNo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewGeneralAll",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EventTime = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    FacilName = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    ScanDocsNo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewOutstandingClearances",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EventTime = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    ClearanceID = table.Column<string>(type: "TEXT", nullable: true),
                    ScanDocsNo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewOutstandingEOS",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EventTime = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    FacilName = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    ScanDocsNo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewOutstandingSOC",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EventTime = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    FacilName = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    ScanDocsNo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewRelatedAllevents",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    FacilName = table.Column<string>(type: "TEXT", nullable: false),
                    FacilAbbr = table.Column<string>(type: "TEXT", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EventTime = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<string>(type: "TEXT", nullable: true),
                    ClearanceID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ViewWorkOrders",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    Wo_No = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "WORKTOBEPERMED_PX",
                schema: "ESL",
                table: "ESL_WorkToBePerformed",
                columns: new[] { "FACILTYPE", "WORKNO" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ESL_LOGTYPES_LOGTYPENO_LogTypeName",
                schema: "ESL",
                table: "ESL_LOGTYPES",
                columns: new[] { "LOGTYPENO", "LogTypeName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_ALLEVENTS",
                column: "UPDATEDATE");

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_CreatedBy",
                schema: "ESL",
                table: "ESL_SOC",
                column: "CreatedBy",
                principalSchema: "ESL",
                principalTable: "ESL_EMPLOYEES",
                principalColumn: "EMPLOYEENO");

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_ModifiedBy",
                schema: "ESL",
                table: "ESL_SOC",
                column: "ModifiedBy",
                principalSchema: "ESL",
                principalTable: "ESL_EMPLOYEES",
                principalColumn: "EMPLOYEENO");

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_NotifiedPerson",
                schema: "ESL",
                table: "ESL_SOC",
                column: "NotifiedPerson",
                principalSchema: "ESL",
                principalTable: "ESL_EMPLOYEES",
                principalColumn: "EMPLOYEENO");

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_OperatorID",
                schema: "ESL",
                table: "ESL_SOC",
                column: "OperatorID",
                principalSchema: "ESL",
                principalTable: "ESL_EMPLOYEES",
                principalColumn: "EMPLOYEENO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_ReleasedBy_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC",
                column: "ReleasedBy_EmployeeEmployeeNo",
                principalSchema: "ESL",
                principalTable: "ESL_EMPLOYEES",
                principalColumn: "EMPLOYEENO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_ReleasedTo_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC",
                column: "ReleasedTo_EmployeeEmployeeNo",
                principalSchema: "ESL",
                principalTable: "ESL_EMPLOYEES",
                principalColumn: "EMPLOYEENO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_ReportedBy_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC",
                column: "ReportedBy_EmployeeEmployeeNo",
                principalSchema: "ESL",
                principalTable: "ESL_EMPLOYEES",
                principalColumn: "EMPLOYEENO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_ReportedTo_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC",
                column: "ReportedTo_EmployeeEmployeeNo",
                principalSchema: "ESL",
                principalTable: "ESL_EMPLOYEES",
                principalColumn: "EMPLOYEENO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_UpdatedBy_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC",
                column: "UpdatedBy_EmployeeEmployeeNo",
                principalSchema: "ESL",
                principalTable: "ESL_EMPLOYEES",
                principalColumn: "EMPLOYEENO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_FACILITIES_FacilNo",
                schema: "ESL",
                table: "ESL_SOC",
                column: "FacilNo",
                principalSchema: "ESL",
                principalTable: "ESL_FACILITIES",
                principalColumn: "FACILNO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_FACILITIES_NotifiedFacilityFacilNo",
                schema: "ESL",
                table: "ESL_SOC",
                column: "NotifiedFacilityFacilNo",
                principalSchema: "ESL",
                principalTable: "ESL_FACILITIES",
                principalColumn: "FACILNO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_LOGTYPES_LogTypeNo",
                schema: "ESL",
                table: "ESL_SOC",
                column: "LogTypeNo",
                principalSchema: "ESL",
                principalTable: "ESL_LOGTYPES",
                principalColumn: "LOGTYPENO",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_CreatedBy",
                schema: "ESL",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_ModifiedBy",
                schema: "ESL",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_NotifiedPerson",
                schema: "ESL",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_OperatorID",
                schema: "ESL",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_ReleasedBy_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_ReleasedTo_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_ReportedBy_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_ReportedTo_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_EMPLOYEES_UpdatedBy_EmployeeEmployeeNo",
                schema: "ESL",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_FACILITIES_FacilNo",
                schema: "ESL",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_FACILITIES_NotifiedFacilityFacilNo",
                schema: "ESL",
                table: "ESL_SOC");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_LOGTYPES_LogTypeNo",
                schema: "ESL",
                table: "ESL_SOC");

            migrationBuilder.DropTable(
                name: "ViewAllEventsByFacility");

            migrationBuilder.DropTable(
                name: "ViewAllEventsByLogType");

            migrationBuilder.DropTable(
                name: "ViewAlleventsSearches");

            migrationBuilder.DropTable(
                name: "ViewAllFlowChanges");

            migrationBuilder.DropTable(
                name: "ViewAllSOC");

            migrationBuilder.DropTable(
                name: "ViewClearanceAll");

            migrationBuilder.DropTable(
                name: "ViewCurrentAllEvents");

            migrationBuilder.DropTable(
                name: "ViewCurrentClearanceIssues");

            migrationBuilder.DropTable(
                name: "ViewCurrentEOS");

            migrationBuilder.DropTable(
                name: "ViewCurrentSOC");

            migrationBuilder.DropTable(
                name: "ViewEOSAll");

            migrationBuilder.DropTable(
                name: "ViewGeneralAll");

            migrationBuilder.DropTable(
                name: "ViewOutstandingClearances");

            migrationBuilder.DropTable(
                name: "ViewOutstandingEOS");

            migrationBuilder.DropTable(
                name: "ViewOutstandingSOC");

            migrationBuilder.DropTable(
                name: "ViewRelatedAllevents");

            migrationBuilder.DropTable(
                name: "ViewWorkOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_FLOWCHANGES",
                table: "ESL_FLOWCHANGES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_EQUIPMENTINVOLVED",
                table: "ESL_EQUIPMENTINVOLVED");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_DETAILS",
                table: "ESL_DETAILS");

            migrationBuilder.DropIndex(
                name: "WORKTOBEPERMED_PX",
                schema: "ESL",
                table: "ESL_WorkToBePerformed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_SCANDOCS",
                schema: "ESL",
                table: "ESL_SCANDOCS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_LOGTYPES",
                schema: "ESL",
                table: "ESL_LOGTYPES");

            migrationBuilder.DropIndex(
                name: "IX_ESL_LOGTYPES_LOGTYPENO_LogTypeName",
                schema: "ESL",
                table: "ESL_LOGTYPES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_FACILITIES",
                schema: "ESL",
                table: "ESL_FACILITIES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_EMPLOYEES",
                schema: "ESL",
                table: "ESL_EMPLOYEES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_CONSTANTS",
                schema: "ESL",
                table: "ESL_CONSTANTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_CLEARANCEZONES",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_CLEARANCETYPES",
                schema: "ESL",
                table: "ESL_CLEARANCETYPES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_CLEARANCEISSUES",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_ALLEVENTS",
                schema: "ESL",
                table: "ESL_ALLEVENTS");

            migrationBuilder.DropIndex(
                name: "UpdateDate",
                schema: "ESL",
                table: "ESL_ALLEVENTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_PLANTSHITS",
                table: "ESL_PLANTSHITS");

            migrationBuilder.DropColumn(
                name: "SUBJNO",
                table: "ESL_DETAILS");

            migrationBuilder.DropColumn(
                name: "FACILNO",
                schema: "ESL",
                table: "ESL_CLEARANCEZONES");

            migrationBuilder.DropColumn(
                name: "ISSUEDBY",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES");

            migrationBuilder.DropColumn(
                name: "ISSUEDDATE",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES");

            migrationBuilder.DropColumn(
                name: "ISSUEDTIME",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES");

            migrationBuilder.DropColumn(
                name: "ISSUEDTO",
                schema: "ESL",
                table: "ESL_CLEARANCEISSUES");

            migrationBuilder.RenameTable(
                name: "ESL_FLOWCHANGES",
                newName: "ESL_FlowChanges");

            migrationBuilder.RenameTable(
                name: "ESL_EQUIPMENTINVOLVED",
                newName: "ESL_EquipmentInvolved");

            migrationBuilder.RenameTable(
                name: "ESL_DETAILS",
                newName: "ESL_Details");

            migrationBuilder.RenameTable(
                name: "ESL_WorkToBePerformed",
                schema: "ESL",
                newName: "ESL_WorkToBePerformed");

            migrationBuilder.RenameTable(
                name: "ESL_WorkOrders",
                schema: "ESL",
                newName: "ESL_WorkOrders");

            migrationBuilder.RenameTable(
                name: "ESL_SOC",
                schema: "ESL",
                newName: "ESL_SOC");

            migrationBuilder.RenameTable(
                name: "ESL_SCANDOCS",
                schema: "ESL",
                newName: "ESL_ScanDocs");

            migrationBuilder.RenameTable(
                name: "ESL_RelatedTo",
                schema: "ESL",
                newName: "ESL_RelatedTo");

            migrationBuilder.RenameTable(
                name: "ESL_LOGTYPES",
                schema: "ESL",
                newName: "ESL_LogTypes");

            migrationBuilder.RenameTable(
                name: "ESL_FACILITIES",
                schema: "ESL",
                newName: "ESL_Facilities");

            migrationBuilder.RenameTable(
                name: "ESL_EMPLOYEES",
                schema: "ESL",
                newName: "ESL_Employees");

            migrationBuilder.RenameTable(
                name: "ESL_CONSTANTS",
                schema: "ESL",
                newName: "ESL_Constants");

            migrationBuilder.RenameTable(
                name: "ESL_CLEARANCEZONES",
                schema: "ESL",
                newName: "ESL_ClearanceZones");

            migrationBuilder.RenameTable(
                name: "ESL_CLEARANCETYPES",
                schema: "ESL",
                newName: "ESL_ClearanceTypes");

            migrationBuilder.RenameTable(
                name: "ESL_CLEARANCEISSUES",
                schema: "ESL",
                newName: "ESL_ClearanceIssues");

            migrationBuilder.RenameTable(
                name: "ESL_ALLEVENTS",
                schema: "ESL",
                newName: "ESL_AllEvents");

            migrationBuilder.RenameTable(
                name: "ESL_PLANTSHITS",
                newName: "ESL_PlantShifts");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_Units",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_Subjects",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_Meters",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_General",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "YR",
                table: "ESL_FlowChanges",
                newName: "Yr");

            migrationBuilder.RenameColumn(
                name: "WORKORDERS",
                table: "ESL_FlowChanges",
                newName: "WorkOrders");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_FlowChanges",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_FlowChanges",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "SHIFTNO",
                table: "ESL_FlowChanges",
                newName: "ShiftNo");

            migrationBuilder.RenameColumn(
                name: "SEQNO",
                table: "ESL_FlowChanges",
                newName: "SeqNo");

            migrationBuilder.RenameColumn(
                name: "REQUESTEDTO",
                table: "ESL_FlowChanges",
                newName: "RequestedTo");

            migrationBuilder.RenameColumn(
                name: "REQUESTEDTIME",
                table: "ESL_FlowChanges",
                newName: "RequestedTime");

            migrationBuilder.RenameColumn(
                name: "REQUESTEDDATE",
                table: "ESL_FlowChanges",
                newName: "RequestedDate");

            migrationBuilder.RenameColumn(
                name: "REQUESTEDBY",
                table: "ESL_FlowChanges",
                newName: "RequestedBy");

            migrationBuilder.RenameColumn(
                name: "RELATEDTO",
                table: "ESL_FlowChanges",
                newName: "RelatedTo");

            migrationBuilder.RenameColumn(
                name: "OPERATORTYPE",
                table: "ESL_FlowChanges",
                newName: "OperatorType");

            migrationBuilder.RenameColumn(
                name: "OPERATORID",
                table: "ESL_FlowChanges",
                newName: "OperatorID");

            migrationBuilder.RenameColumn(
                name: "OLDVALUE",
                table: "ESL_FlowChanges",
                newName: "OldValue");

            migrationBuilder.RenameColumn(
                name: "OLDUNIT",
                table: "ESL_FlowChanges",
                newName: "OldUnit");

            migrationBuilder.RenameColumn(
                name: "OFFTIME",
                table: "ESL_FlowChanges",
                newName: "OffTime");

            migrationBuilder.RenameColumn(
                name: "NOTIFIEDPERSON",
                table: "ESL_FlowChanges",
                newName: "NotifiedPerson");

            migrationBuilder.RenameColumn(
                name: "NOTIFIEDFACIL",
                table: "ESL_FlowChanges",
                newName: "NotifiedFacil");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_FlowChanges",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "NEWVALUE",
                table: "ESL_FlowChanges",
                newName: "NewValue");

            migrationBuilder.RenameColumn(
                name: "MODIFYFLAG",
                table: "ESL_FlowChanges",
                newName: "ModifyFlag");

            migrationBuilder.RenameColumn(
                name: "MODIFIEDDATE",
                table: "ESL_FlowChanges",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "MODIFIEDBY",
                table: "ESL_FlowChanges",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "METERID",
                table: "ESL_FlowChanges",
                newName: "MeterID");

            migrationBuilder.RenameColumn(
                name: "EVENTTIME",
                table: "ESL_FlowChanges",
                newName: "EventTime");

            migrationBuilder.RenameColumn(
                name: "EVENTDATE",
                table: "ESL_FlowChanges",
                newName: "EventDate");

            migrationBuilder.RenameColumn(
                name: "CREATEDDATE",
                table: "ESL_FlowChanges",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CREATEDBY",
                table: "ESL_FlowChanges",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CHANGEBYUNIT",
                table: "ESL_FlowChanges",
                newName: "ChangeByUnit");

            migrationBuilder.RenameColumn(
                name: "CHANGEBY",
                table: "ESL_FlowChanges",
                newName: "ChangeBy");

            migrationBuilder.RenameColumn(
                name: "ACCEPTED",
                table: "ESL_FlowChanges",
                newName: "Accepted");

            migrationBuilder.RenameColumn(
                name: "EVENTID_REVNO",
                table: "ESL_FlowChanges",
                newName: "EventID_RevNo");

            migrationBuilder.RenameColumn(
                name: "EVENTID",
                table: "ESL_FlowChanges",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "LOGTYPENO",
                table: "ESL_FlowChanges",
                newName: "LogTypeNo");

            migrationBuilder.RenameColumn(
                name: "FACILNO",
                table: "ESL_FlowChanges",
                newName: "FacilNo");

            migrationBuilder.RenameColumn(
                name: "NEWUNIT",
                table: "ESL_FlowChanges",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_EquipmentInvolved",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_EquipmentInvolved",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_EquipmentInvolved",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "FACILTYPE",
                table: "ESL_EquipmentInvolved",
                newName: "FacilType");

            migrationBuilder.RenameColumn(
                name: "EQUIPNAME",
                table: "ESL_EquipmentInvolved",
                newName: "EquipName");

            migrationBuilder.RenameColumn(
                name: "DISABLE",
                table: "ESL_EquipmentInvolved",
                newName: "Disable");

            migrationBuilder.RenameColumn(
                name: "EQUIPNO",
                table: "ESL_EquipmentInvolved",
                newName: "EquipNo");

            migrationBuilder.RenameColumn(
                name: "FACILNO",
                table: "ESL_EquipmentInvolved",
                newName: "FacilNo");

            migrationBuilder.RenameColumn(
                name: "YR",
                table: "ESL_EOS",
                newName: "Yr");

            migrationBuilder.RenameColumn(
                name: "WORKORDERS",
                table: "ESL_EOS",
                newName: "WorkOrders");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_EOS",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_EOS",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "TAGSREMOVED",
                table: "ESL_EOS",
                newName: "TagsRemoved");

            migrationBuilder.RenameColumn(
                name: "TAGSINSTALLED",
                table: "ESL_EOS",
                newName: "TagsInstalled");

            migrationBuilder.RenameColumn(
                name: "SHIFTNO",
                table: "ESL_EOS",
                newName: "ShiftNo");

            migrationBuilder.RenameColumn(
                name: "SEQNO",
                table: "ESL_EOS",
                newName: "SeqNo");

            migrationBuilder.RenameColumn(
                name: "REPORTEDTO",
                table: "ESL_EOS",
                newName: "ReportedTo");

            migrationBuilder.RenameColumn(
                name: "REPORTEDTIME",
                table: "ESL_EOS",
                newName: "ReportedTime");

            migrationBuilder.RenameColumn(
                name: "REPORTEDDATE",
                table: "ESL_EOS",
                newName: "ReportedDate");

            migrationBuilder.RenameColumn(
                name: "REPORTEDBY",
                table: "ESL_EOS",
                newName: "ReportedBy");

            migrationBuilder.RenameColumn(
                name: "RELEASETYPE",
                table: "ESL_EOS",
                newName: "ReleaseType");

            migrationBuilder.RenameColumn(
                name: "RELEASEDTIME",
                table: "ESL_EOS",
                newName: "ReleasedTime");

            migrationBuilder.RenameColumn(
                name: "RELEASEDDATE",
                table: "ESL_EOS",
                newName: "ReleasedDate");

            migrationBuilder.RenameColumn(
                name: "RELEASEDBY",
                table: "ESL_EOS",
                newName: "ReleasedBy");

            migrationBuilder.RenameColumn(
                name: "RELATEDTO",
                table: "ESL_EOS",
                newName: "RelatedTo");

            migrationBuilder.RenameColumn(
                name: "OPERATORTYPE",
                table: "ESL_EOS",
                newName: "OperatorType");

            migrationBuilder.RenameColumn(
                name: "OPERATORID",
                table: "ESL_EOS",
                newName: "OperatorID");

            migrationBuilder.RenameColumn(
                name: "NOTIFIEDPERSON",
                table: "ESL_EOS",
                newName: "NotifiedPerson");

            migrationBuilder.RenameColumn(
                name: "NOTIFIEDFACIL",
                table: "ESL_EOS",
                newName: "NotifiedFacil");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_EOS",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "MODIFYFLAG",
                table: "ESL_EOS",
                newName: "ModifyFlag");

            migrationBuilder.RenameColumn(
                name: "MODIFIEDDATE",
                table: "ESL_EOS",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "MODIFIEDBY",
                table: "ESL_EOS",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "LOCATION",
                table: "ESL_EOS",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "EQUIPMENTINVOLVED",
                table: "ESL_EOS",
                newName: "EquipmentInvolved");

            migrationBuilder.RenameColumn(
                name: "CREATEDDATE",
                table: "ESL_EOS",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CREATEDBY",
                table: "ESL_EOS",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "EVENTID_REVNO",
                table: "ESL_EOS",
                newName: "EventID_RevNo");

            migrationBuilder.RenameColumn(
                name: "EVENTID",
                table: "ESL_EOS",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "LOGTYPENO",
                table: "ESL_EOS",
                newName: "LogTypeNo");

            migrationBuilder.RenameColumn(
                name: "FACILNO",
                table: "ESL_EOS",
                newName: "FacilNo");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_Details",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_Details",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "SORTNO",
                table: "ESL_Details",
                newName: "SortNo");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_Details",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "FACILTYPE",
                table: "ESL_Details",
                newName: "FacilType");

            migrationBuilder.RenameColumn(
                name: "DETAILSNAME",
                table: "ESL_Details",
                newName: "DetailsName");

            migrationBuilder.RenameColumn(
                name: "DETAILSNO",
                table: "ESL_Details",
                newName: "DetailsNo");

            migrationBuilder.RenameColumn(
                name: "FACILNO",
                table: "ESL_Details",
                newName: "FacilNo");

            migrationBuilder.RenameColumn(
                name: "DISABLE",
                table: "ESL_Details",
                newName: "Disabled?");

            migrationBuilder.RenameColumn(
                name: "WORKDESCRIPTION",
                table: "ESL_WorkToBePerformed",
                newName: "WorkDescription");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_WorkToBePerformed",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_WorkToBePerformed",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "SORTNO",
                table: "ESL_WorkToBePerformed",
                newName: "SortNo");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_WorkToBePerformed",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "DISABLE",
                table: "ESL_WorkToBePerformed",
                newName: "Disable");

            migrationBuilder.RenameColumn(
                name: "WORKNO",
                table: "ESL_WorkToBePerformed",
                newName: "WorkNo");

            migrationBuilder.RenameColumn(
                name: "FACILTYPE",
                table: "ESL_WorkToBePerformed",
                newName: "FacilType");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_WorkOrders",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_WorkOrders",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_WorkOrders",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "WO_NO",
                table: "ESL_WorkOrders",
                newName: "WO_No");

            migrationBuilder.RenameColumn(
                name: "EVENTID",
                table: "ESL_WorkOrders",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "LOGTYPENO",
                table: "ESL_WorkOrders",
                newName: "LogTypeNo");

            migrationBuilder.RenameColumn(
                name: "FACILNO",
                table: "ESL_WorkOrders",
                newName: "FacilNo");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_SOC",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "TagsRemoved",
                table: "ESL_SOC",
                newName: "TagsInstalled");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_ScanDocs",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_ScanDocs",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "SCANFILENAME",
                table: "ESL_ScanDocs",
                newName: "ScanFileName");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_ScanDocs",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "SCANNO",
                table: "ESL_ScanDocs",
                newName: "ScanNo");

            migrationBuilder.RenameColumn(
                name: "EVENTID",
                table: "ESL_ScanDocs",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "LOGTYPENO",
                table: "ESL_ScanDocs",
                newName: "LogTypeNo");

            migrationBuilder.RenameColumn(
                name: "FACILNO",
                table: "ESL_ScanDocs",
                newName: "FacilNo");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_RelatedTo",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_RelatedTo",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_RelatedTo",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "RelatedTo_SUBJECT",
                table: "ESL_RelatedTo",
                newName: "RelatedTo_Subject");

            migrationBuilder.RenameColumn(
                name: "EVENTID",
                table: "ESL_RelatedTo",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "LOGTYPENO",
                table: "ESL_RelatedTo",
                newName: "LogTypeNo");

            migrationBuilder.RenameColumn(
                name: "FACILNO",
                table: "ESL_RelatedTo",
                newName: "FacilNo");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_LogTypes",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_LogTypes",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_LogTypes",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "LOGTYPENO",
                table: "ESL_LogTypes",
                newName: "LogTypeNo");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_Facilities",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_Facilities",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "SORTNO",
                table: "ESL_Facilities",
                newName: "SortNo");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_Facilities",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "FACILTYPE",
                table: "ESL_Facilities",
                newName: "FacilType");

            migrationBuilder.RenameColumn(
                name: "FACILNAME",
                table: "ESL_Facilities",
                newName: "FacilName");

            migrationBuilder.RenameColumn(
                name: "FACILFULLNAME",
                table: "ESL_Facilities",
                newName: "FacilFullName");

            migrationBuilder.RenameColumn(
                name: "FACILABBR",
                table: "ESL_Facilities",
                newName: "FacilAbbr");

            migrationBuilder.RenameColumn(
                name: "DISABLE",
                table: "ESL_Facilities",
                newName: "Disable");

            migrationBuilder.RenameColumn(
                name: "FACILNO",
                table: "ESL_Facilities",
                newName: "FacilNo");

            migrationBuilder.RenameColumn(
                name: "VISABLETO",
                table: "ESL_Facilities",
                newName: "VisibleTo");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_Employees",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_Employees",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_Employees",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "LASTNAME",
                table: "ESL_Employees",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "JOBTITLE",
                table: "ESL_Employees",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "GROUPNAME",
                table: "ESL_Employees",
                newName: "GroupName");

            migrationBuilder.RenameColumn(
                name: "FIRSTNAME",
                table: "ESL_Employees",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "FACILNO",
                table: "ESL_Employees",
                newName: "FacilNo");

            migrationBuilder.RenameColumn(
                name: "DISABLE",
                table: "ESL_Employees",
                newName: "Disable");

            migrationBuilder.RenameColumn(
                name: "COMPANY",
                table: "ESL_Employees",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "EMPLOYEENO",
                table: "ESL_Employees",
                newName: "EmployeeNo");

            migrationBuilder.RenameColumn(
                name: "VALUE",
                table: "ESL_Constants",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_Constants",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_Constants",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_Constants",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "ENDDATE",
                table: "ESL_Constants",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "STARTDATE",
                table: "ESL_Constants",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "CONSTANTNAME",
                table: "ESL_Constants",
                newName: "ConstantName");

            migrationBuilder.RenameColumn(
                name: "FACILNO",
                table: "ESL_Constants",
                newName: "FacilNo");

            migrationBuilder.RenameColumn(
                name: "ZONEDESCRIPTION",
                table: "ESL_ClearanceZones",
                newName: "ZoneDescription");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_ClearanceZones",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_ClearanceZones",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "SORTNO",
                table: "ESL_ClearanceZones",
                newName: "SortNo");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_ClearanceZones",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "DISABLE",
                table: "ESL_ClearanceZones",
                newName: "Disable");

            migrationBuilder.RenameColumn(
                name: "ZONENO",
                table: "ESL_ClearanceZones",
                newName: "ZoneNo");

            migrationBuilder.RenameColumn(
                name: "FACILTYPE",
                table: "ESL_ClearanceZones",
                newName: "FacilType");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_ClearanceTypes",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_ClearanceTypes",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "SORTNO",
                table: "ESL_ClearanceTypes",
                newName: "SortNo");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_ClearanceTypes",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "CLEARANCETYPENAME",
                table: "ESL_ClearanceTypes",
                newName: "ClearanceTypeName");

            migrationBuilder.RenameColumn(
                name: "CLEARANCETYPEABBR",
                table: "ESL_ClearanceTypes",
                newName: "ClearanceTypeAbbr");

            migrationBuilder.RenameColumn(
                name: "CLEARANCETYPENO",
                table: "ESL_ClearanceTypes",
                newName: "ClearanceTypeNo");

            migrationBuilder.RenameColumn(
                name: "YR",
                table: "ESL_ClearanceIssues",
                newName: "Yr");

            migrationBuilder.RenameColumn(
                name: "WORKTOBEPERFORMED",
                table: "ESL_ClearanceIssues",
                newName: "WorkToBePerformed");

            migrationBuilder.RenameColumn(
                name: "WORKORDERS",
                table: "ESL_ClearanceIssues",
                newName: "WorkOrders");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_ClearanceIssues",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_ClearanceIssues",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "TAGSREMOVED",
                table: "ESL_ClearanceIssues",
                newName: "TagsRemoved");

            migrationBuilder.RenameColumn(
                name: "SHIFTNO",
                table: "ESL_ClearanceIssues",
                newName: "ShiftNo");

            migrationBuilder.RenameColumn(
                name: "SEQNO",
                table: "ESL_ClearanceIssues",
                newName: "SeqNo");

            migrationBuilder.RenameColumn(
                name: "RELEASETYPE",
                table: "ESL_ClearanceIssues",
                newName: "ReleaseType");

            migrationBuilder.RenameColumn(
                name: "RELEASEDTO",
                table: "ESL_ClearanceIssues",
                newName: "ReleasedTo");

            migrationBuilder.RenameColumn(
                name: "RELEASEDTIME",
                table: "ESL_ClearanceIssues",
                newName: "ReleasedTime");

            migrationBuilder.RenameColumn(
                name: "RELEASEDDATE",
                table: "ESL_ClearanceIssues",
                newName: "ReleasedDate");

            migrationBuilder.RenameColumn(
                name: "RELEASEDBY",
                table: "ESL_ClearanceIssues",
                newName: "ReleasedBy");

            migrationBuilder.RenameColumn(
                name: "RELATEDTO",
                table: "ESL_ClearanceIssues",
                newName: "RelatedTo");

            migrationBuilder.RenameColumn(
                name: "OPERATORTYPE",
                table: "ESL_ClearanceIssues",
                newName: "OperatorType");

            migrationBuilder.RenameColumn(
                name: "OPERATORID",
                table: "ESL_ClearanceIssues",
                newName: "OperatorID");

            migrationBuilder.RenameColumn(
                name: "NOTIFIEDPERSON",
                table: "ESL_ClearanceIssues",
                newName: "NotifiedPerson");

            migrationBuilder.RenameColumn(
                name: "NOTIFIEDFACIL",
                table: "ESL_ClearanceIssues",
                newName: "NotifiedFacil");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_ClearanceIssues",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "MODIFYFLAG",
                table: "ESL_ClearanceIssues",
                newName: "ModifyFlag");

            migrationBuilder.RenameColumn(
                name: "MODIFIEDDATE",
                table: "ESL_ClearanceIssues",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "MODIFIEDBY",
                table: "ESL_ClearanceIssues",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "LOCATION",
                table: "ESL_ClearanceIssues",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "FACILABBR",
                table: "ESL_ClearanceIssues",
                newName: "FacilAbbr");

            migrationBuilder.RenameColumn(
                name: "EQUIPMENTINVOLVED",
                table: "ESL_ClearanceIssues",
                newName: "EquipmentInvolved");

            migrationBuilder.RenameColumn(
                name: "CREATEDDATE",
                table: "ESL_ClearanceIssues",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CREATEDBY",
                table: "ESL_ClearanceIssues",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CLEARANCEZONE",
                table: "ESL_ClearanceIssues",
                newName: "ClearanceZone");

            migrationBuilder.RenameColumn(
                name: "CLEARANCETYPE",
                table: "ESL_ClearanceIssues",
                newName: "ClearanceType");

            migrationBuilder.RenameColumn(
                name: "CLEARANCEID",
                table: "ESL_ClearanceIssues",
                newName: "ClearanceID");

            migrationBuilder.RenameColumn(
                name: "EVENTID_REVNO",
                table: "ESL_ClearanceIssues",
                newName: "EventID_RevNo");

            migrationBuilder.RenameColumn(
                name: "EVENTID",
                table: "ESL_ClearanceIssues",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "LOGTYPENO",
                table: "ESL_ClearanceIssues",
                newName: "LogTypeNo");

            migrationBuilder.RenameColumn(
                name: "FACILNO",
                table: "ESL_ClearanceIssues",
                newName: "FacilNo");

            migrationBuilder.RenameColumn(
                name: "UPDATEDBY",
                table: "ESL_AllEvents",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UPDATEDATE",
                table: "ESL_AllEvents",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "SUBJECT",
                table: "ESL_AllEvents",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "NOTES",
                table: "ESL_AllEvents",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "MODIFYFLAG",
                table: "ESL_AllEvents",
                newName: "ModifyFlag");

            migrationBuilder.RenameColumn(
                name: "EVENTTIME",
                table: "ESL_AllEvents",
                newName: "EventTime");

            migrationBuilder.RenameColumn(
                name: "EVENTDATE",
                table: "ESL_AllEvents",
                newName: "EventDate");

            migrationBuilder.RenameColumn(
                name: "DETAILS",
                table: "ESL_AllEvents",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "CLEARANCEID",
                table: "ESL_AllEvents",
                newName: "ClearanceID");

            migrationBuilder.RenameColumn(
                name: "EVENTID_REVNO",
                table: "ESL_AllEvents",
                newName: "EventID_RevNo");

            migrationBuilder.RenameColumn(
                name: "EVENTID",
                table: "ESL_AllEvents",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "LOGTYPENO",
                table: "ESL_AllEvents",
                newName: "LogTypeNo");

            migrationBuilder.RenameColumn(
                name: "FACILNO",
                table: "ESL_AllEvents",
                newName: "FacilNo");

            migrationBuilder.RenameColumn(
                name: "OPERATORYTYPE",
                table: "ESL_AllEvents",
                newName: "OperatorType");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_Units",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_Subjects",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_Subjects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_Subjects",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_ScanLobs",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_ScanLobs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ScanLobType",
                table: "ESL_ScanLobs",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "ScanLob",
                table: "ESL_ScanLobs",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_Meters",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_Meters",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_Meters",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeterType",
                table: "ESL_Meters",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_General",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Yr",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "WorkOrders",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftNo",
                table: "ESL_FlowChanges",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SeqNo",
                table: "ESL_FlowChanges",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "RequestedTo",
                table: "ESL_FlowChanges",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "RequestedTime",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedDate",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<int>(
                name: "RequestedBy",
                table: "ESL_FlowChanges",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RelatedTo",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OperatorType",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OperatorID",
                table: "ESL_FlowChanges",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "OldValue",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OldUnit",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "OffTime",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NotifiedPerson",
                table: "ESL_FlowChanges",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NotifiedFacil",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewValue",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifyFlag",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "ESL_FlowChanges",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeterID",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "EventTime",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EventDate",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "ESL_FlowChanges",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChangeByUnit",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "ChangeBy",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "Accepted",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventID_RevNo",
                table: "ESL_FlowChanges",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "EventID",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<int>(
                name: "LogTypeNo",
                table: "ESL_FlowChanges",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_FlowChanges",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "ESL_FlowChanges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_EquipmentInvolved",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_EquipmentInvolved",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_EquipmentInvolved",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacilType",
                table: "ESL_EquipmentInvolved",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "EquipName",
                table: "ESL_EquipmentInvolved",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "Disable",
                table: "ESL_EquipmentInvolved",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipNo",
                table: "ESL_EquipmentInvolved",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_EquipmentInvolved",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "Yr",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "WorkOrders",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TagsRemoved",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TagsInstalled",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftNo",
                table: "ESL_EOS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SeqNo",
                table: "ESL_EOS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "ReportedTo",
                table: "ESL_EOS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReportedTime",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportedDate",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReportedBy",
                table: "ESL_EOS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReleaseType",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReleasedTime",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleasedDate",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReleasedBy",
                table: "ESL_EOS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RelatedTo",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OperatorType",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OperatorID",
                table: "ESL_EOS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "NotifiedPerson",
                table: "ESL_EOS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NotifiedFacil",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifyFlag",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "ESL_EOS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "EquipmentInvolved",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "ESL_EOS",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventID_RevNo",
                table: "ESL_EOS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "EventID",
                table: "ESL_EOS",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<int>(
                name: "LogTypeNo",
                table: "ESL_EOS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_EOS",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_Details",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_Details",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortNo",
                table: "ESL_Details",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_Details",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacilType",
                table: "ESL_Details",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "DetailsName",
                table: "ESL_Details",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<int>(
                name: "DetailsNo",
                table: "ESL_Details",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_Details",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "Disabled?",
                table: "ESL_Details",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WorkDescription",
                table: "ESL_WorkToBePerformed",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_WorkToBePerformed",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_WorkToBePerformed",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortNo",
                table: "ESL_WorkToBePerformed",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_WorkToBePerformed",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Disable",
                table: "ESL_WorkToBePerformed",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkNo",
                table: "ESL_WorkToBePerformed",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "FacilType",
                table: "ESL_WorkToBePerformed",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_WorkOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_WorkOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_WorkOrders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WO_No",
                table: "ESL_WorkOrders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "EventID",
                table: "ESL_WorkOrders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<int>(
                name: "LogTypeNo",
                table: "ESL_WorkOrders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_WorkOrders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy_EmployeeEmployeeNo",
                table: "ESL_SOC",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "ReportedTo_EmployeeEmployeeNo",
                table: "ESL_SOC",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "ReportedTime",
                table: "ESL_SOC",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReportedBy_EmployeeEmployeeNo",
                table: "ESL_SOC",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "ReleasedTo_EmployeeEmployeeNo",
                table: "ESL_SOC",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "ReleasedBy_EmployeeEmployeeNo",
                table: "ESL_SOC",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "OperatorID",
                table: "ESL_SOC",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "NotifiedPerson",
                table: "ESL_SOC",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NotifiedFacilityFacilNo",
                table: "ESL_SOC",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_SOC",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "ESL_SOC",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "ESL_SOC",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LogTypeNo",
                table: "ESL_SOC",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_SOC",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_ScanDocs",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_ScanDocs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ScanFileName",
                table: "ESL_ScanDocs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_ScanDocs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ScanNo",
                table: "ESL_ScanDocs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "EventID",
                table: "ESL_ScanDocs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<int>(
                name: "LogTypeNo",
                table: "ESL_ScanDocs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_ScanDocs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_RelatedTo",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_RelatedTo",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_RelatedTo",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RelatedTo_Subject",
                table: "ESL_RelatedTo",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "EventID",
                table: "ESL_RelatedTo",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<int>(
                name: "LogTypeNo",
                table: "ESL_RelatedTo",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_RelatedTo",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_LogTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_LogTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_LogTypes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogTypeName",
                table: "ESL_LogTypes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<int>(
                name: "LogTypeNo",
                table: "ESL_LogTypes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_Facilities",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_Facilities",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortNo",
                table: "ESL_Facilities",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_Facilities",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacilType",
                table: "ESL_Facilities",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "FacilName",
                table: "ESL_Facilities",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "FacilFullName",
                table: "ESL_Facilities",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacilAbbr",
                table: "ESL_Facilities",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "Disable",
                table: "ESL_Facilities",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_Facilities",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "VisibleTo",
                table: "ESL_Facilities",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ESL_Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "ESL_Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "ESL_Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ESL_Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_Employees",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Disable",
                table: "ESL_Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "ESL_Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeNo",
                table: "ESL_Employees",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "ESL_Constants",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_Constants",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_Constants",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_Constants",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ESL_Constants",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ESL_Constants",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<string>(
                name: "ConstantName",
                table: "ESL_Constants",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_Constants",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "ZoneDescription",
                table: "ESL_ClearanceZones",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_ClearanceZones",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_ClearanceZones",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortNo",
                table: "ESL_ClearanceZones",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_ClearanceZones",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Disable",
                table: "ESL_ClearanceZones",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ZoneNo",
                table: "ESL_ClearanceZones",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "FacilType",
                table: "ESL_ClearanceZones",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_ClearanceTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_ClearanceTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SortNo",
                table: "ESL_ClearanceTypes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_ClearanceTypes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClearanceTypeName",
                table: "ESL_ClearanceTypes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "ClearanceTypeAbbr",
                table: "ESL_ClearanceTypes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<int>(
                name: "ClearanceTypeNo",
                table: "ESL_ClearanceTypes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "Yr",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "WorkToBePerformed",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WorkOrders",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TagsRemoved",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftNo",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SeqNo",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "ReleaseType",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReleasedTo",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReleasedTime",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleasedDate",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReleasedBy",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RelatedTo",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OperatorType",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OperatorID",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "NotifiedPerson",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NotifiedFacil",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifyFlag",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FacilAbbr",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "EquipmentInvolved",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "ClearanceZone",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "ClearanceType",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<string>(
                name: "ClearanceID",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventID_RevNo",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "EventID",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<int>(
                name: "LogTypeNo",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AddColumn<int>(
                name: "IssedBy",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssedDate",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IssedTime",
                table: "ESL_ClearanceIssues",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IssedTo",
                table: "ESL_ClearanceIssues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_AllEvents",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_AllEvents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "ESL_AllEvents",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ESL_AllEvents",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifyFlag",
                table: "ESL_AllEvents",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventTime",
                table: "ESL_AllEvents",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EventDate",
                table: "ESL_AllEvents",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "ESL_AllEvents",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClearanceID",
                table: "ESL_AllEvents",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventID_RevNo",
                table: "ESL_AllEvents",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "EventID",
                table: "ESL_AllEvents",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR2");

            migrationBuilder.AlterColumn<int>(
                name: "LogTypeNo",
                table: "ESL_AllEvents",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<int>(
                name: "FacilNo",
                table: "ESL_AllEvents",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER");

            migrationBuilder.AlterColumn<string>(
                name: "OperatorType",
                table: "ESL_AllEvents",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_PlantShifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "ESL_PlantShifts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_FlowChanges",
                table: "ESL_FlowChanges",
                columns: new[] { "FacilNo", "LogTypeNo", "EventID", "EventID_RevNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_EquipmentInvolved",
                table: "ESL_EquipmentInvolved",
                columns: new[] { "FacilNo", "EquipNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_Details",
                table: "ESL_Details",
                columns: new[] { "FacilNo", "DetailsNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_ScanDocs",
                table: "ESL_ScanDocs",
                columns: new[] { "FacilNo", "LogTypeNo", "EventID", "ScanNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_LogTypes",
                table: "ESL_LogTypes",
                column: "LogTypeNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_Facilities",
                table: "ESL_Facilities",
                column: "FacilNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_Employees",
                table: "ESL_Employees",
                column: "EmployeeNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_Constants",
                table: "ESL_Constants",
                columns: new[] { "FacilNo", "ConstantName", "StartDate" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_ClearanceZones",
                table: "ESL_ClearanceZones",
                columns: new[] { "FacilType", "ZoneNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_ClearanceTypes",
                table: "ESL_ClearanceTypes",
                column: "ClearanceTypeNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_ClearanceIssues",
                table: "ESL_ClearanceIssues",
                columns: new[] { "FacilNo", "LogTypeNo", "EventID", "EventID_RevNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_AllEvents",
                table: "ESL_AllEvents",
                columns: new[] { "FacilNo", "LogTypeNo", "EventID", "EventID_RevNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_PlantShifts",
                table: "ESL_PlantShifts",
                columns: new[] { "FacilNo", "ShiftNo" });

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_CreatedBy",
                table: "ESL_SOC",
                column: "CreatedBy",
                principalTable: "ESL_Employees",
                principalColumn: "EmployeeNo");

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_ModifiedBy",
                table: "ESL_SOC",
                column: "ModifiedBy",
                principalTable: "ESL_Employees",
                principalColumn: "EmployeeNo");

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_NotifiedPerson",
                table: "ESL_SOC",
                column: "NotifiedPerson",
                principalTable: "ESL_Employees",
                principalColumn: "EmployeeNo");

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_OperatorID",
                table: "ESL_SOC",
                column: "OperatorID",
                principalTable: "ESL_Employees",
                principalColumn: "EmployeeNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_ReleasedBy_EmployeeEmployeeNo",
                table: "ESL_SOC",
                column: "ReleasedBy_EmployeeEmployeeNo",
                principalTable: "ESL_Employees",
                principalColumn: "EmployeeNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_ReleasedTo_EmployeeEmployeeNo",
                table: "ESL_SOC",
                column: "ReleasedTo_EmployeeEmployeeNo",
                principalTable: "ESL_Employees",
                principalColumn: "EmployeeNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_ReportedBy_EmployeeEmployeeNo",
                table: "ESL_SOC",
                column: "ReportedBy_EmployeeEmployeeNo",
                principalTable: "ESL_Employees",
                principalColumn: "EmployeeNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_ReportedTo_EmployeeEmployeeNo",
                table: "ESL_SOC",
                column: "ReportedTo_EmployeeEmployeeNo",
                principalTable: "ESL_Employees",
                principalColumn: "EmployeeNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_Employees_UpdatedBy_EmployeeEmployeeNo",
                table: "ESL_SOC",
                column: "UpdatedBy_EmployeeEmployeeNo",
                principalTable: "ESL_Employees",
                principalColumn: "EmployeeNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_Facilities_FacilNo",
                table: "ESL_SOC",
                column: "FacilNo",
                principalTable: "ESL_Facilities",
                principalColumn: "FacilNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_Facilities_NotifiedFacilityFacilNo",
                table: "ESL_SOC",
                column: "NotifiedFacilityFacilNo",
                principalTable: "ESL_Facilities",
                principalColumn: "FacilNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_LogTypes_LogTypeNo",
                table: "ESL_SOC",
                column: "LogTypeNo",
                principalTable: "ESL_LogTypes",
                principalColumn: "LogTypeNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
