using HikerWeb.API.Entities;

namespace HikerWeb.API.Repositories.Contracts
{
    public interface IUserActivityRepository
    {
        Task<IEnumerable<UserActivity>> GetUsersForActivity(int activityId);
        Task<IEnumerable<UserActivity>> GetActivityForUser( int userId);
        Task<UserActivity> AddItem(UserActivity userActivity);
        Task<bool> DeleteItem(int userId,int activityId);
    }
}
