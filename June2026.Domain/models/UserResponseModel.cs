using System.Collections.Generic;

namespace June2026.Domain.Models;

public class UserModel
{
    public int UserId { get; set; }
    public string Username { get; set; } = null!;
}

public class UserListRequestModel
{
}

public class UserListResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = null!;
    public List<UserModel> Users { get; set; } = new List<UserModel>();
}

public class UserEditRequestModel
{
    public int UserId { get; set; }
}

public class UserEditResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = null!;
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
}
