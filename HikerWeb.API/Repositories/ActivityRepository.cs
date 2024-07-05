using HikerWeb.API.Data;

using HikerWeb.API.Repositories.Contracts;
using HikerWeb.API.Entities;
using Microsoft.EntityFrameworkCore;
using HikerWeb.API.Extensions;
using HikerWeb.Models.DTOs.Activity;

namespace HikerWeb.API.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly HikerWebDBContext hikerWebDBContext;
        private readonly IActivityTypeRepository activityTypeRepository;
        private readonly IClubReposirtory clubRepository;

        public ActivityRepository(HikerWebDBContext hikerWebDBContext,
            IActivityTypeRepository activityTypeRepository,
            IClubReposirtory clubRepository)
        {
            this.hikerWebDBContext = hikerWebDBContext;
            this.activityTypeRepository = activityTypeRepository;
            this.clubRepository = clubRepository;
        }
        public async Task<Activity> AddItem(AddActivityDto addActivityDto)
        {
            var act = addActivityDto.ConvertToEntity();

            act.Club = await this.clubRepository.GetItem(act.ClubId);
            act.ActivityType = await this.activityTypeRepository.GetItem(act.ActivityTypeId);
            
            var result = await this.hikerWebDBContext.AddAsync(act);

            await this.hikerWebDBContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Activity> DeleteItem(int id)
        {
            var item = await this.hikerWebDBContext.Activities.FindAsync(id);

            if(item != null)
            {
                this.hikerWebDBContext.Remove(item);

                await this.hikerWebDBContext.SaveChangesAsync();

            }
            return item;
        }

        public async Task<Activity> GetItem(int id)
        {
            var item = await this.hikerWebDBContext.Activities
                                                        .Include(a => a.Club)
                                                        .Include(a => a.ActivityType)
                                                        .SingleOrDefaultAsync(a => a.Id == id);

            return item;
        }

        public async Task<IEnumerable<Activity>> GetItems(string searchParam)
        {
             
            var items = await this.hikerWebDBContext.Activities
                                                     .Include(a => a.Club)
                                                     .Include(a => a.ActivityType)
                                                     .Where(a => a.Date == searchParam ||
                                                     a.Place.Contains(searchParam))
                                                      .ToListAsync();

            return items; 
        }

        public async Task<IEnumerable<Activity>> GetItems()
        {
            var items = await this.hikerWebDBContext.Activities
                                               .Include(a => a.Club)
                                               .Include(a => a.ActivityType)
                                                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<Activity>> GetItems(int clubId)
        {
            var items = await this.hikerWebDBContext.Activities
                                                    .Where(a => a.ClubId == clubId)
                                                    .Include(a => a.ActivityType).ToListAsync();
            return items;
        }

        public async Task<Activity> UpdateItem(UpdateActivityDto activity)
        {
            var item = await this.hikerWebDBContext.Activities
                                                       .Include(a => a.Club)
                                                       .Include(a => a.ActivityType)
                                                       .SingleOrDefaultAsync(a => a.Id == activity.Id);
            item.Title = activity.Title;
            item.Description = activity.Description;
            item.Dificulty = activity.Difficulty;
            item    .Elevation = activity.Elevation;
            item.Distance = activity.Distance;
            item.Conditions = activity.Conditions;
            item    .Date = activity.Date;
            item.Place = activity.Place;
            item.StartPoint = activity.StartPoint;
            item.EndPoint = activity.EndPoint;
            item.ImageLink = activity.ImageLink;

            await this.hikerWebDBContext.SaveChangesAsync();

            return item;
        }
    }
}
