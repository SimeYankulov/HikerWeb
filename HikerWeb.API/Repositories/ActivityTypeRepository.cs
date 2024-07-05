using HikerWeb.API.Data;
using HikerWeb.API.Entities;
using HikerWeb.API.Extensions;
using HikerWeb.API.Repositories.Contracts;
using HikerWeb.Models.DTOs.ActivityDtos;
using Microsoft.EntityFrameworkCore;

namespace HikerWeb.API.Repositories
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly HikerWebDBContext hikerWebDBContext;

        public ActivityTypeRepository(HikerWebDBContext hikerWebDBContext)
        {
            this.hikerWebDBContext = hikerWebDBContext;
        }
        public async Task<ActivityType> AddItem(ActivityTypeDto activityType)
        {
            var result = await this.hikerWebDBContext.ActivityTypes.AddAsync(activityType.ConvertToEntity());

            await this.hikerWebDBContext.SaveChangesAsync();

            return result.Entity;

        }

        public async Task<ActivityType> GetItem(int id)
        {
            var result = await this.hikerWebDBContext.ActivityTypes.FindAsync(id);

            return result;
        }

        public async Task<IEnumerable<ActivityType>> GetItems()
        {
            var items = await this.hikerWebDBContext.ActivityTypes.ToListAsync();

            return items;
        }
    }
}
