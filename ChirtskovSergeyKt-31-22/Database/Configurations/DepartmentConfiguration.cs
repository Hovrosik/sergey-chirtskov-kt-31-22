using ChirtskovSergeyKt_31_22.Database.Helpers;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ChirtskovSergeyKt_31_22.Database.Configurations
{
	public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		// Название таблицы, которое будет отображаться в БД
		private const string TableName = "cd_department";
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			// Задаем первичный ключ
			builder
				.HasKey(p => p.DepartmentId)
				.HasName($"pk_{TableName}_department_id");

			// Для целочисленного первичного ключа задаем автогеренацию (к каждой новой записи будет добавлять +1)
			builder.Property(p => p.DepartmentId)
				.ValueGeneratedOnAdd();

			//Расписываем как будут называться колонки в БД, а так же их обязательность и тд
			builder.Property(p => p.DepartmentId)
				.HasColumnName("department_id")
				.HasComment("Идентификатор записи кафедры");

			// HasComment добавит комментарий, который будет отображаться в СУБД (по желанию)
			builder.Property(p => p.DepartmentName)
				.IsRequired()
				.HasColumnName("c_department_name")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Наименование кафедры");
		}
	}
}
