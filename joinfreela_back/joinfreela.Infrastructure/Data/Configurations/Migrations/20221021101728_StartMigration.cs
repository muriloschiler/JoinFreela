using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace joinfreela.Infrastructure.Migrations
{
    public partial class StartMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Active",
                table: "Projects",
                type: "Integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Active",
                table: "Owners",
                type: "Integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Open",
                table: "Jobs",
                type: "Integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Active",
                table: "Freelancers",
                type: "Integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Open",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Freelancers");
        }
    }
}
