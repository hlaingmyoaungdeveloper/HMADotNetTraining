using June2026.ConsoleApp2;
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");
AdoDotNetService service = new AdoDotNetService();
service.Read();
service.Create();
service.Update();
service.Delete();
Console.ReadLine();