using HikerWeb.API.Entities;
using HikerWeb.API.Extensions;
using HikerWeb.API.Repositories.Contracts;
using HikerWeb.Models.DTOs.Activity;
using Microsoft.AspNetCore.Mvc;

namespace HikerWeb.API.Controllers
{
    [Route("Activity")]
    [ApiController]
    public class ActivityController:ControllerBase
    {
        private readonly IActivityRepository activityRepository;

        public ActivityController(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseActivityDto>>> GetActivities(
            [FromQuery] String? searchParam = null
            )
            {
            try
            {
                IEnumerable<Activity> activities;

                if(searchParam != null)
                {
                    activities = await this.activityRepository.GetItems(searchParam);
                }
                else
                {
                    activities = await this.activityRepository.GetItems();
                }

                if(activities == null)
                {
                    return NotFound();
                }
                else
                {
                    var activityDtos = activities.ConvertToDto();

                    return Ok(activityDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                "Error retriving data from the database");
                
            }
        }

        [HttpGet("{activityId}")]
        public async Task<ActionResult<ResponseActivityInfoDto>> GetActivity(int activityId)
        {
            try
            {
                var activity = await this.activityRepository.GetItem(activityId);

                if(activity == null)
                {
                    return NotFound();
                }
                else
                {
                    var activityDto = activity.ConvertToDto();

                    return Ok(activityDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                "Error retriving data from the database");
            }
        }
        [HttpGet("GetActivityToUpdate/{activityId}")]
        public async Task<ActionResult<UpdateActivityDto>> GetActivityToUpdate(int activityId)
        {
            try
            {
                var activity = await this.activityRepository.GetItem(activityId);

                if (activity == null)
                {
                    return NotFound();
                }
                else
                {
                    var activityDto = activity.ConvertToUpdateDto();

                    return Ok(activityDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                "Error retriving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseActivityDto>> AddActivity(AddActivityDto activityDto)
        {
            try
            {
                var newActivity = await this.activityRepository.AddItem(activityDto);

                if (newActivity == null)
                {
                    return BadRequest();
                }
                var activity = await this.activityRepository.GetItem(newActivity.Id);

                if (activity == null)
                {
                    return BadRequest();
                }

                var newActivityDto = newActivity.ConvertToDto();

                //return CreatedAtAction(nameof(GetActivity), new { newActivityDto.Id }, newActivityDto);

                return Ok(newActivityDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest,
                              "Error retriving data from the database");
            }
        }

        [HttpGet("ByClub/{id}")]
        public async Task<ActionResult<IEnumerable<ResponseActivityDto>>> GetActivities(int id)
        {
            try
            {
                IEnumerable<Activity> activities;

                 activities = await this.activityRepository.GetItems(id);
                

                if (activities == null)
                {
                    return NotFound();
                }
                else
                {
                    var activityDtos = activities.ConvertToDto();

                    return Ok(activityDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                "Error retriving data from the database");

            }
        }

        [HttpPut]
        public async Task<ActionResult<ResponseActivityInfoDto>> UpdateActivity(UpdateActivityDto activity)
        {

            try
            {
                var actToUpdate = await this.activityRepository.GetItem(activity.Id);

                if(activity == null)
                {
                    return NotFound();
                }
                else
                {

                    var result = await this.activityRepository.UpdateItem(activity);

                    return Ok(result.ConvertToDto());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
