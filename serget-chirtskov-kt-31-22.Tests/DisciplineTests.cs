using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ChirtskovSergeyKt_31_22.Models;

namespace serget_chirtskov_kt_31_22.Tests
{
    public class DisciplineTests
    {
        [Fact]
        public void IsValidDisciplineName_generate_True()
        {
            TestDataGenerator _generator = new TestDataGenerator();
            var discipline = _generator.DisciplineFaker.Generate();

            Assert.True(discipline.IsValidDisciplineName());
        }
        [Fact]
        public void IsValidDisciplineName_generate_False()
        {
            var discipline = new Discipline
            {
                DisciplinesName = null
            };

            Assert.False(discipline.IsValidDisciplineName());
        }
        [Fact]
        public void IsValidDisciplineName_generate_True2()
        {
            var discipline = new Discipline
            {
                DisciplinesName = "q"
            };

            Assert.False(discipline.IsValidDisciplineName());
        }
    }
}
