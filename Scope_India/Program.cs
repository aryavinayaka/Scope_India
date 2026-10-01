using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scope_India.DAL;
using Scope_India.DATA;
using Scope_India.DATA.Context;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register DbContext
builder.Services.AddDbContext<Scope_IndiaDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/Login";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
    });




    builder.Services.AddScoped<IEmailSender, EmailSender>();
    builder.Services.AddScoped<IChatbotService, ChatbotService>();
    builder.Services.AddScoped<IStudent, SqlStudent>();
    builder.Services.AddScoped<ICourse, SqlCourse>();
builder.Services.AddScoped<ITestimonial, SqlTestimonial>();

//for sessions
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(20);

});


//Register Services
builder.Services.AddScoped<IStudent, SqlStudent>();
builder.Services.AddScoped<ICourse, SqlCourse>();


//builder.Services.AddScoped<IEmailServise, EmailService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/ Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
