using HikerWeb.Models.DTOs.ClubDtos;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace HikerWeb.Web.Pages.Clubs
{
    public class ClubsBase : ComponentBase
    {
        [Inject]
        public IClubService ClubService { get; set; }

        //EventCallback<string> OnSearchChanged;
        public IEnumerable<ResponseClubLogoDto> Clubs { get; set; } = new List<ResponseClubLogoDto>();

        public IEnumerable<ResponseClubLogoDto> FilteredClubs { get; set; } = new List<ResponseClubLogoDto>();
        protected override async Task OnInitializedAsync()
        {
            Clubs = await ClubService.GetItems(string.Empty);
            FilteredClubs = Clubs;
        }

        public async void UpdateFilteredClubs(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                FilteredClubs = Clubs;
            }
            else
            {
                FilteredClubs = Clubs.Where(c => c.Name.Contains
                                            (searchTerm, StringComparison.OrdinalIgnoreCase));
              
            }
        }

    }
}
