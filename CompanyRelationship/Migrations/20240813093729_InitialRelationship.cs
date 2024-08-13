using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyRelationship.Migrations
{
    /// <inheritdoc />
    public partial class InitialRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Name",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "BranchOffices",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompanyName1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffices", x => x.Name);
                    table.ForeignKey(
                        name: "FK_BranchOffices_Companies_CompanyName",
                        column: x => x.CompanyName,
                        principalTable: "Companies",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchOffices_Companies_CompanyName1",
                        column: x => x.CompanyName1,
                        principalTable: "Companies",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "BranchOfficeDepts",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BranchOfficeName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOfficeDepts", x => x.Name);
                    table.ForeignKey(
                        name: "FK_BranchOfficeDepts_BranchOffices_BranchOfficeName",
                        column: x => x.BranchOfficeName,
                        principalTable: "BranchOffices",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchOfficeDepts_Companies_CompanyName",
                        column: x => x.CompanyName,
                        principalTable: "Companies",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchOfficeDepts_BranchOfficeName",
                table: "BranchOfficeDepts",
                column: "BranchOfficeName");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOfficeDepts_CompanyName",
                table: "BranchOfficeDepts",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOffices_CompanyName",
                table: "BranchOffices",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOffices_CompanyName1",
                table: "BranchOffices",
                column: "CompanyName1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchOfficeDepts");

            migrationBuilder.DropTable(
                name: "BranchOffices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CompanyRelation",
                columns: table => new
                {
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRelation", x => new { x.ChildId, x.ParentId });
                    table.ForeignKey(
                        name: "FK_CompanyRelation_Companies_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyRelation_Companies_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Name",
                table: "Companies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRelation_ParentId",
                table: "CompanyRelation",
                column: "ParentId");
        }
    }
}
