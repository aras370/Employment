using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmploymentDataLayer.Migrations
{
    public partial class createemployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FhatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodeMelli = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Marriege = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    EducationLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Major = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Univercity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Formerjob = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CauseOfLeave = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InformaionOfFormerBoss = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    RequestedSalary = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DateTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
