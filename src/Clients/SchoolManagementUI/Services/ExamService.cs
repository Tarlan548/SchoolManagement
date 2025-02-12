using Newtonsoft.Json;
using SchoolManagementUI.Abstractions;
using SchoolManagementUI.Models;
using SchoolManagementUI.Models.ExamModels;
using SchoolManagementUI.Models.ViewModels;
using System.Text;

namespace SchoolManagementUI.Services;

public class ExamService(HttpClient httpClient) : IExamService
{
    public async Task<(bool, string)> Create(CreateExamRequest request)
    {
        try
        {
            string jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("Exam/Create", content);
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
        HttpResponseMessage response = await httpClient.PutAsync("Exam/Delete", content);
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

    public async Task<PagedResponse<ExamViewModel>> GetAllPagination(ExamFilter filter)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"Exam/GetAllPagination?currentPage={filter.CurrentPage}&pageSize={filter.PageSize}&Name={filter.Name}&LessonName={filter.LessonName}&StudentName={filter.StudentName}&ExamDate={filter.ExamDate}");
        string responseContent = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            PagedResponse<ExamViewModel> result = (JsonConvert.DeserializeObject<PagedResponse<ExamViewModel>>(responseContent))!;
            return result;
        }
        else
        {
            return new PagedResponse<ExamViewModel>();
        }
    }

    public async Task<(bool, string)> Update(UpdateExamRequest request)
    {
        string jsonRequest = JsonConvert.SerializeObject(request);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PutAsync("Exam/Update", content);
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
