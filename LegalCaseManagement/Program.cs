using LegalCaseManagement.Areas.Identity;
using LegalCaseManagement.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using MudBlazor.Services;
using LegalCaseManagement.Data.LegalServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString),
    ServiceLifetime.Transient);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<AppUserService>();
builder.Services.AddTransient<CaseService>();
builder.Services.AddTransient<LawyerService>();
builder.Services.AddTransient<EmailService>();
builder.Services.AddTransient<RoleService>();
builder.Services.AddTransient<CaseTypeService>();
builder.Services.AddTransient<CaseStatusService>();
builder.Services.AddTransient<CaseService>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
