using Bogus;
using ChirtskovSergeyKt_31_22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace serget_chirtskov_kt_31_22.Tests
{
    public class TeacherTests
    {
   
        [Fact]
        public void GetFullName_generate_True()
        {
            TestDataGenerator _generator = new TestDataGenerator();

            var teacher = _generator.TeacherFaker.Generate();
           
            //act
            var result = $"{teacher.LastName} {teacher.FirstName} {teacher.MiddleName}".Trim();

            //asscert
            Assert.Equal(result, teacher.GetFullName());
        }

        [Fact]
        public void GetTotalHours_generate_SumOfHours()
        {
            TestDataGenerator _generator = new TestDataGenerator();
            var classes = new List<Class>
            {
                new Class { Hours = 200 },
                new Class { Hours = 300 }
            };

            var teacher = _generator.TeacherFaker.Generate();
            teacher.Classes = classes;

            //asscert
            Assert.Equal(500, teacher.GetTotalHours());
        }

        [Fact]
        public void IsTotalHoursWithinLimit_generate_True()
        {
            TestDataGenerator _generator = new TestDataGenerator();
            var teacher = _generator.TeacherFaker.Generate();
            teacher.Classes = _generator.ClassFaker.Generate(3);

            Assert.True(teacher.IsTotalHoursWithinLimit());
        }

        [Fact]
        public void IsTotalHoursWithinLimit_generate_False()
        {
            TestDataGenerator _generator = new TestDataGenerator();
            var teacher = _generator.TeacherFaker.Generate();
            teacher.Classes = new List<Class>
            {
                new Class { Hours = 400 },
                new Class { Hours = 400 },
                new Class { Hours = 300 } // = 1100
            };

            Assert.False(teacher.IsTotalHoursWithinLimit());
        }

        [Fact]
        public void MarkAsDeleted_generate_True()
        {
            TestDataGenerator _generator = new TestDataGenerator();
            var teacher = _generator.TeacherFaker.Generate();

            teacher.MarkAsDeleted();

            Assert.True(teacher.isDeleted);
        }
    }
}
