using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyRelationship.Migrations
{
    /// <inheritdoc />
    public partial class InitialRelationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BranchOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BranchOfficeDepts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BranchOffices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BranchOfficeDepts");
        }
    }
}
