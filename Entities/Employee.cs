using System;
using System.Collections.Generic;

namespace Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Position { get; set; }

    public DateTime? BirthDate { get; set; }

    public virtual ICollection<Assignment> Assignments { get; } = new List<Assignment>();
}
