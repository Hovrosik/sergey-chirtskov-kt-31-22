using System.Text.RegularExpressions;

namespace ChirtskovSergeyKt_31_22.Models
{
    public class Discipline
    {
        public int DisciplinesId { get; set; }
        public string DisciplinesName { get; set; }
        public ICollection<Class> classes { get; set; }
        public bool IsValidDisciplineName()
        {
            return !string.IsNullOrWhiteSpace(DisciplinesName)
                   && Regex.IsMatch(DisciplinesName, @"^[А-Яа-яA-Za-z\s\-]{3,100}$");
        }
    }
}
