using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotyApp.api.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sender_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    reciever_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_contacts_users_reciever_id",
                        column: x => x.reciever_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contacts_users_sender_id",
                        column: x => x.sender_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sender_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    reciever_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_messages_users_reciever_id",
                        column: x => x.reciever_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_messages_users_sender_id",
                        column: x => x.sender_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userRoles",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    role_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRoles", x => x.id);
                    table.ForeignKey(
                        name: "FK_userRoles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRoles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_reciever_id",
                table: "contacts",
                column: "reciever_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_sender_id",
                table: "contacts",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_reciever_id",
                table: "messages",
                column: "reciever_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_sender_id",
                table: "messages",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_userRoles_role_id",
                table: "userRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_userRoles_user_id",
                table: "userRoles",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "userRoles");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
