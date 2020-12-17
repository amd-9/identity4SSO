using Identity4SSO.WebAuth.IdentityData;
using Identity4SSO.WebAuth.Models;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Identity4SSO.WebAuth
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlite("Data Source=Identity4SSOAppDbContext.db"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            });

            services.AddIdentityServer(
                options =>
                {
                    // Events
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;
                    // Endpoints
                    options.Endpoints.EnableAuthorizeEndpoint = true;
                    options.Endpoints.EnableCheckSessionEndpoint = true;
                    options.Endpoints.EnableEndSessionEndpoint = true;
                    options.Endpoints.EnableUserInfoEndpoint = true;
                    options.Endpoints.EnableDiscoveryEndpoint = true;
                    options.Endpoints.EnableIntrospectionEndpoint = false;
                    options.Endpoints.EnableTokenEndpoint = true;
                    options.Endpoints.EnableTokenRevocationEndpoint = false;
                })
                .AddInMemoryIdentityResources(Resources.GetIdentityResources())
                .AddInMemoryApiScopes(Resources.GetApiScopes())
                .AddInMemoryClients(Clients.Get())                
                .AddAspNetIdentity<ApplicationUser>()
                .AddDeveloperSigningCredential();


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, ApplicationDbContext applicationDbContext)
        {
            applicationDbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            await ApplicationDbInitializer.SeedUsers(userManager);

            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

        }
    }
}
