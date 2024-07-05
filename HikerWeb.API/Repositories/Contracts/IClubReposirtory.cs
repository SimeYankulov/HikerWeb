using HikerWeb.API.Entities;
using HikerWeb.Models.DTOs.ClubDtos;

namespace HikerWeb.API.Repositories.Contracts
{
    public interface IClubReposirtory
    {
        Task<IEnumerable<Club>> GetItems();
        Task<IEnumerable<Club>> GetItems(string searchParam);
        Task<Club> GetItem(int id);
        Task<Club> AddItem(UpdateClubDto club);
        Task<Club> UpdateItem(UpdateClubDto club);
        Task<Club> DeleteItem(int id);
    }
}
