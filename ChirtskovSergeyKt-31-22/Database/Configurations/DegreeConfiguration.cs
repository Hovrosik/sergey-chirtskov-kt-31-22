using ChirtskovSergeyKt_31_22.Database.Helpers;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChirtskovSergeyKt_31_22.Database.Configurations
{
	public class DegreeConfiguration : IEntityTypeConfiguration<Degree>
	{
		// Название таблицы, которое будет отображаться в БД
		private const string TableName = "cd_degree";

		public void Configure(EntityTypeBuilder<Degree> builder)
		{
			// Задаем первичный ключ
			builder
				.HasKey(p => p.DegreeId)
				.HasName($"pk_{TableName}_degree_id");

			// Для целочисленного первичного ключа задаем автогеренацию (к каждой новой записи будет добавлять +1)
			builder.Property(p => p.DegreeId)
				.ValueGeneratedOnAdd();

			//Расписываем как будут называться колонки в БД, а так же их обязательность и тд
			builder.Property(p => p.DegreeId)
				.HasColumnName("degree_id")
				.HasComment("Идентификатор ученой степени");

			// HasComment добавит комментарий, который будет отображаться в СУБД (по желанию)
			builder.Property(p => p.DegreeName)
				.IsRequired()
				.HasColumnName("c_degree_degreename")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Наименование ученой степени");
		}
	}
}
