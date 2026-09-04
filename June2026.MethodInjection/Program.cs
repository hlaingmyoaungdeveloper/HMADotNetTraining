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

public class OrderProcessor
{

    public void ProcessOrder(int orderId, ILogger logger)
    {
        Console.WriteLine($"Processing Order: {orderId}");

        logger.Log($"Order {orderId} has been processed successfully.");
    }
}

class Program
{
    static void Main()
    {
        OrderProcessor processor = new OrderProcessor();
        ILogger myLogger = new ConsoleLogger();

        processor.ProcessOrder(101, myLogger);
    }
}
//use [FromServices] in ASP.NET Core Controller