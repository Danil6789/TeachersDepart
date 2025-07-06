using System;
using System.Collections.Generic;

namespace TeachersDepart.Models;

public partial class ClassType
{
    public int ClassTypeId { get; set; }

    public string ClassTypeName { get; set; } = null!;

    public virtual ICollection<TeachersGroupDiscipline> TeacherGroupDisciplines { get; set; } = new List<TeachersGroupDiscipline>();
}
