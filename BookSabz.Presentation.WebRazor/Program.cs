using BookSabz.Application.Contracts.Book.BookValidation;
using BookSabz.Infrastructure.EFCore;
using BookSabz.Presentation.WebRazor.Helpers;
using BookSabz.ServiceRegister;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookSabz.Presentation.WebRazor.Db;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

# region DbContext

builder.Services.AddDbContext<BookSabzContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("me")));

builder.Services.AddDbContext<BookSabzIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("me")));

#endregion

#region Identity

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => { options.SignIn.RequireConfirmedAccount = true; })
    .AddRoles<IdentityRole>()
    .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<IdentityUser, IdentityRole>>()
    .AddDefaultUI()
    .AddEntityFrameworkStores<BookSabzIdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SiteManagement", policy =>
          policy.RequireRole("admin"));
});


#endregion

#region Services
builder.Services.AddAutoMapper(Assemblies.PresentationAssembly, Assemblies.InfrastuctureAssembly, Assemblies.ApplicationAssembly);
builder.Services.AddBookSabzService();
builder.Services.AddValidatorsFromAssemblyContaining<BookValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
#endregion

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
