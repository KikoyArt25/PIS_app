using Firebase.Database;


namespace PIS_app;
public partial class App : Application
{
    public static FirebaseClient patient = new("https://patientinfodb-default-rtdb.asia-southeast1.firebasedatabase.app/");
	public static string name, key,sexs,ages,addres,birth,constatus,contactNumb,rOom;
    public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Page.WelcomePage());
	}
}
