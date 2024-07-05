using HikerWeb.API.Entities;
using HikerWeb.API.Extensions;
using HikerWeb.API.Repositories.Contracts;
using HikerWeb.Models.DTOs.UserDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikerWeb.API.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        } 
        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<ResponseUserDto>> GetCurrentUser()
        {
            User user = new User();

            if (User.Identity.IsAuthenticated)
            {
                user.Email = User.FindFirstValue(ClaimTypes.Email).ToString();
            }
            return Ok(user.ConvertToDto());
        }
        [HttpPost("LoginUser")]
        public async Task<ActionResult<LoginDto>> LoginUser(LoginDto user)
        {
            User loggedInUser = await this.userRepository.AuthenticateUser(user);
            
           
            if(loggedInUser != null) {

                var claimEmail = new Claim(ClaimTypes.Email, loggedInUser.Email);
                var claimName = new Claim(ClaimTypes.Name, loggedInUser.FName);
                var claimId = new Claim(ClaimTypes.NameIdentifier, loggedInUser.Id.ToString());

                var claimsIdentity = new ClaimsIdentity(
                  new[] { claimEmail,claimName,claimId },
                  CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal);

                var loggedInUserDto = loggedInUser.ConvertToDtoLogin();

                return await Task.FromResult(loggedInUserDto);
               
            }
        

           else { return BadRequest(); }

        }

        [HttpGet("LogOutUser")]
        public async Task<ActionResult<String>> LogOutUser()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok("Success");
        }


        [HttpGet("/Users/{Id}")]
        public async Task<ActionResult<IEnumerable<ResponseUserDto>>> GetUsers(int Id)
        {

            try
            {
                var users = await this.userRepository.GetItems(Id);

                if (users == null)
                {
                    return NotFound();
                }
                else
                {
                    var userDtos = users.ConvertToDto();

                    return Ok(userDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                   "Error retriving data from the database");
            }

        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ResponseUserInfoDto>> GetItem(int  Id)
        {
            try
            {
                var user = await this.userRepository.GetItem(Id);
                

                if(user == null)
                {
                    return BadRequest();
                }
                else
                {
                    var userDto = user.ConvertToDto();
                    
                    return Ok(userDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                         "Error retriving data from the database");
            }
        }
        [HttpGet("GetItemToUpdate/{userId}")]
        public async Task<ActionResult<UpdateUserDto>> GetItemToUpdate(int userId)
        {
            try
            {
                var user = await this.userRepository.GetItem(userId);

                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    var userDto = user.ConvertToUpdateDto();

                    return Ok(userDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest,
                              "Error retriving data from the database");
            }
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<bool>> DeleteItem(int userId)
        {
            try
            {
                var user = await this.userRepository.DeleteItem(userId);

                if(user != null)
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
                "Error writing data in the database");
              
            }
        }

        [HttpPost]
        public async Task<ActionResult<UpdateUserDto>> Register(UpdateUserDto userDto)
        {
            try
            {
                var newUser = await this.userRepository.AddItem(userDto);

                if(newUser == null)
                {
                    return BadRequest();
                }
                var user = await this.userRepository.GetItem(newUser.Id);

                if(user == null)
                {
                    return BadRequest();
                }

                var newUserDto = newUser.ConvertToUpdateDto();

                return Ok(newUserDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                 "Error writing data in the database");
            }
        }
        [HttpPut]
        public async Task<ActionResult<ResponseUserInfoDto>> UpdateItem(UpdateUserDto userDto)
        {
            try
            {
                var user = await this.userRepository.GetItem(userDto.Id);
                if (user == null)
                {
                    return NotFound("Not Found");
                }

                var result = await this.userRepository.UpdateItem(userDto);

                if (result != null)
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
                   "Error writing data in the database");
            }
        }

        [HttpPut("UpdateClub/{UserId}/{ClubId}")]
        public async Task<ActionResult<bool>> UpdateUserClub(int UserId,int ClubId)
        {
            try
            {
                var user = await this.userRepository.GetItem(UserId);

                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    var result = await this.userRepository.UpdateUsersClub(user.Id, ClubId);

                    return Ok(true);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest,
                              "Error writing data in the database");
            }
        }

        [HttpGet("ByClub/{ClubId}")]
        public async Task<ActionResult<IEnumerable<ResponseUserDto>>> GetUsersByClub(int ClubId)
        {

            try
            {
                var users = await this.userRepository.GetUsersByClub(ClubId);

                if (users == null)
                {
                    return NotFound();
                }
                else
                { 
                    return Ok(users);
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
