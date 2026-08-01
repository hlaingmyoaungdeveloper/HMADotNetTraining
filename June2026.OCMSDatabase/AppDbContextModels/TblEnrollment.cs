using System;
using System.Collections.Generic;

namespace June2026.OCMSDatabase.AppDbContextModels;

public partial class TblEnrollment
{
    public int EnrollmentId { get; set; }

    public string SubClassId { get; set; } = null!;

    public string StudentName { get; set; } = null!;

    public string StudentContact { get; set; } = null!;

    public string PaymentInfo { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDateTime { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public virtual TblSubClass Enrollment { get; set; } = null!;
}
