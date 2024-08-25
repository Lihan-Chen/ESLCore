using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESL.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESL_AllEvents",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EventTime = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false),
                    ModifyFlag = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    ClearanceID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_AllEvents", x => new { x.FacilNo, x.LogTypeNo, x.EventID, x.EventID_RevNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_ClearanceIssues",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
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
                    ClearanceID = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_ClearanceIssues", x => new { x.FacilNo, x.LogTypeNo, x.EventID, x.EventID_RevNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_ClearanceTypes",
                columns: table => new
                {
                    ClearanceTypeNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClearanceTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    ClearanceTypeAbbr = table.Column<string>(type: "TEXT", nullable: false),
                    SortNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_ClearanceTypes", x => x.ClearanceTypeNo);
                });

            migrationBuilder.CreateTable(
                name: "ESL_ClearanceZones",
                columns: table => new
                {
                    FacilType = table.Column<string>(type: "TEXT", nullable: false),
                    ZoneNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ZoneDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Disable = table.Column<string>(type: "TEXT", nullable: true),
                    SortNo = table.Column<int>(type: "INTEGER", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_ClearanceZones", x => new { x.FacilType, x.ZoneNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_Constants",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ConstantName = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Constants", x => new { x.FacilNo, x.ConstantName, x.StartDate });
                });

            migrationBuilder.CreateTable(
                name: "ESL_Details",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    DetailsNo = table.Column<int>(type: "INTEGER", nullable: false),
                    DetailsName = table.Column<string>(type: "TEXT", nullable: false),
                    FacilType = table.Column<string>(type: "TEXT", nullable: false),
                    SortNo = table.Column<int>(type: "INTEGER", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Disabled = table.Column<string>(name: "Disabled?", type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Details", x => new { x.FacilNo, x.DetailsNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_Employees",
                columns: table => new
                {
                    EmployeeNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    Company = table.Column<string>(type: "TEXT", nullable: false),
                    GroupName = table.Column<string>(type: "TEXT", nullable: false),
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: true),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    Disable = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Employees", x => x.EmployeeNo);
                });

            migrationBuilder.CreateTable(
                name: "ESL_EOS",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReportedBy = table.Column<int>(type: "INTEGER", nullable: true),
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
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    WorkOrders = table.Column<string>(type: "TEXT", nullable: true),
                    RelatedTo = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_EOS", x => new { x.FacilNo, x.LogTypeNo, x.EventID, x.EventID_RevNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_EquipmentInvolved",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipNo = table.Column<int>(type: "INTEGER", nullable: false),
                    FacilType = table.Column<string>(type: "TEXT", nullable: false),
                    EquipName = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Disable = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_EquipmentInvolved", x => new { x.FacilNo, x.EquipNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_Facilities",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FacilName = table.Column<string>(type: "TEXT", nullable: false),
                    FacilAbbr = table.Column<string>(type: "TEXT", nullable: false),
                    FacilType = table.Column<string>(type: "TEXT", nullable: false),
                    SortNo = table.Column<int>(type: "INTEGER", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Disable = table.Column<string>(type: "TEXT", nullable: true),
                    VisibleTo = table.Column<string>(type: "TEXT", nullable: true),
                    FacilFullName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Facilities", x => x.FacilNo);
                });

            migrationBuilder.CreateTable(
                name: "ESL_FlowChanges",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RequestedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    RequestedTo = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RequestedTime = table.Column<string>(type: "TEXT", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EventTime = table.Column<string>(type: "TEXT", nullable: false),
                    OffTime = table.Column<string>(type: "TEXT", nullable: true),
                    MeterID = table.Column<string>(type: "TEXT", nullable: false),
                    ChangeBy = table.Column<string>(type: "TEXT", nullable: false),
                    NewValue = table.Column<decimal>(type: "TEXT", nullable: true),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    OldValue = table.Column<decimal>(type: "TEXT", nullable: true),
                    OldUnit = table.Column<string>(type: "TEXT", nullable: false),
                    ChangeByUnit = table.Column<string>(type: "TEXT", nullable: false),
                    Accepted = table.Column<string>(type: "TEXT", nullable: true),
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
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    WorkOrders = table.Column<string>(type: "TEXT", nullable: true),
                    RelatedTo = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_FlowChanges", x => new { x.FacilNo, x.LogTypeNo, x.EventID, x.EventID_RevNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_General",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReportedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EventTime = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    ModifyFlag = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Yr = table.Column<string>(type: "TEXT", nullable: false),
                    SeqNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    NotifiedFacil = table.Column<string>(type: "TEXT", nullable: true),
                    NotifiedPerson = table.Column<int>(type: "INTEGER", nullable: true),
                    ShiftNo = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    WorkOrders = table.Column<string>(type: "TEXT", nullable: true),
                    RelatedTo = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_General", x => new { x.FacilNo, x.LogTypeNo, x.EventID, x.EventID_RevNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_LogTypes",
                columns: table => new
                {
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_LogTypes", x => x.LogTypeNo);
                });

            migrationBuilder.CreateTable(
                name: "ESL_Meters",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    MeterID = table.Column<string>(type: "TEXT", nullable: false),
                    MeterType = table.Column<string>(type: "TEXT", nullable: false),
                    SortNo = table.Column<int>(type: "INTEGER", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Disabled = table.Column<string>(name: "Disabled?", type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Meters", x => new { x.FacilNo, x.MeterID });
                });

            migrationBuilder.CreateTable(
                name: "ESL_PlantShifts",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ShiftNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ShiftName = table.Column<string>(type: "TEXT", nullable: true),
                    ShiftStart = table.Column<string>(type: "TEXT", nullable: false),
                    ShiftEnd = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_PlantShifts", x => new { x.FacilNo, x.ShiftNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_RelatedTo",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    RelatedTo_Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_RelatedTo", x => new { x.FacilNo, x.LogTypeNo, x.EventID, x.RelatedTo_Subject });
                });

            migrationBuilder.CreateTable(
                name: "ESL_ScanDocs",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    ScanNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ScanFileName = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_ScanDocs", x => new { x.FacilNo, x.LogTypeNo, x.EventID, x.ScanNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_ScanLobs",
                columns: table => new
                {
                    ScanSeqNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    ScanNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ScanLob = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ScanLobType = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_ScanLobs", x => x.ScanSeqNo);
                });

            migrationBuilder.CreateTable(
                name: "ESL_Subjects",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjNo = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjName = table.Column<string>(type: "TEXT", nullable: false),
                    FacilType = table.Column<string>(type: "TEXT", nullable: false),
                    SortNo = table.Column<int>(type: "INTEGER", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Disable = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Subjects", x => new { x.FacilNo, x.SubjNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_Units",
                columns: table => new
                {
                    UnitNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UnitName = table.Column<string>(type: "TEXT", nullable: true),
                    UnitDesc = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Units", x => x.UnitNo);
                });

            migrationBuilder.CreateTable(
                name: "ESL_Users",
                columns: table => new
                {
                    EmployeeNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: true),
                    UserGuid = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PrincipalName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Users", x => x.EmployeeNo);
                });

            migrationBuilder.CreateTable(
                name: "ESL_WorkOrders",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    WO_No = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_WorkOrders", x => new { x.FacilNo, x.LogTypeNo, x.EventID, x.WO_No });
                });

            migrationBuilder.CreateTable(
                name: "ESL_WorkToBePerformed",
                columns: table => new
                {
                    FacilType = table.Column<string>(type: "TEXT", nullable: false),
                    WorkNo = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkDescription = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    SortNo = table.Column<int>(type: "INTEGER", nullable: true),
                    Disable = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_WorkToBePerformed", x => new { x.FacilType, x.WorkNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_SOC",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifyFlag = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    NotifiedFacil = table.Column<string>(type: "TEXT", nullable: true),
                    NotifiedPerson = table.Column<int>(type: "INTEGER", nullable: true),
                    ShiftNo = table.Column<int>(type: "INTEGER", nullable: true),
                    Yr = table.Column<string>(type: "TEXT", nullable: false),
                    SeqNo = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkOrders = table.Column<string>(type: "TEXT", nullable: true),
                    RelatedTo = table.Column<string>(type: "TEXT", nullable: true),
                    OperatorType = table.Column<string>(type: "TEXT", nullable: true),
                    ReportedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    ReportedTo = table.Column<int>(type: "INTEGER", nullable: true),
                    ReportedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReportedTime = table.Column<string>(type: "TEXT", nullable: false),
                    ReleasedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    ReleasedTo = table.Column<int>(type: "INTEGER", nullable: true),
                    ReleasedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReleasedTime = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseType = table.Column<string>(type: "TEXT", nullable: true),
                    FacilAbbr = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Limitations = table.Column<string>(type: "TEXT", nullable: false),
                    EquipmentInvolved = table.Column<string>(type: "TEXT", nullable: true),
                    TagsInstalled = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedBy_EmployeeEmployeeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    NotifiedFacilityFacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ReportedBy_EmployeeEmployeeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ReportedTo_EmployeeEmployeeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ReleasedBy_EmployeeEmployeeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ReleasedTo_EmployeeEmployeeNo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_SOC", x => new { x.FacilNo, x.LogTypeNo, x.EventID, x.EventID_RevNo });
                    table.ForeignKey(
                        name: "FK_ESL_SOC_ESL_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "ESL_Employees",
                        principalColumn: "EmployeeNo");
                    table.ForeignKey(
                        name: "FK_ESL_SOC_ESL_Employees_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "ESL_Employees",
                        principalColumn: "EmployeeNo");
                    table.ForeignKey(
                        name: "FK_ESL_SOC_ESL_Employees_NotifiedPerson",
                        column: x => x.NotifiedPerson,
                        principalTable: "ESL_Employees",
                        principalColumn: "EmployeeNo");
                    table.ForeignKey(
                        name: "FK_ESL_SOC_ESL_Employees_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "ESL_Employees",
                        principalColumn: "EmployeeNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESL_SOC_ESL_Employees_ReleasedBy_EmployeeEmployeeNo",
                        column: x => x.ReleasedBy_EmployeeEmployeeNo,
                        principalTable: "ESL_Employees",
                        principalColumn: "EmployeeNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESL_SOC_ESL_Employees_ReleasedTo_EmployeeEmployeeNo",
                        column: x => x.ReleasedTo_EmployeeEmployeeNo,
                        principalTable: "ESL_Employees",
                        principalColumn: "EmployeeNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESL_SOC_ESL_Employees_ReportedBy_EmployeeEmployeeNo",
                        column: x => x.ReportedBy_EmployeeEmployeeNo,
                        principalTable: "ESL_Employees",
                        principalColumn: "EmployeeNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESL_SOC_ESL_Employees_ReportedTo_EmployeeEmployeeNo",
                        column: x => x.ReportedTo_EmployeeEmployeeNo,
                        principalTable: "ESL_Employees",
                        principalColumn: "EmployeeNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESL_SOC_ESL_Employees_UpdatedBy_EmployeeEmployeeNo",
                        column: x => x.UpdatedBy_EmployeeEmployeeNo,
                        principalTable: "ESL_Employees",
                        principalColumn: "EmployeeNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESL_SOC_ESL_Facilities_FacilNo",
                        column: x => x.FacilNo,
                        principalTable: "ESL_Facilities",
                        principalColumn: "FacilNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESL_SOC_ESL_Facilities_NotifiedFacilityFacilNo",
                        column: x => x.NotifiedFacilityFacilNo,
                        principalTable: "ESL_Facilities",
                        principalColumn: "FacilNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESL_SOC_ESL_LogTypes_LogTypeNo",
                        column: x => x.LogTypeNo,
                        principalTable: "ESL_LogTypes",
                        principalColumn: "LogTypeNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "SCANLOB_DOC_IDX",
                table: "ESL_ScanLobs",
                columns: new[] { "FacilNo", "LogTypeNo", "EventID", "ScanNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ESL_SOC_CreatedBy",
                table: "ESL_SOC",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ESL_SOC_LogTypeNo",
                table: "ESL_SOC",
                column: "LogTypeNo");

            migrationBuilder.CreateIndex(
                name: "IX_ESL_SOC_ModifiedBy",
                table: "ESL_SOC",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ESL_SOC_NotifiedFacilityFacilNo",
                table: "ESL_SOC",
                column: "NotifiedFacilityFacilNo");

            migrationBuilder.CreateIndex(
                name: "IX_ESL_SOC_NotifiedPerson",
                table: "ESL_SOC",
                column: "NotifiedPerson");

            migrationBuilder.CreateIndex(
                name: "IX_ESL_SOC_OperatorID",
                table: "ESL_SOC",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_ESL_SOC_ReleasedBy_EmployeeEmployeeNo",
                table: "ESL_SOC",
                column: "ReleasedBy_EmployeeEmployeeNo");

            migrationBuilder.CreateIndex(
                name: "IX_ESL_SOC_ReleasedTo_EmployeeEmployeeNo",
                table: "ESL_SOC",
                column: "ReleasedTo_EmployeeEmployeeNo");

            migrationBuilder.CreateIndex(
                name: "IX_ESL_SOC_ReportedBy_EmployeeEmployeeNo",
                table: "ESL_SOC",
                column: "ReportedBy_EmployeeEmployeeNo");

            migrationBuilder.CreateIndex(
                name: "IX_ESL_SOC_ReportedTo_EmployeeEmployeeNo",
                table: "ESL_SOC",
                column: "ReportedTo_EmployeeEmployeeNo");

            migrationBuilder.CreateIndex(
                name: "IX_ESL_SOC_UpdatedBy_EmployeeEmployeeNo",
                table: "ESL_SOC",
                column: "UpdatedBy_EmployeeEmployeeNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESL_AllEvents");

            migrationBuilder.DropTable(
                name: "ESL_ClearanceIssues");

            migrationBuilder.DropTable(
                name: "ESL_ClearanceTypes");

            migrationBuilder.DropTable(
                name: "ESL_ClearanceZones");

            migrationBuilder.DropTable(
                name: "ESL_Constants");

            migrationBuilder.DropTable(
                name: "ESL_Details");

            migrationBuilder.DropTable(
                name: "ESL_EOS");

            migrationBuilder.DropTable(
                name: "ESL_EquipmentInvolved");

            migrationBuilder.DropTable(
                name: "ESL_FlowChanges");

            migrationBuilder.DropTable(
                name: "ESL_General");

            migrationBuilder.DropTable(
                name: "ESL_Meters");

            migrationBuilder.DropTable(
                name: "ESL_PlantShifts");

            migrationBuilder.DropTable(
                name: "ESL_RelatedTo");

            migrationBuilder.DropTable(
                name: "ESL_ScanDocs");

            migrationBuilder.DropTable(
                name: "ESL_ScanLobs");

            migrationBuilder.DropTable(
                name: "ESL_SOC");

            migrationBuilder.DropTable(
                name: "ESL_Subjects");

            migrationBuilder.DropTable(
                name: "ESL_Units");

            migrationBuilder.DropTable(
                name: "ESL_Users");

            migrationBuilder.DropTable(
                name: "ESL_WorkOrders");

            migrationBuilder.DropTable(
                name: "ESL_WorkToBePerformed");

            migrationBuilder.DropTable(
                name: "ESL_Employees");

            migrationBuilder.DropTable(
                name: "ESL_Facilities");

            migrationBuilder.DropTable(
                name: "ESL_LogTypes");
        }
    }
}
