using ChirtskovSergeyKt_31_22.Database.Helpers;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChirtskovSergeyKt_31_22.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        // Название таблицы, которое будет отображаться в БД
        private const string TableName = "cd_teacher";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // Задаем первичный ключ
            builder
                .HasKey(p => p.TeacherId)
                .HasName($"pk_{TableName}_teacher_id");

            // Для целочисленного первичного ключа задаем автогеренацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.TeacherId)
                .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.TeacherId)
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор записи преподавателя");

            // HasComment добавит комментарий, который будет отображаться в СУБД (по желанию)
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_teacher_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_teacher_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("c_teacher_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество преподавателя");

			builder.Property(p => p.DegreeId)
			   .IsRequired()
			   .HasColumnName("c_teacher_degreeid")
			   .HasColumnType(ColumnType.Int);

			builder.ToTable(TableName)
				.HasOne(p => p.Degree)
				.WithMany()
				.HasForeignKey(p => p.DegreeId)
				.HasConstraintName("fk_f_degree_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.ToTable(TableName)
				.HasIndex(p => p.DegreeId, $"idx_{TableName}_fk_f_degree_id");

			builder.Property(p => p.JobTitleId)
			   .IsRequired()
			   .HasColumnName("c_teacher_jobtitleid")
			   .HasColumnType(ColumnType.Int);

			builder.ToTable(TableName)
				.HasOne(p => p.JobTitle)
				.WithMany()
				.HasForeignKey(p => p.JobTitleId)
				.HasConstraintName("fk_f_jobtitle_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.ToTable(TableName)
				.HasIndex(p => p.JobTitleId, $"idx_{TableName}_fk_f_jobtitle_id");

			builder.Property(p => p.DepartmentId)
                .IsRequired()
                .HasColumnName("c_teacher_departmentid")
                .HasColumnType(ColumnType.Int);

            builder.ToTable(TableName)
                .HasOne(p => p.Department)
                .WithMany()
                .HasForeignKey(p => p.DepartmentId)
                .HasConstraintName("fk_f_department_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.DepartmentId, $"idx_{TableName}_fk_f_department_id");

            // Добавим явную автоподгрузку связанной сущности
            builder.Navigation(p => p.Department)
                .AutoInclude();
            builder.Navigation(p => p.Degree)
                .AutoInclude();
			builder.Navigation(p => p.JobTitle)
				.AutoInclude();
		}
    }
}
