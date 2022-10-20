using PIS_app.Model;

namespace PIS_app.Page;

public partial class AddPatientPage : ContentPage
{
	private Patients addPatient = new();
	public AddPatientPage()
	{
		InitializeComponent();
	}

	private async void btncancel_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	private async void BTN_addPat_Clicked(object sender, EventArgs e)
	{		
		if (   string.IsNullOrEmpty(FullName.Text)
			|| string.IsNullOrEmpty(Sex.Text)
			|| string.IsNullOrEmpty(Ages.Text)
			|| string.IsNullOrEmpty(Birthdays.Text)
			|| string.IsNullOrEmpty(Paddress.Text)
			|| string.IsNullOrEmpty(ContactNum.Text)
			|| string.IsNullOrEmpty(constatus.Text)
			|| string.IsNullOrEmpty(Prooms.Text))
		{
            await DisplayAlert("Notice", "Please Fill Up The Empty Fields", "OK");
			return;
        }

        var i = await addPatient.AddPatient(FullName.Text, Sex.Text, Ages.Text,
            Birthdays.Text, Paddress.Text, ContactNum.Text, constatus.Text, Prooms.Text);
        if (i)
		{
			await DisplayAlert("Notice", "Patient Successfully Added", "OK");
			return;
		}
        await DisplayAlert("Notice", "Patient is Already Added", "OK");
		return;
    }
}