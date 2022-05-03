using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stage_Books.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace Stage_Books
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
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("conn1")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddLocalization(options => options.ResourcesPath = "languages");
            services.AddMvc()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);


            services.Configure<RequestLocalizationOptions>(Option =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("Es"),
                    new CultureInfo("Ar"),
                    new CultureInfo("Fr"),
                    new CultureInfo("Hi"),
                    new CultureInfo("De")
            };
                Option.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
                Option.SupportedCultures = supportedCultures;
                Option.SupportedUICultures = supportedCultures;
            });

            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            var locoption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locoption.Value);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
