using System.Net.Http.Json;
using HikerWeb.Web.Services.Contracts;
using HikerWeb.Models.DTOs.Activity;
using HikerWeb.Models.DTOs.ActivityDtos;

namespace HikerWeb.Web.Services
{
    public class ActivityService : IActivityService
    {
        private readonly HttpClient httpClient;

        public ActivityService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ResponseActivityInfoDto> CreateItem(AddActivityDto activity)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync("/Activity", activity);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ResponseActivityInfoDto);
                    }
                    return await response.Content.ReadFromJsonAsync<ResponseActivityInfoDto>();
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

        public async Task<ResponseActivityInfoDto> GetItem(int id)
        {
            try
            {
                var response = await this.httpClient
                    .GetAsync($"/Activity/{id}");

                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent ) 
                    {
                        return default(ResponseActivityInfoDto);
                    }

                    return await response.Content.ReadFromJsonAsync<ResponseActivityInfoDto>();

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

        public async Task<IEnumerable<ResponseActivityDto>> GetItems()
        {
            try
            {
                var response = await this.httpClient.GetAsync("/Activity");
                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ResponseActivityDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ResponseActivityDto>>();
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

        public async Task<IEnumerable<ResponseActivityDto>> GetItemsByClub(int id)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"/Activity/ByClub/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ResponseActivityDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ResponseActivityDto>>();
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

        public async Task<IEnumerable<ActivityTypeDto>> GetItemsType()
        {
            try
            {
                var response = await this.httpClient.GetAsync("/ActivityType");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ActivityTypeDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ActivityTypeDto>>();
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

        public async Task<UpdateActivityDto> GetItemToUpdate(int id)
        {
            try
            {
                var response = await this.httpClient
                    .GetAsync($"/Activity/GetActivityToUpdate/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(UpdateActivityDto);
                    }

                    return await response.Content.ReadFromJsonAsync<UpdateActivityDto>();

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

        public async Task<ResponseActivityInfoDto> UpdateItem(UpdateActivityDto activity)
        {
            try
            {
                var response = await this.httpClient.PutAsJsonAsync("/Activity", activity);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default!;
                    }
                    else
                    {
                        return await response.Content.ReadFromJsonAsync<ResponseActivityInfoDto>();
                    }
                
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
