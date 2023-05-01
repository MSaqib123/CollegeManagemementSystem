using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            string con = "server=saqib\\saqib;database=college_06G;trusted_connection=true;MultipleActiveResultSets=True";
            services.AddDbContext<cms_06GContext>(x =>
            {
                x.UseSqlServer(con);
            });
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<cms_06GContext>();
            services.AddTransient<cms_06GContext>();
            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Security/Account/SignIn/";
                option.AccessDeniedPath = "/Security/Account/PageNotFound_404/";
                //PageNotFound_404
            });
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //___________ Area Route ____________
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
