using MonkeyFinder.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MonkeyFinder.ViewModel
{
	public class MonkeyDetailsViewModel : BaseViewModel
	{
		private Monkey _monkey;
		public Monkey Monkey
		{
			get => _monkey;
			set
			{
				if (_monkey == value)
					return;

				_monkey = value;
				OnPropertyChanged();
			}
		}

		public Command OpenMapCommand { get; }

		public MonkeyDetailsViewModel()
		{
		}

		public MonkeyDetailsViewModel(Monkey monkey) : this()
		{
			Monkey = monkey;
			Title = $"{Monkey.Name} Details";

			OpenMapCommand = new Command(async () => await OpenMapAsync());
		}

		private async Task OpenMapAsync()
		{
			if (IsBusy) return;

			IsBusy = true;

			try
			{
				await Map.OpenAsync(Monkey.Latitude, Monkey.Longitude);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Unable to launch maps: {ex.Message}");
				await Application.Current.MainPage.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
