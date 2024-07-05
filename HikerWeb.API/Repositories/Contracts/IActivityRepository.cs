

using HikerWeb.API.Entities;
using HikerWeb.Models.DTOs.Activity;

namespace HikerWeb.API.Repositories.Contracts
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetItems(string searchParam);
        Task<Activity> GetItem(int id);
        Task<Activity> AddItem(AddActivityDto addActivityDto);
        Task<Activity> UpdateItem(UpdateActivityDto activity);
        Task<Activity> DeleteItem(int id);
        Task<IEnumerable<Activity>> GetItems();

        Task<IEnumerable<Activity>> GetItems(int clubId);
    }
}
