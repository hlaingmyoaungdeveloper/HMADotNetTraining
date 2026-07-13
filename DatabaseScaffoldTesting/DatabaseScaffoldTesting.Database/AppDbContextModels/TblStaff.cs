using System;
using System.Collections.Generic;

namespace DatabaseScaffoldTesting.Database.AppDbContextModels;

public partial class TblStaff
{
    public int StaffId { get; set; }

    public string StaffName { get; set; } = null!;

    public int Age { get; set; }
}
