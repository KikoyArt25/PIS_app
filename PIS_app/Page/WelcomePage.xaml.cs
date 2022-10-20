namespace PIS_app.Page;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}

	private async void BTN_Tologin_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new MainPage());
	}

	private async void BTN_ToRegister_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RegisterPage());

	}
}