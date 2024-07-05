using HikerWeb.Models.DTOs.ActivityDtos;
using HikerWeb.Models.DTOs.UserDtos;

namespace HikerWeb.Web.Services.Contracts
{
    public interface IUserActivityService
    {
        Task<IEnumerable<ResponseUserDto>> GetUsersForActivity(int activityId);
        Task<IEnumerable<ResponseActivityShortDto>> GetActivitiesForUser(int userId);
        Task<ResponseUserDto> AddItem(int userId, int activityId);
        Task<bool> DeleteItem(int userId, int activityId);
    }
}
