using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Data;
using MonkeyFinder.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MonkeyFinder
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage())
			{
				BarBackgroundColor = (Color)Resources["Primary"],
				BarTextColor = Color.White
			};
		}

		private const string AppCenteriOS = "d0a857ff-843c-458c-90c0-00c24cdccd21";
		private const string AppCenterAndroid = "9150e8b5-7788-4951-ab5a-260ae099c669";

		protected override void OnStart()
		{
			if (!string.IsNullOrWhiteSpace(AppCenteriOS) && !string.IsNullOrWhiteSpace(AppCenterAndroid))
			{
				AppCenter.Start($"ios={AppCenteriOS};" +
					  $"android={AppCenterAndroid}",
					  typeof(Analytics), typeof(Crashes), typeof(Data));
			}
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
