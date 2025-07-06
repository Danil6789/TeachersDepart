using System;
using System.Collections.Generic;

namespace TeachersDepart.Models;

public partial class Course
{
    public string CourseName { get; set; } = null!;

    public string AssessmentType { get; set; } = null!;

    public virtual ICollection<TeachersGroupDiscipline> TeacherGroupDisciplines { get; set; } = new List<TeachersGroupDiscipline>();
}
