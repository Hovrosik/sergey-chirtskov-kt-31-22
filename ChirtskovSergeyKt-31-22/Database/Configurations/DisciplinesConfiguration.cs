using ChirtskovSergeyKt_31_22.Database.Helpers;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChirtskovSergeyKt_31_22.Database.Configurations
{
	public class DisciplinesConfiguration : IEntityTypeConfiguration<Disciplines>
	{
		// Название таблицы, которое будет отображаться в БД
		private const string TableName = "cd_disciplines";
		public void Configure(EntityTypeBuilder<Disciplines> builder)
		{
			// Задаем первичный ключ
			builder
				.HasKey(p => p.DisciplinesId)
				.HasName($"pk_{TableName}_disciplines_id");

			// Для целочисленного первичного ключа задаем автогеренацию (к каждой новой записи будет добавлять +1)
			builder.Property(p => p.DisciplinesId)
				.ValueGeneratedOnAdd();

			//Расписываем как будут называться колонки в БД, а так же их обязательность и тд
			builder.Property(p => p.DisciplinesId)
				.HasColumnName("disciplines_id")
				.HasComment("Идентификатор записи дисциплины");

			// HasComment добавит комментарий, который будет отображаться в СУБД (по желанию)
			builder.Property(p => p.DisciplinesName)
				.IsRequired()
				.HasColumnName("c_teacher_disciplinesname")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Наименование дисциплины");
		}
	}
}
