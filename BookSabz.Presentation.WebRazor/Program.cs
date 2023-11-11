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

#region DbContext
var connectionString = builder.Configuration.GetConnectionString("booksabz");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
builder.Services.AddDbContext<BookSabzContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddDbContext<BookSabzIdentityContext>(options =>
    options.UseMySql(connectionString, serverVersion));



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
builder.Services.AddAutoMapper(Assemblies.PresentationAssembly, Assemblies.ApplicationAssembly);
builder.Services.AddBookSabzService();
builder.Services.AddValidatorsFromAssemblyContaining<BookValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
#endregion

builder.Services.AddRazorPages();

var app = builder.Build();

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    app.UseHsts();
//}

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
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
