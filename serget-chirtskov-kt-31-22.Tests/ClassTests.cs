using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ChirtskovSergeyKt_31_22.Models;

namespace serget_chirtskov_kt_31_22.Tests
{
    public class ClassTests
    {
        [Fact]
        public void IsValidHours_generate_True()
        {
            TestDataGenerator _generator = new TestDataGenerator();
            var lesson = _generator.ClassFaker.Generate();

            Assert.True(lesson.IsValidHours());
        }

        [Fact]
        public void IsValidHours_generate_False()
        {
            var lesson = new Class
            {
                Hours = 1000
            };

            Assert.False(lesson.IsValidHours());
        }
    }
}
