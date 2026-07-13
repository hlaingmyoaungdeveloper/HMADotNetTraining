using System;
using System.Collections.Generic;

namespace DatabaseScaffoldTesting.Database.AppDbContextModels;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentNo { get; set; } = null!;

    public string FatherName { get; set; } = null!;

    public DateTime DateOfBirthday { get; set; }

    public string Email { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public bool? IsDelete { get; set; }
}
