using eCommerceApp.UI.ViewModels;

namespace eCommerceApp.UI.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel homePageViewModel)
	{
		InitializeComponent();
		BindingContext=homePageViewModel;
	}
}