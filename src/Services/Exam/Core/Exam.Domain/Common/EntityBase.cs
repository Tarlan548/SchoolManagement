namespace Exam.Domain.Common;
public class EntityBase<TId> : IEntityBase
{
    public TId Id { get; set; } = default!;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    //public Guid CreatedById { get; set; }
    public DateTime? ModifiedDate { get; set; }
    //public Guid? ModifiedById { get; set; }
    public bool IsDeleted { get; set; }
}