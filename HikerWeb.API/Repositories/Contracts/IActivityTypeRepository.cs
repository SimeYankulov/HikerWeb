using HikerWeb.API.Entities;
using HikerWeb.Models.DTOs.ActivityDtos;

namespace HikerWeb.API.Repositories.Contracts
{
    public interface IActivityTypeRepository
    {
        Task<ActivityType> AddItem(ActivityTypeDto activityType);
        Task<ActivityType> GetItem(int id);
        Task <IEnumerable<ActivityType>> GetItems();
    }
}
