using CoreGularCommerce.Repo.Data;
using CoreGularCommerce.WebApi.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CoreGularCommerce.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BuggyController : ControllerBase
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("NotFoundError")]
        public ActionResult GetNotFound()
        {
            var thing = _context.Products.Find(42);
            if(thing == null) {
                return NotFound(new ApiResponse(404));
            }
            return Ok(thing);

        }

        [HttpGet("ServerError")]
        public ActionResult GetServerError() 
        {
            var thing = _context.Products.Find(42);
            var thingToReturn = thing.ToString();
            return Ok(thing);
        }

        [HttpGet("BadRequestError")]
        public ActionResult GetBadRequest() 
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("BadRequestError/{id}")]
        public ActionResult GetNotFound(int id) 
        {
            return Ok();
        }
    }
}