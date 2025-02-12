using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SchoolManagementUI.Abstractions;
using SchoolManagementUI.Models.ExamModels;

namespace SchoolManagementUI.Controllers;

public class ExamController(IExamService service, IToastNotification toast, ILessonService lessonService, IStudentService studentService) : Controller
{
    public async Task<IActionResult> Index([FromQuery] ExamFilter filter)
    {
        var resultLesson = await lessonService.GetAll();
        var resultStudent = await studentService.GetAll();
        ViewBag.Lesson = resultLesson;
        ViewBag.Student = resultStudent;
        var result = await service.GetAllPagination(filter);
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateExamRequest request)
    {
        if (ModelState.IsValid)
        {
            var response = await service.Create(request);

            if (response.Item1)
            {
                toast.AddSuccessToastMessage("Created successfully!");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                toast.AddErrorToastMessage(response.Item2);
                return RedirectToAction(nameof(Index));
            }
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(UpdateExamRequest request)
    {
        if (ModelState.IsValid)
        {
            var response = await service.Update(request);

            if (response.Item1)
            {
                toast.AddSuccessToastMessage("Updated successfully!");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                toast.AddErrorToastMessage(response.Item2);
                return RedirectToAction(nameof(Index));
            }
        }
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Delete(Guid id)
    {
        if (id == Guid.Empty)
        {
            toast.AddErrorToastMessage("The ID is empty. Please provide a valid ID.");
        }

        var response = await service.Delete(id);

        if (response.Item1)
        {
            toast.AddSuccessToastMessage("Deleted successfully!");

            return RedirectToAction(nameof(Index));
        }
        else
        {
            toast.AddErrorToastMessage(response.Item2);
            return RedirectToAction(nameof(Index));
        }
    }
}
