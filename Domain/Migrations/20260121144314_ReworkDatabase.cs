using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class ReworkDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_challenge_user_author_id",
                table: "challenge");

            migrationBuilder.DropTable(
                name: "challenge_quest_bind");

            migrationBuilder.DropTable(
                name: "profile");

            migrationBuilder.DropTable(
                name: "quest");

            migrationBuilder.DropIndex(
                name: "ix_challenge_category",
                table: "challenge");

            migrationBuilder.DropColumn(
                name: "external_user_id",
                table: "user");

            migrationBuilder.DropColumn(
                name: "category",
                table: "challenge");

            migrationBuilder.DropColumn(
                name: "experience_reward",
                table: "challenge");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "user",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "created_at",
                table: "user",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "is_archive",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "telegram_id",
                table: "user",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "updated_at",
                table: "user",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "challenge",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "author_id",
                table: "challenge",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "user_challenge_check_in",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_challenge_bind_id = table.Column<string>(type: "text", nullable: false),
                    check_in_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_challenge_check_in", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_challenge_check_in_user_challenge_bind_user_challenge_",
                        column: x => x.user_challenge_bind_id,
                        principalTable: "user_challenge_bind",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_challenge_check_in_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_telegram_id",
                table: "user",
                column: "telegram_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_challenge_check_in_id",
                table: "user_challenge_check_in",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_challenge_check_in_status",
                table: "user_challenge_check_in",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_user_challenge_check_in_user_challenge_bind_id",
                table: "user_challenge_check_in",
                column: "user_challenge_bind_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_challenge_check_in_user_id",
                table: "user_challenge_check_in",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_challenge_user_author_id",
                table: "challenge",
                column: "author_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_challenge_user_author_id",
                table: "challenge");

            migrationBuilder.DropTable(
                name: "user_challenge_check_in");

            migrationBuilder.DropIndex(
                name: "ix_user_telegram_id",
                table: "user");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "user");

            migrationBuilder.DropColumn(
                name: "is_archive",
                table: "user");

            migrationBuilder.DropColumn(
                name: "telegram_id",
                table: "user");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "user");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "user",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<Guid>(
                name: "external_user_id",
                table: "user",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "challenge",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "author_id",
                table: "challenge",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "category",
                table: "challenge",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "experience_reward",
                table: "challenge",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    experience = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    experience_to_next_level = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    is_archive = table.Column<bool>(type: "boolean", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profile", x => x.id);
                    table.ForeignKey(
                        name: "fk_profile_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quest",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    experience_reward = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    is_archive = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quest", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "challenge_quest_bind",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    challenge_id = table.Column<string>(type: "text", nullable: false),
                    quest_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_challenge_quest_bind", x => x.id);
                    table.ForeignKey(
                        name: "fk_challenge_quest_bind_challenge_challenge_id",
                        column: x => x.challenge_id,
                        principalTable: "challenge",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_challenge_quest_bind_quest_quest_id",
                        column: x => x.quest_id,
                        principalTable: "quest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_challenge_category",
                table: "challenge",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "ix_challenge_quest_bind_challenge_id",
                table: "challenge_quest_bind",
                column: "challenge_id");

            migrationBuilder.CreateIndex(
                name: "ix_challenge_quest_bind_id",
                table: "challenge_quest_bind",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_challenge_quest_bind_quest_id",
                table: "challenge_quest_bind",
                column: "quest_id");

            migrationBuilder.CreateIndex(
                name: "ix_profile_id",
                table: "profile",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_profile_user_id",
                table: "profile",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_quest_id",
                table: "quest",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_quest_name",
                table: "quest",
                column: "name");

            migrationBuilder.AddForeignKey(
                name: "fk_challenge_user_author_id",
                table: "challenge",
                column: "author_id",
                principalTable: "user",
                principalColumn: "id");
        }
    }
}
