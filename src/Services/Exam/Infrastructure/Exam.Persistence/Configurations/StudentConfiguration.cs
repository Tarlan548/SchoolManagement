using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Exam.Domain.Entities;

namespace Exam.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(x => x.Id)
            .HasDefaultValueSql("uuid_generate_v4()");

        builder.Property(s => s.FirstName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.LastName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(s => s.ClassLevel)
               .IsRequired()
               .HasDefaultValue(1);

        builder.Property(s => s.CreatedDate)
               .HasDefaultValueSql("GETDATE()");

        builder.Property(s => s.IsDeleted)
               .HasDefaultValue(false);
        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasIndex(s => new { s.FirstName, s.LastName }, "IX_Student_Name");
    }
}