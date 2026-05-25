using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Database;
using MauiApp1.ViewModel;
using MauiApp1.Views;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
// הסבר בילדר
namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            var config = new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyAE2LPPIRYcB9fMaWxcdy1Euo8phxcA4D4",
                AuthDomain = "jobfinderdb-e10c3.firebaseapp.com",

                Providers = new FirebaseAuthProvider[]
       {
             new EmailProvider()
       },
                UserRepository = new FileUserRepository("appuser")//persist data into %AppData%\appuser
            };
            Trace.WriteLine("[JobFinder] Try1");
            FirebaseAuthClient auth = new FirebaseAuthClient(config);
            Trace.WriteLine("[JobFinder] Try2");
            FirebaseClient client = new FirebaseClient("https://jobfinderdb-e10c3-default-rtdb.europe-west1.firebasedatabase.app/",

                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(auth.User.Credential.IdToken)
                }); Trace.WriteLine("[JobFinder] Try3");

            builder.Services.AddSingleton(auth);
            builder.Services.AddSingleton(client);
            Trace.WriteLine("[JobFinder] Try4");
            client.Child("Works").AsObservable<Models.Works>().Subscribe(ViewModel.WorksListVM.ChangeList);
            Trace.WriteLine("[JobFinder] Try5");
            // client.Child("WorkPerUser").AsObservable<Models.Works>().Subscribe(ViewModel.WorkPerUserVM.ChangeList);
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageVM>();





            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<RegisterPageVM>();


            builder.Services.AddSingleton<JobForUPage>();
            builder.Services.AddSingleton<WorksVM>();


            builder.Services.AddSingleton<WorksListPage>();
            builder.Services.AddSingleton<WorksListVM>();

            builder.Services.AddSingleton<AppUserList>();
            builder.Services.AddSingleton<AppUserListVM>();

            builder.Services.AddSingleton<SavedWorkPage>();
            builder.Services.AddSingleton<WorkPerUserVM>();

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            return builder.Build();
        }
    }
}
