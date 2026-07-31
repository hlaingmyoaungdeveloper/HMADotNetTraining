namespace June2026.WebApi.model;

public class UserCreateRequestModel
{
    public string Username { get; set; } = null!;
    public string Password { get; set; }
}

public class UserCreateResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int UserId { get; set; }
}