using System;
using System.Collections.Generic;

namespace TeachersDepart.Models;

public partial class StudentGroup
{
    public string GroupNumber { get; set; } = null!;

    public byte StudentCount { get; set; }

    public int? SpecializationId { get; set; }

    public virtual Specialization? Specialization { get; set; }

    public virtual ICollection<TeachersGroupDiscipline> TeacherGroupDisciplines { get; set; } = new List<TeachersGroupDiscipline>();
}
