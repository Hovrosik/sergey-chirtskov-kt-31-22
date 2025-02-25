namespace ChirtskovSergeyKt_31_22.Models
{
	public class Department
	{
		public int DepartmentId { get; set; }
		public string DepartmentName { get; set; }
		public int HeadTeacherId { get; set; }
		public Teacher HeadTeacher { get; set; }
	}
}