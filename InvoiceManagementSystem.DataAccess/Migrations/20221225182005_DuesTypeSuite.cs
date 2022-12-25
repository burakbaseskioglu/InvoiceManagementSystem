using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DuesTypeSuite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SuiteId",
                table: "Dues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dues_SuiteId",
                table: "Dues",
                column: "SuiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dues_Suites_SuiteId",
                table: "Dues",
                column: "SuiteId",
                principalTable: "Suites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dues_Suites_SuiteId",
                table: "Dues");

            migrationBuilder.DropIndex(
                name: "IX_Dues_SuiteId",
                table: "Dues");

            migrationBuilder.DropColumn(
                name: "SuiteId",
                table: "Dues");
        }
    }
}
