using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SchoolManagementUI.Abstractions;
using SchoolManagementUI.Models.StudentModels;

namespace SchoolManagementUI.Controllers
{
    public class StudentController(IStudentService service, IToastNotification toast) : Controller
    {
        public async Task<IActionResult> Index([FromQuery] StudentFilter filter)
        {
            var result = await service.GetAllPagination(filter);
            return View(result);
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

        public async Task<IActionResult> Update(UpdateStudentRequest request)
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

        public async Task<IActionResult> Create(CreateStudentRequest request)
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
    }
}
