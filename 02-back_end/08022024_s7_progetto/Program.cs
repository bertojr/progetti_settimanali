using _08022024_s7_progetto.DataModels;
using _08022024_s7_progetto.Interfaces;
using _08022024_s7_progetto.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// configurazione del database context
var conn = builder.Configuration.GetConnectionString("PizzeriaInFornoDB");
builder.Services.AddDbContext<ApplicationDbContext>(
    opt => opt.UseSqlServer(conn)
    );

// configurazione servizi
builder.Services
    .AddScoped<IAuthService, AuthService>();

// Autenticazione e autorizzazione
builder.Services
    .AddAuthentication(opt =>
    {
        opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Account/Login";
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(30); // imposta il tempo di scadenza del cookie
        opt.SlidingExpiration = true; // Rinnova il cookie se manca meno della metà del tempo di scadenza
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

app.UseAuthentication(); // Autenticazione
app.UseAuthorization(); // Autorizzazione

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

