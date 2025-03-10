﻿// <auto-generated />
using ChirtskovSergeyKt_31_22.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChirtskovSergeyKt_31_22.Migrations
{
    [DbContext(typeof(TeacherDbContext))]
    partial class TeacherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChirtskovSergeyKt_31_22.Models.Degree", b =>
                {
                    b.Property<int>("DegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("degree_id")
                        .HasComment("Идентификатор ученой степени");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DegreeId"));

                    b.Property<string>("DegreeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_degree_degreename")
                        .HasComment("Наименование ученой степени");

                    b.HasKey("DegreeId")
                        .HasName("pk_cd_degree_degree_id");

                    b.ToTable("Degree");
                });

            modelBuilder.Entity("ChirtskovSergeyKt_31_22.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("department_id")
                        .HasComment("Идентификатор записи кафедры");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_department_name")
                        .HasComment("Наименование кафедры");

                    b.Property<int>("HeadTeacherId")
                        .HasColumnType("int4")
                        .HasColumnName("c_teacher_headteacherid");

                    b.HasKey("DepartmentId")
                        .HasName("pk_cd_department_department_id");

                    b.HasIndex(new[] { "HeadTeacherId" }, "idx_cd_department_fk_f_headteacher_id");

                    b.ToTable("cd_department", (string)null);
                });

            modelBuilder.Entity("ChirtskovSergeyKt_31_22.Models.Disciplines", b =>
                {
                    b.Property<int>("DisciplinesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("disciplines_id")
                        .HasComment("Идентификатор записи дисциплины");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DisciplinesId"));

                    b.Property<string>("DisciplinesName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_disciplinesname")
                        .HasComment("Наименование дисциплины");

                    b.HasKey("DisciplinesId")
                        .HasName("pk_cd_disciplines_disciplines_id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("ChirtskovSergeyKt_31_22.Models.JobTitle", b =>
                {
                    b.Property<int>("JobTitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("jobtitle_id")
                        .HasComment("Идентификатор записи должности");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JobTitleId"));

                    b.Property<string>("JobTitleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_jobtitlename")
                        .HasComment("Наименование должности");

                    b.HasKey("JobTitleId")
                        .HasName("pk_cd_jobtitle_jobtitle_id");

                    b.ToTable("JobTitle");
                });

            modelBuilder.Entity("ChirtskovSergeyKt_31_22.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("teacher_id")
                        .HasComment("Идентификатор записи преподавателя");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TeacherId"));

                    b.Property<int>("DegreeId")
                        .HasColumnType("int4")
                        .HasColumnName("c_teacher_degreeid");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int4")
                        .HasColumnName("c_teacher_departmentid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_firstname")
                        .HasComment("Имя преподавателя");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int4")
                        .HasColumnName("c_teacher_jobtitleid");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_lastname")
                        .HasComment("Фамилия преподавателя");

                    b.Property<int>("LoadHours")
                        .HasColumnType("integer");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_middlename")
                        .HasComment("Отчество преподавателя");

                    b.HasKey("TeacherId")
                        .HasName("pk_cd_teacher_teacher_id");

                    b.HasIndex(new[] { "DegreeId" }, "idx_cd_teacher_fk_f_degree_id");

                    b.HasIndex(new[] { "DepartmentId" }, "idx_cd_teacher_fk_f_department_id");

                    b.HasIndex(new[] { "JobTitleId" }, "idx_cd_teacher_fk_f_jobtitle_id");

                    b.ToTable("cd_teacher", (string)null);
                });

            modelBuilder.Entity("ChirtskovSergeyKt_31_22.Models.Department", b =>
                {
                    b.HasOne("ChirtskovSergeyKt_31_22.Models.Teacher", "HeadTeacher")
                        .WithMany()
                        .HasForeignKey("HeadTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_headteacher_id");

                    b.Navigation("HeadTeacher");
                });

            modelBuilder.Entity("ChirtskovSergeyKt_31_22.Models.Teacher", b =>
                {
                    b.HasOne("ChirtskovSergeyKt_31_22.Models.Degree", "Degree")
                        .WithMany()
                        .HasForeignKey("DegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_degree_id");

                    b.HasOne("ChirtskovSergeyKt_31_22.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_department_id");

                    b.HasOne("ChirtskovSergeyKt_31_22.Models.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_jobtitle_id");

                    b.Navigation("Degree");

                    b.Navigation("Department");

                    b.Navigation("JobTitle");
                });
#pragma warning restore 612, 618
        }
    }
}
