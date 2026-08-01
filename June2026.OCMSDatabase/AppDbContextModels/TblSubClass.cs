using System;
using System.Collections.Generic;

namespace June2026.OCMSDatabase.AppDbContextModels;

public partial class TblSubClass
{
    public int SubClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateOnly OpenDate { get; set; }

    public int StudentLimit { get; set; }

    public TimeOnly OpenTime { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDateTime { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public bool IsDelete { get; set; }

    public virtual TblEnrollment? TblEnrollment { get; set; }
}
