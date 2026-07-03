// See https://aka.ms/new-console-template for more information
using June2026.ConsoleApp3;

Console.WriteLine("Hello, World!");
DapperService service = new DapperService();
service.Read();
service.Create();
service.Update();
service.Delete();