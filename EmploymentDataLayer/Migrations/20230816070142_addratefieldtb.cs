using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmploymentDataLayer.Migrations
{
    public partial class addratefieldtb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeUsers_HotelDepartments_DepartmentId",
                table: "EmployeeUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogs_Users_UserId",
                table: "UserLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersPermissions_Permissions_PermissionId",
                table: "UsersPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersPermissions_Users_UserId",
                table: "UsersPermissions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EmployeeUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FieldOfRatings",
                columns: table => new
                {
                    FieldOfRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOfRatings", x => x.FieldOfRatingId);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    RateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeUserId = table.Column<int>(type: "int", nullable: false),
                    FieldOfRatingId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.RateId);
                    table.ForeignKey(
                        name: "FK_Rates_EmployeeUsers_EmployeeUserId",
                        column: x => x.EmployeeUserId,
                        principalTable: "EmployeeUsers",
                        principalColumn: "EmployeeUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rates_FieldOfRatings_FieldOfRatingId",
                        column: x => x.FieldOfRatingId,
                        principalTable: "FieldOfRatings",
                        principalColumn: "FieldOfRatingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rates_HotelDepartments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "HotelDepartments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rates_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rates_DepartmentID",
                table: "Rates",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_EmployeeUserId",
                table: "Rates",
                column: "EmployeeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_FieldOfRatingId",
                table: "Rates",
                column: "FieldOfRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_ManagerId",
                table: "Rates",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeUsers_HotelDepartments_DepartmentId",
                table: "EmployeeUsers",
                column: "DepartmentId",
                principalTable: "HotelDepartments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogs_Users_UserId",
                table: "UserLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPermissions_Permissions_PermissionId",
                table: "UsersPermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPermissions_Users_UserId",
                table: "UsersPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeUsers_HotelDepartments_DepartmentId",
                table: "EmployeeUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogs_Users_UserId",
                table: "UserLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersPermissions_Permissions_PermissionId",
                table: "UsersPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersPermissions_Users_UserId",
                table: "UsersPermissions");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "FieldOfRatings");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EmployeeUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeUsers_HotelDepartments_DepartmentId",
                table: "EmployeeUsers",
                column: "DepartmentId",
                principalTable: "HotelDepartments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogs_Users_UserId",
                table: "UserLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPermissions_Permissions_PermissionId",
                table: "UsersPermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPermissions_Users_UserId",
                table: "UsersPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
