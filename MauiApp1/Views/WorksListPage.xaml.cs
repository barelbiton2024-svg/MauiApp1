using MauiApp1.ViewModel;

namespace MauiApp1.Views;

public partial class WorksListPage : ContentPage
{
	public WorksListPage(WorksListVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}