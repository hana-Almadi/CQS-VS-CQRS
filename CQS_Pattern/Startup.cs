using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using AutoMapper;

namespace CQS_Pattern
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
            var dbSetting = Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            services.AddControllers();
            services.AddTransient<IQuery<Employee,int>, QueryEmployee>();
            services.AddTransient<ICommand<Employee>, CommandEmployee>();
            services.AddTransient< EmployeeService, EmployeeService> ();
            services.AddDbContext<CqsContext>(
              options => options.UseSqlServer(dbSetting));
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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
