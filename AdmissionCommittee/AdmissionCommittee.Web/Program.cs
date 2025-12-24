using AdmissionCommittee.Abstractions.Repositories;
using AdmissionCommittee.Abstractions.Services;
using AdmissionCommittee.Data.EF;
using AdmissionCommittee.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем MVC
builder.Services.AddControllersWithViews();

// Добавляем контекст базы данных через DI
builder.Services.AddDbContext<AdmissionCommitteeDbContext>(options =>
    options.UseSqlServer(
        "Server=(localdb)\\MSSQLLocalDB;Database=AdmissionCommitteeDb;Trusted_Connection=True;"));

builder.Services.AddScoped<IApplicantRepository, ApplicantEfRepository>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Маршрутизация по умолчанию
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Applicants}/{action=Index}/{id?}");

app.Run();