using AutoMapper;
using SmartSchool.API.Data.Repository;
using SmartSchool.API.Dto.Aluno.v1;
using SmartSchool.API.Dto.v1.Disciplina;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartSchool.API.Services
{
    public class AlunoService:IAlunoService
    {
        private IAlunoRepository _repository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AlunoPostDtoResult> InsertAsync(AlunoPostDto userDto)
        {
            try
            {
                var model = _mapper.Map<Aluno>(userDto);

                var result = await _repository.InsertAsync(model);

                var retorno = _mapper.Map<AlunoPostDtoResult>(result);

                return retorno;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<AlunoPutDtoResult> UpdateAsync(AlunoPutDto userDto)
        {
            try
            {
                var model = _mapper.Map<Aluno>(userDto);

                var result = await _repository.UpdateAsync(model);

                var retorno = _mapper.Map<AlunoPutDtoResult>(result);

                return retorno;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                var item = await _repository.FindAsync(Id);

                if (item == null)
                    return false;

                return await _repository.DeleteAsync(item);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<AlunoFindDtoResult> FindAsync(int Id)
        {
            try
            {
                var result = await _repository.FindAsync(Id);

                var retorno = _mapper.Map<AlunoFindDtoResult>(result);

                return retorno;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<PageList<AlunoFindDtoResult>> FindAsync(PageParams pageParams, Expression<Func<AlunoFindDto, bool>> predicate = null)
        {
            try
            {
                var model = _mapper.Map<Expression<Func<Aluno, bool>>>(predicate);

                var result = await _repository.FindAsync(pageParams, model);

                var retorno = new PageList<AlunoFindDtoResult>(
                                                                _mapper.Map<IEnumerable<AlunoFindDtoResult>>(result).ToList(), 
                                                                result.TotalItens, 
                                                                result.PageNumber, 
                                                                result.PageSize);

                return retorno;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AlunoFindDtoResult>> GetAllAlunosByDisciplinas(int AlunoId)
        {
            try
            {
                var result = await _repository.GetAllAlunosByDisciplinas(AlunoId);

                var retorno = _mapper.Map<IEnumerable<AlunoFindDtoResult>>(result);

                return retorno;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
