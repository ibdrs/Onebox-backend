using Microsoft.AspNetCore.Mvc;
using Onebox_backend.Models;
using System.Threading.Tasks;

namespace Onebox_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxController : ControllerBase
    {
        private readonly BoxModel _boxModel;

        public BoxController(BoxModel boxModel)
        {
            _boxModel = boxModel;
        }

        
        // GET api/Box/all
        [HttpGet("all")]
        public async Task<IActionResult> GetStateAsync()
        {
            var boxes = await _boxModel.GetAllBoxesAsync();
            return Ok(boxes);
        }

        // GET api/Box/{id}/state
        [HttpGet("{id}/state")]
        public async Task<IActionResult> GetStateAsync(int id)
        {
            try
            {
                var state = await _boxModel.GetStateAsync(id);
                return Ok(state);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Box not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // POST api/Box/{id}/lock
        [HttpPost("{id}/lock")]
        public async Task<IActionResult> LockAsync(int id)
        {
            try
            {
                await _boxModel.LockAsync(id);
                return Ok(new { message = "Box locked" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Box not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // POST api/Box/{id}/unlock
        [HttpPost("{id}/unlock")]
        public async Task<IActionResult> UnlockAsync(int id)
        {
            try
            {
                await _boxModel.UnlockAsync(id);
                return Ok(new { message = "Box unlocked" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Box not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
