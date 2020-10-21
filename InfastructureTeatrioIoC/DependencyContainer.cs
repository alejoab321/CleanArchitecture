
using ApplicationTeatro.ObraApp;
using ApplicationTeatro.PersonApp;
using ApplicationTeatro.TeatroApp;
using Domain.Interface;
using InfrastructureTeatro.Interface.ObraInfra;
using InfrastructureTeatro.Interface.TeatroInfra;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TeatroPersistence.SqlServer.Obra;
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
            services.AddTransient<IObraRepository>(obra => new ObraSql(connectionString));
            
            //Application
            services.AddTransient<IPersonaApp, PersonaAppImpl>();
            services.AddTransient<ITeatroApp, TeatroAppImpl>();
            services.AddTransient<IObraApp, ObraAppImpl>();      
        }
    }
}
