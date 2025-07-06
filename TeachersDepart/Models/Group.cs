using System;
using System.Collections.Generic;

namespace TeachersDepart.Models;

public partial class Group
{
    public string НомерГруппы { get; set; } = null!;

    public byte КоличествоСтудентов { get; set; }

    public int КодНаправления { get; set; }

    public virtual ICollection<TeachersGroupDiscipline> TeacherGroupDisciplines { get; set; } = new List<TeachersGroupDiscipline>();

    public virtual Specialization КодНаправленияNavigation { get; set; } = null!;
}
