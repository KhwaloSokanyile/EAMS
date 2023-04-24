using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EMS.Data;
using Microsoft.AspNetCore.Identity;
using EMS.Repository;
using EMS.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EMSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase") ?? throw new InvalidOperationException("Connection string 'EMSContext' not found.")));


builder.Services.AddDefaultIdentity<ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<EMSContext>();
builder.Services.AddScoped<ISignUpRepo, SignUpRepo>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ClaimsRepo>();
builder.Services.ConfigureApplicationCookie(options => 
{
    options.AccessDeniedPath = new PathString("/Admins/AccessDenied");
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequireDigit = false;
});

var app = builder.Build();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
