using Exam.Domain.Common;

namespace Exam.Domain.Entities;
public class Student : EntityBase<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int ClassLevel { get; set; }
}
