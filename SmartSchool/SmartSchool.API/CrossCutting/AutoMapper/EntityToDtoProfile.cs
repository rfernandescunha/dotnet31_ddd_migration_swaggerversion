using AutoMapper;
using SmartSchool.API.Dto.Aluno.v1;
using SmartSchool.API.Dto.Professor.v1;
using SmartSchool.API.Dto.v1.AlunoCurso;
using SmartSchool.API.Dto.v1.AlunoDisciplina;
using SmartSchool.API.Dto.v1.Curso;
using SmartSchool.API.Dto.v1.Disciplina;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.CrossCutting.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {

            CreateMap<AlunoPostDtoResult, Aluno>().ReverseMap();
            CreateMap<AlunoPutDtoResult, Aluno>().ReverseMap();
            //CreateMap<AlunoFindDtoResult, Aluno>().ReverseMap();
            CreateMap<AlunoFindDtoResult, Aluno>().ReverseMap();

            //.ForMember(
            //    dest => dest.Idade,
            //    opt => opt.MapFrom(src => src.DtNascimento.GetCurrentAge())
            //    );

            //            .ForMember(
            //dest => dest[].Idade,
            //opt => opt.MapFrom(src => src[].DtNascimento.GetCurrentAge())
            //);

            CreateMap<ProfessorPostDtoResult, Professor>().ReverseMap();
            CreateMap<ProfessorPutDtoResult, Professor>().ReverseMap();

            
            CreateMap<DisciplinaFindDtoResult, Disciplina>().ReverseMap();
            CreateMap<AlunoDisciplinaFindDtoResult, AlunoDisciplina>().ReverseMap();
            CreateMap<ProfessorFindDtoResult, Professor>().ReverseMap();

            

            CreateMap<AlunoCursoFindDtoResult, AlunoCurso>().ReverseMap();

            

            CreateMap<CursoFindDtoResult, Curso>().ReverseMap();

        }
    }
}
