using Microsoft.Extensions.DependencyInjection;
using SmartSchool.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.CrossCutting.DependencyInjection
{
    public static class InjectionServices
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAlunoService, AlunoService>();
            serviceCollection.AddScoped<IProfessorService, ProfessorService>();
        }
    }


}
