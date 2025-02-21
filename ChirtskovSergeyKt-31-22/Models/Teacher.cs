namespace ChirtskovSergeyKt_31_22.Models
{
	public class Teacher
	{
		public int TeacherId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public int DepartmentId { get; set; }
		public Department Department { get; set; }
		public string Degree { get; set; }
		public string JobTitle { get; set; }
	}
}
