using System;
using System.Collections.Generic;

namespace TeachersDepart.Models;

public partial class AcademicTitle
{
    public int AcademicTitleId { get; set; }

    public string AcademicTitleName { get; set; } = null!;

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
