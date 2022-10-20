using PIS_app.Model;

namespace PIS_app.Page;

public partial class HomePage : ContentPage
{
	private Patients getPatient = new();
	public HomePage()
	{
		InitializeComponent();
		ListPatients.ItemsSource = getPatient.GetPatientsList();
	}



	private async void AddPatient_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddPatientPage());
	}

	private async void ListPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        App.name = (e.CurrentSelection.FirstOrDefault() as Patients)?.fullname;
        App.key = await getPatient.GetUserKey(App.name);

    }

	private async void BTN_EditPatient_Clicked(object sender, EventArgs e)
	{
        if (!string.IsNullOrEmpty(App.key))
        {
            await Navigation.PushAsync(new EditPatientPage());
        }
        else
        {
            await DisplayAlert("Data", "Please Select a Data to modify! ", "Got it!");
        }
    }

	private async void BTN_delete_Clicked(object sender, EventArgs e)
	{
        var result = await DisplayAlert("Alert", "Are You Sure to Delete Patient Info", "YES", "NO");
        if (result)
        {
            await getPatient.DeletePatientdata();
            return;

        }
    }
}
