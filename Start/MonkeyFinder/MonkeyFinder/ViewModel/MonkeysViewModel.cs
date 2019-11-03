using MonkeyFinder.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyFinder.ViewModel
{
	public class MonkeysViewModel : BaseViewModel
	{
		private const string MonkeyRepositoryUrl = "https://montemagno.com/monkeys.json";

		private HttpClient _client;
		private HttpClient Client => _client ?? (_client = new HttpClient());

		public ObservableCollection<Monkey> Monkeys { get; }
		
		public Command GetMonkeysCommand { get; }

		public MonkeysViewModel()
		{
			Title = "Monkey Finder";
			Monkeys = new ObservableCollection<Monkey>();

			GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
		}

		private async Task GetMonkeysAsync()
		{
			if (IsBusy) return;

			try
			{
				IsBusy = true;

				var json = await Client.GetStringAsync(MonkeyRepositoryUrl);
				var monkeys = Monkey.FromJson(json);

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
	}
}
