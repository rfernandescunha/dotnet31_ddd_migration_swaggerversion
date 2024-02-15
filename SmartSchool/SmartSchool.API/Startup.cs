using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartSchool.API.Data;
using SmartSchool.API.CrossCutting.DependencyInjection;
using SmartSchool.API.CrossCutting.AutoMapper;
using System.Reflection;
using System.IO;
using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace SmartSchool.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SmartSchoolContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("SmartSchoolConnection"))
                );


            InjectionServices.Register(services);
            InjectionRepository.Register(services);
            InjectionAutoMapper.Register(services);



            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddVersionedApiExplorer(opt => {

                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;
            
            }).AddApiVersioning(opt=> {

                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
            
            });

            var apiProviderDescription = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(
                opt=>
                {
                    foreach (var descriptions in apiProviderDescription.ApiVersionDescriptions)
                    {
                        opt.SwaggerDoc(
                                        descriptions.GroupName,
                                        new Microsoft.OpenApi.Models.OpenApiInfo()
                                        {
                                            Title = "SmartSchool Api",
                                            Version = descriptions.ApiVersion.ToString(),
                                            Contact = new Microsoft.OpenApi.Models.OpenApiContact
                                            {
                                                Name = "Rafael F Cunha",
                                                Email = "rafa_fernandes_cunha@hotmail.com"
                                            }
                                        });
                    }

                    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                    opt.IncludeXmlComments(xmlCommentsFullPath);
                });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(x=> x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseSwagger()
                .UseSwaggerUI(
                opt=>
                {
                    foreach (var descriptions in apiVersionDescriptionProvider.ApiVersionDescriptions)
                    {
                        opt.SwaggerEndpoint($"swagger/{descriptions.GroupName}/swagger.api.json", descriptions.GroupName.ToUpperInvariant());
                        opt.RoutePrefix = "";
                    }


                });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
