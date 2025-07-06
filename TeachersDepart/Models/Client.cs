using System;
using System.Collections.Generic;

namespace TeachersDepart.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public int Age { get; set; }

    public string Job { get; set; } = null!;
}
