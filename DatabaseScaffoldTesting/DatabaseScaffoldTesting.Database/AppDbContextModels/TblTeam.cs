using System;
using System.Collections.Generic;

namespace DatabaseScaffoldTesting.Database.AppDbContextModels;

public partial class TblTeam
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;
}
