using HikerWeb.API.Entities;
using HikerWeb.Models.DTOs.UserDtos;

namespace HikerWeb.API.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> AuthenticateUser(LoginDto user);
        Task<IEnumerable<User>> GetItems(int id);
        Task<User> GetItem(int id);
        Task<User> AddItem(UpdateUserDto user);
        Task<User> UpdateItem(UpdateUserDto user);
        Task<User> DeleteItem(int id);

        Task<bool> UpdateUsersClub(int UserId, int ClubId);
        Task<IEnumerable<ResponseUserDto>> GetUsersByClub(int ClubId);
    }
}
