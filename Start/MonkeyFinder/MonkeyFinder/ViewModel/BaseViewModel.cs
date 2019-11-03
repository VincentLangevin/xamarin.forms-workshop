using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MonkeyFinder.ViewModel
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		private bool _isBusy;
		public bool IsBusy
		{
			get => _isBusy;
			set
			{
				if (_isBusy == value) return;
				_isBusy = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(IsNotBusy));
			}
		}

		public bool IsNotBusy => !IsBusy;

		private string _title;
		public string Title
		{
			get => _title;
			set
			{
				if (_title == value) return;
				_title = value;
				OnPropertyChanged();
			}
		}

		public BaseViewModel()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
