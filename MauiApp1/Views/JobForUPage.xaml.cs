using MauiApp1.ViewModel;

namespace MauiApp1.Views;
//דף הוספת עבודה
public partial class JobForUPage : ContentPage
{
	public JobForUPage(WorksVM vm)
	{
		InitializeComponent();
		BindingContext = vm;


	}
}