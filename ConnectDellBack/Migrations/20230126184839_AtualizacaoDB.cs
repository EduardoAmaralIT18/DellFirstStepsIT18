using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConnectDellBack.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoDB : Migration
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
                    description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
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
                    notes = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
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
                values: new object[,]
                {
                    { 1, "Internship Program in partnership with PUCRS, focused in software development", null, "IT Academy", new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "The Design Academy is a capacitation program for students from Unisinos, focusing on Digital Product Design activities, with the goal to qualify interns to execute final functions on the Information Communication Technologies (ICT) area. It focuses on supplying the companies needs of digital design professionals, more specifically related to User Experience and User Interface, and to allow young professionals to complete their academic journey with a scientific and technical knowledge and to be oriented by the market needs. ", null, "Design Academy", new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "The Infrastructure Residence on IT focuses on implementing and executing a training and experience program in different IT infrastructure areas, allowing the members to participate in an immersive training program, merging technical knowledge with the latest research and innovation trends in the field and hands-on experience in a lab with the same materials and conditions that they will be involved in the future labor market. The term 'residence' was chosen to characterize exactly those practical aspects and capacitation experiences. Since the Infrastructure area requires a multistack and multidisciplinary formation, the residency program will innovate and provide the needed familiarity with the area so the students with medium to advanced knowledge can become Infrastructure professionals able to deal with all of the challenges on the field.", null, "Infrastructure Residence", new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "editionInternid", "email", "name", "notes", "role" },
                values: new object[,]
                {
                    { 1, null, "tassia.borochedes@dell.com", "Tassia Borochedes", "N/A", 0 },
                    { 2, null, "felipe.barreto@dell.com", "Felipe Barreto", "N/A", 0 },
                    { 3, null, "marcio.borges@dell.com", "Marcio Borges", "N/A", 0 },
                    { 4, null, "michael.dell@dell.com", "Michael Dell", "N/A", 0 },
                    { 5, null, "nelson.muller@dell.com", "Nelson Muller", "N/A", 2 },
                    { 6, null, "marcelo.soares@dell.com", "Marcelo Soares", "N/A", 2 },
                    { 7, null, "norton.zamboni@dellteam.com", "Norton Zamboni", "N/A", 3 },
                    { 8, null, "daniel.callegari@dell.com", "Daniel Callegari", "N/A", 4 },
                    { 9, null, "edson.moreno@dell.com", "Edson Moreno", "N/A", 4 },
                    { 10, null, "tuani.alves@edupucrs.com", "Tuani Alves", "N/A", 4 },
                    { 11, null, "natalya.goelzer@edu.pucrs.br", "Natalya Goelzer", "N/A", 4 }
                });

            migrationBuilder.InsertData(
                table: "OwnershipModel",
                columns: new[] { "ownerid", "programid" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "editions",
                columns: new[] { "id", "curriculum", "description", "endDate", "mode", "name", "numberOfInterns", "numberOfMembers", "programid", "startDate" },
                values: new object[,]
                {
                    { 1, "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js entre outros.", "Seventeenth edition of the IT Academy program focused solely on the self-titled female audience.", new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Edição 17", 21, 20, 1, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js", "Sixteenth edition of the IT Academy program aimed at undergraduate students in computer science courses.", new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Edição 16", 20, 25, 1, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js", "Eighteenth edition of the IT Academy program aimed at undergraduate students in computer science courses.", new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Edição 18", 21, 25, 1, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "User Experience and User Interface", "Seventeenth edition of the Design Academy program", new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Edição 17", 21, 25, 2, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "User Experience and User Interface", "Sixteenth edition of the Design Academy program", new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Edição 16", 21, 25, 2, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Computer Architecture, Cloud Computing, Database, and Security and IT environments", "Seventeenth edition of the Infrastructure Resindece program", new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Edição 17", 21, 25, 3, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Computer Architecture, Cloud Computing, Database, and Security and IT environments", "Sixteenth edition of the Infrastructure Resindece program", new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Edição 16", 21, 25, 3, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 2, 1 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 3, 1 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 4, 2 },
                    { 4, 5 },
                    { 5, 2 },
                    { 5, 5 },
                    { 6, 2 },
                    { 6, 5 },
                    { 6, 10 },
                    { 7, 2 },
                    { 7, 5 },
                    { 7, 10 }
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
                    { 12, 1, "laura.teixeira@dellteam.com", "Laura", "N/A", 1 },
                    { 13, 1, "kristen.arguello@dellteam.com", "Kristen Arguello", "N/A", 1 },
                    { 14, 1, "isadora.brust@dellteam.com", "Isadora Brust", "N/A", 1 },
                    { 15, 1, "yolanda.colombo@dellteam.com", "Yolanda Colombo", "N/A", 1 },
                    { 16, 1, "andressa.correa@dellteam.com", "Andressa Correa", "N/A", 1 },
                    { 17, 1, "kauana.galan@dellteam.com", "Kauana Galan", "N/A", 1 },
                    { 18, 1, "taise.goulart@dellteam.com", "Taise Goulart", "N/A", 1 },
                    { 19, 1, "jessica.haushahn@dellteam.com", "Jessica Haushahn", "N/A", 1 },
                    { 20, 1, "heloisa.farias@dellteam.com", "Heloisa Farias", "N/A", 1 },
                    { 21, 1, "paola.lopes@dellteam.com", "Paola Lopes", "N/A", 1 },
                    { 22, 1, "juliana.santos@dellteam.com", "Juliana Santos", "N/A", 1 },
                    { 23, 1, "yasmin.nunes@dellteam.com", "Yasmin Nunes", "N/A", 1 },
                    { 24, 1, "alexya.oliveira@dellteam.com", "Alexya Oliveira", "N/A", 1 },
                    { 25, 1, "yanni.partichelli@dellteam.com", "Yanni Partichelli", "N/A", 1 },
                    { 26, 1, "gabrielle.rodrigues@dellteam.com", "Gabrielle Rodrigues", "N/A", 1 },
                    { 27, 1, "larissa.rosa@dellteam.com", "Larissa Rosa", "N/A", 1 },
                    { 28, 1, "renata.rosa@dellteam.com", "Renata Rosa", "N/A", 1 },
                    { 29, 1, "jordana.santos@dellteam.com", "Jordana Santos", "N/A", 1 },
                    { 30, 1, "adriana.serpa@dellteam.com", "Adriana Serpa", "N/A", 1 },
                    { 31, 1, "gabriela.machado@dellteam.com", "Gabriela Machado", "N/A", 1 },
                    { 32, 1, "leandra.torbes@dellteam.com", "Leandra Torbes", "N/A", 1 }
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
