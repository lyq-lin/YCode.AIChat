
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace YCode.AIChat.SDK
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected virtual bool OnPropertyChanged<TValue>(ref TValue field, TValue value, [CallerMemberName] string propertyName = "")
		{
			if (!Equals(field, value))
			{
				field = value;

				this.OnPropertyChanged(propertyName);

				return true;
			}

			return false;
		}
	}
}
