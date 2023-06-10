using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample_EntityFrameworkCore_CodeFirstApproach.Migrations
{
    public partial class officeAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Office_Address",
                table: "EmployeeDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Office_Address",
                table: "EmployeeDetails");
        }
    }
}
