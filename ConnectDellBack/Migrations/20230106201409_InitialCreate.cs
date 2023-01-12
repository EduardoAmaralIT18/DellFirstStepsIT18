using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectDellBack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "programs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "editions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    numberOfMembers = table.Column<int>(type: "int", nullable: false),
                    numberOfInterns = table.Column<int>(type: "int", nullable: false),
                    mode = table.Column<int>(type: "int", nullable: false),
                    curriculum = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    programid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editions", x => x.id);
                    table.ForeignKey(
                        name: "FK_editions_programs_programid",
                        column: x => x.programid,
                        principalTable: "programs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    programid = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.id);
                    table.ForeignKey(
                        name: "FK_news_programs_programid",
                        column: x => x.programid,
                        principalTable: "programs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phases",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    peopleInvolved = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    editionid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phases", x => x.id);
                    table.ForeignKey(
                        name: "FK_phases_editions_editionid",
                        column: x => x.editionid,
                        principalTable: "editions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    editionInternid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_editions_editionInternid",
                        column: x => x.editionInternid,
                        principalTable: "editions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "MembershipModel",
                columns: table => new
                {
                    editionid = table.Column<int>(type: "int", nullable: false),
                    ownerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipModel", x => new { x.editionid, x.ownerid });
                    table.ForeignKey(
                        name: "FK_MembershipModel_editions_editionid",
                        column: x => x.editionid,
                        principalTable: "editions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembershipModel_users_ownerid",
                        column: x => x.ownerid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnershipModel",
                columns: table => new
                {
                    ownerid = table.Column<int>(type: "int", nullable: false),
                    programid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnershipModel", x => new { x.ownerid, x.programid });
                    table.ForeignKey(
                        name: "FK_OwnershipModel_programs_programid",
                        column: x => x.programid,
                        principalTable: "programs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnershipModel_users_ownerid",
                        column: x => x.ownerid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_editions_programid",
                table: "editions",
                column: "programid");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipModel_ownerid",
                table: "MembershipModel",
                column: "ownerid");

            migrationBuilder.CreateIndex(
                name: "IX_news_programid",
                table: "news",
                column: "programid");

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipModel_programid",
                table: "OwnershipModel",
                column: "programid");

            migrationBuilder.CreateIndex(
                name: "IX_phases_editionid",
                table: "phases",
                column: "editionid");

            migrationBuilder.CreateIndex(
                name: "IX_users_editionInternid",
                table: "users",
                column: "editionInternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembershipModel");

            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropTable(
                name: "OwnershipModel");

            migrationBuilder.DropTable(
                name: "phases");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "editions");

            migrationBuilder.DropTable(
                name: "programs");
        }
    }
}
