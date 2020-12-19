using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MatriculaWebApplicationEF.ApplicationServices;
using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;

namespace MatriculaWebApplicationEF
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

            services.AddScoped<EstudianteDomainService>();
            services.AddScoped<CursoDomainService>();
            services.AddScoped<PaisHacerDomainService>();
            services.AddScoped<ProfesorDomainService>();
            services.AddScoped<UsuarioDomainService>();
            services.AddScoped<MateriasCubrirDomainService>();
            services.AddScoped<CarroDomainService>();
            services.AddScoped<ModeloDomainService>();


            services.AddScoped<EstudianteAppService>();
            services.AddScoped<CursoAppService>();
            services.AddScoped<PaisHacerAppService>();
            services.AddScoped<ProfesorAppService>();
            services.AddScoped<UsuarioAppService>();
            services.AddScoped<MateriasCubrirAppService>();
            services.AddScoped<CarroAppService>();
            services.AddScoped<ModeloAppService>();


            services.AddDbContext<UniversidadDataContext>();
            
            services.AddMvc().AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var contex = serviceScope.ServiceProvider.GetRequiredService<UniversidadDataContext>();
                contex.Database.EnsureCreated();
            }

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
