using System;
using System.Collections.Generic;

namespace TeachersDepart.Models;

public partial class TeachersGroupDiscipline
{
    public int TeacherPassportNumber { get; set; }

    public string CourseName { get; set; } = null!;

    public int ClassTypeId { get; set; }

    public string GroupNumber { get; set; } = null!;

    public byte SemesterNumber { get; set; }

    public virtual ClassType ClassType { get; set; } = null!;

    public virtual Course CourseNameNavigation { get; set; } = null!;

    public virtual StudentGroup GroupNumberNavigation { get; set; } = null!;

    public virtual Teacher TeacherPassportNumberNavigation { get; set; } = null!;
}
