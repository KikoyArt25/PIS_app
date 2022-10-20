using PIS_app.Model;

namespace PIS_app;

public partial class MainPage : ContentPage
{

	private Admin getlogin = new();
	public MainPage()
	{
		InitializeComponent();
	}

	private async void BTN_Signin_Clicked(object sender, EventArgs e)
	{
		var log = await getlogin.AdminisLogin(entryEmail.Text, entryPassword.Text);

        if (string.IsNullOrEmpty(entryEmail.Text) || string.IsNullOrEmpty(entryPassword.Text))
        {
            await DisplayAlert("Notice!", "Please Dont Empty your Email or Pasword!", "OK");
            entryEmail.Text = "";
            entryPassword.Text = "";
            return;
        }


        progressLoading.IsVisible = true;
        if (log)
		{
			await DisplayAlert("Notice", "Login Successfully ", "OK");
            Application.Current!.MainPage = new AppShell();
            progressLoading.IsVisible = false;
			return;
        }
		await DisplayAlert("Notice", "Login not Successfully or Check your internet Connection", "OK");
        progressLoading.IsVisible = false;
    }

	private async void BTN_Cancel_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}

