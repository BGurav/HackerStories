using HackerStories.BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackerStories.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryService _storyService;
        public StoryController(IStoryService storyService) 
        {
            _storyService = storyService;
        }

        [HttpGet("getstories")]
        public async Task<IActionResult> GetStories()
        {
            try
            {
                return Ok(await _storyService.GetAll());
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("getstory")]
        public async Task<IActionResult> GetStory(int id)
        {
            try
            {
                return Ok(await _storyService.GetById(id));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
