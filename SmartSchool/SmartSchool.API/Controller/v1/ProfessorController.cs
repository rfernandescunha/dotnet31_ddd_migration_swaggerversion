using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Dto.Professor.v1;
using SmartSchool.API.Helpers;
using SmartSchool.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controller.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _service;
        public ProfessorController(IProfessorService service)
        {
            _service = service;
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.FindAsync(id).Result;

            if (result == null)
                return BadRequest("Professor não encontrado");

            return Ok(result);
        }

        // GET api/<ProfessorController>/5
        [HttpGet]
        public IActionResult Get([FromQuery] PageParams pageParams)
        {
            var result = _service.FindAsync(pageParams, null).Result;

            Response.AddPagination(result.PageNumber, result.TotalPages, result.PageSize, result.TotalItens);

            return Ok(result);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post([FromBody] ProfessorPostDto professor)
        {
            _service.InsertAsync(professor);

            return Ok(professor);
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProfessorPutDto Professor)
        {
            var result = _service.FindAsync(id);

            if (result == null)
                return BadRequest("Professor não encontrado");


            _service.UpdateAsync(Professor);

            return Ok(Professor);
        }

        // PUT api/<ProfessorController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] ProfessorPutDto Professor)
        {
            var result = _service.FindAsync(id);

            if (result == null)
                return BadRequest("Professor não encontrado");

            _service.UpdateAsync(Professor);

            return Ok(Professor);
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.FindAsync(id).Result;

            if (result == null)
                return BadRequest("Professor não encontrado");

            _service.DeleteAsync(id);

            return Ok();
        }

        // GET api/<ProfessorController>/5
        [HttpGet("GetByAlunoId/{AlunoId}")]
        public IActionResult GetByAlunoId(int AlunoId)
        {
            var result = _service.GetByAlunoId(AlunoId).Result;

            if (result == null)
                return BadRequest("Professor não encontrado");

            return Ok(result);
        }
    }
}
