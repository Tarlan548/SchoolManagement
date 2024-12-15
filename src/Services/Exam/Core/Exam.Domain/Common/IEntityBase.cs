namespace Exam.Domain.Common;

public interface IEntityBase
{
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
}
