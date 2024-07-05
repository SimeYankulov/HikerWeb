using HikerWeb.Models.DTOs.ClubDtos;
using HikerWeb.Web.Services.Contracts;
using System.Net.Http.Json;

namespace HikerWeb.Web.Services
{
    public class ClubService : IClubService
    {
        private readonly HttpClient httpClient;

        public ClubService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UpdateClubDto> GetItemToUpdate(int id)
        {
            try
            {
                var response = await this.httpClient
                    .GetAsync($"/Club/GetItemToUpdate/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(UpdateClubDto);
                    }

                    return await response.Content.ReadFromJsonAsync<UpdateClubDto>();

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

        public async Task<ResponseClubInfoDto> GetItem(int id)
        {
            try
            {
                var response = await this.httpClient
                    .GetAsync($"/Club/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ResponseClubInfoDto);
                    }

                    return await response.Content.ReadFromJsonAsync<ResponseClubInfoDto>();

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

        public async Task<IEnumerable<ResponseClubLogoDto>> GetItems(string searchParam)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"/Club?search={searchParam}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ResponseClubLogoDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ResponseClubLogoDto>>();
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

        public async Task<UpdateClubDto> UpdateItem(UpdateClubDto club)
        {

            try
            {
                var response = await this.httpClient.PutAsJsonAsync("/Club", club);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(UpdateClubDto);
                    }
                    return await response.Content.ReadFromJsonAsync<UpdateClubDto>();
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

        public async Task<UpdateClubDto> CreateItem(UpdateClubDto club)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync("/Club", club);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default!;
                    }
                    else
                    {
                        return await response.Content.ReadFromJsonAsync<UpdateClubDto>();
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

