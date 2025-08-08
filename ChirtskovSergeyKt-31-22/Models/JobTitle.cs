using System.Text.RegularExpressions;

namespace ChirtskovSergeyKt_31_22.Models
{
    public class JobTitle
    {
        public int JobTitleId { get; set; }
        public string JobTitleName { get; set; }
        public bool IsValidJobTitleName()
        {
            return !string.IsNullOrWhiteSpace(JobTitleName)
                   && Regex.IsMatch(JobTitleName, @"^[А-Яа-яA-Za-z\s\-]{2,100}$");
        }
    }
}
