using MauiApp1.ViewModel;

namespace MauiApp1.Views;

public partial class AppUserList : ContentPage
{
	public AppUserList(AppUserListVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}