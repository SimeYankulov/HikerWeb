using HikerWeb.API.Data;
using HikerWeb.API.Entities;
using HikerWeb.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HikerWeb.API.Repositories
{
    public class UserActivityRepository : IUserActivityRepository
    {
        private readonly HikerWebDBContext hikerWebDBContext;

        public UserActivityRepository(HikerWebDBContext hikerWebDBContext)
        {
            this.hikerWebDBContext = hikerWebDBContext;
        }
        public async Task<UserActivity> AddItem(UserActivity userActivity)
        {
            var result = this.hikerWebDBContext.AddAsync(userActivity);
            
            await this.hikerWebDBContext.SaveChangesAsync();

            return result.Result.Entity;
        }

        public async Task<bool> DeleteItem(int userId,int activityId)
        {
            var item = await this.hikerWebDBContext.UserActivities
                                    .Where(ua => ua.UserId == userId)
                                    .Where(ua => ua.ActivityId == activityId)
                                    .FirstAsync();

            if (item != null)
            {
                this.hikerWebDBContext.UserActivities.Remove(item);
                await this.hikerWebDBContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<IEnumerable<UserActivity>> GetActivityForUser(int userId)
        {
            var items = await this.hikerWebDBContext.UserActivities
                                    .Include(ua => ua.Activity)
                                    .Where(ua => ua.UserId == userId)
                                    .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<UserActivity>> GetUsersForActivity(int activityId)
        {
            var items = await this.hikerWebDBContext.UserActivities
                             .Include(ua => ua.User)
                             .Where(ua => ua.ActivityId == activityId)
                             .ToListAsync();

            return items;
        }
    }
}
