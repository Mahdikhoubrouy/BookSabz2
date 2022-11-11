﻿using BookSabz.Application;
using BookSabz.Application.Contracts.BookApp;
using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Application.Contracts.Search;
using BookSabz.Domain.BookAgg.Repository;
using BookSabz.Domain.BookAgg.Services;
using BookSabz.Domain.BookCategoryAgg.Repository;
using BookSabz.Domain.BookCategoryAgg.Services;
using BookSabz.Domain.SearchAgg.Repository;
using BookSabz.Infrastructure.EFCore.BookCategoeryRepo;
using BookSabz.Infrastructure.EFCore.BookCategoryRepo.BookCategoryCommand;
using BookSabz.Infrastructure.EFCore.BookCategoryRepo.BookCategoryQueries;
using BookSabz.Infrastructure.EFCore.BookRep;
using BookSabz.Infrastructure.EFCore.BookRep.BookQueries;
using BookSabz.Infrastructure.EFCore.BookRepo.BookCommand;
using BookSabz.Infrastructure.EFCore.Search;
using Microsoft.Extensions.DependencyInjection;

namespace BookSabz.ServiceRegister
{
    public static class ServiceRegistrar
    {

        private static IServiceCollection AddApplicationService(IServiceCollection services)
        {
            services.AddTransient<IBookApplication, BookApplication>();
            services.AddScoped<IBookCategoryApplication, BookCategoryApplication>();
            services.AddScoped<ISearchApplication, SearchApplication>();
            return services;
        }

        private static IServiceCollection AddInfrastructureService(IServiceCollection services)
        {
            services.AddScoped<IReadBookRepository, ReadBookRepository>();
            services.AddScoped<IWriteBookRepository, WriteBookRepository>();
            services.AddScoped<IReadBookCategoryRepository, ReadBookCategoryRepository>();
            services.AddScoped<IWriteBookCategoryRepository, WriteBookCategoryRepository>();
            services.AddScoped<IBookUnitOfWork, BookUnitOfWork>();
            services.AddScoped<IBookCategoryUnitOfWork, BookCategoryUnitOfWork>();
            services.AddScoped<ISearchRepository, SearchRepository>();
            return services;
        }

        private static IServiceCollection AddDomainService(IServiceCollection services)
        {
            services.AddScoped<IBookValidatorService, BookValidatorService>();
            services.AddScoped<IBookCategoryValidatorService, BookCategoryValidatorService>();
            return services;
        }




        public static IServiceCollection AddBookSabzService(this IServiceCollection services)
        {

            AddApplicationService(services);
            AddDomainService(services);
            AddInfrastructureService(services);

            return services;
        }

    }
}
