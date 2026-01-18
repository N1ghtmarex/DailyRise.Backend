using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quest",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    experience_reward = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    is_archive = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quest", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    external_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "challenge",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    experience_reward = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    category = table.Column<int>(type: "integer", nullable: false),
                    author_id = table.Column<string>(type: "text", nullable: true),
                    is_archive = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_challenge", x => x.id);
                    table.ForeignKey(
                        name: "fk_challenge_user_author_id",
                        column: x => x.author_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    experience = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    experience_to_next_level = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    is_archive = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "user_challenge_bind",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    challenge_id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    joined_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_challenge_bind", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_challenge_bind_challenge_challenge_id",
                        column: x => x.challenge_id,
                        principalTable: "challenge",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_challenge_bind_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_challenge_author_id",
                table: "challenge",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_challenge_category",
                table: "challenge",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "ix_challenge_id",
                table: "challenge",
                column: "id",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "ix_user_id",
                table: "user",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_username",
                table: "user",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_challenge_bind_challenge_id",
                table: "user_challenge_bind",
                column: "challenge_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_challenge_bind_id",
                table: "user_challenge_bind",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_challenge_bind_status",
                table: "user_challenge_bind",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_user_challenge_bind_user_id",
                table: "user_challenge_bind",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "challenge_quest_bind");

            migrationBuilder.DropTable(
                name: "profile");

            migrationBuilder.DropTable(
                name: "user_challenge_bind");

            migrationBuilder.DropTable(
                name: "quest");

            migrationBuilder.DropTable(
                name: "challenge");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
