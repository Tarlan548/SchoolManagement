using SchoolManagementUI.Models.ViewModels;
using SchoolManagementUI.Models;
using SchoolManagementUI.Models.StudentModels;

namespace SchoolManagementUI.Abstractions;

public interface IStudentService
{
    Task<PagedResponse<StudentViewModel>> GetAllPagination(StudentFilter filter);
    Task<IList<StudentViewModel>> GetAll();
    Task<(bool, string)> Create(CreateStudentRequest request);
    Task<(bool, string)> Update(UpdateStudentRequest request);
    Task<(bool, string)> Delete(Guid id);
}
