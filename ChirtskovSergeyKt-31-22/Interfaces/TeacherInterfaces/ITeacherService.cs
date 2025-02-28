using ChirtskovSergeyKt_31_22.Database;
using ChirtskovSergeyKt_31_22.Filters.TeacherFilters;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace ChirtskovSergeyKt_31_22.Interfaces.TeacherInterfaces
{
	public interface ITeacherService
	{
		public Task<Teacher[]> GetTeachersAsync(TeacherFilter filter, CancellationToken cancellationToken);
	}

	public class TeacherService : ITeacherService
	{
		private readonly TeacherDbContext _dbContext;

		public TeacherService(TeacherDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task<Teacher[]> GetTeachersAsync(TeacherFilter filter, CancellationToken cancellationToken = default)
		{
			var teachers = _dbContext.Set<Teacher>().Where(w => w.Department.DepartmentName == filter.DepartmentName).ToArrayAsync(cancellationToken);

			return teachers;
		}
	}
}
