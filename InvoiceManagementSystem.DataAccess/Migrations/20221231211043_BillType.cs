using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InvoiceManagementSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BillType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Dues",
                newName: "BillTypeId");

            migrationBuilder.CreateTable(
                name: "BillTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dues_BillTypeId",
                table: "Dues",
                column: "BillTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dues_BillTypes_BillTypeId",
                table: "Dues",
                column: "BillTypeId",
                principalTable: "BillTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dues_BillTypes_BillTypeId",
                table: "Dues");

            migrationBuilder.DropTable(
                name: "BillTypes");

            migrationBuilder.DropIndex(
                name: "IX_Dues_BillTypeId",
                table: "Dues");

            migrationBuilder.RenameColumn(
                name: "BillTypeId",
                table: "Dues",
                newName: "Type");
        }
    }
}
