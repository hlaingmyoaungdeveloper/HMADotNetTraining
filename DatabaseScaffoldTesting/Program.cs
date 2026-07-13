// See https://aka.ms/new-console-template for more information
using DatabaseScaffoldTesting.Database.AppDbContextModels;

Console.WriteLine("Hello, World!");
AppDbContext db = new AppDbContext();
List<TblStaff> staffs = db.TblStaffs.ToList();
foreach(TblStaff staff in staffs)
{
    Console.WriteLine($"StaffName : {staff.StaffName}");
}

//List<TblStudent> students = db.TblStudents.ToList();

List<TblTeam> teams = db.TblTeams.ToList();
foreach(TblTeam team in teams)
{
    Console.WriteLine($"TeamName : {team.TeamName}");
}
Console.ReadLine();
