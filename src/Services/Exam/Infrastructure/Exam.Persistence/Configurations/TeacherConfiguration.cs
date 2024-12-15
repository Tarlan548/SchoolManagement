using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Exam.Persistence.Configurations;
public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(x => x.Id)
               .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(t => t.FirstName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(t => t.LastName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(t => t.CreatedDate)
               .HasDefaultValueSql("GETDATE()");

        builder.Property(t => t.IsDeleted)
               .HasDefaultValue(false);
        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasIndex(t => new { t.FirstName, t.LastName }, "IX_Teacher_Name");
    }
}
