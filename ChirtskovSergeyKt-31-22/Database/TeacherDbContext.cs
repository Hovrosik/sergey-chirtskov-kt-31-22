using ChirtskovSergeyKt_31_22.Database.Configurations;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace ChirtskovSergeyKt_31_22.Database
{
	public class TeacherDbContext : DbContext
	{
		// Добавляем таблицы
		public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Degree> Degree { get; set; }
        public DbSet<Discipline> Discipline { get; set; }
		public DbSet<JobTitle> JobTitle { get; set; }
        public DbSet<JobTitle> Class { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Добавляем конфигурации к таблицам
			modelBuilder.ApplyConfiguration(new TeacherConfiguration());
			modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
			modelBuilder.ApplyConfiguration(new DegreeConfiguration());
			modelBuilder.ApplyConfiguration(new DisciplinesConfiguration());
			modelBuilder.ApplyConfiguration(new JobTitleConfiguration());
            modelBuilder.ApplyConfiguration(new ClassConfiguration());

            modelBuilder.Entity<Department>().HasQueryFilter(d => !d.isDeleted);
            modelBuilder.Entity<Teacher>().HasQueryFilter(t => !t.isDeleted);
        }

		public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
		{
			
		}
	}
}
