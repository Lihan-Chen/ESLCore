using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESL.Core.Migrations
{
    /// <inheritdoc />
    public partial class ESL_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ESL_AllEvents_LogTypes_LogTypeNo",
                table: "ESL_AllEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_LogTypes_LogTypeNo",
                table: "ESL_SOC");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantShift",
                table: "PlantShift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogTypes",
                table: "LogTypes");

            migrationBuilder.RenameTable(
                name: "PlantShift",
                newName: "ESL_PlantShifts");

            migrationBuilder.RenameTable(
                name: "LogTypes",
                newName: "ESL_LogTypes");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_Details",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_PlantShifts",
                table: "ESL_PlantShifts",
                columns: new[] { "FacilNo", "ShiftNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_LogTypes",
                table: "ESL_LogTypes",
                column: "LogTypeNo");

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_AllEvents_ESL_LogTypes_LogTypeNo",
                table: "ESL_AllEvents",
                column: "LogTypeNo",
                principalTable: "ESL_LogTypes",
                principalColumn: "LogTypeNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_ESL_LogTypes_LogTypeNo",
                table: "ESL_SOC",
                column: "LogTypeNo",
                principalTable: "ESL_LogTypes",
                principalColumn: "LogTypeNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ESL_AllEvents_ESL_LogTypes_LogTypeNo",
                table: "ESL_AllEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_SOC_ESL_LogTypes_LogTypeNo",
                table: "ESL_SOC");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_PlantShifts",
                table: "ESL_PlantShifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_LogTypes",
                table: "ESL_LogTypes");

            migrationBuilder.RenameTable(
                name: "ESL_PlantShifts",
                newName: "PlantShift");

            migrationBuilder.RenameTable(
                name: "ESL_LogTypes",
                newName: "LogTypes");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ESL_Details",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantShift",
                table: "PlantShift",
                columns: new[] { "FacilNo", "ShiftNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogTypes",
                table: "LogTypes",
                column: "LogTypeNo");

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_AllEvents_LogTypes_LogTypeNo",
                table: "ESL_AllEvents",
                column: "LogTypeNo",
                principalTable: "LogTypes",
                principalColumn: "LogTypeNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_SOC_LogTypes_LogTypeNo",
                table: "ESL_SOC",
                column: "LogTypeNo",
                principalTable: "LogTypes",
                principalColumn: "LogTypeNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
