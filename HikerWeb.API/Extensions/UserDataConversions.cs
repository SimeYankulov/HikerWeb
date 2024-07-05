using HikerWeb.API.Entities;
using HikerWeb.Models.DTOs.UserDtos;

namespace HikerWeb.API.Extensions
{
    public static class UserDataConversions
    {
        public static IEnumerable<ResponseUserDto> ConvertToDto(this IEnumerable<User> users)
        {
            return (from user in users select new ResponseUserDto
              {
                  Id = user.Id,
                  FName = user.FName,
                  LName = user.LName
              }).ToList();
        }

        public static IEnumerable<ResponseUserDto> ConvertToDtoForActivity(this IEnumerable<UserActivity> UserActivities)
        {
            return (from userActivity in UserActivities
                    select new ResponseUserDto
                    {
                        Id = userActivity.UserId,
                        FName = userActivity.User.FName,
                        LName = userActivity.User.LName
                    }).ToList();
        }
        public static ResponseUserDto ConvertToDtoForActivity(this UserActivity userActivity)
        {
            return new ResponseUserDto
            {
                Id = userActivity.UserId,
                FName = userActivity.User.FName,
                LName = userActivity.User.LName
            };
        }
        public static LoginDto ConvertToDtoLogin(this User user)
        {
            return new LoginDto
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password
            };
        }
        public static ResponseUserInfoDto ConvertToDto(this User user)
        {
            return new ResponseUserInfoDto
            {
                Id = user.Id,
                Fname = user.FName,
                Lname = user.LName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                DOB = user.DOB,
                ClubDto = user.Club.ConvertToShortDto(),
                ProfilePicture = user.profilePicture
            };
                
                
        }
        public static UpdateUserDto ConvertToUpdateDto(this User user)
        {
            return new UpdateUserDto
            {
                Id = user.Id,
                Fname = user.FName,
                Lname = user.LName,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                DOB = user.DOB,
                ProfilePicture = user.profilePicture
            };


        }

        public static User ConvertToEntity(this RegisterUserDto user)
        {
            return new User { };
                
        }

        public static User ConvertToEntity(this UpdateUserDto user)
        {
            return new User {
                FName = user.Fname,
                LName = user.Lname,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                ClubId = 13,
                DOB = user.DOB,
                profilePicture = user.ProfilePicture
            };
       
        }

    }
}
