using Microsoft.AspNetCore.Components;
using HikerWeb.Web.Services.Contracts;
using HikerWeb.Models.DTOs.Activity;

namespace HikerWeb.Web.Pages
{
    public class ActivitiesBase:ComponentBase
    {
        [Inject]
        public IActivityService ActivityService { get; set; }
        
        public IEnumerable<ResponseActivityDto> Activities { get; set; }

        public IEnumerable<ResponseActivityDto> FilteredActivities { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Activities = await ActivityService.GetItems();
            FilteredActivities = Activities;
        }

        protected IOrderedEnumerable<IGrouping<int, ResponseActivityDto>> GetGroupedActivities()
        {
            return from activity in FilteredActivities
                   group activity by activity.ActivityType.Id into actByTypeGroup
                   orderby actByTypeGroup.Key
                   select actByTypeGroup;
        }

        protected string GetActivityType(IGrouping<int, ResponseActivityDto> groupedActivityDtos)
        {
            return groupedActivityDtos.FirstOrDefault
                (ag => ag.ActivityType.Id == groupedActivityDtos.Key)!.ActivityType.Type;
        }

        public async void UpdateFilteredActivities(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                FilteredActivities = Activities;
            }
            else
            {
                FilteredActivities = Activities.Where(
                    a => a.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                    || a.Date.Contains(searchTerm,StringComparison.OrdinalIgnoreCase) 
                    );
            }
        }
    }
}
