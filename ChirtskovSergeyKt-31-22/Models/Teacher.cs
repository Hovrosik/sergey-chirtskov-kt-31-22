namespace ChirtskovSergeyKt_31_22.Models
{
	public class Teacher
	{
		public int TeacherId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public int DegreeId { get; set; }
		public Degree Degree { get; set; }
		public int JobTitleId { get; set; }
		public JobTitle JobTitle { get; set; }
		public int DepartmentId { get; set; }
		public Department Department { get; set; }
		public bool isDeleted { get; set; } = false;
		public ICollection<Class> Classes { get; set; }
	}
}
