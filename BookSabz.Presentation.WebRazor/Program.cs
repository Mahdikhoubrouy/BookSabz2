using BookSabz.Application.Contracts.Book.BookValidation;
using BookSabz.Infrastructure.EFCore;
using BookSabz.Presentation.WebRazor.Helpers;
using BookSabz.ServiceRegister;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<BookSabzContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("me")));

builder.Services.AddAutoMapper(Assemblies.PresentationAssembly,Assemblies.InfrastuctureAssembly);
builder.Services.AddBookSabzService();



builder.Services.AddValidatorsFromAssemblyContaining<BookValidator>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();



builder.Services.AddSingleton<AuthAdmin>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
