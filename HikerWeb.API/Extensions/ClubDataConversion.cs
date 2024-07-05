using HikerWeb.API.Entities;
using HikerWeb.Models.DTOs.ClubDtos;

namespace HikerWeb.API.Extensions
{
    public static class ClubDataConversion
    {
        public static IEnumerable<ResponseClubLogoDto> ConvertToDto(this IEnumerable<Club> clubs)
        {
            return (from club in clubs
                    select new ResponseClubLogoDto
                    {
                        Id = club.Id,
                        Name = club.ClubName,
                        LogoUrl = club.LogoUrl
                    }).ToList();
        }

        public static ResponseClubInfoDto ConvertToDto(this Club club)
        {
            return new ResponseClubInfoDto 
            { 
                Id = club.Id,
                Email = club.Email,
                Phone = club.PhoneNumber,
                ClubName= club.ClubName,
                DateFormed = club.DateFormed,
                Place = club.Place,
                LogoUrl = club.LogoUrl,
                MembersCount = club.MembersCount
            };


        }
        public static UpdateClubDto ConvertToUpdateDto(this Club club)
        {
            return new UpdateClubDto
            {
                Id = club.Id,
                Email = club.Email,
                Password = club.Password,
                Phone = club.PhoneNumber,
                ClubName = club.ClubName,
                DateFormed = club.DateFormed,
                Place = club.Place,
                LogoUrl = club.LogoUrl,
                MembersCount = club.MembersCount
            };


        }

        public static ResponseClubDto ConvertToShortDto(this Club club)
        {
            if(club == null)
            {
                return new ResponseClubDto { Id = 0, Name = "None" };
            }
            else
            {
                return new ResponseClubDto
                {
                    Id = club.Id,
                    Name = club.ClubName
                };
            }
      
        }

        public static Club ConvertToEntity(this RegisterClubDto club)
        {
            return new Club
            {
                Email = club.Email,
                Password = club.Password,
                PhoneNumber = club.PhoneNumber,
                ClubName = club.ClubName,
                DateFormed = club.DateFormed,
                Place = club.Place,
                LogoUrl = club.LogoUrl,
                MembersCount = club.MembersCount
            };

        }

        public static Club ConvertToEntity(this UpdateClubDto club)
        {
            return new Club { 
                Email = club.Email,
                Password = club.Password,
                PhoneNumber = club.Phone,
                ClubName = club.ClubName,
                DateFormed = club.DateFormed,
                Place = club.Place,
                LogoUrl = club.LogoUrl,
                MembersCount = club.MembersCount

            };


        }
    }
}
