using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ChirtskovSergeyKt_31_22.Models;

namespace serget_chirtskov_kt_31_22.Tests
{
    public class DepartmentTests
    {
        [Fact]
        public void AddTeacher_generate_TeacherAppearsInCollection()
        {
            TestDataGenerator _generator = new TestDataGenerator();
            var department = _generator.DepartmentFaker.Generate();
            var teacher = _generator.TeacherFaker.Generate();
            teacher.TeacherId = 55;

            department.AddTeacher(teacher);

            Assert.Contains(teacher, department.Teachers);
        }
        [Fact]
        public void GetActiveTeachers_generate_ReturnsOnlyNotDeleted()
        {
            TestDataGenerator _generator = new TestDataGenerator();
            var department = _generator.DepartmentFaker.Generate();
            var activeTeachers = department.GetActiveTeachers().ToList();

            Assert.All(activeTeachers, t => Assert.False(t.isDeleted));
        }

        [Fact]
        public void IsValidDepartmentName_generate_False()
        {
            var department = new Department { DepartmentName = "A" };

            Assert.False(department.IsValidDepartmentName());
        }

        [Fact]
        public void SoftDelete_SetsIsDeletedToTrue()
        {
            TestDataGenerator _generator = new TestDataGenerator();
            var department = _generator.DepartmentFaker.Generate();

            department.SoftDelete();

            Assert.True(department.isDeleted);
        }
    }
}
