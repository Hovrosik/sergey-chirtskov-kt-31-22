using System.Text.RegularExpressions;

namespace ChirtskovSergeyKt_31_22.Models
{
    public class Degree
    {
        public int DegreeId { get; set; }
        public string DegreeName { get; set; }
        public bool IsValidDegreeName()
        {
            return !string.IsNullOrWhiteSpace(DegreeName)
                   && Regex.IsMatch(DegreeName, @"^[А-Яа-яA-Za-z\s\-]{3,100}$");
        }
    }
}
