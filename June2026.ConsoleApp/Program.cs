// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//int num = 33;
//int a, b, c;
//a = 10;
//double d = 10D;
//Console.WriteLine(d);
//Console.WriteLine(a);
//Console.ReadKey();




//Console.Write("Enter the name :");
//string name = Console.ReadLine();
//Console.Write("\nEnter the text:");
//char text = Console.ReadKey().KeyChar;
//Console.WriteLine("\n" + name  + " and " + text);
//Console.Write("Enter the number:");
//int number = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine(number);
Console.Write("Enter the number:");
int readText = Console.Read();//give asci number
Console.WriteLine(readText);
Console.ReadLine();
Console.Write("Enter the first name:");
string firstName = Console.ReadLine()!;//! means cannot access null
Console.WriteLine(firstName);

Console.Write("\nEnter the last name:");
string lastName = Console.ReadLine()!;
Console.WriteLine(lastName.Length);
Console.WriteLine(string.Concat(firstName,lastName));
Console.ReadLine();

//int[] oneDArray = new int[3];
//int[,] twoDArray = new int[3, 4];
//int[,,] threeDArray = new int[2, 3, 4];
//int[,,,,,,,] manyArray = new int[1, 2, 3, 4, 4, 5, 8, 9];
