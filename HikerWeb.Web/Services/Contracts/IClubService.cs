using HikerWeb.Models.DTOs.ClubDtos;

namespace HikerWeb.Web.Services.Contracts
{
    public interface IClubService
    {
        Task<IEnumerable<ResponseClubLogoDto>> GetItems(string SearchParam);
        Task<ResponseClubInfoDto> GetItem(int id);
        Task<UpdateClubDto> GetItemToUpdate(int id);

        Task<UpdateClubDto> UpdateItem(UpdateClubDto club);
        Task<UpdateClubDto> CreateItem(UpdateClubDto club);
    }
}
