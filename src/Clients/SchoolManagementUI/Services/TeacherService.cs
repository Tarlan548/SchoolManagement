using Newtonsoft.Json;
using SchoolManagementUI.Abstractions;
using SchoolManagementUI.Models.ViewModels;
using SchoolManagementUI.Models;
using System.Text;
using SchoolManagementUI.Models.TeacherModels;

namespace SchoolManagementUI.Services;

public class TeacherService(HttpClient httpClient) : ITeacherService
{
    public async Task<(bool, string)> Create(CreateTeacherRequest request)
    {
        try
        {
            string jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("Teacher/Create", content);
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
        HttpResponseMessage response = await httpClient.PutAsync("Teacher/Delete", content);
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

    public async Task<PagedResponse<TeacherViewModel>> GetAllPagination(TeacherFilter filter)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"Teacher/GetAllPagination?currentPage={filter.CurrentPage}&pageSize={filter.PageSize}&FirstName={filter.FirstName}&LastName={filter.LastName}");
        string responseContent = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            PagedResponse<TeacherViewModel> result = (JsonConvert.DeserializeObject<PagedResponse<TeacherViewModel>>(responseContent))!;
            return result;
        }
        else
        {
            return new PagedResponse<TeacherViewModel>();
        }
    }

    public async Task<(bool, string)> Update(UpdateTeacherRequest request)
    {
        string jsonRequest = JsonConvert.SerializeObject(request);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PutAsync("Teacher/Update", content);
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

