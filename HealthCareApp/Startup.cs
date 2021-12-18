using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Http;
using Repository.Abstract;
using Repository.Concrete;
using Repository.Helpers;
using Service.Concrete;
using ServiceStack.Redis;

namespace HealthCareApp
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
            services.AddNotyf(cfg =>
            {
                cfg.DurationInSeconds = 5;
                cfg.IsDismissable = true;
                cfg.Position = NotyfPosition.BottomRight;
            });

            services.AddControllersWithViews();
            services.AddSession();
            //services
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IApplicationService, ApplicationService>();
            services.AddSingleton<IDonorService, DonorService>();
            services.AddSingleton<IQuestionService, QuestionService>();
            services.AddSingleton<ISickService, SickService>();
            //repositories

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IApplicationRepository, ApplicationRepository>();
            services.AddSingleton<IDonorRepository, DonorRepository>();
            services.AddSingleton<IQuestionRepository, QuestionRepository>();
            services.AddSingleton<ISickRepository, SickRepository>();
            services.AddSingleton<IRedisClient, RedisClient>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            SessionHelper.Configure(services.BuildServiceProvider().GetService<IHttpContextAccessor>(), services.BuildServiceProvider().GetService<IRedisClient>());


        }

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
