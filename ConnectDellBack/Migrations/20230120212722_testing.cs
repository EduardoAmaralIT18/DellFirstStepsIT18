using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConnectDellBack.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
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
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    numberOfMembers = table.Column<int>(type: "int", nullable: false),
                    numberOfInterns = table.Column<int>(type: "int", nullable: false),
                    mode = table.Column<int>(type: "int", nullable: false),
                    curriculum = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    programid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editions", x => x.id);
                    table.ForeignKey(
                        name: "FK_editions_programs_programid",
                        column: x => x.programid,
                        principalTable: "programs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "phases",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    peopleInvolved = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    type = table.Column<int>(type: "int", nullable: false),
                    editionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phases", x => x.id);
                    table.ForeignKey(
                        name: "FK_phases_editions_editionid",
                        column: x => x.editionid,
                        principalTable: "editions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    memberid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipModel", x => new { x.editionid, x.memberid });
                    table.ForeignKey(
                        name: "FK_MembershipModel_editions_editionid",
                        column: x => x.editionid,
                        principalTable: "editions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembershipModel_users_memberid",
                        column: x => x.memberid,
                        principalTable: "users",
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
                    programid = table.Column<int>(type: "int", nullable: true),
                    authorid = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.id);
                    table.ForeignKey(
                        name: "FK_news_programs_programid",
                        column: x => x.programid,
                        principalTable: "programs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_news_users_authorid",
                        column: x => x.authorid,
                        principalTable: "users",
                        principalColumn: "id");
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

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    imageId = table.Column<int>(type: "int", nullable: false),
                    imageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    newsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.imageId);
                    table.ForeignKey(
                        name: "FK_images_news_imageId",
                        column: x => x.imageId,
                        principalTable: "news",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "programs",
                columns: new[] { "id", "description", "endDate", "name", "startDate" },
                values: new object[] { 1, "Internship Program in partnership with PUCRS, focused in software development", null, "IT Academy", new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "editionInternid", "email", "name", "notes", "role" },
                values: new object[,]
                {
                    { 1, null, "tassia.borochedes@dell.com", "Tassia", "N/A", 0 },
                    { 2, null, "nelson.muller@dell.com", "Nelson", "N/A", 2 },
                    { 3, null, "marcelo.soares@dell.com", "Marcelo", "N/A", 2 },
                    { 4, null, "norton.zamboni@dellteam.com", "Norton", "N/A", 3 },
                    { 5, null, "daniel.callegari@dell.com", "Daniel", "N/A", 4 },
                    { 6, null, "edson.moreno@dell.com", "Edson", "N/A", 4 },
                    { 7, null, "tuani.alves@edupucrs.com", "Tuani", "N/A", 4 },
                    { 8, null, "natalya.goelzer@edu.pucrs.br", "Natalya", "N/A", 4 }
                });

            migrationBuilder.InsertData(
                table: "OwnershipModel",
                columns: new[] { "ownerid", "programid" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "editions",
                columns: new[] { "id", "curriculum", "description", "endDate", "mode", "name", "numberOfInterns", "numberOfMembers", "programid", "startDate" },
                values: new object[] { 1, "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js entre outros", "First edition of the IT Academy program focused solely on the self-titled female audience", new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "IT Academy 17", 21, 25, 1, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "news",
                columns: new[] { "id", "authorid", "date", "programid", "text", "title" },
                values: new object[] { 1, 1, new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "The all-girls team starts development of the Dell FirstSteps Project, that will help organize all contents about Dell's Internship Programs.", "IT 17 team starts development of the Dell FirstSteps Project" });

            migrationBuilder.InsertData(
                table: "MembershipModel",
                columns: new[] { "editionid", "memberid" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 }
                });

            migrationBuilder.InsertData(
                table: "phases",
                columns: new[] { "id", "description", "editionid", "endDate", "name", "peopleInvolved", "startDate", "type" },
                values: new object[] { 1, "Enrollment stage", 1, new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enrollment", "Puc and Dell Staff", new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "editionInternid", "email", "name", "notes", "role" },
                values: new object[,]
                {
                    { 9, 1, "alexya.oliveira@dellteam.com", "Alexya", "Wish we had more Vue.js lessons, due to this we had difficulties doing our integration project. But the team is awesome and we managed to overcome this difficulty together", 1 },
                    { 10, 1, "juliana.maulzolfsantos@dellteam.com", "Juliana", "Entity framework is difficult to understand and integrating the DB via code is still complicated to me", 1 },
                    { 11, 1, "yolanda.colombo@dellteam.com", "Yolanda", "I need to learn Vue.js.", 1 },
                    { 12, 1, "gabrielle.rodrigues@dellteam.com", "Gabrielle", "Entity framework is very difficult and I need more Vue.js lessons", 1 },
                    { 13, 1, "heloisa.lopesfarias@dellteam.com", "Heloisa", "I learned a lot about C# and Dotnet, but need to learn more about Vue.js.", 1 },
                    { 14, 1, "adriana.serpa@dellteam.com", "Adriana", "I need to review the Entity framework lessons and study Vue.Js", 1 },
                    { 15, 1, "larissa.rosa@dellteam.com", "Larissa", "I like Entity Framework but need to review Vue.js", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_editions_programid",
                table: "editions",
                column: "programid");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipModel_memberid",
                table: "MembershipModel",
                column: "memberid");

            migrationBuilder.CreateIndex(
                name: "IX_news_authorid",
                table: "news",
                column: "authorid");

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
                name: "images");

            migrationBuilder.DropTable(
                name: "MembershipModel");

            migrationBuilder.DropTable(
                name: "OwnershipModel");

            migrationBuilder.DropTable(
                name: "phases");

            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "editions");

            migrationBuilder.DropTable(
                name: "programs");
        }
    }
}
