using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ApartmentNewProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Apartments",
                newName: "ApartmentNo");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Apartments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlockCode",
                table: "Apartments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "BlockCode",
                table: "Apartments");

            migrationBuilder.RenameColumn(
                name: "ApartmentNo",
                table: "Apartments",
                newName: "MyProperty");
        }
    }
}
