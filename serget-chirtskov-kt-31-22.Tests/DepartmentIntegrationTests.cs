using ChirtskovSergeyKt_31_22.Database;
using ChirtskovSergeyKt_31_22.Interfaces.TeacherInterfaces;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serget_chirtskov_kt_31_22.Tests
{
    public class DepartmentIntegrationTests
    {
        public readonly DbContextOptions<TeacherDbContext> _dbContextOptions;

        public DepartmentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<TeacherDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        }

        [Fact]
        public async Task CreateAsync_objects_CreatedObjects()
        {
            var ctx = new TeacherDbContext(_dbContextOptions);
            var departmentService = new DepartmentService(ctx);

            var department = new Department { DepartmentName = "Информатический" };
            await departmentService.CreateAsync(department);

            var saved = await ctx.Department.FirstOrDefaultAsync();
            Assert.NotNull(saved);
            Assert.Equal("Информатический", saved.DepartmentName);
        }

        [Fact]
        public async Task UpdateDepartmentNameAsync_object_UpdatedObjects()
        {
            var ctx = new TeacherDbContext(_dbContextOptions);
            var departmentService = new DepartmentService(ctx);

            var department = new Department { DepartmentName = "Математ" };
            ctx.Department.Add(department);
            await ctx.SaveChangesAsync();

            var result = await departmentService.UpdateDepartmentNameAsync(department.DepartmentId, "Математический");

            Assert.NotNull(result);
            Assert.Equal("Математический", result.DepartmentName);
        }
    }
}
