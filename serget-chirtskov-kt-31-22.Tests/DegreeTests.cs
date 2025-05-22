using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChirtskovSergeyKt_31_22.Models;

namespace serget_chirtskov_kt_31_22.Tests
{
    public class DegreeTests
    {
        [Fact]
        public void IsValidDegreeName_generate_True()
        {
            TestDataGenerator _generator = new TestDataGenerator();
            var degree = _generator.DegreeFaker.Generate();

            Assert.True(degree.IsValidDegreeName());
        }

        [Fact]
        public void IsValidDegreeName_generate_False()
        {
            TestDataGenerator _generator = new TestDataGenerator();
            var degree = new Degree
            {
                DegreeName = null
            };
            Assert.False(degree.IsValidDegreeName());
        }
        [Fact]
        public void IsValidDegreeName_generate_False2()
        {
            var degree = new Degree
            {
                DegreeName = "@!Кандидат наук@#123"
            };

            Assert.False(degree.IsValidDegreeName());
        }
        [Fact]
        public void IsValidDegreeName_generate_False3()
        {
            var degree = new Degree
            {
                DegreeName = "Ю"
            };

            Assert.False(degree.IsValidDegreeName());
        }
    }
}
