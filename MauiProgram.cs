using Brasserie.Utilities.DataAccess;
using Brasserie.Utilities.DataAccess.Files;
using Brasserie.Utilities.Interfaces;
using Brasserie.Utilities.Services;
using Brasserie.View;
using Brasserie.ViewModel;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Brasserie
{
    public static class MauiProgram
    {
        private const string CONFIG_HOME_CSV = @"C:\Users\Max\Desktop\IRAM\INF\POO\Brasserie\Brasserie\Configuration\Datas\Config.txt";
        private const string CONFIG_PORT_CSV = @"C:\POO\Brasserie\Configuration\Datas\Config.txt";

        private const string CONFIG_HOME_JSON = @"C:\Users\Max\Desktop\IRAM\INF\POO\Brasserie\Brasserie\Configuration\Datas\ConfigJson.txt";
        private const string CONFIG_PORT_JSON = @"C:\POO\Brasserie\Configuration\Datas\ConfigJson.txt";
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<DataFilesManager>(new DataFilesManager(CONFIG_HOME_JSON));
            /*
            Services.AddSingleton() permet de faire de l'injection de dépendance dans le constructeur des ViewModel par exemple
            sans devoir faire un new DataAccessJsonFile() dans celui-ci
            une instance est créée à ce stade et rendue disponible dans les constructeurs des classes. L'instance est permanente pour la méthode AddSingleton
            tandis qu'elle est recréée à chaque fois qu'on en a besoin quand on fait du .AddTransient()
            Les Services doivent être vu comme un conteneur de services disponibles ailleurs. Il contient toutes les instances spécifiées dans les <>
            */
            //Singleton for AlertServiceDisplay
            builder.Services.AddSingleton<IAlertService, AlertServiceDisplay>(); 
            builder.Services.AddSingleton<IDataAccess, DataAccessJsonFile>();

            //permet de faire de l'injection de dépendance dans le constructeur de la MainPage sans devoir faire un new MainPageViewModel() dans celui-ci
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
