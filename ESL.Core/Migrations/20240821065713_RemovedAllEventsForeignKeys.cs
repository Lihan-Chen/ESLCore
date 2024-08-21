using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESL.Core.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAllEventsForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ESL_AllEvents_ESL_Facilities_FacilNo",
                table: "ESL_AllEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_ESL_AllEvents_ESL_LogTypes_LogTypeNo",
                table: "ESL_AllEvents");

            migrationBuilder.DropIndex(
                name: "IX_ESL_AllEvents_LogTypeNo",
                table: "ESL_AllEvents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ESL_AllEvents_LogTypeNo",
                table: "ESL_AllEvents",
                column: "LogTypeNo");

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_AllEvents_ESL_Facilities_FacilNo",
                table: "ESL_AllEvents",
                column: "FacilNo",
                principalTable: "ESL_Facilities",
                principalColumn: "FacilNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ESL_AllEvents_ESL_LogTypes_LogTypeNo",
                table: "ESL_AllEvents",
                column: "LogTypeNo",
                principalTable: "ESL_LogTypes",
                principalColumn: "LogTypeNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
