﻿// <auto-generated />
using System;
using LecturalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LecturalAPI.Migrations
{
    [DbContext(typeof(AppdbContext))]
    partial class AppdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LecturalAPI.Models.CadetDB", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birthDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateOfStartService")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("idGrup")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isMarried")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("militaryRank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pathPhotoBig")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pathPhotoSmall")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cadet");
                });

            modelBuilder.Entity("LecturalAPI.Models.DisciplineDB", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("countCourseWorkours")
                        .HasColumnType("int");

                    b.Property<int>("countCourseWorksHours")
                        .HasColumnType("int");

                    b.Property<int>("countGroupsHours")
                        .HasColumnType("int");

                    b.Property<int>("countHours")
                        .HasColumnType("int");

                    b.Property<int>("countLecturalThreads")
                        .HasColumnType("int");

                    b.Property<int>("countLectureHours")
                        .HasColumnType("int");

                    b.Property<int>("countMetodicalHours")
                        .HasColumnType("int");

                    b.Property<int>("countNorm")
                        .HasColumnType("int");

                    b.Property<int>("countPracticalHours")
                        .HasColumnType("int");

                    b.Property<int>("countPracticalThreads")
                        .HasColumnType("int");

                    b.Property<int>("countSelfWorkHours")
                        .HasColumnType("int");

                    b.Property<int>("countSeminarsHours")
                        .HasColumnType("int");

                    b.Property<int>("countTacticalHours")
                        .HasColumnType("int");

                    b.Property<int>("countTestHours")
                        .HasColumnType("int");

                    b.Property<int>("countTestWithScoreHours")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateOfPlan")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("idLectural")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idProfession")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idSpecialization")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isExam")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Discipline");
                });

            modelBuilder.Entity("LecturalAPI.Models.GroupDB", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountCadets")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProfessionDBid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SpecializationDBid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numberOfGroup")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ProfessionDBid");

                    b.HasIndex("SpecializationDBid");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("LecturalAPI.Models.Lectural", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("academicDegree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("academicTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birthDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("countOfChildren")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateOfStartService")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isMarried")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("militaryRank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pathPhotoBig")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pathPhotoSmall")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Lectural");
                });

            modelBuilder.Entity("LecturalAPI.Models.LessonTypeDB", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameOfType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("LessonType");
                });

            modelBuilder.Entity("LecturalAPI.Models.dataBaseModel.LessonDB", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("countHours")
                        .HasColumnType("int");

                    b.Property<Guid>("idDiciplines")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idLectural")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idLessonType")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numberOfDiciplines")
                        .HasColumnType("int");

                    b.Property<string>("sectionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("themeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("LecturalAPI.Models.dataBaseModel.ProfessionDB", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameOfProffession")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("proffesionCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Profession");
                });

            modelBuilder.Entity("LecturalAPI.Models.dataBaseModel.SpecializationDB", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SpecializationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameOfSpecialization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("LecturalAPI.Models.GroupDB", b =>
                {
                    b.HasOne("LecturalAPI.Models.dataBaseModel.ProfessionDB", "ProfessionDB")
                        .WithMany("GroupDB")
                        .HasForeignKey("ProfessionDBid");

                    b.HasOne("LecturalAPI.Models.dataBaseModel.SpecializationDB", "SpecializationDB")
                        .WithMany("GroupDB")
                        .HasForeignKey("SpecializationDBid");
                });
#pragma warning restore 612, 618
        }
    }
}
