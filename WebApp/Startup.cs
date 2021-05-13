using AutoMapper;
using BugTracker.Applicaton;
using BugTracker.Applicaton.Contracts;
using BugTracker.Applicaton.Services;
using BugTracker.DAL;
using BugTracker.DAL.Context;
using BugTracker.DAL.Repository;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using BugTracker.WebApp.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BugTracker.WebApp
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
            #region OLD
            services.AddControllers();
            services.AddScoped<IBugService, BugService>();
            services.AddScoped<IUserService, UserService>();


            services.AddDbContext<AppDbContext>(builder =>
                builder.UseNpgsql(Configuration.GetConnectionString("PgSql")));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IRepository<Bug>, BugRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region FAILED UPDATED
            //// DAL
            //services.AddScoped<IRepository<Bug>, BugRepository>();
            //services.AddScoped<IRepository<User>, UserRepository>();
            //services.AddScoped<IRepository<BugHistory>, BugHistoryRepository>();
            //services.AddDbContext<AppDbContext>(builder =>
            //    builder.UseNpgsql(Configuration.GetConnectionString("PgSql")));

            //// Application
            //services.AddScoped<IBugService, BugService>();
            //services.AddScoped<IUserService<User>, UserService>();

            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MapperProfile());
            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);


            //services.AddControllers();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandlerMiddleware();
            app.UseMiddleware<JwtMiddleware>();
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
