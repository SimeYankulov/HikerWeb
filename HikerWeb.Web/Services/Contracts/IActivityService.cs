using HikerWeb.Models.DTOs.Activity;
using HikerWeb.Models.DTOs.ActivityDtos;
using HikerWeb.Web.Pages;

namespace HikerWeb.Web.Services.Contracts
{
    public interface IActivityService
    {
        Task<IEnumerable<ResponseActivityDto>> GetItems();
        Task<IEnumerable<ActivityTypeDto>> GetItemsType();
        Task<ResponseActivityInfoDto> GetItem(int id);

        Task<IEnumerable<ResponseActivityDto>> GetItemsByClub(int id);
        Task <ResponseActivityInfoDto> CreateItem(AddActivityDto activity);
        Task<ResponseActivityInfoDto> UpdateItem(UpdateActivityDto activity);
        Task<UpdateActivityDto> GetItemToUpdate(int id);
    }
}
