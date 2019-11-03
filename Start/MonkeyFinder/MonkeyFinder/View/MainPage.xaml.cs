using MonkeyFinder.Model;
using MonkeyFinder.ViewModel;
using Xamarin.Forms;

namespace MonkeyFinder.View
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = new MonkeysViewModel();
		}

		private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (!( e.SelectedItem is Monkey monkey )) return;

			await Navigation.PushAsync(new DetailsPage(monkey));

			((ListView) sender).SelectedItem = null;
		}
	}
}
