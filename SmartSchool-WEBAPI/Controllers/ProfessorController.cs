using Microsoft.AspNetCore.Mvc;

namespace SmartSchool_WEBAPI.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Lucas");
        }
    }
}