using Microsoft.Extensions.DependencyInjection;
using SmartSchool.API.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.CrossCutting.DependencyInjection
{
    public static class InjectionRepository
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IAlunoRepository, AlunoRepository>();
            serviceCollection.AddScoped<IProfessorRepository, ProfessorRepository>();
        }
    }
}
