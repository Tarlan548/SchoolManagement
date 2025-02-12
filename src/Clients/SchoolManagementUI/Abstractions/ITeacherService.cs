using SchoolManagementUI.Models.ViewModels;
using SchoolManagementUI.Models;
using SchoolManagementUI.Models.TeacherModels;

namespace SchoolManagementUI.Abstractions;

public interface ITeacherService
{
    Task<PagedResponse<TeacherViewModel>> GetAllPagination(TeacherFilter filter);
    Task<(bool, string)> Create(CreateTeacherRequest request);
    Task<(bool, string)> Update(UpdateTeacherRequest request);
    Task<(bool, string)> Delete(Guid id);
}
