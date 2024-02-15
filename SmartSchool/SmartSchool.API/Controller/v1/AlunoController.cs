using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Data.Repository;
using SmartSchool.API.Dto.Aluno.v1;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using SmartSchool.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controller.v1
{
    /// <summary>
    /// Aluno Controller 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]    
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;
        /// <summary>
        /// AlunoController
        /// </summary>
        /// <param name="service"></param>
        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Metodo que retorna aluno por id
        /// </summary>
        /// <param name="AlunoId"></param>
        /// <returns>Aluno</returns>
        // GET api/<AlunoController>/5
        [HttpGet("GetById/{AlunoId}")]
        public IActionResult GetById(int AlunoId)
        {
            var result = _service.FindAsync(AlunoId).Result;

            if (result == null)
                return BadRequest("Aluno não encontrado");

            return Ok(result);
        }

        /// <summary>
        /// Metodo que retona uma lista de alunos
        /// </summary>
        /// <returns>Lista de Alunos</returns>
        [HttpGet]
        public IActionResult Get([FromQuery]PageParams pageParams)
        {
            var result = _service.FindAsync(pageParams, null).Result;

            Response.AddPagination(result.PageNumber, result.TotalPages, result.PageSize, result.TotalItens);

            return Ok(result);
        }

        /// <summary>
        /// Metodo que salva um aluno
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns>Aluno</returns>
        [HttpPost]
        public IActionResult Post([FromBody] AlunoPostDto aluno)
        {
            _service.InsertAsync(aluno);

            return Ok(aluno);
        }

        /// <summary>
        /// Metodo que atualiza um aluno
        /// </summary>
        /// <param name="AlunoId"></param>
        /// <param name="aluno"></param>
        /// <returns>Aluno</returns>
        [HttpPut("{AlunoId}")]
        public IActionResult Put(int AlunoId, [FromBody] AlunoPutDto aluno)
        {
            var result = _service.FindAsync(AlunoId);

            if (result == null)
                return BadRequest("Aluno não encontrado");


            _service.UpdateAsync(aluno);

            return Ok(aluno);
        }

        [HttpPut("ativarDesativarAluno/{AlunoId}")]
        public IActionResult ativarDesativarAluno(int AlunoId, [FromBody] AlunoPutDto aluno)
        {
            //var result = _service.FindAsync(AlunoId);

            //if (result == null)
            //    return BadRequest("Aluno não encontrado");

            AlunoPutDto update = aluno;
            update.Ativo = !update.Ativo;

            _service.UpdateAsync(update);

            return Ok(update);
        }

        /// <summary>
        /// Metodo que atualiza um aluno
        /// </summary>
        /// <param name="AlunoId"></param>
        /// <param name="aluno"></param>
        /// <returns>Aluno</returns>
        [HttpPatch("{AlunoId}")]
        public IActionResult Patch(int AlunoId, [FromBody] AlunoPutDto aluno)
        {
            var result = _service.FindAsync(AlunoId);

            if (result == null)
                return BadRequest("Aluno não encontrado");

            _service.UpdateAsync(aluno);

            return Ok(aluno);
        }

        /// <summary>
        /// Metodo que deleta um aluno
        /// </summary>
        /// <param name="AlunoId"></param>
        /// <returns>boleano</returns>
        [HttpDelete("{AlunoId}")]
        public IActionResult Delete(int AlunoId)
        {
            var result = _service.FindAsync(AlunoId).Result;

            if (result == null)
                return BadRequest("Aluno não encontrado");

            _service.DeleteAsync(AlunoId);

            return Ok();
        }

        /// <summary>
        /// Metodo que retorna aluno por id
        /// </summary>
        /// <param name="AlunoId"></param>
        /// <returns>Aluno</returns>
        // GET api/<AlunoController>/5
        [HttpGet("GetAllAlunosByDisciplinas/{AlunoId}")]
        public IActionResult GetAllAlunosByDisciplinas(int AlunoId)
        {
            var result = _service.GetAllAlunosByDisciplinas(AlunoId).Result;

            if (result == null)
                return BadRequest("Aluno não encontrado");

            return Ok(result);
        }
    }
}
