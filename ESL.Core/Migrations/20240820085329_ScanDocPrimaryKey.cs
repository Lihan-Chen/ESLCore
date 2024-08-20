using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESL.Core.Migrations
{
    /// <inheritdoc />
    public partial class ScanDocPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
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
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
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
                    ConstantName = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<string>(type: "TEXT", nullable: false),
                    EndDate = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Constants", x => new { x.FacilNo, x.ConstantName, x.StartDate });
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
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
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
                    Disable = table.Column<string>(type: "TEXT", nullable: true),
                    VisibleTo = table.Column<string>(type: "TEXT", nullable: true),
                    FacilFullName = table.Column<string>(type: "TEXT", nullable: true),
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Facilities", x => x.FacilNo);
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
                    Disable = table.Column<string>(type: "TEXT", nullable: true),
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Meters", x => new { x.FacilNo, x.MeterID });
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
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
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
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_ScanDocs", x => new { x.FacilNo, x.LogTypeNo, x.EventID, x.ScanNo });
                });

            migrationBuilder.CreateTable(
                name: "ESL_ScanLobs",
                columns: table => new
                {
                    ScanLobNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventID = table.Column<string>(type: "TEXT", nullable: false),
                    ScanNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ScanFileName = table.Column<string>(type: "TEXT", nullable: false),
                    ScanLobType = table.Column<string>(type: "TEXT", nullable: false),
                    Blob = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_ScanLobs", x => x.ScanLobNo);
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
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
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
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
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
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
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
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_WorkToBePerformed", x => new { x.FacilType, x.WorkNo });
                });

            migrationBuilder.CreateTable(
                name: "LogTypes",
                columns: table => new
                {
                    LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LogTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTypes", x => x.LogTypeNo);
                });

            migrationBuilder.CreateTable(
                name: "PlantShift",
                columns: table => new
                {
                    FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ShiftNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ShiftName = table.Column<string>(type: "TEXT", nullable: true),
                    ShiftStart = table.Column<string>(type: "TEXT", nullable: false),
                    ShiftEnd = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantShift", x => new { x.FacilNo, x.ShiftNo });
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
                    SubjNo = table.Column<int>(type: "INTEGER", nullable: true),
                    Disable = table.Column<string>(type: "TEXT", nullable: true),
                    SubjectFacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    SubjectNo1 = table.Column<int>(type: "INTEGER", nullable: false),
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Details", x => new { x.FacilNo, x.DetailsNo });
                    table.ForeignKey(
                        name: "FK_ESL_Details_ESL_Subjects_SubjectFacilNo_SubjectNo1",
                        columns: x => new { x.SubjectFacilNo, x.SubjectNo1 },
                        principalTable: "ESL_Subjects",
                        principalColumns: new[] { "FacilNo", "SubjNo" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ESL_Employees",
                columns: table => new
                {
                    EmployeeNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserEmployeeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Company = table.Column<string>(type: "TEXT", nullable: false),
                    GroupName = table.Column<string>(type: "TEXT", nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Disable = table.Column<string>(type: "TEXT", nullable: true),
                    FacilityFacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_Employees", x => x.EmployeeNo);
                    table.ForeignKey(
                        name: "FK_ESL_Employees_ESL_Facilities_FacilityFacilNo",
                        column: x => x.FacilityFacilNo,
                        principalTable: "ESL_Facilities",
                        principalColumn: "FacilNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESL_Employees_ESL_Users_EmployeeNo",
                        column: x => x.EmployeeNo,
                        principalTable: "ESL_Users",
                        principalColumn: "EmployeeNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESL_Employees_ESL_Users_UserEmployeeNo",
                        column: x => x.UserEmployeeNo,
                        principalTable: "ESL_Users",
                        principalColumn: "EmployeeNo",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    ClearanceID = table.Column<string>(type: "TEXT", nullable: true),
                    EventIdentity_EventID = table.Column<string>(type: "TEXT", nullable: false),
                    EventIdentity_EventID_RevNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventIdentity_FacilNo = table.Column<int>(type: "INTEGER", nullable: false),
                    EventIdentity_LogTypeNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Update_UpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Update_UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESL_AllEvents", x => new { x.FacilNo, x.LogTypeNo, x.EventID, x.EventID_RevNo });
                    table.ForeignKey(
                        name: "FK_ESL_AllEvents_ESL_Facilities_FacilNo",
                        column: x => x.FacilNo,
                        principalTable: "ESL_Facilities",
                        principalColumn: "FacilNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESL_AllEvents_LogTypes_LogTypeNo",
                        column: x => x.LogTypeNo,
                        principalTable: "LogTypes",
                        principalColumn: "LogTypeNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ESL_AllEvents_LogTypeNo",
                table: "ESL_AllEvents",
                column: "LogTypeNo");

            migrationBuilder.CreateIndex(
                name: "IX_ESL_Details_SubjectFacilNo_SubjectNo1",
                table: "ESL_Details",
                columns: new[] { "SubjectFacilNo", "SubjectNo1" });

            migrationBuilder.CreateIndex(
                name: "IX_ESL_Employees_FacilityFacilNo",
                table: "ESL_Employees",
                column: "FacilityFacilNo");

            migrationBuilder.CreateIndex(
                name: "IX_ESL_Employees_UserEmployeeNo",
                table: "ESL_Employees",
                column: "UserEmployeeNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESL_AllEvents");

            migrationBuilder.DropTable(
                name: "ESL_ClearanceTypes");

            migrationBuilder.DropTable(
                name: "ESL_ClearanceZones");

            migrationBuilder.DropTable(
                name: "ESL_Constants");

            migrationBuilder.DropTable(
                name: "ESL_Details");

            migrationBuilder.DropTable(
                name: "ESL_Employees");

            migrationBuilder.DropTable(
                name: "ESL_EquipmentInvolved");

            migrationBuilder.DropTable(
                name: "ESL_Meters");

            migrationBuilder.DropTable(
                name: "ESL_RelatedTo");

            migrationBuilder.DropTable(
                name: "ESL_ScanDocs");

            migrationBuilder.DropTable(
                name: "ESL_ScanLobs");

            migrationBuilder.DropTable(
                name: "ESL_Units");

            migrationBuilder.DropTable(
                name: "ESL_WorkOrders");

            migrationBuilder.DropTable(
                name: "ESL_WorkToBePerformed");

            migrationBuilder.DropTable(
                name: "PlantShift");

            migrationBuilder.DropTable(
                name: "LogTypes");

            migrationBuilder.DropTable(
                name: "ESL_Subjects");

            migrationBuilder.DropTable(
                name: "ESL_Facilities");

            migrationBuilder.DropTable(
                name: "ESL_Users");
        }
    }
}
