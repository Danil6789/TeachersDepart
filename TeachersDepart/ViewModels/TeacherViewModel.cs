using TeachersDepart.Models;

namespace TeachersDepart.ViewModels
{
    public class TeacherViewModel
    {
        public int TeacherPassportNumber { get; set; }

        public string FullName { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public string? AcademicTitleName { get; set; }

        public string? AcademicDegreeName { get; set; }

        public string? PositionName { get; set; }

    }
}
