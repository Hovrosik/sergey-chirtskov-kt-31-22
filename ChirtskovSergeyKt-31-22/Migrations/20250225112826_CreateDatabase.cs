﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChirtskovSergeyKt_31_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    degree_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор ученой степени")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_degree_degreename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Наименование ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_degree_degree_id", x => x.degree_id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    disciplines_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_teacher_disciplinesname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Наименование дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_disciplines_disciplines_id", x => x.disciplines_id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitle",
                columns: table => new
                {
                    jobtitle_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи должности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_teacher_jobtitlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Наименование должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_jobtitle_jobtitle_id", x => x.jobtitle_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_department_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Наименование кафедры"),
                    c_teacher_headteacherid = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи преподавателя")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_teacher_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_teacher_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_teacher_middlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    c_teacher_degreeid = table.Column<int>(type: "int4", nullable: false),
                    c_teacher_jobtitleid = table.Column<int>(type: "int4", nullable: false),
                    c_teacher_departmentid = table.Column<int>(type: "int4", nullable: false),
                    LoadHours = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "fk_f_degree_id",
                        column: x => x.c_teacher_degreeid,
                        principalTable: "Degree",
                        principalColumn: "degree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_department_id",
                        column: x => x.c_teacher_departmentid,
                        principalTable: "cd_department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_jobtitle_id",
                        column: x => x.c_teacher_jobtitleid,
                        principalTable: "JobTitle",
                        principalColumn: "jobtitle_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_department_fk_f_headteacher_id",
                table: "cd_department",
                column: "c_teacher_headteacherid");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_degree_id",
                table: "cd_teacher",
                column: "c_teacher_degreeid");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_department_id",
                table: "cd_teacher",
                column: "c_teacher_departmentid");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_jobtitle_id",
                table: "cd_teacher",
                column: "c_teacher_jobtitleid");

            migrationBuilder.AddForeignKey(
                name: "fk_f_headteacher_id",
                table: "cd_department",
                column: "c_teacher_headteacherid",
                principalTable: "cd_teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_f_headteacher_id",
                table: "cd_department");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "cd_department");

            migrationBuilder.DropTable(
                name: "JobTitle");
        }
    }
}
