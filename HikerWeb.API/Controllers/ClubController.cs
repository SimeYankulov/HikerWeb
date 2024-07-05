using HikerWeb.API.Entities;
using HikerWeb.API.Extensions;
using HikerWeb.API.Repositories.Contracts;
using HikerWeb.Models.DTOs.ClubDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HikerWeb.API.Controllers
{
    [Route("Club")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubReposirtory clubRepository;

        public ClubController(IClubReposirtory clubReposirtory)
        {
            this.clubRepository = clubReposirtory;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseClubLogoDto>>> GetClubs(
            [FromQuery] String? SearchParam = null

            )
        {
            try
            {
                IEnumerable<Club> clubs;

                if(SearchParam.IsNullOrEmpty())
                {
                    clubs = await this.clubRepository.GetItems();
                }
                else
                {
                    clubs = await this.clubRepository.GetItems(SearchParam);
                }

                if(clubs == null)
                {
                    return NotFound(); 
                }
                else
                {
                    var clubDtos = clubs.ConvertToDto();

                    return Ok(clubDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                              "Error retriving data from the database");
            }
        }

        [HttpGet("{clubId}")]
        public async Task<ActionResult<ResponseClubInfoDto>> GetItem(int clubId)
        {
            try
            {
                var club = await this.clubRepository.GetItem(clubId);

                if(club == null)
                {
                    return NotFound();  
                }
                else
                {
                    var clubDto = club.ConvertToDto();

                    return Ok(clubDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest,
                              "Error retriving data from the database");
            }
        }
        [HttpGet("GetItemToUpdate/{clubId}")]
        public async Task<ActionResult<UpdateClubDto>> GetItemToUpdate(int clubId)
        {
            try
            {
                var club = await this.clubRepository.GetItem(clubId);

                if (club == null)
                {
                    return NotFound();
                }
                else
                {
                    var clubDto = club.ConvertToUpdateDto();

                    return Ok(clubDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest,
                              "Error retriving data from the database");
            }
        }
        [HttpDelete("{clubId}")]
        public async Task<ActionResult<bool>> DeleteItem(int clubId)
        {
            try
            {
                var club = await this.clubRepository.DeleteItem(clubId);

                if(club != null)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                              "Error retriving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UpdateClubDto>> Register(UpdateClubDto clubDto)
        {
            try
            {
                var newClub = await this.clubRepository.AddItem(clubDto);

                if(newClub == null)
                {
                    return BadRequest();
                }
                var club = await this.clubRepository.GetItem(newClub.Id);

                if(club == null)
                {
                    return BadRequest(); 
                }

                var newClubDto = newClub.ConvertToDto();

                return Ok(newClubDto);
                
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest,
                              "Error retriving data from the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<UpdateClubDto>> UpdateItem(UpdateClubDto clubDto)
        {
            try
            {
                var club = await this.clubRepository.GetItem(clubDto.Id);
                if(club == null)
                {
                    return NotFound("Not Found");
                }

                var result = await this.clubRepository.UpdateItem(clubDto);

                if(result != null)
                {
                    return Ok(result.ConvertToUpdateDto());
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                              "Error retriving data from the database");

            }
        }
    }
}
