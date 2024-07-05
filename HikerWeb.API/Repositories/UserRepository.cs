using HikerWeb.API.Data;
using HikerWeb.API.Entities;
using HikerWeb.API.Extensions;
using HikerWeb.API.Repositories.Contracts;
using HikerWeb.Models.DTOs.UserDtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HikerWeb.API.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly HikerWebDBContext hikerWebDBContext;

        public UserRepository(HikerWebDBContext hikerWebDBContext)
        {
            this.hikerWebDBContext = hikerWebDBContext;
        }
        public async Task<User> AuthenticateUser(LoginDto user)
        {
            var result = await this.hikerWebDBContext.Users.Where(u => u.Email.Equals(user.Email)
                                                                   && u.Password.Equals(user.Password)
                                                                   ).FirstOrDefaultAsync();

            return result;
        }
        public async Task<User> AddItem(UpdateUserDto user)
        {
            var result = await this.hikerWebDBContext.Users.AddAsync(user.ConvertToEntity());

            await this.hikerWebDBContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<User> DeleteItem(int id)
        {
            var item = await this.hikerWebDBContext.Users.FindAsync(id);
            
            if (item != null)
            {
                this.hikerWebDBContext.Users.Remove(item);
                await this.hikerWebDBContext.SaveChangesAsync();
            }
            return item;
        }

        public async Task<User> GetItem(int id)
        {
            var item = await this.hikerWebDBContext.Users.Include(u => u.Club).SingleOrDefaultAsync(u => u.Id == id);

            if (item != null)
            {
                return item;
            }
            else
            {
                return new User();
            }
        }

        public async Task<IEnumerable<User>> GetItems(int id)
        {
            var users = await this.hikerWebDBContext.Users.Where(u => u.Id != id).ToListAsync();
            return users;
        }

        public async Task<User> UpdateItem(UpdateUserDto user)
        {
            var result = await this.hikerWebDBContext.Users.
                FirstOrDefaultAsync(u => u.Id == user.Id);

            if (result != null)
            {
                result.Email = user.Email;
                result.Password = user.Password;
                result.PhoneNumber = user.PhoneNumber;
                result.FName = user.Fname;
                result.LName = user.Lname;
                result.DOB = user.DOB;
                result.profilePicture = user.ProfilePicture;
                await this.hikerWebDBContext.SaveChangesAsync();

                return result;
            }

            return null;

        }

        public async Task<bool> UpdateUsersClub(int UserId, int ClubId)
        {
            var result = await this.hikerWebDBContext.Users.
            FirstOrDefaultAsync(u => u.Id == UserId);

            if (result != null)
            {
                result.ClubId = ClubId;
                await this.hikerWebDBContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ResponseUserDto>> GetUsersByClub(int ClubId)
        {
            var users = await this.hikerWebDBContext.Users.Where(u => u.ClubId == ClubId).ToListAsync();

            if (users.IsNullOrEmpty())
            {
                return Enumerable.Empty<ResponseUserDto>();
            }
            else
            {
                return users.ConvertToDto();
            }
        }
    }
}
