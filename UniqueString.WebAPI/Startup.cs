using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UniqueString.Core.BL;
using UniqueString.Core.Interfaces.BLContract;
using UniqueString.Core.Interfaces.RepositoryContract;
using UniqueString.Infrastructure.DAL;
using UniqueString.Infrastructure.DAL.Data;
using UniqueString.Infrastructure.DAL.Repositories;

namespace UniqueString.WebAPI
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


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<UniqueStringDBContext>(e => e.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddTransient<IUniqueStringBL, UniqueStringBL>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Unique String API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UniqueStringDBContext uniqueStringDBContext)
        {

            uniqueStringDBContext.Database.Migrate();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Unique String API V1");
            });
        }
    }
}
