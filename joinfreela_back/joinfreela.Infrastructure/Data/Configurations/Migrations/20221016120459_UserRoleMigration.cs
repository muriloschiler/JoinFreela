using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace joinfreela.Infrastructure.Migrations
{
    public partial class UserRoleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "Owners",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "Freelancers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "Varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Owners_UserRoleId",
                table: "Owners",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_UserRoleId",
                table: "Freelancers",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Freelancers_UserRole_UserRoleId",
                table: "Freelancers",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_UserRole_UserRoleId",
                table: "Owners",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_UserRole_UserRoleId",
                table: "Freelancers");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_UserRole_UserRoleId",
                table: "Owners");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Owners_UserRoleId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Freelancers_UserRoleId",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Freelancers");
        }
    }
}
