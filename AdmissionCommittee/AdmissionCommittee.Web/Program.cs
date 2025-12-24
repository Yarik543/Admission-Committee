using AdmissionCommittee.Abstractions.Repositories;
using AdmissionCommittee.Abstractions.Services;
using AdmissionCommittee.Data.EF;
using AdmissionCommittee.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AdmissionCommitteeDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicantRepository, ApplicantEfRepository>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Applicants}/{action=Index}/{id?}");

app.Run();