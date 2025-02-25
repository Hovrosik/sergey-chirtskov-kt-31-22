using ChirtskovSergeyKt_31_22.Database.Configurations;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace ChirtskovSergeyKt_31_22.Database
{
	public class TeacherDbContext : DbContext
	{
		// Добавляем таблицы
		DbSet<Teacher> Teacher { get; set; }
		DbSet<Department> Department { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Добавляем конфигурации к таблицам
			modelBuilder.ApplyConfiguration(new TeacherConfiguration());
			modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
			modelBuilder.ApplyConfiguration(new DegreeConfiguration());
			modelBuilder.ApplyConfiguration(new DisciplinesConfiguration());
			modelBuilder.ApplyConfiguration(new JobTitleConfiguration());
		}

		public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
		{
			
		}
	}
}
