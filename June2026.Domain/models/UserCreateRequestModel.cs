namespace June2026.Domain.Models;

public class UserCreateRequestModel
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class UserCreateResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = null!;
    public int UserId { get; set; }
}
