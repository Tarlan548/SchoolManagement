using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Exam.Persistence.Configurations;

public class ExamConfiguration : IEntityTypeConfiguration<Domain.Entities.Exam>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Exam> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Name, "UQ_Lesson_Name").IsUnique();

        builder.Property(x => x.Id).HasDefaultValueSql("uuid_generate_v4()");

        builder.Property(x => x.CreatedDate)
            .HasDefaultValueSql("Now()");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.Property(x => x.Name)
            .HasMaxLength(50);
    }
}