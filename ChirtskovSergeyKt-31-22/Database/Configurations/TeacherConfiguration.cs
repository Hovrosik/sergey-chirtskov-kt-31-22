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

            builder.Property(p => p.DepartmentId)
                .IsRequired()
                .HasColumnName("c_teacher_departmentid")
                .HasColumnType(ColumnType.Int);

            builder.Property(p => p.)
        }
    }
}
