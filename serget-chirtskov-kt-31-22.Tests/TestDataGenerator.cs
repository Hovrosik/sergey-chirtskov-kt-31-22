using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using ChirtskovSergeyKt_31_22.Models;

namespace serget_chirtskov_kt_31_22.Tests
{
    public class TestDataGenerator
    {
        public Faker<Degree> DegreeFaker => new Faker<Degree>()
            .RuleFor(d => d.DegreeId, f => f.IndexFaker + 1)
            .RuleFor(d => d.DegreeName, f => f.Name.JobTitle());

        public Faker<JobTitle> JobTitleFaker => new Faker<JobTitle>()
            .RuleFor(j => j.JobTitleId, f => f.IndexFaker + 1)
            .RuleFor(j => j.JobTitleName, f => f.Name.JobType());

        public Faker<Department> DepartmentFaker => new Faker<Department>()
            .RuleFor(d => d.DepartmentId, f => f.IndexFaker + 1)
            .RuleFor(d => d.DepartmentName, f => f.Commerce.Department())
            .RuleFor(d => d.isDeleted, f => false)
            .RuleFor(d => d.Teachers, f => new List<Teacher>());

        public string[] SubjectTitles = new[]
        {
            "Математический анализ",
            "Физика",
            "История",
            "Программирование",
            "Базы данных",
            "Алгоритмы",
            "Философия",
            "Экономика"
        };

        public Faker<Discipline> DisciplineFaker => new Faker<Discipline>()
            .RuleFor(d => d.DisciplinesId, f => f.IndexFaker + 1)
            .RuleFor(d => d.DisciplinesName, f => f.PickRandom(SubjectTitles))
            .RuleFor(d => d.classes, f => new List<Class>());

        public Faker<Teacher> TeacherFaker => new Faker<Teacher>()
            .RuleFor(t => t.TeacherId, f => f.IndexFaker + 1)
            .RuleFor(t => t.FirstName, f => f.Name.FirstName())
            .RuleFor(t => t.LastName, f => f.Name.LastName())
            .RuleFor(t => t.MiddleName, f => f.Name.FirstName())
            .RuleFor(t => t.DegreeId, f => 1)
            .RuleFor(t => t.JobTitleId, f => 1)
            .RuleFor(t => t.DepartmentId, f => 1)
            .RuleFor(t => t.isDeleted, f => false)
            .RuleFor(t => t.Classes, f => new List<Class>())
            .RuleFor(t => t.Degree, _ => DegreeFaker.Generate())
            .RuleFor(t => t.JobTitle, _ => JobTitleFaker.Generate())
            .RuleFor(t => t.Department, _ => DepartmentFaker.Generate());

        public Faker<Class> ClassFaker => new Faker<Class>()
            .RuleFor(c => c.ClassId, f => f.IndexFaker + 1)
            .RuleFor(c => c.TeacherId, f => 1)
            .RuleFor(c => c.DisciplineId, f => 1)
            .RuleFor(c => c.Hours, f => f.Random.Int(200, 400))
            .RuleFor(c => c.Teacher, _ => TeacherFaker.Generate())
            .RuleFor(c => c.Discipline, _ => DisciplineFaker.Generate());
    }

}
