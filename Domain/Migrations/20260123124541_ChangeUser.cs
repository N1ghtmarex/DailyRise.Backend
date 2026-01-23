using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "user",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "user",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "user",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_firstname",
                table: "user",
                column: "firstname");

            migrationBuilder.CreateIndex(
                name: "ix_user_lastname",
                table: "user",
                column: "lastname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_user_firstname",
                table: "user");

            migrationBuilder.DropIndex(
                name: "ix_user_lastname",
                table: "user");

            migrationBuilder.DropColumn(
                name: "firstname",
                table: "user");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "user");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "user",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
