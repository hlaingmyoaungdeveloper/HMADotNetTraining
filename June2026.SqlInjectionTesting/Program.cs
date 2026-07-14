// See https://aka.ms/new-console-template for more information
using June2026.SqlInjectionTesting;

Console.WriteLine("Hello, World!");
LoginService service = new LoginService();
Console.Write("Enter the username :");
string username = Console.ReadLine()!;
Console.Write("\nEnter the password:");
string password = Console.ReadLine()!;
service.Login(username, password);