using Microsoft.AspNetCore.Mvc;
using Onebox_backend.Models;

namespace Onebox_backend.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : Controller
    {
        private readonly TrackingModel _trackingModel;

        public TrackingController(TrackingModel trackingModel)
        {
            _trackingModel = trackingModel;
        }

        [HttpGet("track/all")]
        public async Task<IActionResult> TrackAllAsync([FromQuery] int limit = 20)
        {
            try
            {
                var allTrackingInfo = await _trackingModel.GetAllTrackingsAsync(limit);
                return Ok(allTrackingInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpGet("track/{klantId}")]
        public async Task<IActionResult> TrackByIdAsync(int klantId)
        {
            try
            {
                var trackingInfo = await _trackingModel.GetTrackingAsync(klantId);
                return Ok(trackingInfo);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        }
    }
