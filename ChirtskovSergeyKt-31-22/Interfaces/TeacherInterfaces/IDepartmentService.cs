using ChirtskovSergeyKt_31_22.Database;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace ChirtskovSergeyKt_31_22.Interfaces.TeacherInterfaces
{
    public interface IDepartmentService
    {
        Task<Department> CreateAsync(Department department, CancellationToken cancellationToken = default);
        Task<Department?> UpdateDepartmentNameAsync(int id, string newName, CancellationToken cancellationToken = default);
        Task<bool> DeleteDepartmentAsync(int id, CancellationToken cancellationToken = default);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly TeacherDbContext _dbContext;

        public DepartmentService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> CreateAsync(Department department, CancellationToken cancellationToken = default)
        {
            _dbContext.Department.Add(department);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return department;
        }

        public async Task<Department?> UpdateDepartmentNameAsync(int id, string newName, CancellationToken cancellationToken = default)
        {
            var department = await _dbContext.Department.FindAsync(new object[] { id }, cancellationToken);

            if (department == null || department.isDeleted)
                return null;

            department.DepartmentName = newName;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return department;
        }


        public async Task<bool> DeleteDepartmentAsync(int id, CancellationToken cancellationToken = default)
        {
            var department = await _dbContext.Department
                .Include(d => d.Teachers)
                .FirstOrDefaultAsync(d => d.DepartmentId == id, cancellationToken);

            if (department == null || department.isDeleted)
                return false;

            department.isDeleted = true;

            foreach (var teacher in department.Teachers)
            {
                teacher.isDeleted = true;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
