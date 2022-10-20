using static PIS_app.App;
using PIS_app.Model;

namespace PIS_app.Page;

public partial class EditPatientPage : ContentPage
{
    private Patients upPatient = new();
	public EditPatientPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {

        base.OnAppearing();
        entryfname.Text = name;
        entryAge.Text=ages;
        entryAddres.Text = addres;
        entryconNum.Text = contactNumb;
        entryconstats.Text = constatus;
        entrypatientroom.Text = rOom;

    }

    private async void BTN_Save_Clicked(object sender, EventArgs e)
    {
        if(!string.IsNullOrEmpty(entryfname.Text) ||
        string.IsNullOrEmpty(entryAge.Text)       ||
        string.IsNullOrEmpty(entryAddres.Text)    ||
        string.IsNullOrEmpty(entryconNum.Text)    ||
        string.IsNullOrEmpty(entryconstats.Text)  ||
        string.IsNullOrEmpty(entrypatientroom.Text)){
            var a = await upPatient.EditPatientData(entryAge.Text,entryAddres.Text,entryconNum.Text,entryconstats.Text,entrypatientroom.Text);
            if (!a)
            await DisplayAlert("Notice", "Patient Data Successfully Updated", "OK");
            await Navigation.PopAsync();
            return;
        }
        await DisplayAlert("Notice", "Patient Data Not Successfully Updated", "OK");
    }

    private async void BTN_Exit_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}