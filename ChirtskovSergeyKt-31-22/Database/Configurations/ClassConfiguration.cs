using ChirtskovSergeyKt_31_22.Database.Helpers;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChirtskovSergeyKt_31_22.Database.Configurations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        private const string TableName = "cd_class";

        public void Configure(EntityTypeBuilder<Class> builder)
        {
            // Задаем первичный ключ
            builder
                .HasKey(p => p.ClassId)
                .HasName($"pk_{TableName}_class_id");

            // Для целочисленного первичного ключа задаем автогеренацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.ClassId)
                .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.ClassId)
                .HasColumnName("class_id")
                .HasComment("Идентификатор записи нагрузки");

            // HasComment добавит комментарий, который будет отображаться в СУБД (по желанию)
            builder.Property(p => p.Hours)
                .IsRequired()
                .HasColumnName("c_class_hours")
                .HasColumnType(ColumnType.Int)
                .HasComment("Количество часов");

            builder.Property(p => p.TeacherId)
            .IsRequired()
            .HasColumnName("c_class_teacherid")
            .HasColumnType(ColumnType.Int);

            builder.ToTable(TableName)
            .HasOne(p => p.Teacher)
            .WithMany(p => p.Classes)
            .HasForeignKey(p => p.TeacherId)
            .HasConstraintName("fk_f_class_teacherid")
            .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
            .HasIndex(p => p.TeacherId)
            .HasDatabaseName($"idx_{TableName}_fk_teacher_id");

            builder.Property(p => p.DisciplineId)
            .IsRequired()
            .HasColumnName("c_class_disciplineid")
            .HasColumnType(ColumnType.Int);

            builder.ToTable(TableName)
            .HasOne(p => p.Discipline)
            .WithMany(p => p.classes)
            .HasForeignKey(p => p.DisciplineId)
            .HasConstraintName("fk_f_class_disciplineid")
            .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
            .HasIndex(p => p.DisciplineId)
            .HasDatabaseName($"idx_{TableName}_fk_discipline_id");

            builder.Navigation(p => p.Discipline)
                .AutoInclude();
        }
    }
}
