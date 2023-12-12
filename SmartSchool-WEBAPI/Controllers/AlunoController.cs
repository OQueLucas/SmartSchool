using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WEBAPI.Data;
using SmartSchool_WEBAPI.Models;

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
        public async Task<IActionResult> Get()
        {
            try {
                var result = await _repo.GetAllAlunosAsync(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpGet("{AlunoID}")]
        public async Task<IActionResult> GetByAlunoId(int AlunoID)
        { 
            try   {
                var result = await _repo.GetAlunoAsyncById(AlunoID, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpGet("ByDisciplina/{disciplinaID}")]
        public async Task<IActionResult> GetByDisciplinaId(int disciplinaID)
        { 
            try   {
                var result = await _repo.GetAlunosAsyncByDisciplinaId(disciplinaID, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
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
        
        [HttpPut("{alunoID}")]
        public async Task<IActionResult> Put(int alunoID, Aluno model)
        { 
            try   {
                var aluno = await _repo.GetAlunoAsyncById(alunoID, false);
                if(aluno == null) return NotFound("Aluno não encontrado");

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
        
        [HttpDelete("{alunoID}")]
        public async Task<IActionResult> Delete(int alunoID)
        { 
            try   {
                var aluno = await _repo.GetAlunoAsyncById(alunoID, false);
                if(aluno == null) return NotFound("Aluno não encontrado");

                _repo.Delete(aluno);

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