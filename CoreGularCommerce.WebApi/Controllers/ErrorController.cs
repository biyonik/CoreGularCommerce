using CoreGularCommerce.WebApi.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CoreGularCommerce.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        [NonAction]
        public IActionResult Error(int code) 
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}