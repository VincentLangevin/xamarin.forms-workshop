using MonkeyFinder.Model;

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

		public MonkeyDetailsViewModel()
		{
		}

		public MonkeyDetailsViewModel(Monkey monkey) : this()
		{
			Monkey = monkey;
			Title = $"{Monkey.Name} Details";
		}
	}
}
