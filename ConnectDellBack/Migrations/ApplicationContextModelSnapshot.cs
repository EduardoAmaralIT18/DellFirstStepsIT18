﻿// <auto-generated />
using System;
using ConnectDellBack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConnectDellBack.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConnectDellBack.Models.EditionModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("curriculum")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("mode")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("numberOfInterns")
                        .HasColumnType("int");

                    b.Property<int>("numberOfMembers")
                        .HasColumnType("int");

                    b.Property<int?>("programid")
                        .HasColumnType("int");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("programid");

                    b.ToTable("editions");

                    b.HasData(
                        new
                        {
                            id = 1,
                            curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js entre outros.",
                            description = "Seventeenth edition of the IT Academy program focused solely on the self-titled female audience.",
                            endDate = new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            mode = 1,
                            name = "Edição 17",
                            numberOfInterns = 21,
                            numberOfMembers = 20,
                            programid = 1,
                            startDate = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 2,
                            curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js",
                            description = "Sixteenth edition of the IT Academy program aimed at undergraduate students in computer science courses.",
                            endDate = new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            mode = 0,
                            name = "Edição 16",
                            numberOfInterns = 20,
                            numberOfMembers = 25,
                            programid = 1,
                            startDate = new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 3,
                            curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js",
                            description = "Eighteenth edition of the IT Academy program aimed at undergraduate students in computer science courses.",
                            endDate = new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            mode = 2,
                            name = "Edição 18",
                            numberOfInterns = 21,
                            numberOfMembers = 25,
                            programid = 1,
                            startDate = new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 4,
                            curriculum = "User Experience and User Interface",
                            description = "Seventeenth edition of the Design Academy program",
                            endDate = new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            mode = 1,
                            name = "Edição 17",
                            numberOfInterns = 21,
                            numberOfMembers = 25,
                            programid = 2,
                            startDate = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 5,
                            curriculum = "User Experience and User Interface",
                            description = "Sixteenth edition of the Design Academy program",
                            endDate = new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            mode = 1,
                            name = "Edição 16",
                            numberOfInterns = 21,
                            numberOfMembers = 25,
                            programid = 2,
                            startDate = new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 6,
                            curriculum = "Computer Architecture, Cloud Computing, Database, and Security and IT environments",
                            description = "Seventeenth edition of the Infrastructure Resindece program",
                            endDate = new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            mode = 1,
                            name = "Edição 17",
                            numberOfInterns = 21,
                            numberOfMembers = 25,
                            programid = 3,
                            startDate = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 7,
                            curriculum = "Computer Architecture, Cloud Computing, Database, and Security and IT environments",
                            description = "Sixteenth edition of the Infrastructure Resindece program",
                            endDate = new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            mode = 1,
                            name = "Edição 17",
                            numberOfInterns = 21,
                            numberOfMembers = 25,
                            programid = 3,
                            startDate = new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ConnectDellBack.Models.ImageModel", b =>
                {
                    b.Property<int>("imageId")
                        .HasColumnType("int");

                    b.Property<byte[]>("imageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("imageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("newsId")
                        .HasColumnType("int");

                    b.HasKey("imageId");

                    b.ToTable("images");
                });

            modelBuilder.Entity("ConnectDellBack.Models.MembershipModel", b =>
                {
                    b.Property<int>("editionid")
                        .HasColumnType("int");

                    b.Property<int>("memberid")
                        .HasColumnType("int");

                    b.HasKey("editionid", "memberid");

                    b.HasIndex("memberid");

                    b.ToTable("MembershipModel");

                    b.HasData(
                        new
                        {
                            editionid = 1,
                            memberid = 1
                        },
                        new
                        {
                            editionid = 1,
                            memberid = 5
                        },
                        new
                        {
                            editionid = 1,
                            memberid = 6
                        },
                        new
                        {
                            editionid = 1,
                            memberid = 7
                        },
                        new
                        {
                            editionid = 1,
                            memberid = 8
                        },
                        new
                        {
                            editionid = 1,
                            memberid = 9
                        },
                        new
                        {
                            editionid = 1,
                            memberid = 10
                        },
                        new
                        {
                            editionid = 1,
                            memberid = 11
                        },
                        new
                        {
                            editionid = 2,
                            memberid = 1
                        },
                        new
                        {
                            editionid = 2,
                            memberid = 5
                        },
                        new
                        {
                            editionid = 2,
                            memberid = 6
                        },
                        new
                        {
                            editionid = 2,
                            memberid = 8
                        },
                        new
                        {
                            editionid = 2,
                            memberid = 9
                        },
                        new
                        {
                            editionid = 2,
                            memberid = 10
                        },
                        new
                        {
                            editionid = 2,
                            memberid = 11
                        },
                        new
                        {
                            editionid = 3,
                            memberid = 1
                        },
                        new
                        {
                            editionid = 3,
                            memberid = 5
                        },
                        new
                        {
                            editionid = 3,
                            memberid = 6
                        },
                        new
                        {
                            editionid = 3,
                            memberid = 8
                        },
                        new
                        {
                            editionid = 3,
                            memberid = 9
                        },
                        new
                        {
                            editionid = 3,
                            memberid = 10
                        },
                        new
                        {
                            editionid = 3,
                            memberid = 11
                        },
                        new
                        {
                            editionid = 4,
                            memberid = 2
                        },
                        new
                        {
                            editionid = 4,
                            memberid = 5
                        },
                        new
                        {
                            editionid = 5,
                            memberid = 2
                        },
                        new
                        {
                            editionid = 5,
                            memberid = 5
                        },
                        new
                        {
                            editionid = 6,
                            memberid = 2
                        },
                        new
                        {
                            editionid = 6,
                            memberid = 5
                        },
                        new
                        {
                            editionid = 6,
                            memberid = 10
                        },
                        new
                        {
                            editionid = 7,
                            memberid = 2
                        },
                        new
                        {
                            editionid = 7,
                            memberid = 5
                        },
                        new
                        {
                            editionid = 7,
                            memberid = 10
                        });
                });

            modelBuilder.Entity("ConnectDellBack.Models.NewsModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("authorid")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("programid")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.HasIndex("authorid");

                    b.HasIndex("programid");

                    b.ToTable("news");

                    b.HasData(
                        new
                        {
                            id = 1,
                            authorid = 1,
                            date = new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            programid = 1,
                            text = "The all-girls team starts development of the Dell FirstSteps Project, that will help organize all contents about Dell's Internship Programs.",
                            title = "IT 17 team starts development of the Dell FirstSteps Project"
                        });
                });

            modelBuilder.Entity("ConnectDellBack.Models.OwnershipModel", b =>
                {
                    b.Property<int>("ownerid")
                        .HasColumnType("int");

                    b.Property<int>("programid")
                        .HasColumnType("int");

                    b.HasKey("ownerid", "programid");

                    b.HasIndex("programid");

                    b.ToTable("OwnershipModel");

                    b.HasData(
                        new
                        {
                            ownerid = 1,
                            programid = 1
                        },
                        new
                        {
                            ownerid = 2,
                            programid = 2
                        },
                        new
                        {
                            ownerid = 3,
                            programid = 3
                        });
                });

            modelBuilder.Entity("ConnectDellBack.Models.PhasesModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("editionid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("peopleInvolved")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("editionid");

                    b.ToTable("phases");

                    b.HasData(
                        new
                        {
                            id = 1,
                            description = "Enrollment stage",
                            editionid = 1,
                            endDate = new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Enrollment",
                            peopleInvolved = "Puc and Dell Staff",
                            startDate = new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            type = 0
                        });
                });

            modelBuilder.Entity("ConnectDellBack.Models.ProgramModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("programs");

                    b.HasData(
                        new
                        {
                            id = 1,
                            description = "Internship Program in partnership with PUCRS, focused in software development",
                            name = "IT Academy",
                            startDate = new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 2,
                            description = "The Design Academy is a capacitation program for students from Unisinos, focusing on Digital Product Design activities, with the goal to qualify interns to execute final functions on the Information Communication Technologies (ICT) area. It focuses on supplying the companies needs of digital design professionals, more specifically related to User Experience and User Interface, and to allow young professionals to complete their academic journey with a scientific and technical knowledge and to be oriented by the market needs. ",
                            name = "Design Academy",
                            startDate = new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 3,
                            description = "The Infrastructure Residence on IT focuses on implementing and executing a training and experience program in different IT infrastructure areas, allowing the members to participate in an immersive training program, merging technical knowledge with the latest research and innovation trends in the field and hands-on experience in a lab with the same materials and conditions that they will be involved in the future labor market. The term 'residence' was chosen to characterize exactly those practical aspects and capacitation experiences. Since the Infrastructure area requires a multistack and multidisciplinary formation, the residency program will innovate and provide the needed familiarity with the area so the students with medium to advanced knowledge can become Infrastructure professionals able to deal with all of the challenges on the field.",
                            name = "Infrastructure Residence",
                            startDate = new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ConnectDellBack.Models.UserModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("editionInternid")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("editionInternid");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            id = 1,
                            email = "tassia.borochedes@dell.com",
                            name = "Tassia Borochedes",
                            notes = "N/A",
                            role = 0
                        },
                        new
                        {
                            id = 2,
                            email = "felipe.barreto@dell.com",
                            name = "Felipe Barreto",
                            notes = "N/A",
                            role = 0
                        },
                        new
                        {
                            id = 3,
                            email = "marcio.borges@dell.com",
                            name = "Marcio Borges",
                            notes = "N/A",
                            role = 0
                        },
                        new
                        {
                            id = 4,
                            email = "michael.dell@dell.com",
                            name = "Michael Dell",
                            notes = "N/A",
                            role = 0
                        },
                        new
                        {
                            id = 5,
                            email = "nelson.muller@dell.com",
                            name = "Nelson Muller",
                            notes = "N/A",
                            role = 2
                        },
                        new
                        {
                            id = 6,
                            email = "marcelo.soares@dell.com",
                            name = "Marcelo Soares",
                            notes = "N/A",
                            role = 2
                        },
                        new
                        {
                            id = 7,
                            email = "norton.zamboni@dellteam.com",
                            name = "Norton Zamboni",
                            notes = "N/A",
                            role = 3
                        },
                        new
                        {
                            id = 8,
                            email = "daniel.callegari@dell.com",
                            name = "Daniel Callegari",
                            notes = "N/A",
                            role = 4
                        },
                        new
                        {
                            id = 9,
                            email = "edson.moreno@dell.com",
                            name = "Edson Moreno",
                            notes = "N/A",
                            role = 4
                        },
                        new
                        {
                            id = 10,
                            email = "tuani.alves@edupucrs.com",
                            name = "Tuani Alves",
                            notes = "N/A",
                            role = 4
                        },
                        new
                        {
                            id = 11,
                            email = "natalya.goelzer@edu.pucrs.br",
                            name = "Natalya Goelzer",
                            notes = "N/A",
                            role = 4
                        },
                        new
                        {
                            id = 12,
                            editionInternid = 1,
                            email = "laura.teixeira@dellteam.com",
                            name = "Laura",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 13,
                            editionInternid = 1,
                            email = "kristen.arguello@dellteam.com",
                            name = "Kristen Arguello",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 14,
                            editionInternid = 1,
                            email = "isadora.brust@dellteam.com",
                            name = "Isadora Brust",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 15,
                            editionInternid = 1,
                            email = "yolanda.colombo@dellteam.com",
                            name = "Yolanda Colombo",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 16,
                            editionInternid = 1,
                            email = "andressa.correa@dellteam.com",
                            name = "Andressa Correa",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 17,
                            editionInternid = 1,
                            email = "kauana.galan@dellteam.com",
                            name = "Kauana Galan",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 18,
                            editionInternid = 1,
                            email = "taise.goulart@dellteam.com",
                            name = "Taise Goulart",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 19,
                            editionInternid = 1,
                            email = "jessica.haushahn@dellteam.com",
                            name = "Jessica Haushahn",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 20,
                            editionInternid = 1,
                            email = "heloisa.farias@dellteam.com",
                            name = "Heloisa Farias",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 21,
                            editionInternid = 1,
                            email = "paola.lopes@dellteam.com",
                            name = "Paola Lopes",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 22,
                            editionInternid = 1,
                            email = "juliana.santos@dellteam.com",
                            name = "Juliana Santos",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 23,
                            editionInternid = 1,
                            email = "yasmin.nunes@dellteam.com",
                            name = "Yasmin Nunes",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 24,
                            editionInternid = 1,
                            email = "alexya.oliveira@dellteam.com",
                            name = "Alexya Oliveira",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 25,
                            editionInternid = 1,
                            email = "yanni.partichelli@dellteam.com",
                            name = "Yanni Partichelli",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 26,
                            editionInternid = 1,
                            email = "gabrielle.rodrigues@dellteam.com",
                            name = "Gabrielle Rodrigues",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 27,
                            editionInternid = 1,
                            email = "larissa.rosa@dellteam.com",
                            name = "Larissa Rosa",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 28,
                            editionInternid = 1,
                            email = "renata.rosa@dellteam.com",
                            name = "Renata Rosa",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 29,
                            editionInternid = 1,
                            email = "jordana.santos@dellteam.com",
                            name = "Jordana Santos",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 30,
                            editionInternid = 1,
                            email = "adriana.serpa@dellteam.com",
                            name = "Adriana Serpa",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 31,
                            editionInternid = 1,
                            email = "gabriela.machado@dellteam.com",
                            name = "Gabriela Machado",
                            notes = "N/A",
                            role = 1
                        },
                        new
                        {
                            id = 32,
                            editionInternid = 1,
                            email = "leandra.torbes@dellteam.com",
                            name = "Leandra Torbes",
                            notes = "N/A",
                            role = 1
                        });
                });

            modelBuilder.Entity("ConnectDellBack.Models.EditionModel", b =>
                {
                    b.HasOne("ConnectDellBack.Models.ProgramModel", "program")
                        .WithMany("editions")
                        .HasForeignKey("programid");

                    b.Navigation("program");
                });

            modelBuilder.Entity("ConnectDellBack.Models.ImageModel", b =>
                {
                    b.HasOne("ConnectDellBack.Models.NewsModel", "news")
                        .WithOne("image")
                        .HasForeignKey("ConnectDellBack.Models.ImageModel", "imageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("news");
                });

            modelBuilder.Entity("ConnectDellBack.Models.MembershipModel", b =>
                {
                    b.HasOne("ConnectDellBack.Models.EditionModel", "edition")
                        .WithMany("memberships")
                        .HasForeignKey("editionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConnectDellBack.Models.UserModel", "member")
                        .WithMany("memberships")
                        .HasForeignKey("memberid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("edition");

                    b.Navigation("member");
                });

            modelBuilder.Entity("ConnectDellBack.Models.NewsModel", b =>
                {
                    b.HasOne("ConnectDellBack.Models.UserModel", "author")
                        .WithMany("listNews")
                        .HasForeignKey("authorid");

                    b.HasOne("ConnectDellBack.Models.ProgramModel", "program")
                        .WithMany("news")
                        .HasForeignKey("programid");

                    b.Navigation("author");

                    b.Navigation("program");
                });

            modelBuilder.Entity("ConnectDellBack.Models.OwnershipModel", b =>
                {
                    b.HasOne("ConnectDellBack.Models.UserModel", "owner")
                        .WithMany("ownerships")
                        .HasForeignKey("ownerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConnectDellBack.Models.ProgramModel", "program")
                        .WithMany("ownerships")
                        .HasForeignKey("programid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");

                    b.Navigation("program");
                });

            modelBuilder.Entity("ConnectDellBack.Models.PhasesModel", b =>
                {
                    b.HasOne("ConnectDellBack.Models.EditionModel", "edition")
                        .WithMany("phases")
                        .HasForeignKey("editionid");

                    b.Navigation("edition");
                });

            modelBuilder.Entity("ConnectDellBack.Models.UserModel", b =>
                {
                    b.HasOne("ConnectDellBack.Models.EditionModel", "editionIntern")
                        .WithMany("interns")
                        .HasForeignKey("editionInternid");

                    b.Navigation("editionIntern");
                });

            modelBuilder.Entity("ConnectDellBack.Models.EditionModel", b =>
                {
                    b.Navigation("interns");

                    b.Navigation("memberships");

                    b.Navigation("phases");
                });

            modelBuilder.Entity("ConnectDellBack.Models.NewsModel", b =>
                {
                    b.Navigation("image");
                });

            modelBuilder.Entity("ConnectDellBack.Models.ProgramModel", b =>
                {
                    b.Navigation("editions");

                    b.Navigation("news");

                    b.Navigation("ownerships");
                });

            modelBuilder.Entity("ConnectDellBack.Models.UserModel", b =>
                {
                    b.Navigation("listNews");

                    b.Navigation("memberships");

                    b.Navigation("ownerships");
                });
#pragma warning restore 612, 618
        }
    }
}
