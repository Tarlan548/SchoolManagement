namespace Exam.Application.Features.Queries.TeacherQueries
{
    public sealed record GetTeacherQueryResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}