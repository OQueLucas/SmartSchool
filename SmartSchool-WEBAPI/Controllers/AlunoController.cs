using Microsoft.AspNetCore.Mvc;
using SmartSchool_WEBAPI.Data;

namespace SmartSchool_WEBAPI.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        public AlunoController(IRepository repo){
            _repo = repo;
            
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Gustavo");
        }
    }
}