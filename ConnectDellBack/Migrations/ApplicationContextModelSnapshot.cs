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
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConnectDellBack.Models.EditionModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("curriculum")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("endDate")
                        .IsRequired()
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

                    b.Property<int>("programid")
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
                            curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js entre outros",
                            description = "First edition of the IT Academy program focused solely on the self-titled female audience",
                            endDate = new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            mode = 1,
                            name = "IT Academy 17",
                            numberOfInterns = 21,
                            numberOfMembers = 25,
                            programid = 1,
                            startDate = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
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
                            memberid = 2
                        },
                        new
                        {
                            editionid = 1,
                            memberid = 3
                        },
                        new
                        {
                            editionid = 1,
                            memberid = 4
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
                        });
                });

            modelBuilder.Entity("ConnectDellBack.Models.NewsModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("NewsModelid")
                        .HasColumnType("int");

                    b.Property<int>("authorid")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("programid")
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

                    b.HasIndex("NewsModelid");

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
                        });
                });

            modelBuilder.Entity("ConnectDellBack.Models.PhasesModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("editionid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("peopleInvolved")
                        .IsRequired()
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
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

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
                            startDate = new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("notes")
                        .IsRequired()
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
                            name = "Tassia",
                            notes = "N/A",
                            role = 0
                        },
                        new
                        {
                            id = 2,
                            email = "nelson.muller@dell.com",
                            name = "Nelson",
                            notes = "N/A",
                            role = 2
                        },
                        new
                        {
                            id = 3,
                            email = "marcelo.soares@dell.com",
                            name = "Marcelo",
                            notes = "N/A",
                            role = 2
                        },
                        new
                        {
                            id = 4,
                            email = "norton.zamboni@dellteam.com",
                            name = "Norton",
                            notes = "N/A",
                            role = 3
                        },
                        new
                        {
                            id = 5,
                            email = "daniel.callegari@dell.com",
                            name = "Daniel",
                            notes = "N/A",
                            role = 4
                        },
                        new
                        {
                            id = 6,
                            email = "edson.moreno@dell.com",
                            name = "Edson",
                            notes = "N/A",
                            role = 4
                        },
                        new
                        {
                            id = 7,
                            email = "tuani.alves@edupucrs.com",
                            name = "Tuani",
                            notes = "N/A",
                            role = 4
                        },
                        new
                        {
                            id = 8,
                            email = "natalya.goelzer@edu.pucrs.br",
                            name = "Natalya",
                            notes = "N/A",
                            role = 4
                        },
                        new
                        {
                            id = 9,
                            editionInternid = 1,
                            email = "alexya.oliveira@dellteam.com",
                            name = "Alexya",
                            notes = "Wish we had more Vue.js lessons, due to this we had difficulties doing our integration project. But the team is awesome and we managed to overcome this difficulty together",
                            role = 1
                        },
                        new
                        {
                            id = 10,
                            editionInternid = 1,
                            email = "juliana.maulzolfsantos@dellteam.com",
                            name = "Juliana",
                            notes = "Entity framework is difficult to understand and integrating the DB via code is still complicated to me",
                            role = 1
                        },
                        new
                        {
                            id = 11,
                            editionInternid = 1,
                            email = " yolanda.colombo@dellteam.com",
                            name = "Yolanda",
                            notes = "I need to learn Vue.js.",
                            role = 1
                        },
                        new
                        {
                            id = 12,
                            editionInternid = 1,
                            email = "gabrielle.rodrigues@dellteam.com",
                            name = "Gabrielle",
                            notes = "Entity framework is very difficult and I need more Vue.js lessons",
                            role = 1
                        },
                        new
                        {
                            id = 13,
                            editionInternid = 1,
                            email = "heloisa.lopesfarias@dellteam.com",
                            name = "Heloisa",
                            notes = "I learned a lot about C# and Dotnet, but need to learn more about Vue.js.",
                            role = 1
                        },
                        new
                        {
                            id = 14,
                            editionInternid = 1,
                            email = "adriana.serpa@dellteam.com",
                            name = "Adriana",
                            notes = "I need to review the Entity framework lessons and study Vue.Js",
                            role = 1
                        },
                        new
                        {
                            id = 15,
                            editionInternid = 1,
                            email = "larissa.rosa@dellteam.com",
                            name = "Larissa",
                            notes = "I like Entity Framework but need to review Vue.js",
                            role = 1
                        });
                });

            modelBuilder.Entity("ConnectDellBack.Models.EditionModel", b =>
                {
                    b.HasOne("ConnectDellBack.Models.ProgramModel", "program")
                        .WithMany("editions")
                        .HasForeignKey("programid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                    b.HasOne("ConnectDellBack.Models.NewsModel", null)
                        .WithMany("news")
                        .HasForeignKey("NewsModelid");

                    b.HasOne("ConnectDellBack.Models.UserModel", "author")
                        .WithMany("listNews")
                        .HasForeignKey("authorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConnectDellBack.Models.ProgramModel", "program")
                        .WithMany("news")
                        .HasForeignKey("programid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("editionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.Navigation("news");
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
