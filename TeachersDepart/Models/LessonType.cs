using System;
using System.Collections.Generic;

namespace TeachersDepart.Models;

public partial class LessonType
{
    public int КодВидаЗанятий { get; set; }

    public string НазваниеВидаЗанятий { get; set; } = null!;

    public virtual ICollection<TeachersGroupDiscipline> TeacherGroupDisciplines { get; set; } = new List<TeachersGroupDiscipline>();
}
