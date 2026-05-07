namespace MauiApp1.Views;

public partial class LogoPage : ContentPage
{
    public LogoPage()
    {
        InitializeComponent();
        double wait_time = 2.5;
        bool success = App.Current.Dispatcher.DispatchDelayed(TimeSpan.FromSeconds(wait_time), () =>
        {
            Continue();
        });

    }
    public void Continue()
	{
        App.Current.MainPage = new NavigationPage(new MainPage());
	}
}