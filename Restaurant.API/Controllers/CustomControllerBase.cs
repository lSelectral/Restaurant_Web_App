using Microsoft.AspNetCore.Mvc;
using Restaurant_Web_API.DTOs;

namespace Restaurant_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
        [NonAction] // Don't expose
        public IActionResult CreateActionResult<T>(ResponseDto<T> response)
        {
            // For swagger only. Not necessary for API
            if (response.StatusCode == 204)
                return new ObjectResult(null) { StatusCode = response.StatusCode };

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
