using Domain.features.SubClass;
using Domain.models;
using Microsoft.AspNetCore.Mvc;

namespace OCMSWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubClassController : Controller
{
    private readonly SubClassService _service;

    public SubClassController()
    {
        _service = new SubClassService();
    }

    [HttpGet]
    public IActionResult GetSubClass()
    {
        var lst = _service.GetSubClasses(new SubClassListRequestModel());
        return Ok(lst);
    }

    [HttpPost]
    public IActionResult CreateSubClass([FromBody] SubClassCreateRequestModel model)
    {
        return Ok(_service.CreateSubClass(model));
    }

    [HttpGet("{SubClassId}")]
    public IActionResult GetSubClass([FromRoute] SubClassEditRequestModel model)
    {
        return Ok(_service?.GetSubClass(model));
    }

    [HttpPatch("{id}")]
    public IActionResult PatchSubClass(int id , SubClassPatchRequestModel model)
    {
        return Ok(_service.PatchSubClass(id, model));
    }

    [HttpDelete("{SubClassId}")]
    public IActionResult DeleteSubClass([FromRoute] SubClassDeleteRequestModel model)
    {
        return Ok(_service.DeleteSubClass(model));
    }
}
