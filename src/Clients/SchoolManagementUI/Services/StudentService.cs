using Newtonsoft.Json;
using SchoolManagementUI.Abstractions;
using SchoolManagementUI.Models.ViewModels;
using SchoolManagementUI.Models;
using System.Text;
using SchoolManagementUI.Models.StudentModels;

namespace SchoolManagementUI.Services;

public class StudentService(HttpClient httpClient) : IStudentService
{
    public async Task<(bool, string)> Create(CreateStudentRequest request)
    {
        try
        {
            string jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("Student/Create", content);
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
        HttpResponseMessage response = await httpClient.PutAsync("Student/Delete", content);
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

    public async Task<PagedResponse<StudentViewModel>> GetAllPagination(StudentFilter filter)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"Student/GetAllPagination?currentPage={filter.CurrentPage}&pageSize={filter.PageSize}&FirstName={filter.FirstName}&LastName={filter.LastName}&ClassLevel={filter.ClassLevel}");
        string responseContent = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            PagedResponse<StudentViewModel> result = (JsonConvert.DeserializeObject<PagedResponse<StudentViewModel>>(responseContent))!;
            return result;
        }
        else
        {
            return new PagedResponse<StudentViewModel>();
        }
    }
    public async Task<IList<StudentViewModel>> GetAll()
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync("Student/GetAll");
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            IList<StudentViewModel> result = JsonConvert.DeserializeObject<IList<StudentViewModel>>(responseContent) ?? [];

            return result;
        }
        catch (Exception)
        {
            return [];
        }
    }

    public async Task<(bool, string)> Update(UpdateStudentRequest request)
    {
        string jsonRequest = JsonConvert.SerializeObject(request);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PutAsync("Student/Update", content);
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
