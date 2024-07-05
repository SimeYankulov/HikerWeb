using HikerWeb.API.Data;
using HikerWeb.API.Entities;
using HikerWeb.API.Extensions;
using HikerWeb.API.Repositories.Contracts;
using HikerWeb.Models.DTOs.ClubDtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace HikerWeb.API.Repositories
{
    public class ClubRepository : IClubReposirtory
    {
        private readonly HikerWebDBContext hikerWebDBContext;
        public ClubRepository(HikerWebDBContext hikerWebDBContext)
        {
                this.hikerWebDBContext = hikerWebDBContext; 
        }
        public async Task<Club> AddItem(UpdateClubDto club)
        {
            var result = await this.hikerWebDBContext.Clubs.AddAsync(club.ConvertToEntity());

            await this.hikerWebDBContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Club> DeleteItem(int id)
        {
            var item = await this.hikerWebDBContext.Clubs.FindAsync(id);

            if(item!= null)
            {
                this.hikerWebDBContext.Clubs.Remove(item);
                await this.hikerWebDBContext.SaveChangesAsync();
            }
            return item;
        }

        public async Task<Club> GetItem(int id)
        {
            var item = await this.hikerWebDBContext.Clubs.FindAsync(id);

            return item;
        }

        public async Task<IEnumerable<Club>> GetItems()
        {
            var items = await this.hikerWebDBContext.Clubs
                                .Where(c => c.Id != 13).ToListAsync();

            return items;
        }

        public async Task<IEnumerable<Club>> GetItems(string searchParam)
        {
            var items = await this.hikerWebDBContext.Clubs.Where
                        (c => c.ClubName.Contains(searchParam, StringComparison.OrdinalIgnoreCase) || 
                                  c.Place.Contains(searchParam, StringComparison.OrdinalIgnoreCase)).ToListAsync();

            return items;

        }

        public async Task<Club> UpdateItem(UpdateClubDto club)
        {
            var result = await this.hikerWebDBContext.Clubs.
                FirstOrDefaultAsync(c => c.Id == club.Id);

            if(result != null)
            {
                result.Email = club.Email;
                result.Password = club.Password;
                result.PhoneNumber = club.Phone;
                result.ClubName = club.ClubName;
                result.DateFormed = club.DateFormed;
                result.Place = club.Place;
                result.LogoUrl = club.LogoUrl;
                result.MembersCount = club.MembersCount;

                await this.hikerWebDBContext.SaveChangesAsync();

                return result;
            }

            return null;
          
        }
    }
}
