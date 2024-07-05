using HikerWeb.API.Extensions;
using HikerWeb.API.Repositories.Contracts;
using HikerWeb.Models.DTOs.ActivityDtos;
using Microsoft.AspNetCore.Mvc;

namespace HikerWeb.API.Controllers
{
    [Route("ActivityType")]
    [ApiController]
    public class ActivityTypeController : ControllerBase
    {
        private readonly IActivityTypeRepository activityTypeRepository;

        public ActivityTypeController(IActivityTypeRepository activityTypeRepository)
        {
            this.activityTypeRepository = activityTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityTypeDto>>> GetItems()
        {
            try
            {
                var items = await activityTypeRepository.GetItems();

                return Ok(items.ConvertToDto());

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                "Error retriving data from the database");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityTypeDto>> GetItem(int id)
        {
            try
            {
                var item = await this.activityTypeRepository.GetItem(id);

                if (item == null) {

                    return NotFound();

                }
                else
                {
                    var activityTypeDto = item.ConvertToDto();

                    return Ok(activityTypeDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                         "Error retriving data from the database");

            }
        }
        [HttpPost]
        public async Task<ActionResult<ActivityTypeDto>> AddItem([FromBody] ActivityTypeDto activityTypeDto)
        {
            try
            {
                var newActivityType = await this.activityTypeRepository.AddItem(activityTypeDto);

                if (newActivityType == null)
                {
                    return BadRequest();
                }
                var activityType = await this.activityTypeRepository.GetItem(newActivityType.Id);

                if (activityType == null)
                {
                    return BadRequest();
                }

                var newActivityTypeDto = newActivityType.ConvertToDto();

                return CreatedAtAction(nameof(GetItem), new { newActivityTypeDto.Id }, newActivityType);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                 "Error writing data in the database");

            }

        }

  

    }
}
