using InovaXSprint.API.Configuration;
using InovaXSprint.Database;
using InovaXSprint.Models;
using InovaXSprint.Repository; // Import the repository namespace
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace InovaXSprint.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Register all necessary repositories for controllers
            services.AddScoped<IRepository<Avaliacao>, Repository<Avaliacao>>();
            services.AddScoped<IRepository<Distribuidor>, Repository<Distribuidor>>();
            services.AddScoped<IRepository<Endereco>, Repository<Endereco>>();
            services.AddScoped<IRepository<PessoaFisica>, Repository<PessoaFisica>>();
            services.AddScoped<IRepository<PessoaJuridica>, Repository<PessoaJuridica>>();
            services.AddScoped<IRepository<Produto>, Repository<Produto>>();
            services.AddScoped<IRepository<Servico>, Repository<Servico>>();
            services.AddScoped<IRepository<Telefone>, Repository<Telefone>>();
            services.AddScoped<IRepository<Usuario>, Repository<Usuario>>();

            return services;
        }

        public static IServiceCollection AddContext(this IServiceCollection services, APIConfiguration apiConfiguration)
        {
            // Oracle
            services.AddDbContext<FIAPDbContext>(options =>
            {
                options.UseOracle(apiConfiguration.OracleFIAP.ConnectionString);
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, APIConfiguration apiConfiguration)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{apiConfiguration.Swagger.Title} {DateTime.Now.Year} ",
                    Version = "v1",
                    Description = apiConfiguration.Swagger.Description,
                    Contact = new OpenApiContact() { Name = apiConfiguration.Swagger.Name, Email = apiConfiguration.Swagger.Email }
                });
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }
    }
}