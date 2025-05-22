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

		
		public string GetFullName()
		{
			return $"{LastName} {FirstName} {MiddleName}".Trim();
		}
        
        public int GetTotalHours()
		{
			return Classes?.Sum(c => c.Hours) ?? 0;
		}

        public bool IsTotalHoursWithinLimit(int limit = 1000)
        {
            return GetTotalHours() <= limit;
        }

        public void MarkAsDeleted()
		{
			isDeleted = true;
		}

        
        public void AddClass(Class newClass)
        {
            if (newClass == null)
                throw new ArgumentNullException(nameof(newClass));

            if (!Classes.Contains(newClass))
            {
                Classes.Add(newClass);
                newClass.Teacher = this;
                newClass.TeacherId = this.TeacherId;
            }
        }
    }
}
