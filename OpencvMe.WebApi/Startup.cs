using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpencvMe.Repository.Interface;
using OpencvMe.Repository.Repositories;
using OpencvMe.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpencvMe.Service.Service;
using AutoMapper;
using OpencvMe.Service.Mapper;
using OpencvMe.Service.Interface;
using Microsoft.IdentityModel.Tokens;
using OpencvMe.Common.Constant;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OpencvMe.WebApi
{
    public class Startup
    {

        public IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Efcore Sql 
            services.AddDbContext<EfContext>(options => options.UseSqlServer(_configuration.GetConnectionString("OpenCvConnectionString")));

            // Automapper Inject
            services.AddAutoMapper(typeof(MappingProfile));

            #region Dependency Injections
            services.AddTransient<IUserCompanyRepository, UserCompanyRepository>();
            services.AddTransient<IUserSchoolRepository, UserSchoolRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<ICvRepository, CvRepository>();
            services.AddTransient<IUserRepository, UserRepository>();


            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISchoolService, SchoolService>();
            services.AddTransient<ICompanyService, CompanyService>();
            #endregion

            #region JWT Settings
            // aspnetcore.authentication.jwtbearer nuget
            services.AddAuthentication(configureOptions => {
                configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(config =>
            {

               var secretBytes = Encoding.UTF8.GetBytes(AuthenticationConstant.SecretKey);
               var key = new SymmetricSecurityKey(secretBytes);
               config.RequireHttpsMetadata = false;
                config.TokenValidationParameters = new TokenValidationParameters()
               {
                  
                   ValidateActor = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = AuthenticationConstant.Issuer,
                   ValidAudience = AuthenticationConstant.Audience,
                   IssuerSigningKey = key,
                };
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
        
}
