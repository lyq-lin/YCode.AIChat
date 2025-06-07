using System.ComponentModel;
using System.Windows;

namespace YCode.AIChat.SDK
{
	public abstract class AIPage<TView, TViewModel>
		where TView : FrameworkElement, new()
		where TViewModel : INotifyPropertyChanged, new()
	{
		public AIPage()
		{
			this.Content = new();

			this.DataContext = new();

			this.Content.DataContext = this.DataContext;
		}

		public TView Content { get; set; }

		public TViewModel DataContext { get; set; }
	}
}
