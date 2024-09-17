using BLL.Helper;
using BLL.Services.BillServices;
using BLL.Services.ClientServices;
using BLL.Services.CompanyServices;
using BLL.Services.ItemServices;
using BLL.Services.SelesReportServices;
using BLL.Services.SpecieServices;
using BLL.Services.UnitServices;
using DAL.database;
using DAL.Entity;
using DAL.Repo.BillRepo;
using DAL.Repo.ClientRepo;
using DAL.Repo.CompanyRepo;
using DAL.Repo.ItemRepo;
using DAL.Repo.SelesReportRepo;
using DAL.Repo.SpecieRepo;
using DAL.Repo.UnitRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System.Globalization;

namespace BillsSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var conn = builder.Configuration.GetConnectionString("DfulteConnection");

            //Newtonsoft
            builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            }).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();


            //sur
            builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<DatabaseDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);


            builder.Services.AddAuthentication().AddCookie(options =>
                {
                    options.LoginPath = $"/Account/Login";
                    options.LogoutPath = $"/Account/Logout";
                });


            builder.Services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;
            });



            // Add services to the container.
            builder.Services.AddControllersWithViews();




            // Register DbContext
            builder.Services.AddDbContext<DatabaseDbContext>(options =>
            {
                options.UseSqlServer(conn);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            });
            // Register AutoMapper
            builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            // Register Repositories
            builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();
            builder.Services.AddScoped<IClientRepo, ClientRepo>();
            builder.Services.AddScoped<IUnitRepo, UnitRepo>();
            builder.Services.AddScoped<IItemRepo, ItemRepo>();
            builder.Services.AddScoped<ISpecieRepo, SpecieRepo>();
            builder.Services.AddScoped<IBillRepo, BillRepo>();
            builder.Services.AddScoped<ISelesReportRepo, SelesReportRepo>();

            // Register Services
            builder.Services.AddScoped<ICompanyServices, CompanyServices>();
            builder.Services.AddScoped<IClientServices, ClientServices>();
            builder.Services.AddScoped<IUnitServices, UnitServices>();
            builder.Services.AddScoped<IItemServices, ItemServices>();
            builder.Services.AddScoped<ISpecieServices, SpecieServices>();
            builder.Services.AddScoped<IBillServices, BillServices>();
            builder.Services.AddScoped<ISelesReportServices, SelesReportServices>();

            //resource file
                    var supportedCultures = new[] {
              new CultureInfo("ar-EG"),
              new CultureInfo("en-US"),
                         };

            var app = builder.Build();



            //resource file

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
                }
            });


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();// Who Are U
            app.UseAuthorization();// what Can U Do

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
