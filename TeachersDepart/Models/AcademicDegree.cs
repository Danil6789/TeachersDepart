using System;
using System.Collections.Generic;

namespace TeachersDepart.Models;

public partial class AcademicDegree
{
    public int AcademicDegreeId { get; set; }

    public string AcademicDegreeName { get; set; } = null!;

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
