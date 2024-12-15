namespace Exam.Application.Features.Queries.StudentQueries.StudentPaginationQuery
{
    public class GetStudentQueryResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int ClassLevel { get; set; }
    }
}