using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESL.Core.Migrations
{
    /// <inheritdoc />
    public partial class ESL_FlowChangesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_(FlowChanges",
                table: "ESL_(FlowChanges");

            migrationBuilder.RenameTable(
                name: "ESL_(FlowChanges",
                newName: "ESL_FlowChanges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_FlowChanges",
                table: "ESL_FlowChanges",
                columns: new[] { "FacilNo", "LogTypeNo", "EventID", "EventID_RevNo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ESL_FlowChanges",
                table: "ESL_FlowChanges");

            migrationBuilder.RenameTable(
                name: "ESL_FlowChanges",
                newName: "ESL_(FlowChanges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESL_(FlowChanges",
                table: "ESL_(FlowChanges",
                columns: new[] { "FacilNo", "LogTypeNo", "EventID", "EventID_RevNo" });
        }
    }
}
