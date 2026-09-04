using System;

public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

public class CustomerService
{
    public ILogger Logger { get; set; }

    public void CreateCustomer(string name)
    {
        Console.WriteLine($"Customer '{name}' created.");

   
        if (Logger != null)
        {
            Logger.Log($"Customer {name} was successfully saved.");
        }
    }
}

class Program
{
    static void Main()
    {
        CustomerService service = new CustomerService();

        service.Logger = new ConsoleLogger();

        service.CreateCustomer("Aung Aung");
    }
}