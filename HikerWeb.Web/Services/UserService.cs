using HikerWeb.Models.DTOs.UserDtos;
using HikerWeb.Web.Services.Contracts;
using Microsoft.VisualBasic;
using System.Net.Http.Json;

namespace HikerWeb.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
 

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UpdateUserDto> CreateItem(UpdateUserDto user)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync("/User", user);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default!;
                    }
                    return await response.Content.ReadFromJsonAsync<UpdateUserDto>();
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

        public async Task<IEnumerable<ResponseUserDto>> GetItems(int id)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"/Users/{id}");
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

        public async Task<UpdateUserDto> GetItemToUpdate(int id)
        {
            try
            {
                var response = await this.httpClient
                    .GetAsync($"/User/GetItemToUpdate/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(UpdateUserDto);
                    }

                    return await response.Content.ReadFromJsonAsync<UpdateUserDto>();

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

        public async Task<ResponseUserInfoDto> GetUser(int id)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"/User/{id}");

                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ResponseUserInfoDto);
                    }
                    
                    return await response.Content.ReadFromJsonAsync<ResponseUserInfoDto>();
                    
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

        public async Task<IEnumerable<ResponseUserDto>> GetClubMembers(int ClubId)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"/User/ByClub/{ClubId}");
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

        public async Task<LoginDto> Login(LoginDto user)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("/User/LoginUser", user);

                if(response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(LoginDto);
                    }
                    return await response.Content.ReadFromJsonAsync<LoginDto>();
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

        public async Task<UpdateUserDto> UpdateItem(UpdateUserDto user)
        {
            try
            {
                var response = await this.httpClient.PutAsJsonAsync("/User", user);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(UpdateUserDto);
                    }
                    return await response.Content.ReadFromJsonAsync<UpdateUserDto>();
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

        public async Task<bool> UpdateUsersClub(int UserId, int ClubId)
        {
            try
            {
                var response = await this.httpClient.PutAsJsonAsync($"/User/UpdateClub/{UserId}/{ClubId}",ClubId);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return false;
                    }
                    return true;
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
