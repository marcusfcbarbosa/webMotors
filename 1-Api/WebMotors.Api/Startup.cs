using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using WebMotors.Api.InfraEstructure;
using WebMotors.Domain.WebMotorsContext.Commands.Input;
using WebMotors.Domain.WebMotorsContext.Repositories.Interfaces;
using WebMotors.Infra.Repositories;
using WebMotors.Infra.SqlContext;

namespace WebMotors.Api
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

            services.AddControllers();
            registrandoDependencias(services);
            DocumentacaoApi(services);
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public void DocumentacaoApi(IServiceCollection services)
        {
            services.AddSwaggerDocumentation();
        }
        public void registrandoDependencias(IServiceCollection services)
        {
            #region"Contexto"
            services.AddScoped<WebMotorsContext, WebMotorsContext>();
            #endregion

            #region"Repositórios"
            services.AddScoped<IAnuncioWebMotorsRepository, AnuncioWebMotorsRepository>();
            #endregion


            #region"mediator"
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CriaAnuncioCommand).GetTypeInfo().Assembly);
            #endregion



        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "swagger");
            });

            app.UseRouting();

            app.UseCors(x => x
                      .AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
