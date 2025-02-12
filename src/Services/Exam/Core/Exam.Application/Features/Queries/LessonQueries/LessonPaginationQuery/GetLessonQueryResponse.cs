namespace Exam.Application.Features.Queries.LessonQueries.LessonPaginationQuery
{
    public class GetLessonQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int ClassLevel { get; set; }
    }
}