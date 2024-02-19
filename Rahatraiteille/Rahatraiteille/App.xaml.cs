using Microsoft.Extensions.DependencyInjection;
using Rahatraiteille.MVVM.View;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Rahatraiteille
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>();
            //services.AddSingleton<MainViewModel>();
            //services.AddSingleton<EtusivuViewModel>();
            //services.AddSingleton<LisaaKategoriaViewModel>();
            //services.AddSingleton<LisaaKirjausViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            _serviceProvider.GetRequiredService<MainWindow>();
            base.OnStartup(e);
        }

    }

}
