using MauiApp1.ViewModel;

namespace MauiApp1.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterPageVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    
}