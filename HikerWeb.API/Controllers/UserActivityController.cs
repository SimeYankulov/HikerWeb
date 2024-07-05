using HikerWeb.API.Entities;
using HikerWeb.API.Extensions;
using HikerWeb.API.Repositories.Contracts;
using HikerWeb.Models.DTOs;
using HikerWeb.Models.DTOs.ActivityDtos;
using HikerWeb.Models.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace HikerWeb.API.Controllers
{
    [Route("UserActivity")]
    [ApiController]
    public class UserActivityController : ControllerBase
    {
        private readonly IUserActivityRepository userActivityRepository;
        private readonly IUserRepository userRepository;
        private readonly IActivityRepository activityRepository;

        public UserActivityController(
            IUserActivityRepository userActivityRepository,
            IUserRepository userRepository,
            IActivityRepository activityRepository)
        {
            this.userActivityRepository = userActivityRepository;
            this.userRepository = userRepository;
            this.activityRepository = activityRepository;
        }

        [HttpGet("ForUser/{UserId}")]
        public async Task<ActionResult<ResponseActivityShortDto>> GetActivitiesForUser(int UserId)
        {
            try
            {
                var result = await this.userActivityRepository.GetActivityForUser(UserId);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    var activityDtos = result.ConvertToDto();

                    return Ok(activityDtos);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("ForActivity/{ActivityId}")]
        public async Task<ActionResult<ResponseUserDto>> GetUsersForActivity(int ActivityId)
        {
            try
            {
                var result = await this.userActivityRepository.GetUsersForActivity(ActivityId);

                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    var users = result.ConvertToDtoForActivity();
                    return Ok(users);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult<ResponseUserDto>> AddItem(CreateUserActivity userActivityDto)
        {
            try
            {
                var userActivity = new UserActivity(
                    );
                userActivity.UserId = userActivityDto.UserId;
                userActivity.ActivityId = userActivity.ActivityId;
                userActivity.Activity = await activityRepository.GetItem(id: userActivityDto.ActivityId);
                userActivity.User = await userRepository.GetItem(id: userActivityDto.UserId);

                var newUserAct = await this.userActivityRepository.AddItem(userActivity);
                if (newUserAct == null)
                {
                    return BadRequest();
                }

                var newUserToAct = newUserAct.ConvertToDtoForActivity();

                return Ok(newUserToAct);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{userId}/{activityId}")]
        public async Task<ActionResult<bool>> DeleteItem(int userId,int activityId)
        {
            try
            {
                var result = await this.userActivityRepository.DeleteItem(userId,activityId);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                              "Error retriving data from the database");
            }
        }

    }
}
