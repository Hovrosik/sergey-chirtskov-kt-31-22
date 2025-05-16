namespace ChirtskovSergeyKt_31_22.Models
{
    public class Discipline
    {
        public int DisciplinesId { get; set; }
        public string DisciplinesName { get; set; }
        public ICollection<Class> classes { get; set; }
    }
}
