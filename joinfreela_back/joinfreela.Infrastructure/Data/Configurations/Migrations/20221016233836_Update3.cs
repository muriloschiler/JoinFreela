using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace joinfreela.Infrastructure.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Owners",
                type: "Varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Owners",
                type: "Varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Freelancers",
                type: "Varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Freelancers",
                type: "Varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Owners",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Owners",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Freelancers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Freelancers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(30)");
        }
    }
}
