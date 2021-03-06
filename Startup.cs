using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSys.Bll;
using HotelSys.Data;
using HotelSys.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelSys
{
    // 启动配置
    public class Startup
    {
        // 读取配置文件
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // 配置服务
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            string connString = Configuration.GetConnectionString("HotelContext");
            services.AddDbContext<HotelDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("HotelContext")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddSingleton
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IRoomTypeService, RoomTypeService>();
        }

        // 配置中间件
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Room}/{action=Index}/{id?}");
            });
        }
    }

}