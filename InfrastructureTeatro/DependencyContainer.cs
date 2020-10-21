using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureTeatro
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            //CleanArchitecture.Application
            //services.AddScoped<IBookService, BookService>();

            ////CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            //services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
