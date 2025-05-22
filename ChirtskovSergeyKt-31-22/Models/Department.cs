using System.Text.RegularExpressions;

namespace ChirtskovSergeyKt_31_22.Models
{
	public class Department
	{
		public int DepartmentId { get; set; }
		public string DepartmentName { get; set; }
        public bool isDeleted { get; set; } = false;
        public ICollection<Teacher> Teachers { get; set; }

		public bool IsValidDepartmentName()
        {
            return !string.IsNullOrWhiteSpace(DepartmentName)
                   && Regex.IsMatch(DepartmentName, @"^[А-Яа-яA-Za-z\s\-]{3,100}$");
        }
        public void AddTeacher(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            if (Teachers.Any(t => t.TeacherId == teacher.TeacherId))
                throw new InvalidOperationException("Преподаватель уже добавлен.");

            teacher.DepartmentId = this.DepartmentId;
            Teachers.Add(teacher);
        }
        public IEnumerable<Teacher> GetActiveTeachers()
        {
            return Teachers.Where(t => !t.isDeleted);
        }
        public void SoftDelete()
        {
            this.isDeleted = true;
        }
    }
}