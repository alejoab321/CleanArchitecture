
using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TeatroPersistence.SqlServer.Persona;

namespace InfrastructureTeatroIoc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            //CleanArchitecture.Application
            //services.AddScoped<IBookService, BookService>();
            services.AddTransient<IPersonaRepository>(persona => new PersonaSql(connectionString));

            ////CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            //services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
