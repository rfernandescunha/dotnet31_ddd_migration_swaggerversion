using AutoMapper;
using SmartSchool.API.Data.Repository;
using SmartSchool.API.Dto.Professor.v1;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartSchool.API.Services
{
    public class ProfessorService : IProfessorService
    {
        private IProfessorRepository _repository;
        private readonly IMapper _mapper;

        public ProfessorService(IProfessorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProfessorPostDtoResult> InsertAsync(ProfessorPostDto userDto)
        {
            try
            {
                var model = _mapper.Map<Professor>(userDto);

                var result = await _repository.InsertAsync(model);

                var retorno = _mapper.Map<ProfessorPostDtoResult>(result);

                return retorno;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<ProfessorPutDtoResult> UpdateAsync(ProfessorPutDto userDto)
        {
            try
            {
                var model = _mapper.Map<Professor>(userDto);

                var result = await _repository.UpdateAsync(model);

                var retorno = _mapper.Map<ProfessorPutDtoResult>(result);

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

        public async Task<ProfessorFindDtoResult> FindAsync(int Id)
        {
            try
            {
                var result = await _repository.FindAsync(Id);

                var retorno = _mapper.Map<ProfessorFindDtoResult>(result);

                return retorno;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProfessorFindDtoResult>> GetByAlunoId(int AlunoId)
        {
            try
            {
                var result = await _repository.GetByAlunoId(AlunoId);

                var retorno = _mapper.Map<IEnumerable<ProfessorFindDtoResult>>(result);

                return retorno;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<PageList<ProfessorFindDtoResult>> FindAsync(PageParams pageParams, Expression<Func<ProfessorFindDto, bool>> predicate = null)
        {
            try
            {
                var model = _mapper.Map<Expression<Func<Professor, bool>>>(predicate);

                var result = await _repository.FindAsync(pageParams, model);

                var retorno = new PageList<ProfessorFindDtoResult>(
                                                                    _mapper.Map<IEnumerable<ProfessorFindDtoResult>>(result).ToList(), 
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
    }
}
