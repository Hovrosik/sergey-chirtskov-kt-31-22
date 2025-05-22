using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChirtskovSergeyKt_31_22.Models;

namespace serget_chirtskov_kt_31_22.Tests
{
    public class JobTitleTests
    {
        [Fact]

        public void IsValidJobTitleName_generate_True()
        {
            TestDataGenerator _generator = new TestDataGenerator();
            var jobTitle = _generator.JobTitleFaker.Generate();

            Assert.True(jobTitle.IsValidJobTitleName());
        }

        [Fact]
        public void IsValidJobTitleName_generate_False()
        {
            var jobTitle = new JobTitle
            {
                JobTitleName = null
            };
            Assert.False(jobTitle.IsValidJobTitleName());
        }
        [Fact]
        public void IsValidJobTitleName_generate_False2()
        {
            var jobTitle = new JobTitle
            {
                JobTitleName = "@!$Доцент@#123"
            };

            Assert.False(jobTitle.IsValidJobTitleName());
        }
        [Fact]
        public void IsValidJobTitleName_generate_False3()
        {
            var jobTitle = new JobTitle
            {
                JobTitleName = "Ю"
            };

            Assert.False(jobTitle.IsValidJobTitleName());
        }
    }
}
