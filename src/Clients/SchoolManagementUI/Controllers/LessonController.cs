using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SchoolManagementUI.Abstractions;
using SchoolManagementUI.Models.LessonModels;

namespace SchoolManagementUI.Controllers
{
    public class LessonController(ILessonService lessonService, IToastNotification toast) : Controller
    {
        public async Task<IActionResult> Index([FromQuery] LessonFilter lessonFilter)
        {
            var result = await lessonService.GetAllPagination(lessonFilter);
            return View(result);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                toast.AddErrorToastMessage("The ID is empty. Please provide a valid ID.");
            }

            var response = await lessonService.Delete(id);

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

        public async Task<IActionResult> Update(UpdateLessonRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await lessonService.Update(request);

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

        public async Task<IActionResult> Create(CreateLessonRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await lessonService.Create(request);

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
    }
}
