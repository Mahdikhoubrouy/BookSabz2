using BookSabz.Application;
using BookSabz.Domain.BookAgg;
using BookSabz.Infrastructure.EFCore;
using System.Reflection;

namespace BookSabz.ServiceRegister
{
    internal static class Assemblies
    {
        public static Assembly DomianAssembly { get; } = typeof(Book).Assembly;

        public static Assembly ApplicationAssembly { get; } = typeof(BookApplication).Assembly;

        public static Assembly InfrastuctureAssembly { get; } = typeof(BookSabzContext).Assembly;

        public static Assembly PresentationAssembly { get; } = typeof(Program).Assembly;
    }
}
