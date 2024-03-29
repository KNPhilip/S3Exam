﻿using System;
using System.Collections.Generic;

namespace Entities;

public partial class Assignment
{
    public int Id { get; set; }

    public string Notes { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? ExpectedEndDate { get; set; }

    public DateTime? ActualEndDate { get; set; }

    public bool? Solved { get; set; }

    public int? SolvedBy { get; set; }

    public int? ResidentId { get; set; }

    public virtual Resident Resident { get; set; }

    public virtual Employee SolvedByNavigation { get; set; }
}
