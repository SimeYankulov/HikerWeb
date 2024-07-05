using HikerWeb.API.Entities;
using HikerWeb.Models.DTOs.ActivityDtos;

namespace HikerWeb.API.Extensions
{
    public static class ActivityTypeDataConversion
    {
        public static ActivityTypeDto ConvertToDto(this ActivityType activityType)
        {
            return new ActivityTypeDto
            {
                Id = activityType.Id,
                Type= activityType.Type
            };
        }
        public static IEnumerable<ActivityTypeDto> ConvertToDto(this IEnumerable<ActivityType> activityTypes)
        {
            return (from activityType in activityTypes
                select new ActivityTypeDto
                 {
                    Id = activityType.Id,
                    Type = activityType.Type

                 }).ToList();
        }
        public static ActivityType ConvertToEntity(this ActivityTypeDto activityType)
        {
            return new ActivityType
            {

            };
        }
    }
}
