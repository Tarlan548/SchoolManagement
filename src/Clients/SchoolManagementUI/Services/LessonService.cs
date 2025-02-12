using Newtonsoft.Json;
using SchoolManagementUI.Abstractions;
using SchoolManagementUI.Models;
using SchoolManagementUI.Models.LessonModels;
using SchoolManagementUI.Models.ViewModels;
using System.Text;

namespace SchoolManagementUI.Services;
public class LessonService(HttpClient httpClient) : ILessonService
{
    public async Task<(bool, string)> Create(CreateLessonRequest request)
    {
        try
        {
            string jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("Lesson/Create", content);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return (true, responseContent);
            }
            else
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorViewModel>(responseContent);
                return (false, errorResponse?.Detail ?? "An error occurred, but no details were provided.");
            }
        }
        catch (Exception ex)
        {
            return (false, $"An error occurred: {ex.Message}");
        }
    }

    public async Task<(bool, string)> Delete(Guid id)
    {
        string jsonRequest = JsonConvert.SerializeObject(new { Id = id });
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PutAsync("Lesson/Delete", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            return (true, responseContent);
        }
        else
        {
            var errorResponse = JsonConvert.DeserializeObject<ErrorViewModel>(responseContent);
            return (false, errorResponse?.Detail ?? "An error occurred, but no details were provided.");
        }
    }

    public async Task<PagedResponse<LessonViewModel>> GetAllPagination(LessonFilter lessonFilter)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"Lesson/GetAllPagination?currentPage={lessonFilter.CurrentPage}&pageSize={lessonFilter.PageSize}&Name={lessonFilter.Name}&ClassLevel={lessonFilter.ClassLevel}");
        string responseContent = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            PagedResponse<LessonViewModel> result = (JsonConvert.DeserializeObject<PagedResponse<LessonViewModel>>(responseContent))!;
            return result;
        }
        else
        {
            return new PagedResponse<LessonViewModel>();
        }
    }

    public async Task<IList<LessonViewModel>> GetAll()
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync("Lesson/GetAll");
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            IList<LessonViewModel> result = JsonConvert.DeserializeObject<IList<LessonViewModel>>(responseContent) ?? [];

            return result;
        }
        catch (Exception)
        {
            return [];
        }
    }



    public async Task<(bool, string)> Update(UpdateLessonRequest request)
    {
        string jsonRequest = JsonConvert.SerializeObject(request);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PutAsync("Lesson/Update", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            return (true, responseContent);
        }
        else
        {
            var errorResponse = JsonConvert.DeserializeObject<ErrorViewModel>(responseContent);
            return (false, errorResponse?.Detail ?? "An error occurred, but no details were provided.");
        }
    }
}
