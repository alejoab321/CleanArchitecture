
using ApplicationTeatro.PersonApp;
using ApplicationTeatro.TeatroApp;
using Domain.Interface;
using InfrastructureTeatro.Interface.TeatroInfra;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TeatroPersistence.SqlServer.Persona;
using TeatroPersistence.SqlServer.Teatro;

namespace InfrastructureTeatroIoc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            //IRepository
            services.AddTransient<IPersonaRepository>(persona => new PersonaSql(connectionString));
            services.AddTransient<ITeatroRepository>(teatro => new TeatroSql(connectionString));
            

            //Application
            services.AddTransient<IPersonaApp, PersonaAppImpl>();
            services.AddTransient<ITeatroApp, TeatroAppImpl>();

       
        }
    }
}
