using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
start:
Console.WriteLine("User List");
Console.WriteLine("1. View User");
Console.WriteLine("2. Add User");
Console.WriteLine("3. Update User");
Console.WriteLine("4. Delete User");

Console.Write("Enter the number : ");

string? strNumber = Console.ReadLine();

int number = Convert.ToInt32(strNumber);

if (number == 1)
{
    HttpClient client = new HttpClient();

    HttpResponseMessage response = await client.GetAsync("https://localhost:7124/api/User");

    if (response.IsSuccessStatusCode)
    {
        int count = 0;
        string content = await response.Content.ReadAsStringAsync();
        var users = JsonConvert.DeserializeObject<List<UserModel>>(content);

        foreach (var user in users)
        {
            Console.WriteLine($"{++count} : {user.Username}");
        }
    }
}
else if(number == 2)
{
    Console.Write("\nEnter the username : ");
    string username = Console.ReadLine();
    Console.Write("\nEnter the password : ");
    string password = Console.ReadLine();

    UserModel newUser = new UserModel
    {
        Username = username,
        Password = password
    };
    HttpClient client = new HttpClient();
    string json = JsonConvert.SerializeObject(newUser);
    StringContent stringContent = new StringContent(json,Encoding.UTF8,Application.Json);
    var response = await client.PostAsync("https://localhost:7124/api/User", stringContent);
    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        var responseModel = JsonConvert.DeserializeObject<UserCreateResponseModel>(content);
        Console.WriteLine(responseModel.Message);
    }
}
else if(number == 3)
{
    Console.Write("Enter the id want to update:");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Write("\nEnter the username : ");
    string? username = Console.ReadLine();
    Console.Write("\nEnter the password : ");
    string? password = Console.ReadLine();

    UserPatchRequestModel patchUser = new UserPatchRequestModel
    {
        Username = username,
        Password = password
    };
    string json = JsonConvert.SerializeObject(patchUser);
    StringContent stringContent = new StringContent(json, Encoding.UTF8, Application.Json);
    HttpClient client= new HttpClient();
    var response = await client.PatchAsync($"https://localhost:7124/api/User/{id}",stringContent);
    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        var responseModel = JsonConvert.DeserializeObject<UserPatchResponseModel>(content);
        Console.WriteLine(responseModel.Message);
    }
}
else if(number == 4)
{
    Console.Write("Enter the id want to delete:");
    int id = Convert.ToInt32(Console.ReadLine());

    HttpClient client = new HttpClient();
    var response = await client.DeleteAsync($"https://localhost:7124/api/User/{id}");
    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        var responseModel = JsonConvert.DeserializeObject<UserDeleteResponseModel>(content);
        Console.WriteLine(responseModel.Message);
    }
}
else
{
    goto exit;
}

goto start;
exit:
Console.WriteLine("Exit the program");
Console.WriteLine("Press any key");
Console.ReadLine();

public class UserModel
{
    public int id { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; }
}

public class UserCreateResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int UserId { get; set; }
}

public class UserPatchRequestModel
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}

public class UserPatchResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

public class UserDeleteResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}