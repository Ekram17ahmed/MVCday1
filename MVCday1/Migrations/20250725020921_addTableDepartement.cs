using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCday1.Migrations
{
    /// <inheritdoc />
    public partial class addTableDepartement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedON = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptID",
                table: "Employees",
                column: "DeptID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departement_DeptID",
                table: "Employees",
                column: "DeptID",
                principalTable: "Departement",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departement_DeptID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Departement");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DeptID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DeptID",
                table: "Employees");
        }
    }
}
