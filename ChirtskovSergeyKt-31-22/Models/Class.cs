namespace ChirtskovSergeyKt_31_22.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public int Hours { get; set; }
    }
}
