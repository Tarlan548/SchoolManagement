using SchoolManagementUI.Models.ViewModels;
using SchoolManagementUI.Models;
using SchoolManagementUI.Models.ExamModels;

namespace SchoolManagementUI.Abstractions;

public interface IExamService
{
    Task<PagedResponse<ExamViewModel>> GetAllPagination(ExamFilter filter);
    Task<(bool, string)> Create(CreateExamRequest request);
    Task<(bool, string)> Update(UpdateExamRequest request);
    Task<(bool, string)> Delete(Guid id);
}
