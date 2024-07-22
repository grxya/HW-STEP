using System;
using System.Collections.Generic;

namespace HW1.Data.Models;

public partial class Task
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; }

    public DateOnly Deadline { get; set; }
}
