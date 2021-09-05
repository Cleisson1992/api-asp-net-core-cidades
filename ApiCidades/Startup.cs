using ApiCidades.Domain.Service;
using ApiCidades.Domain.UserCase.UserCaseCidade.Cadastro;
using ApiCidades.Domain.UserCase.UserCaseCidade.Consulta;
using ApiCidades.Domain.UserCase.UserCaseCliente.Altera;
using ApiCidades.Domain.UserCase.UserCaseCliente.Cadastro;
using ApiCidades.Domain.UserCase.UserCaseCliente.Consulta;
using ApiCidades.Domain.UserCase.UserCaseCliente.Remove;
using ApiCidades.Infra.DataAccess;
using ApiCidades.Infra.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace ApiCidades
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
            services.AddDbContext<ApiCidadesContext>(opts => opts.UseMySQL(Configuration.GetConnectionString("CidadesConnection")));

            services.AddScoped<IRepository, Repository>();

            services.AddScoped<ICadastroDeCidade, CadastroDeCidade>();
            services.AddScoped<IConsultaDeCidade, ConsultaDeCidade>();

            services.AddScoped<ICadastroDeCliente, CadastroDeCliente>();
            services.AddScoped<IConsultaDeCliente, ConsultaDeCliente>();
            services.AddScoped<IAlteraCliente, AlteraCliente>();
            services.AddScoped<IRemoveCliente, RemoveCliente>();

            services.AddDbContext<ApiCidadesContext>(opts => opts.UseMySQL(Configuration.GetConnectionString("CidadesConnection")));

            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Documentando Api
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Documentação da Cidades API",
                    Description = "API Asp NET Core 3.1 Entity Framework LocalDB",
                    Contact = new OpenApiContact
                    {
                        Name = "Cleisson Vasconcelos dos Santos",
                        Email = "cleissonvasconcelos1992@hotmail.com"
                    }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            // Habilite o middleware para servir swagger-ui (HTML, JS, CSS, etc.),
            // especificando o terminal JSON Swagger.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1.0");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
