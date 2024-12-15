using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Exam.Persistence.Configurations;

public class ExamConfiguration : IEntityTypeConfiguration<Domain.Entities.Exam>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Exam> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Name, "UQ_Lesson_Name").IsUnique();

        builder.Property(x => x.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);
        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.Property(x => x.Name)
            .HasMaxLength(50);
    }
}