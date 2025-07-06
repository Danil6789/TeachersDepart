using System;
using System.Collections.Generic;

namespace TeachersDepart.Models;

public partial class Teacher
{
    public int TeacherPassportNumber { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public int? AcademicTitleId { get; set; }

    public int? AcademicDegreeId { get; set; }

    public int? PositionId { get; set; }

    public virtual AcademicDegree? AcademicDegree { get; set; }

    public virtual AcademicTitle? AcademicTitle { get; set; }

    public virtual Position? Position { get; set; }

    public virtual ICollection<TeachersGroupDiscipline> TeacherGroupDisciplines { get; set; } = new List<TeachersGroupDiscipline>();
}
