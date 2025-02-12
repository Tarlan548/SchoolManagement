namespace Exam.Application.Features.Queries.StudentQueries.StudentGetAllQuery;

public class GetAllStudentQueryResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

}