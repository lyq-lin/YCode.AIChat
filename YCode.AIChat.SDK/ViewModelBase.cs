
using System.ComponentModel;

namespace YCode.AIChat.SDK
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected virtual void OnPropertyChanged()
		{
			OnPropertyChanged(string.Empty);
		}
	}
}
