using TeachersDepart.Models;

namespace TeachersDepart.ViewModels
{
    public class TeachersGroupDisciplineViewModel
    {
        public string? FullName { get; set; }

        public string? CourseName { get; set; }

        public string? GroupNumber { get; set; }

        public byte SemesterNumber { get; set; }

        public string? ClassType { get; set; }
    }
}
