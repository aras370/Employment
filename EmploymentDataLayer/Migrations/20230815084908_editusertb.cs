using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmploymentDataLayer.Migrations
{
    public partial class editusertb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_HotelDepartments_DepartmentId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_DepartmentId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Permissions");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                unique: true,
                filter: "[DepartmentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_HotelDepartments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "HotelDepartments",
                principalColumn: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_HotelDepartments_DepartmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DepartmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Permissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_DepartmentId",
                table: "Permissions",
                column: "DepartmentId",
                unique: true,
                filter: "[DepartmentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_HotelDepartments_DepartmentId",
                table: "Permissions",
                column: "DepartmentId",
                principalTable: "HotelDepartments",
                principalColumn: "DepartmentId");
        }
    }
}
