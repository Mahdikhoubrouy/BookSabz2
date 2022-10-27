using BookSabz.Application;
using BookSabz.Application.Contracts.BookApp;
using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Application.Contracts.Search;
using BookSabz.Core.Infrastructure;
using BookSabz.Domain.BookAgg.Repository;
using BookSabz.Domain.BookAgg.Services;
using BookSabz.Domain.BookCategoryAgg.Repository;
using BookSabz.Domain.BookCategoryAgg.Services;
using BookSabz.Domain.SearchAgg.Repository;
using BookSabz.Infrastructure.EFCore;
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

        private static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IBookApplication, BookApplication>();
            services.AddScoped<IBookCategoryApplication, BookCategoryApplication>();
            services.AddScoped<ISearchApplication, SearchApplication>();
            return services;
        }

        private static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IReadBookRepository, ReadBookRepository>();
            services.AddScoped<IWriteBookRepository, WriteBookRepository>();
            services.AddScoped<IReadBookCategoryRepository, ReadBookCategoryRepository>();
            services.AddScoped<IWriteBookCategoryRepository, WriteBookCategoryRepository>();
            services.AddScoped<IBookUnitOfWork, BookUnitOfWork>();
            services.AddScoped<IBookCategoryUnitOfWork, BookCategoryUnitOfWork>();
            services.AddScoped<ISearchRepository, SearchRepository>();
            services.AddScoped<IDbUnitOfWork, DbUnitOfWork>();
            return services;
        }

        private static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            services.AddScoped<IBookValidatorService, BookValidatorService>();
            services.AddScoped<IBookCategoryValidatorService, BookCategoryValidatorService>();
            return services;
        }



        public static IServiceCollection AddBookSabzService(this IServiceCollection services)
        {
            services.AddApplicationService();
            services.AddInfrastructureService();
            services.AddDomainService();

            return services;
        }

    }
}
