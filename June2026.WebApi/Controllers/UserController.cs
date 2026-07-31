using DatabaseScaffoldTesting.Database.AppDbContextModels;
using June2026.WebApi.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace June2026.WebApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _dbContent;

    public UserController()
    {
        _dbContent = new AppDbContext();
    }

    [HttpGet]
    public IActionResult GetUser() 
    { 
        var lst = _dbContent.TblUsers.ToList();
        return Ok(lst);
    }

    [HttpGet("{id}")]
    public IActionResult GetUsers(int id)
    {
        var user = _dbContent.TblUsers.FirstOrDefault(x => x.UserId == id);
        if(user is null)
        {
            return NotFound("User doesn't found");
        }
        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserCreateRequestModel requestModel)
    {
        TblUser newUser = new TblUser()
        { 
            Username = requestModel.Username,
            Password = requestModel.Password
        };
        _dbContent.Add(newUser);
        int result = _dbContent.SaveChanges();
        UserCreateResponseModel responseModel = new UserCreateResponseModel
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Successfully create  new user":"Failed to create new user",
            UserId = newUser.UserId
        };
        return Ok(responseModel);
    }

    [HttpPut]
    public IActionResult UpsertUser()
    {
        return Ok("Upsert User");
    }

    [HttpPatch("{id}")]
    public IActionResult PatchUser(int id,UserPatchRequestModel requestModel)
    {
        var user = _dbContent.TblUsers.FirstOrDefault(x => x.UserId == id);
        if (user is null)
        {
            return NotFound(new UserPatchResponseModel
            {
                Message = "User doesn't exit"
            });
        }

        if (!string.IsNullOrEmpty(requestModel.Username))
        {
            user.Username = requestModel.Username;
        }
        if(!string.IsNullOrEmpty(requestModel.Password))
        {
            user.Password = requestModel.Password;
        }
        int result = _dbContent.SaveChanges();
        UserPatchResponseModel responseMode = new UserPatchResponseModel
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Successfully updated" : "Failed to update",
        };
        return Ok(responseMode);
    }

    [HttpDelete("{UserId}")]
    public IActionResult DeleteUser([FromRoute]UserDeleteRequestModel requestModel)
    {
        var user = _dbContent.TblUsers.FirstOrDefault(x => x.UserId == requestModel.UserId);
        if (user is null)
        {
            return NotFound(new UserDeleteResponseModel
            {
                Message = "User doesnot found"
            });
        }
        _dbContent.Remove(user);
        int result = _dbContent.SaveChanges();

        UserDeleteResponseModel responseModel = new UserDeleteResponseModel
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Successfully deleted" : "Failed to delete"
        };
        return Ok(responseModel);
    }

}
