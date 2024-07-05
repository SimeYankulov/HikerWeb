using HikerWeb.Models.DTOs.UserDtos;

namespace HikerWeb.Web.Services.Contracts
{
    public interface IUserService
    {
        Task<LoginDto> Login(LoginDto user);
        Task<ResponseUserInfoDto> GetUser(int id);
        Task<IEnumerable<ResponseUserDto>> GetItems(int id);
        Task<UpdateUserDto> GetItemToUpdate(int id);
        Task<UpdateUserDto> UpdateItem(UpdateUserDto user);
        Task<UpdateUserDto> CreateItem(UpdateUserDto user);
        Task<bool> UpdateUsersClub(int UserId, int ClubId);
        Task<IEnumerable<ResponseUserDto>> GetClubMembers(int ClubId);
    }
}
