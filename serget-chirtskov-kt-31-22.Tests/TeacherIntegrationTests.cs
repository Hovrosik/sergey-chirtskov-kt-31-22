using ChirtskovSergeyKt_31_22.Database;
using ChirtskovSergeyKt_31_22.Filters.TeacherFilters;
using ChirtskovSergeyKt_31_22.Interfaces.TeacherInterfaces;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace serget_chirtskov_kt_31_22.Tests
{ 
    public class TeacherIntegrationTests
    {
        public readonly DbContextOptions<TeacherDbContext> _dbContextOptions;

        public TeacherIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<TeacherDbContext>()
            .UseInMemoryDatabase(databaseName: "teacher_db")
            .Options;
        }

        [Fact]
        public async Task GetTeachersAsync_IVT_TwoObjects()
        {
            // Arrange
            var ctx = new TeacherDbContext(_dbContextOptions);
            var teacherService = new TeacherService(ctx);
            var departments = new List<Department>
            {
                new Department { DepartmentName = "ИВТ" },
                new Department { DepartmentName = "Математика" }
            };

            await ctx.Set<Department>().AddRangeAsync(departments);
            await ctx.SaveChangesAsync();

            var degrees = new List<Degree>
            {
                new Degree { DegreeName = "Кандидат наук" }
            };
            var jobTitles = new List<JobTitle>
            {
                new JobTitle { JobTitleName = "Профессор" }
            };

            await ctx.Set<Degree>().AddRangeAsync(degrees);
            await ctx.Set<JobTitle>().AddRangeAsync(jobTitles);
            await ctx.SaveChangesAsync();

            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    FirstName = "Иванов",
                    LastName = "Иван",
                    MiddleName = "Иванович",
                    DepartmentId = departments[0].DepartmentId,
                    DegreeId = degrees[0].DegreeId,
                    JobTitleId = jobTitles[0].JobTitleId
                },
                new Teacher
                {
                    FirstName = "Петров",
                    LastName = "Петр",
                    MiddleName = "Петрович",
                    DepartmentId = departments[1].DepartmentId,
                    DegreeId = degrees[0].DegreeId,
                    JobTitleId = jobTitles[0].JobTitleId
                },
                new Teacher
                {
                    FirstName = "Зайцев",
                    LastName = "Антон",
                    MiddleName = "Антонович",
                    DepartmentId = departments[0].DepartmentId,
                    DegreeId = degrees[0].DegreeId,
                    JobTitleId = jobTitles[0].JobTitleId
                }
            };
            await ctx.Set<Teacher>().AddRangeAsync(teachers);
            await ctx.SaveChangesAsync();

            // Act
            var filter = new TeacherFilter
            {
                DepartmentName = "ИВТ"
            };
            var result = await teacherService.GetTeachersAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Length);
            Assert.All(result, t => Assert.Equal("ИВТ", t.Department.DepartmentName));
        }

        [Fact]
        public async Task GetTeachersAsync_ww_ReturnsEmpty()
        {
            // Arrange
            var ctx = new TeacherDbContext(_dbContextOptions);
            var teacherService = new TeacherService(ctx);

            var department = new Department { DepartmentName = "Физический" };
            var degree = new Degree { DegreeName = "Кандидат наук" };
            var jobTitle = new JobTitle { JobTitleName = "Доцент" };

            await ctx.Set<Department>().AddRangeAsync(department);
            await ctx.Set<Degree>().AddRangeAsync(degree);
            await ctx.Set<JobTitle>().AddRangeAsync(jobTitle);
            await ctx.SaveChangesAsync();

            var teacher = new Teacher
            {
                FirstName = "Иванов",
                LastName = "Иван",
                MiddleName = "Иванович",
                DepartmentId = department.DepartmentId,
                DegreeId = degree.DegreeId,
                JobTitleId = jobTitle.JobTitleId
            };

            await ctx.Set<Teacher>().AddRangeAsync(teacher);
            await ctx.SaveChangesAsync();

            // Act
            var filter = new TeacherFilter
            {
                DepartmentName = "Математический"
            };
            var result = await teacherService.GetTeachersAsync(filter, CancellationToken.None);

            // Assert
            Assert.Empty(result);
        }

    }
}
