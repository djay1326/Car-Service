using Bal;
using Dal;
using Dal.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars
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
            services.AddDbContext<CarContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Myconnection")));
            services.AddIdentity<Users, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.SignIn.RequireConfirmedEmail = true; // checks if the mail is confirmed  or not
            })
              .AddEntityFrameworkStores<CarContext>();
            services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.Name = "carService";
                option.ExpireTimeSpan = TimeSpan.FromDays(30);
                option.LoginPath = "/account/login";
            });
            services.AddControllersWithViews();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>(); // For ModelState Implementation in Login Services in Bal
            services.AddScoped<IUsersAccountServices, UsersAccountServices>();
            services.AddScoped<ICarAppointmentServices, CarAppointmentServices>();
            services.AddScoped<IGarageServices, GarageServices>();
            services.AddScoped<IInvoiceServices, InvoiceServices>();
            services.AddScoped<IBillServices, BillServices>();

            services.AddMvc().AddXmlDataContractSerializerFormatters();
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
            }
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
