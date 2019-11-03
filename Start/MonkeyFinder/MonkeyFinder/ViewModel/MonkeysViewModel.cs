using Microsoft.AppCenter.Data;
using MonkeyFinder.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MonkeyFinder.ViewModel
{
	public class MonkeysViewModel : BaseViewModel
	{
		private const double GpsLocationPingTimeoutInSeconds = 30; 

		public ObservableCollection<Monkey> Monkeys { get; }
		
		public Command GetMonkeysCommand { get; }
		public Command FindMonkeyClosestToCurrentLocationCommand { get; }

		public MonkeysViewModel()
		{
			Title = "Monkey Finder";
			Monkeys = new ObservableCollection<Monkey>();

			GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
			FindMonkeyClosestToCurrentLocationCommand = new Command(async () => await FindMonkeyClosestToCurrentLocation());
		}

		private async Task GetMonkeysAsync()
		{
			if (IsBusy) return;

			try
			{
				IsBusy = true;

				var result = await Data.ListAsync<Monkey>(DefaultPartitions.AppDocuments);
				var monkeys = result.CurrentPage.Items.Select(monkey => monkey.DeserializedValue);

				Monkeys.Clear();

				monkeys.Aggregate(Monkeys, (collection, monkey) =>
				{
					collection.Add(monkey);
					return collection;
				});

				Monkeys.Add(Monkey.GenerateGoofyMonkey());
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
				await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}

		private async Task FindMonkeyClosestToCurrentLocation()
		{
			if (IsBusy || Monkeys.Count == 0) return;

			IsBusy = true;

			try
			{
				var location = await Geolocation.GetLastKnownLocationAsync() ?? await Geolocation.GetLocationAsync(new GeolocationRequest()
				{
					DesiredAccuracy = GeolocationAccuracy.Medium,
					Timeout = TimeSpan.FromSeconds(GpsLocationPingTimeoutInSeconds)
				});

				var firstClosestMonkey = Monkeys.OrderBy(monkey =>
											location.CalculateDistance(new Location(monkey.Latitude, monkey.Longitude), DistanceUnits.Kilometers))
										.First();

				await Application.Current.MainPage.DisplayAlert("Closest Monkey", $"{firstClosestMonkey.Name} at {firstClosestMonkey.Location}", "OK");
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Unable to query location: {ex.Message}");
				await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
