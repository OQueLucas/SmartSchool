using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WEBAPI.Data;
using SmartSchool_WEBAPI.Models;

namespace SmartSchool_WEBAPI.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        public ProfessorController(IRepository repo){
            _repo = repo;
            
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try {
                var result = await _repo.GetAllProfessoresAsync(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpGet("{professorID}")]
        public async Task<IActionResult> GetByProfessorId(int professorID)
        { 
            try   {
                var result = await _repo.GetProfessorAsyncById(professorID, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpGet("ByAluno/{alunoID}")]
        public async Task<IActionResult> GetByAlunoId(int alunoID)
        { 
            try   {
                var result = await _repo.GetProfessoresAsyncByAlunoId(alunoID, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        { 
            try   {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
        
        [HttpPut("{professorID}")]
        public async Task<IActionResult> Put(int professorID, Professor model)
        { 
            try   {
                var professor = await _repo.GetProfessorAsyncById(professorID, false);
                if(professor == null) return NotFound("Professor não encontrado");

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
        
        [HttpDelete("{professorID}")]
        public async Task<IActionResult> Delete(int professorID)
        { 
            try   {
                var professor = await _repo.GetProfessorAsyncById(professorID, false);
                if(professor == null) return NotFound("Professor não encontrado");

                _repo.Delete(professor);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok("Deletado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}