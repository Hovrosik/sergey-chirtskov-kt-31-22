using Microsoft.EntityFrameworkCore;

namespace ChirtskovSergeyKt_31_22.Database
{
	public class TeacherDbContext : DbContext
	{
		public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
		{

		}
	}
}
