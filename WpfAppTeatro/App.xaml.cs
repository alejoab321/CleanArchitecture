using InfrastructureTeatroIoc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppTeatro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private string ConnectionString {get;set;}
        private ServiceProvider serviceProvider;
        public App()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            
            services.AddSingleton<MainWindow>();
            RegisterServices(services,ConnectionString);
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        private static void RegisterServices(IServiceCollection services,string connectionString)
        {
            DependencyContainer.RegisterServices(services,connectionString);
        }
    }
}
