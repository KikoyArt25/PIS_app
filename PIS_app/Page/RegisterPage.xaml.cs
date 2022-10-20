using PIS_app.Model;
namespace PIS_app.Page;

public partial class RegisterPage : ContentPage
{
	private Admin register = new();
	public RegisterPage()
	{
		InitializeComponent();
	}

	private async void BTNCancel_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	private async void BTNRegister_Clicked(object sender, EventArgs e)
	{

        if (string.IsNullOrEmpty(fname.Text) || string.IsNullOrEmpty(lname.Text)
            || string.IsNullOrEmpty(mail.Text) || string.IsNullOrEmpty(password.Text))
        {        
            await DisplayAlert("Notice!", "Please Fill Up The Empty Fields ", "OK");          
            return;
        }

        var reg = await register.AddAdminis(fname.Text, lname.Text, mail.Text, password.Text);
        if (reg == true)
        {
            await DisplayAlert("Register", "Data Succesfully Saved", " OK!");
			fname.Text = "";
			lname.Text = "";
            mail.Text = "";
            password.Text = "";
            return;
        }
        else
        {            
            await DisplayAlert("Register", "Data Not Registered or your Email is already Exist or No Internet Connection", " OK!");
            fname.Text = "";
            lname.Text = "";
            mail.Text = "";
            password.Text = "";
            return;
        }
    }
}