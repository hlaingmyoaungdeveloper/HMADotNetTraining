using Domain.features.Enrollment;
using Domain.models;
using Microsoft.AspNetCore.Mvc;

namespace OCMSWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentController : Controller
{
    private readonly EnrollmentService _service;

    public EnrollmentController()
    {
        _service = new EnrollmentService();
    }

    [HttpGet]
    public IActionResult GetEnrollment()
    {
        var lst = _service.GetEnrollments(new EnrollmentListRequestModel());
        return Ok(lst);
    }

    [HttpPost]
    public IActionResult CreateEnrollment([FromBody] EnrollmentCreateRequestModel model)
    {
        return Ok(_service.CreateEnrollment(model));
    }

    [HttpGet("{EnrollmentId}")]
    public IActionResult GetEnrollment([FromRoute] EnrollmentEditRequestModel model)
    {
        return Ok(_service?.GetEnrollment(model));
    }
}
