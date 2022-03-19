using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace CQRS
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
            var commandDbSetting = Configuration.
                GetSection("CommandDatabase:DefaultConnection").Value;
            services.AddControllers();
            services.Configure<QueryDatabaseSettings>
                (Configuration.GetSection("QueryDatabase"));
            services.AddDbContext<CommandDbContext>(
             options => options.UseSqlServer(commandDbSetting));
            services.AddTransient<EmployeeCommandHandler, EmployeeCommandHandler>();
            services.AddTransient<QueryDbContext, QueryDbContext>();
            services.AddTransient<EventHandler, EventHandler>();
            services.AddTransient<EmployeeQueryHandler, EmployeeQueryHandler>();
            services.AddTransient<EmployeeService, EmployeeService>();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));

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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
