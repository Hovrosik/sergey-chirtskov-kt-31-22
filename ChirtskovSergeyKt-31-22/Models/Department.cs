namespace ChirtskovSergeyKt_31_22.Models
{
	public class Department
	{
		public int DepartmentId { get; set; }
		public string DepartmentName { get; set; }
        public bool isDeleted { get; set; } = false;
        public ICollection<Teacher> Teachers { get; set; }
    }
}