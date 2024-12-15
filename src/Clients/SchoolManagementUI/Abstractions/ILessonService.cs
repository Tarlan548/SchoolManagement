using SchoolManagementUI.Models;
using SchoolManagementUI.Models.LessonModels;
using SchoolManagementUI.Models.ViewModels;

namespace SchoolManagementUI.Abstractions
{
    public interface ILessonService
    {
        Task<PagedResponse<LessonViewModel>> GetAllPagination(LessonFilter lessonFilter);
        Task<IList<LessonViewModel>> GetAll();
        Task<(bool, string)> Create(CreateLessonRequest request);
        Task<(bool, string)> Update(UpdateLessonRequest request);
        Task<(bool, string)> Delete(Guid id);
    }
}