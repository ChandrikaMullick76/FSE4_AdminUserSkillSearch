using AdminUserSkillSearch.BusinessLogicLayer;
using AdminUserSkillSearch.DBServiceLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUserSkillSearch
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
            services.Configure<UserSkillProfileDBDatabaseSettings>(Configuration.GetSection(nameof(UserSkillProfileDBDatabaseSettings)));

            services.AddSingleton<IUserSkillProfileDBDatabaseSettings>(sp => sp.GetRequiredService<IOptions<UserSkillProfileDBDatabaseSettings>>().Value);

            services.AddScoped<IUserSkillProfileService_BL, UserSkillProfileService_BL>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Admin Panel",
                    Description = "Admin Serach User's Skill Profile API",
                    Contact = new OpenApiContact
                    {
                        Name = "Chandrika Mullick",
                        Email = string.Empty
                    }
                });
            });
            services.AddCors();
            services.AddControllers();

            services.AddSingleton<UserSkillProfileService>();

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(
              builder => builder
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
