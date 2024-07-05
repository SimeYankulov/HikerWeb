using HikerWeb.Models.DTOs;
using HikerWeb.Models.DTOs.Activity;
using HikerWeb.Models.DTOs.ActivityDtos;
using HikerWeb.Models.DTOs.UserDtos;
using HikerWeb.Web.Services.Contracts;
using System.Net.Http.Json;

namespace HikerWeb.Web.Services
{
    public class UserActivityService : IUserActivityService
    {
        private readonly HttpClient httpClient;

        public UserActivityService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<ResponseUserDto> AddItem(int userId, int activityId)
        {
            try
            {
                var data = new CreateUserActivity { UserId = userId, ActivityId = activityId };
                var response = await httpClient.PostAsJsonAsync($"/UserActivity",data);

                if(response!= null)
                {
                    return await response.Content.ReadFromJsonAsync<ResponseUserDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteItem(int userId, int activityId)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"/UserActivity/{userId}/{activityId}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ResponseActivityShortDto>> GetActivitiesForUser(int userId)
        {
            try
            {
                var response = await httpClient.GetAsync($"/UserActivity/ForUser/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ResponseActivityShortDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ResponseActivityShortDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ResponseUserDto>> GetUsersForActivity(int activityId)
        {
            try
            {
                var response = await httpClient.GetAsync($"/UserActivity/ForActivity/{activityId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ResponseUserDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ResponseUserDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
