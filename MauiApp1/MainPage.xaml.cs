using MauiApp1.Views;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ContentPage p = null;
            switch (btn.Text)
            {
                //case "RegisterPage":
                //    p = new RegisterPage();
                //    await App.Current.MainPage.Navigation.PushAsync(p);
                //    break;
                //case "LoginPage":
                //    p = new LoginPage();
                //    await App.Current.MainPage.Navigation.PushAsync(p);
                //    break;
                case "UserNamePage":
                    p = new UserNamePage();
                    await App.Current.MainPage.Navigation.PushAsync(p);
                    break;
                case "HomePage":
                    p = new HomePage();
                    await App.Current.MainPage.Navigation.PushAsync(p);
                    break;
                case "ProfilePage":
                    p = new ProfilePage();
                    await App.Current.MainPage.Navigation.PushAsync(p);
                    break;
                case "BankAccountPage":
                    p = new BankAccountPage();
                    await App.Current.MainPage.Navigation.PushAsync(p);
                    break;
                case "PastWorkPage":
                    p = new PastWorkPage();
                    await App.Current.MainPage.Navigation.PushAsync(p);
                    break;
                case "SavedWorkPage":
                    p = new SavedWorkPage();
                    await App.Current.MainPage.Navigation.PushAsync(p);
                    break;
                //case "JobForUPage":
                //    p = new JobForUPage();
                //    await App.Current.MainPage.Navigation.PushAsync(p);
                //    break;
                case "SalaryPage":
                    p = new SalaryPage();
                    await App.Current.MainPage.Navigation.PushAsync(p);
                    break;
                default:
                    await DisplayAlert("אין מה לעשות פה", "אין פה כלום", "אישור");
                    break;
            }
        }
    }
}


