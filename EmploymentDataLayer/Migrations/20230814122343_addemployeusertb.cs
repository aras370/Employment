using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmploymentDataLayer.Migrations
{
    public partial class addemployeusertb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeUsers",
                columns: table => new
                {
                    EmployeeUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeUsers", x => x.EmployeeUserId);
                    table.ForeignKey(
                        name: "FK_EmployeeUsers_HotelDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "HotelDepartments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeUsers_DepartmentId",
                table: "EmployeeUsers",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeUsers");
        }
    }
}
