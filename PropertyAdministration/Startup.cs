using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Mocking;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using PropertyAdministration.Core.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace PropertyAdministration
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                        {
                            options.Password.RequiredLength = 8;  
                        })
                        .AddDefaultTokenProviders()
                        .AddDefaultUI()
                        .AddEntityFrameworkStores<AppDBContext>();

            //services.AddScoped<IHouseRepository, MockHouseRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>(); //
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>(); 
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<InvoiceService, InvoiceService>();
            services.AddScoped<HouseService, HouseService>();
            services.AddScoped<OwnerService, OwnerService>(); 
            services.AddScoped<IInvoiceEngine,  InvoiceEngine>();

            services.AddMemoryCache(); //caching
 
            services.AddControllersWithViews() ;//services.AddMvc(); would also work still

            //User must be authenticated. This applies authenticated the default authentication scheme.
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            services.AddMvc(options =>
            {
                options.Filters.Add(new AuthorizeFilter(policy));
            });


            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env )
        {
             

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/AppException"); //blank pag!
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting(); 
            app.UseAuthentication();
             app.UseAuthorization();
 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
