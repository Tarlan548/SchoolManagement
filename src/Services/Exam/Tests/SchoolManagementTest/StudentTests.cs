using Exam.Domain.Entities;

namespace SchoolManagementDomain.Test;

public class StudentTests
{
    [Fact]
    public void Student_Should_NotNull()
    {
        // Arrange
        var student = new Student
        {
            // Act
            FirstName = "John",
            LastName = "Doe",
            ClassLevel = 1
        };

        // Assert
        Assert.NotNull(student);
    }

    [Fact]
    public void Student_Should_TrowException_IfClassLevelIsNegative()
    {
        // Arrange
        var exception = Assert.Throws<ArgumentException>(() => new Student
        {
            // Act
            FirstName = "John",
            LastName = "Doe",
            ClassLevel = -1
        });
        // Act

        // Assert
        Assert.Equal("ClassLevel cannot be negative", exception.Message);
    }
}