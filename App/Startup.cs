using App.Data;
using App.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Startup
    {
        IWebHostEnvironment env;
        public Startup (IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services)
        {
            services.AddControllers();

            if (env.IsEnvironment("Testing"))
            {
                services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("db"));
            }
            else
            {
                services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("sqlserver")).UseSnakeCaseNamingConvention());
            }
            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
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
        }
    }
}