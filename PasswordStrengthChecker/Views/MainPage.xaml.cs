using PasswordStrengthChecker.ViewModel;

namespace PasswordStrengthChecker;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}


