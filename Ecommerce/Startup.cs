using Ecommerce.Database;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;
using Ecommerce.Mapping;
using Ecommerce.Repository.Manager;
using Microsoft.AspNetCore.Identity.UI.Services;
using Ecommerce.Servicies.Manager;

namespace Ecommerce
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
            services.AddDbContext<EcommerceDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            IConfigurationSection identityDefaultOptionsConfigurationSection = Configuration.GetSection("IdentityDefaultOptions");

            services.Configure<IdentityDefaultOptions>(identityDefaultOptionsConfigurationSection);

            var identityDefaultOptions = identityDefaultOptionsConfigurationSection.Get<IdentityDefaultOptions>();

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                   
                    options.Password.RequireDigit = identityDefaultOptions.PasswordRequireDigit;
                    options.Password.RequiredLength = identityDefaultOptions.PasswordRequiredLength;
                    options.Password.RequireNonAlphanumeric = identityDefaultOptions.PasswordRequireNonAlphanumeric;
                    options.Password.RequireUppercase = identityDefaultOptions.PasswordRequireUppercase;
                    options.Password.RequireLowercase = identityDefaultOptions.PasswordRequireLowercase;
                    options.Password.RequiredUniqueChars = identityDefaultOptions.PasswordRequiredUniqueChars;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(identityDefaultOptions.LockoutDefaultLockoutTimeSpanInMinutes);
                    options.Lockout.MaxFailedAccessAttempts = identityDefaultOptions.LockoutMaxFailedAccessAttempts;
                    options.Lockout.AllowedForNewUsers = identityDefaultOptions.LockoutAllowedForNewUsers;

                  
                    options.User.RequireUniqueEmail = identityDefaultOptions.UserRequireUniqueEmail;

                    
                    options.SignIn.RequireConfirmedEmail = identityDefaultOptions.SignInRequireConfirmedEmail;
                })
                .AddEntityFrameworkStores<EcommerceDbContext>()
                .AddDefaultTokenProviders();

                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });

                IMapper mapper = mappingConfig.CreateMapper();
               

            services.ConfigureApplicationCookie(options =>
            {
               
                options.Cookie.HttpOnly = identityDefaultOptions.CookieHttpOnly;
                options.Cookie.Expiration = TimeSpan.FromDays(identityDefaultOptions.CookieExpiration);
                options.LoginPath = identityDefaultOptions.LoginPath; 
                options.LogoutPath = identityDefaultOptions.LogoutPath; 
                options.AccessDeniedPath = identityDefaultOptions.AccessDeniedPath;
                options.SlidingExpiration = identityDefaultOptions.SlidingExpiration;
            });

         

            
            services.Configure<SmtpOptions>(Configuration.GetSection("SmtpOptions"));    

            services.Configure<CookiePolicyOptions>(options =>
            {
                
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient<Servicies.Interface.IEmailSender, EmailSender>();
            services.AddTransient<Servicies.Interface.ICategoryService, CategoryService>();
            services.AddTransient<Servicies.Interface.IUserService, UserService>();
            services.AddTransient<Servicies.Interface.IUnitService, UnitService>();
            services.AddTransient<Repository.Interface.IUserRepository, UserRepository>();
            services.AddTransient<Repository.Interface.ICategoryRepostiroy, CategoryRepository>();
            services.AddTransient<Repository.Interface.IUnitRepository, UnitRepository>();
            services.AddTransient<Repository.Interface.IRoleRepository, RoleRepository>();
            services.AddTransient<Servicies.Interface.IProductService, ProductService>();
            services.AddTransient<Repository.Interface.IProductRepository, ProductRepository>();
            services.AddSingleton(mapper);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
