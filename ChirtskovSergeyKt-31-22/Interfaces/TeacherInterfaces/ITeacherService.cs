using ChirtskovSergeyKt_31_22.Database;
using ChirtskovSergeyKt_31_22.Filters.TeacherFilters;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var teachers = _dbContext.Set<Teacher>()
                .Include(t => t.Department)
                .Include(t => t.Degree)
                .Include(t => t.JobTitle)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.DepartmentName))
            {
                teachers = teachers.Where(w => w.Department.DepartmentName == filter.DepartmentName);
            }

            if (!string.IsNullOrEmpty(filter.DegreeName))
            {
                teachers = teachers.Where(w => w.Degree.DegreeName == filter.DegreeName);
            }

            if (!string.IsNullOrEmpty(filter.JobTitleName))
            {
                teachers = teachers.Where(w => w.JobTitle.JobTitleName == filter.JobTitleName);
            }

            return teachers.ToArrayAsync(cancellationToken);
        }
    }
}
