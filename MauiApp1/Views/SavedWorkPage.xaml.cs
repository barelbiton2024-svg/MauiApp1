using MauiApp1.ViewModel;

namespace MauiApp1.Views;

public partial class SavedWorkPage : ContentPage
{
	public SavedWorkPage(WorkPerUserVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}