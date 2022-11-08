using Assignment_Api.Mapper;
using Assignment_Api.Repository;
using Assignment_Api.Service;
using Assignment_Api.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment_Api.Extentions
{
    public static class ServiceExtention
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IBooksMapper, BooksMapper>();
            services.AddTransient<IInputValidator, InputValidator>();
            return services;
        }
    }
}