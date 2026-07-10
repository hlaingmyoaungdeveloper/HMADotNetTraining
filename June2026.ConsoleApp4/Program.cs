// See https://aka.ms/new-console-template for more information
using June2026.ConsoleApp4;
using June2026.Database.AppDbContextModels;

Console.WriteLine("Hello, World!");
AppDbContext dbContext = new AppDbContext();

Console.WriteLine("Read All Staff");

List<StaffEntity> staffs = dbContext.Staffs.ToList();
foreach (StaffEntity staff in staffs)
{
    Console.WriteLine($"StaffId : {staff.Id}");
    Console.WriteLine($"Staff Name : {staff.Name}");
    Console.WriteLine($"Staff age : {staff.Age}");
    Console.WriteLine("--------------------------------------");
}

Console.WriteLine("Create New Staff");
StaffEntity newStaff = new StaffEntity
{
    Name = "Oaker Aung",
    Age = 21
};
dbContext.Add(newStaff);
int createRow = dbContext.SaveChanges();
Console.WriteLine($"Created Row Effect : {createRow}");
Console.WriteLine("------------------------------------------");


Console.WriteLine("Update Staff");
StaffEntity? oldStaff = dbContext.Staffs.Find(1);
if (oldStaff != null)
{
    oldStaff.Name = "Ko Ko";
    oldStaff.Age = 21;
    int updateRow = dbContext.SaveChanges();
    Console.WriteLine($"Updated Row Effect : {updateRow}");
}
else
{
    Console.WriteLine("Staff id havenot in db");
}
Console.WriteLine("----------------------------------------");

Console.WriteLine("Delete Staff");
//StaffEntity? delStaff = dbContext.Staffs.Find(1);
StaffEntity? delStaff = dbContext.Staffs.Where(s => s.Id == 3).FirstOrDefault();
if (delStaff != null)
{
    dbContext.Remove(delStaff);
    int deleteRow = dbContext.SaveChanges();
    Console.WriteLine($"Deleted Row Effected : {deleteRow}");
}
else
{
    Console.WriteLine("Staff id havenot in db");
}
Console.WriteLine("------------------------------------------");
Console.WriteLine("Search Staff with name");
Console.Write("\nEnter the name want to search :");
string? searchName = Console.ReadLine();

StaffEntity? searchStaff = dbContext.Staffs.FirstOrDefault(s => s.Name == searchName);
if (searchStaff != null)
{
    Console.WriteLine($"Found {searchName} at StaffId {searchStaff.Id}");
}
else
{
    Console.WriteLine("Staff Name havenot in db");
}

//AppDbContext db = new AppDbContext();
//Console.WriteLine("Searching with StaffName");
//Console.Write("\nEnter the name want to find :");
//string? name = Console.ReadLine();
//TblStaff? staff = db.TblStaffs.Where(n => n.StaffName == name).FirstOrDefault();
//if (staff is not null)
//{
//    Console.WriteLine($"StaffId :{staff.StaffId}");
//    Console.WriteLine($"StaffName :{staff.StaffName} and age :{staff.Age}");

//    //return;
//}
//Console.WriteLine("Staff does not found!");
//Console.WriteLine("--------------------------------------------------------");

//Console.WriteLine("Testing Select");
//List<int> staffAge = db.TblStaffs.Select(n => n.Age + 2).ToList();
//foreach (int age in staffAge)
//{
//    Console.WriteLine(age);
//}
//Console.WriteLine("---------------------------------------------------------");

//Console.WriteLine("Testing orderBy");
//List<TblStaff> staffs = db.TblStaffs.OrderBy(n => n.StaffName).ToList();
//foreach(TblStaff orderByStaff in staffs)
//{
//    Console.WriteLine(orderByStaff.StaffName);
//}

Console.ReadLine();

