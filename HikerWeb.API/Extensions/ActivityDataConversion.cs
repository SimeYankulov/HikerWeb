
using HikerWeb.API.Entities;
using HikerWeb.API.Repositories.Contracts;
using HikerWeb.Models.DTOs.Activity;
using HikerWeb.Models.DTOs.ActivityDtos;

namespace HikerWeb.API.Extensions
{
    public static class ActivityDataConversion
    {
        public static IEnumerable<ResponseActivityDto> ConvertToDto(this IEnumerable<Activity> activites)
        {
            return (from activity in activites
                    select new ResponseActivityDto
                    {
                        Id = activity.Id,
                        Title = activity.Title,
                        Date = activity.Date,
                        ImageLink = activity.ImageLink,
                        ActivityType = activity.ActivityType.ConvertToDto(),
                        Club = activity.Club.ConvertToShortDto()

                    }).ToList();
        }
        public static ResponseActivityInfoDto ConvertToDto(this Activity activity)
        {
            return new ResponseActivityInfoDto
            {
                Id = activity.Id,
                Title = activity.Title,
                Description = activity.Description,
                Dificulty = activity.Dificulty,
                Elevation = activity.Elevation,
                Distance = activity.Distance,
                Conditions = activity.Conditions,
                Date = activity.Date,
                Place = activity.Place,
                StartPoint = activity.StartPoint,
                EndPoint = activity.EndPoint,
                ImageLink = activity.ImageLink,

                ClubDto = activity.Club.ConvertToShortDto(),
                Type = activity.ActivityType.ConvertToDto()
            };
        }
        public static UpdateActivityDto ConvertToUpdateDto(this Activity activity)
        {
            return new UpdateActivityDto
            {
                Id = activity.Id,
                Title = activity.Title,
                Description = activity.Description,
                Difficulty = activity.Dificulty,
                Elevation = activity.Elevation,
                Distance = activity.Distance,
                Conditions = activity.Conditions,
                Date = activity.Date,
                Place = activity.Place,
                StartPoint = activity.StartPoint,
                EndPoint = activity.EndPoint,
                ImageLink = activity.ImageLink

            };
        }
        public static Activity ConvertToEntity(this AddActivityDto activityDto)
        {
            return new Activity
            {
                Title = activityDto.Title,
                Description = activityDto.Description,
                Dificulty = activityDto.Difficulty,
                Elevation = activityDto.Elevation,
                Distance = activityDto.Distance,
                Conditions = activityDto.Conditions,
                Date = activityDto.Date,
                Place = activityDto.Place,
                StartPoint = activityDto.StartPoint,
                EndPoint = activityDto.EndPoint,
                ImageLink = activityDto.ImageLink,
                ClubId = activityDto.ClubId,
                ActivityTypeId = activityDto.ActivityTypeId,
                Latitude = activityDto.Latitude,
                Longitude = activityDto.Longitude
            };
        }

        public static IEnumerable<ResponseActivityShortDto> ConvertToDto
            (this IEnumerable<UserActivity> userActivities)
        {
            return (from userActivity in userActivities
                    select new ResponseActivityShortDto
                    {
                        Id = userActivity.ActivityId,
                        Title = userActivity.Activity.Title,
                        Date = userActivity.Activity.Date

                    }).ToList();
        }
    }
}
