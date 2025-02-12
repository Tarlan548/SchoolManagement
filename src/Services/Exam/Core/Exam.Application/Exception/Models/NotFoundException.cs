namespace Exam.Application.Exception.Models;

public class NotFoundException : ApplicationException
{
    public NotFoundException() { }
    public NotFoundException(string item) : base($"{item} Not Found!") { }
}
