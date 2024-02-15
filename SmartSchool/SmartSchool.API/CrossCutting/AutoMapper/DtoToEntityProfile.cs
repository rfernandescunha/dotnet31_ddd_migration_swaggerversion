using AutoMapper;
using SmartSchool.API.Dto.Aluno.v1;
using SmartSchool.API.Dto.Professor.v1;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.CrossCutting.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<Aluno, AlunoPostDto>().ReverseMap();
            CreateMap<Aluno, AlunoPutDto>().ReverseMap();
            CreateMap<Aluno, AlunoFindDto>().ReverseMap();

            CreateMap<Professor, ProfessorPostDto>().ReverseMap();
            CreateMap<Professor, ProfessorPutDto>().ReverseMap();
            CreateMap<Professor, ProfessorFindDto>().ReverseMap();
        }
    }
}
