using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeERPPortal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFacultyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FACULTIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(100)", nullable: false),
                    DEPARTMENT = table.Column<string>(type: "NVARCHAR2(100)", nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(100)", nullable: false),
                    JOINDATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACULTIES", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FACULTIES");
        }
    }
}
