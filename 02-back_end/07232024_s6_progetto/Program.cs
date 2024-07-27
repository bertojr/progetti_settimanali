using _07232024_s6_progetto.DAO;
using _07232024_s6_progetto.Interfaces;
using _07232024_s6_progetto.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("HotelReservationsDB");

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddSingleton<DatabaseHelper>(provider =>
new DatabaseHelper(connectionString, provider.GetRequiredService<ILogger<DatabaseHelper>>()));

builder.Services
    .AddTransient<GuestDao>()
    .AddTransient<ReservationDao>()
    .AddTransient<RoomDao>()
    .AddTransient<UserDao>()
    .AddTransient<ServiceReservationDao>()
    .AddTransient<RoleUserDao>()
    .AddTransient<RoleDao>()
    .AddTransient<AdditionalServiceDao>()
    .AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Reindirizza qui se l'utente non è autenticato
    });
builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

