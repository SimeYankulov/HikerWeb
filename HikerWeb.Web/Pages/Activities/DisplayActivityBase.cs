using HikerWeb.Models.DTOs.Activity;
using Microsoft.AspNetCore.Components;

namespace HikerWeb.Web.Pages
{
    public class DisplayActivityBase:ComponentBase
    {
        [Parameter]
        public IEnumerable<ResponseActivityDto> Activities { get; set; }
    }
}
