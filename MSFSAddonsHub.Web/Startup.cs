using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSFSAddonsHub.Dal.Models;
using MSFSAddonsHub.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using MSFSAddonsHub.Web.Helpers;
using MSFSAddonsHub.BL;
using Microsoft.IdentityModel.Protocols;
using MSFSAddonsHub.Web.Models;

namespace MSFSAddonsHub.Web
{
    public class Startup
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AppConfig.WebRootPath = _hostingEnvironment.WebRootPath;
            AppConfig.ContentRootPath = _hostingEnvironment.ContentRootPath;

            services.AddControllersWithViews();
            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.TopRight,
                ToastClass = "alert",

            });
           
    services.AddIdentity<ApplicationUser, IdentityRole>(config =>
    {
        config.SignIn.RequireConfirmedEmail = true;
        config.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
        config.User.RequireUniqueEmail = true;

    })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<MSFSAddonDBContext>()
        .AddDefaultTokenProviders()      
        .AddRoles<IdentityRole>();

  services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>,
AdditionalUserClaimsPrincipalFactory>();
    services.AddSession(opts =>
    {
        opts.Cookie.IsEssential = false; // make the session cookie Essential
        opts.IdleTimeout = TimeSpan.FromMinutes(30);

    });
            services.Configure<FileTransferConfig>(Configuration.GetSection("FileTransferConfig"));

            services.AddDbContext<MSFSAddonDBContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
                    services.AddHttpContextAccessor();


            services.AddAuthorization(options =>
        options.AddPolicy("TwoFactorEnabled",
        x => x.RequireClaim("amr", "mfa")));
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.Configure<IdentityOptions>(options =>
            {

                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                


            });
    services.ConfigureApplicationCookie(config =>
    {
        config.Cookie.Name = "Identity.Cookie";
        config.LoginPath = "/Identity/Account/Login";
    
    });


            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.TopRight,
                ToastClass = "alert",

            });
            services.AddTransient<IEmailSender, EmailSender>(i =>
                new EmailSender(
                    Configuration["EmailSender:Host"],
                    Configuration.GetValue<int>("EmailSender:Port"),
                    Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    Configuration["EmailSender:UserName"],
                    Configuration["EmailSender:Password"]
                )
            );
       
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                
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
                app.UseDeveloperExceptionPage();


                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
    app.UseHttpsRedirection();
    app.UseStaticFiles();
            
    app.UseRouting();

    app.UseAuthorization();
    app.UseAuthentication();


    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
    });
        }
    }

}
