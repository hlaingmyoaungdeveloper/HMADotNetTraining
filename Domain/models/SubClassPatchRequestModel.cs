namespace Domain.models;

public class SubClassPatchRequestModel
{
    public string ClassName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateOnly OpenDate { get; set; }

    public int StudentLimit { get; set; }

    public TimeOnly OpenTime { get; set; }

}

public class SubClassPatchResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}